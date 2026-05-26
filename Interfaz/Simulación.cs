using FlightLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaz
{
    public partial class Simulación : Form
    {
        FlightLib.FlightPlanList listaVuelos;
        double dist;
        double tiemp;
        double multvelocidad = 1;
        string usuarioActual;
        private string cadenaConexion = "Data Source=LoginVuelos.db";

        List<PictureBox> misPics = new List<PictureBox>();
        List<Label> misLabels = new List<Label>();

        public Simulación(FlightLib.FlightPlanList miLista, double distSeguridad, double tiempoCiclo, string usuarioLogueado)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; //Quita las opciones de arriba de la ventana.
            this.WindowState = FormWindowState.Maximized; //Se abre en modo Fullscreen.
            // Para evitar lag y que todo cargue a la vez
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, PanelSimulacion, new object[] { true });

            this.listaVuelos = miLista;
            this.dist = distSeguridad;
            this.tiemp = tiempoCiclo;
            this.usuarioActual = usuarioLogueado;

            this.TimerSimulación.Tick += new EventHandler(TimerSimulación_Tick);
            this.TimerSimulación.Interval = (int)(this.tiemp * 1000);

            this.DoubleBuffered = true; //Para evitar el parpadeo al dibujar elementos.
        }

        // Métodos:
        private void Simulación_Load(object sender, EventArgs e)
        {
            misPics.Clear();
            misLabels.Clear();

            for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                // Configuramos el dibujo del avión.
                PictureBox pic = new PictureBox();
                pic.Size = new Size(9, 9); //Impar para que cuadre con los píxeles.
                pic.BackColor = Color.Red;
                pic.Tag = fp;
                pic.Click += new EventHandler(Avion_Click);

                //Etiquetas para los aviones
                Label lbl = new Label();
                lbl.Text = fp.GetId();
                lbl.AutoSize = true;
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Transparent;

                // Añadimos ambos:
                PanelSimulacion.Controls.Add(pic);
                PanelSimulacion.Controls.Add(lbl);
                misPics.Add(pic);
                misLabels.Add(lbl);
                pic.BringToFront(); //Para asegurarnos de que se dibujan bien.
                lbl.BringToFront();
            }
            ActualizarInterfaz();
            PanelSimulacion.Invalidate(); //Ejecute el evento Paint

        }

        // Método para actualizar cambios en la simulación:
        private void ActualizarInterfaz()
        {
            labelAlarma.Visible = false;
            string idsConflicto = "";

            //Loop para actualizar posiciones:
            for (int i = 0; i < misPics.Count; i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                if (fp == null) continue;

                int x = (int)Math.Round(fp.GetCurrentPosition().GetX()); //Redondeamos porque no se puede dibujar entre píxeles.
                int y = (int)Math.Round(fp.GetCurrentPosition().GetY());

                //Actualizaciones:
                misPics[i].Location = new Point(x - 4, y - 4); // Movemos el cuadrito existente
                misLabels[i].Location = new Point(x + 6, y - 6);
                //Reseteamos el color por si antes estaba en amarillo por conflicto y ya no lo están.
                misPics[i].BackColor = Color.Red;
            }

            // Detectamos y mostramos si hay conflictos
            List<FlightPlan[]> conflictosDetectados = listaVuelos.GetConflictos(this.dist);
            if (conflictosDetectados.Count > 0)
            {
                foreach (FlightPlan[] pareja in conflictosDetectados)
                {
                    idsConflicto += $"{pareja[0].GetId()} y {pareja[1].GetId()}, ";

                    // Pintamos de amarillo los aviones involucrados
                    for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
                    {
                        FlightPlan fp = listaVuelos.GetFlightPlan(i);
                        if (fp == pareja[0] || fp == pareja[1])
                        {
                            misPics[i].BackColor = Color.Yellow;
                        }
                    }
                }

                labelAlarma.Text = $"Conflicto entre: {idsConflicto.TrimEnd(',', ' ')}";
                labelAlarma.Visible = true;
            }
            //Borra elipses y linias anteriores y dibuja las nuevas.
            PanelSimulacion.Invalidate();
        }

        // Método que dibuja una línia entre la posición inicial y final (trayectoria) y elipses de distancia de seguridad:
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        // Utilizaremos e.Graphics ya que es la única manera de dibujar línias.
        {
            Graphics g = e.Graphics;
            using (Pen Lapiz = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot }) //Para las línias.
            using (Pen Rotulador = new Pen(Color.Blue, 2)) //Para las elipses
            {
                for (int i = 0; i < listaVuelos.GetNumAviones(); i++) // Dibujamos uno por uno.
                {
                    FlightPlan fp = listaVuelos.GetFlightPlan(i);

                    int xi = (int)fp.GetInitialPosition().GetX();
                    int yi = (int)fp.GetInitialPosition().GetY();
                    int xf = (int)fp.GetFinalPosition().GetX();
                    int yf = (int)fp.GetFinalPosition().GetY();

                    g.DrawLine(Lapiz, xi, yi, xf, yf); //Dibujamos la línia

                    // Dibujamos la elipse que representa la distancia de seguridad:
                    float x = (float)fp.GetCurrentPosition().GetX();
                    float y = (float)fp.GetCurrentPosition().GetY();
                    float diametro = (float)this.dist * 2;
                    g.DrawEllipse(Rotulador, x - (float)this.dist, y - (float)this.dist, diametro, diametro);
                }
            }
        }

        // Método para mover los aviones un ciclo:
        private void MoverCiclo()
        {
            //Movemos todos los aviones
            listaVuelos.Mover(this.tiemp);
            ActualizarInterfaz();
        }

        // Método para retroceder un ciclo la simulación:
        private void DeshacerCiclo()
        {
            listaVuelos.RetrocederSimulación();
            ActualizarInterfaz();
        }

        // Método que reinicia la simulación:
        public void ReiniciarSimulacion()
        {
            TimerSimulación.Stop(); //Paramos el timer

            listaVuelos.ReiniciarVuelos();
            ActualizarInterfaz();
        }
        //Método para verificar cada paso de la simulación:
        private void VerificarPaso()
        {
            for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
            {
                for (int j = i + 1; j < listaVuelos.GetNumAviones(); j++)
                {
                    FlightPlan v1 = listaVuelos.GetFlightPlan(i);
                    FlightPlan v2 = listaVuelos.GetFlightPlan(j);

                    if (v1.PrediccionConflicto(v2, this.dist)) // Si se detecta conflicto
                    {
                        // Avisamos al usuario y le preguntamos si quiere resolverlo:
                        MiMessageBox ventanaPregunta = new MiMessageBox();
                        ventanaPregunta.ConfigurarMensaje("Resolución", $"¡Conflicto futuro detectado entre {v1.GetId()} y {v2.GetId()}!\n¿Desea resolverlo?", "PREGUNTA");
                        DialogResult respuesta = ventanaPregunta.ShowDialog();

                        if (respuesta == DialogResult.Yes)
                        {
                            // Intentamos resolverlo cambiando la velocidad de v2
                            bool logrado = v2.ResolverConflicto(v1, this.dist);
                            MiMessageBox ventanaResultado = new MiMessageBox();

                            if (logrado)
                            {
                                ventanaResultado.ConfigurarMensaje("Conflicto resuelto", $"{v2.GetId()} ha cambiado su velocidad.", "INFO");
                            }
                            else
                            {
                                ventanaResultado.ConfigurarMensaje("Atención", $"No se pudo encontrar solución para el conflicto entre {v1.GetId()} y {v2.GetId()}", "ERROR");
                            }
                            ventanaResultado.ShowDialog();
                        }
                    }
                }
            }
            // Una vez revisados todos, arrancamos la simulación
            TimerSimulación.Start();
        }

        // Botón que mueve un ciclo:
        private void btn_UnCiclo_Click(object sender, EventArgs e)
        {
            MoverCiclo();
        }

        // Cuando el timer avanza, se mueven los aviones un ciclo:
        private void TimerSimulación_Tick(object sender, EventArgs e)
        {
            MoverCiclo();
        }

        // Botón de mover un ciclo automáticamente:
        private void btnAutoCiclo_Click(object sender, EventArgs e)
        {
            if (TimerSimulación.Enabled)
                // Si ya está funcionando, lo paramos.
                TimerSimulación.Stop();
            else
                // Si estaba parado, procesamos conflictos y arrancamos.
                VerificarPaso();
        }

        // Método que muestra los datos de un avión al que se le hace click:
        private void Avion_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic) //Comprueba si el sender es un PictureBox i se lo asigna a la variable pic.
            {
                if (pic.Tag is FlightPlan fp) //Comprueba si el Tag del PictureBox es un FlightPlan i se lo asigna a la variable fp.
                {
                    FlightLib.Position posicion = fp.GetCurrentPosition();
                    string compañia = fp.GetAerolinia();
                    // Valores por defecto por si la compañía no está registrada en la base de datos
                    string telefono = "No asignado";
                    string email = "No asignado";

                    //Conexión a la base de datos
                    SQLiteConnection conexionQuery = new SQLiteConnection(cadenaConexion);
                    try
                    {
                        conexionQuery.Open();
                        string query = "SELECT Telefono, Email FROM misCompanias WHERE Nombre = '" + compañia + "'"; //Pedimos el tel y el mail de la compañia
                        SQLiteCommand cmd = new SQLiteCommand(query, conexionQuery);
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) //Si la base de datos encuentra una compañía con ese nombre cogemos sus datos de tel y mail y los guardamos
                        {
                            telefono = reader["Telefono"].ToString();
                            email = reader["Email"].ToString();
                        }
                        reader.Close();
                        conexionQuery.Close();
                    }
                    catch (Exception ex)
                    {
                        telefono = "Error al cargar";
                        email = "Error al cargar";
                    }

                    // Construimos los datos 
                    string datosAvion = $"ID: {fp.GetId()}\n\n" +
                                        $"Posición X: {posicion.GetX():N2}\n" +
                                        $"Posición Y: {posicion.GetY():N2}\n\n" +
                                        $"Velocidad: {fp.GetVelocidad():N2}\n\n" +
                                        $"=======================\n" +
                                        $"Aerolínea: {compañia}\n" +
                                        $"Teléfono: {telefono}\n" +
                                        $"Email: {email}\n" +
                                        $"=======================";

                    MiMessageBox ventanaInfo = new MiMessageBox();
                    ventanaInfo.ConfigurarMensaje($"Información del avión: {fp.GetId()}", datosAvion, "INFO");
                    ventanaInfo.Size = new Size(500, 580);
                    ventanaInfo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error:\nEste avión no tiene información de vuelo asociada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Botón para mostrar todos los datos de los vuelos
        private void btn_DatosAviones_Click(object sender, EventArgs e)
        {
            TablaVuelos ventanaTabla = new TablaVuelos(listaVuelos, this);
            ventanaTabla.ShowDialog();
        }

        // Botón para predecir conflictos futuros entre los vuelos
        private void btn_PredecirConflictos_Click(object sender, EventArgs e)
        {
            string informe = listaVuelos.InformeConflictos(this.dist);

            if (string.IsNullOrEmpty(informe))
            {
                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Ruta segura", "No se han detectado conflictos futuros.", "INFO");
                ventanaMensaje.ShowDialog();
            }
            else
            {
                MiMessageBox ventanaMensaje2 = new MiMessageBox();
                ventanaMensaje2.ConfigurarMensaje("Conflicto encontrado", "Conflicto detectado en la trayectoria entre:\n" + informe, "INFO");
                ventanaMensaje2.ShowDialog();
            }
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            // Paramos simulación
            TimerSimulación.Stop();
            listaVuelos.ReiniciarVuelos();
            ActualizarInterfaz();
            TimerSimulación.Start(); //Renaudar simulación

            MiMessageBox ventanaMensaje2 = new MiMessageBox();
            ventanaMensaje2.ConfigurarMensaje("Simulación reiniciada", "La simulación se ha reiniciado correctamente", "INFO");
            ventanaMensaje2.ShowDialog();
        }

        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            ReiniciarSimulacion();
        }

        private void btn_Deshacer_Click(object sender, EventArgs e)
        {
            DeshacerCiclo();
        }

        private void btn_GuardarSimulacion_Click(object sender, EventArgs e)
        {
            SaveFileDialog ventanaGuardar = new SaveFileDialog();

            ventanaGuardar.Filter = "Archivo de texto (*.txt)|*.txt|All files(*.*)|*.*"; //que alguien me diga si algo de esta parte le sale en ingles al ejecutar!
            ventanaGuardar.Title = "Guardar estado actual de la simulación";

            if (ventanaGuardar.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = ventanaGuardar.FileName;

                try
                {
                    listaVuelos.GuardarFichero(rutaArchivo, dist, tiemp);
                    MiMessageBox ventanaMensaje = new MiMessageBox();
                    ventanaMensaje.ConfigurarMensaje("Guardado exitoso", "Los datos de la simulación se han guardado correctamente", "INFO");
                    ventanaMensaje.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al intentar guardar el archivo:\n" + ex.Message,
                        "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Boton para cargar la simulación
        private void btn_CargarSimulacion_Click(object sender, EventArgs e)
        {
            MiMessageBox ventanaMensaje = new MiMessageBox();
            ventanaMensaje.ConfigurarMensaje("Atención", "¿Está seguro de querer cargar un nuevo archivo?\nSi lo hace, perderá todo el progreso actual de la simulación", "PREGUNTA");
            DialogResult respuesta = ventanaMensaje.ShowDialog();

            if (respuesta == DialogResult.Yes)
            {
                OpenFileDialog ventanaAbrir = new OpenFileDialog();

                ventanaAbrir.Filter = "Archivo de texto (*.txt)|*.txt|All files(*.*)|*.*";
                ventanaAbrir.Title = "Importar simulación";

                if (ventanaAbrir.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = ventanaAbrir.FileName;

                    try
                    {
                        listaVuelos.AbrirFichero(rutaArchivo);
                        MiMessageBox ventanaMensaje2 = new MiMessageBox();
                        ventanaMensaje2.ConfigurarMensaje("Importación exitosa", "Los datos de la simulación se han importado correctamente", "INFO");
                        ventanaMensaje2.ShowDialog();

                        this.dist = listaVuelos.GetDistanciaCargada();
                        this.tiemp = listaVuelos.GetTiempoCargado();
                        this.TimerSimulación.Interval = (int)(this.tiemp * 1000);

                        foreach (PictureBox pic in misPics)
                        {
                            PanelSimulacion.Controls.Remove(pic);
                        }
                        foreach (Label lab in misLabels)
                        {
                            PanelSimulacion.Controls.Remove(lab);
                        }
                        Simulación_Load(null, null);
                        this.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error al intentar importar el fichero:\n" + ex.Message,
                            "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (TimerSimulación.Enabled)
            {
                // Si ya está funcionando, lo paramos y cambiamos el icono a play.
                TimerSimulación.Stop();
                btnPause.BackgroundImage = Properties.Resources.play;
            }
            else
            {
                // Si estaba pausado, cambiamos el icono a Pausa y procesamos la simulación.
                btnPause.BackgroundImage = Properties.Resources.pausa;
                VerificarPaso();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeguridadyTiempo FormSeguridadyTiempo = new SeguridadyTiempo(this.dist, this.tiemp);
            if (FormSeguridadyTiempo.ShowDialog() == DialogResult.OK)
            {
                this.dist = FormSeguridadyTiempo.GetDistancia();
                this.tiemp = FormSeguridadyTiempo.GetTiempo();

                ActualizarInterfaz();

                this.TimerSimulación.Interval = (int)(this.tiemp * 1000);

                // Reseteamos el indicador de velocidad porque el tiempo base ha cambiado
                multvelocidad = 1;
                lblVelocidad.Text = "x1";

                MiMessageBox exitoMsg = new MiMessageBox();
                exitoMsg.ConfigurarMensaje("Información", "Cambios aplicados correctamente.", "INFO");
                exitoMsg.ShowDialog();
            }
        }

        private void btn_Acelerar_Click(object sender, EventArgs e)
        {
            if (TimerSimulación.Interval > 100)
            {
                TimerSimulación.Interval /= 2;
                multvelocidad *= 2;
                lblVelocidad.Text = $"x{multvelocidad}";
            }
        }

        private void btn_Ralentizar_Click(object sender, EventArgs e)
        {
            if (TimerSimulación.Interval < 5000)
            {
                TimerSimulación.Interval *= 2;
                multvelocidad /= 2;
                lblVelocidad.Text = $"x{multvelocidad}";
            }
        }

        private void PanelSimulacion_MouseMove(object sender, MouseEventArgs e)
        {
            lblCords.Text = $"X:  {e.X}  Y:  {e.Y}";
        }

        private void btn_cambiarsimcuenta(object sender, EventArgs e)
        {
            if (listaVuelos == null || listaVuelos.GetNumAviones() == 0)
            {
                MessageBox.Show("No hay datos de vuelo activos en la simulación para guardar.", "Simulación vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Detener temporalmente el Timer si la simulación está en ejecución para evitar problemas de concurrencia
            bool estabaActivo = TimerSimulación.Enabled;
            if (estabaActivo)
            {
                TimerSimulación.Stop();
            }

            // 3. Solicitar un nombre identificativo para la simulación
            // Nota: Requiere tener la referencia o escribir Microsoft.VisualBasic.Interaction.InputBox
            string nombreSimulacion = Microsoft.VisualBasic.Interaction.InputBox(
                "Introduce un nombre para guardar esta simulación en tu cuenta:", 
                "Guardar en Base de Datos", 
                "Simulacion_" + DateTime.Now.ToString("ddMMyy_HHmm")
            ).Trim();

            // Si cancela la ventana o el campo queda completamente en blanco, reanudamos el timer si correspondía y salimos
            if (string.IsNullOrEmpty(nombreSimulacion))
            {
                if (estabaActivo) TimerSimulación.Start();
                return;
            }

            try
            {
                // 4. Crear un archivo de texto temporal para que FlightLib exporte el contenido estructurado en un String
                string rutaTemporal = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_db_radar.txt");
                
                // Usamos el método propio de tu librería pasándole las variables de tu formulario actual
                listaVuelos.GuardarFichero(rutaTemporal, this.dist, this.tiemp);

                // Volcamos todo el contenido plano generado del fichero a una variable String
                string contenidoTextoPlanos = System.IO.File.ReadAllText(rutaTemporal);

                // Limpiamos eliminando el fichero físico del disco temporal
                System.IO.File.Delete(rutaTemporal);

                // 5. Inserción SQL en la base de datos local
                using (SQLiteConnection cnx = new SQLiteConnection(cadenaConexion))
                {
                    cnx.Open();

                    string queryInsert = "INSERT INTO misSimulaciones (Username, NombreSimulacion, ContenidoTexto, FechaGuardado) " +
                                         "VALUES (@user, @nombre, @contenido, @fecha)";

                    using (SQLiteCommand cmd = new SQLiteCommand(queryInsert, cnx))
                    {
                        // Vinculamos los parámetros usando tus variables globales del formulario
                        cmd.Parameters.AddWithValue("@user", this.usuarioActual);
                        cmd.Parameters.AddWithValue("@nombre", nombreSimulacion);
                        cmd.Parameters.AddWithValue("@contenido", contenidoTextoPlanos);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                        int resultadoFila = cmd.ExecuteNonQuery();

                        if (resultadoFila == 1)
                        {
                            // Mostramos confirmación de éxito con tu MessageBox personalizado
                            MiMessageBox ventanaMensaje = new MiMessageBox();
                            ventanaMensaje.ConfigurarMensaje("Guardado exitoso", $"La simulación '{nombreSimulacion}' se ha guardado correctamente en tu cuenta de usuario.", "INFO");
                            ventanaMensaje.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar registrar la simulación en la cuenta:\n" + ex.Message,
                    "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 6. Si el simulador estaba corriendo antes de darle al botón, vuelve a arrancar de forma automática
                if (estabaActivo)
                {
                    TimerSimulación.Start();
                }
            }
        }
    }
}