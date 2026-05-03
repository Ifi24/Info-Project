using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        List<PictureBox> misPics = new List<PictureBox>();
        List<Label> misLabels = new List<Label>();

        public Simulación(FlightLib.FlightPlanList miLista, double distSeguridad, double tiempoCiclo)
        {
            InitializeComponent();

            this.listaVuelos = miLista;
            this.dist = distSeguridad;
            this.tiemp = tiempoCiclo;

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

                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();
                pic.Location = new Point(x - 4, y - 4);

                //Etiquetas para los aviones
                Label lbl = new Label();
                lbl.Text = fp.GetId();
                lbl.AutoSize = true;
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Transparent;
                lbl.Location = new Point(x, y - 15);

                // Añadimos ambos:
                PanelSimulacion.Controls.Add(pic);
                PanelSimulacion.Controls.Add(lbl);
                misPics.Add(pic);
                misLabels.Add(lbl);
                pic.BringToFront(); //Para asegurarnos de que se dibujan bien.
                lbl.BringToFront();

                PanelSimulacion.Invalidate(); //Ejecute el evento Paint
            }
        }

        // Método para mover los aviones un ciclo:
        private void MoverCiclo()
        {
            //Movemos todos los aviones
            listaVuelos.Mover(this.tiemp);
            labelAlarma.Visible = false;

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
            var conflictosDetectados = listaVuelos.GetConflictos(this.dist);

            if (conflictosDetectados.Count > 0)
            {
                string idsConflicto = "";

                foreach (FlightPlan[] pareja in conflictosDetectados)
                {
                    // Guardamos los ids en conflicto
                    idsConflicto += $"{pareja[0].GetId()} y {pareja[1].GetId()}, ";

                    // Pintamos de amarillo los aviones en conflicto
                    for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
                    {
                        FlightPlan fp = listaVuelos.GetFlightPlan(i);
                        if (fp == pareja[0] || fp == pareja[1])
                        {
                            misPics[i].BackColor = Color.Yellow;
                        }
                    }
                }

                labelAlarma.Text = $"¡Conflicto entre: {idsConflicto.TrimEnd(',', ' ')}!";
                labelAlarma.Visible = true;

                PanelSimulacion.Invalidate(); //Borra elipses y linias anteriores y dibuja las nuevas.
            }
        }

        // Método para deshacer un ciclo:
        private void DeshacerCiclo()
        {
            // Movemos hacia atras los vuelos
            listaVuelos.MoverAtras(this.tiemp);
            labelAlarma.Visible = false;

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
            var conflictosDetectados = listaVuelos.GetConflictos(this.dist);

            if (conflictosDetectados.Count > 0)
            {
                string idsConflicto = "";

                foreach (FlightPlan[] pareja in conflictosDetectados)
                {
                    // Guardamos los ids en conflicto
                    idsConflicto += $"{pareja[0].GetId()} y {pareja[1].GetId()}, ";

                    // Pintamos de amarillo los aviones en conflicto
                    for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
                    {
                        FlightPlan fp = listaVuelos.GetFlightPlan(i);
                        if (fp == pareja[0] || fp == pareja[1])
                        {
                            misPics[i].BackColor = Color.Yellow;
                        }
                    }
                }

                labelAlarma.Text = $"¡Conflicto entre: {idsConflicto.TrimEnd(',', ' ')}!";
                labelAlarma.Visible = true;

                PanelSimulacion.Invalidate(); //Borra elipses y linias anteriores y dibuja las nuevas.
            }
        }

        // Método que dibuja una línia entre la posición inicial y final (trayectoria) y elipses de distancia de seguridad:
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        // Utilizaremos e.Graphics ya que es la única manera de dibujar línias.
        {
            Graphics g = e.Graphics;
            using (Pen Lapiz = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot }) //Para las línias.
            using (Pen Rotulador = new Pen(Color.Blue, 2)) //Para las elipses

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

        // Método que reinicia la simulación:
        public void ReiniciarSimulacion()
        {
            TimerSimulación.Stop(); //Paramos el timer
            btn_AutoCiclo.Text = "Iniciar";

            listaVuelos.ReiniciarVuelos();

            // Actualizamos la posición en el panel:
            for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();

                misPics[i].Location = new Point(x - 4, y - 4);
                misPics[i].BackColor = Color.Red;
                misLabels[i].Location = new Point(x + 6, y - 6);
            }

            labelAlarma.Visible = false;
            PanelSimulacion.Invalidate();
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
            {
                //Si ya esta funcionando, lo paramos.
                TimerSimulación.Stop();
                btn_AutoCiclo.Text = "Iniciar";
            }
            else //Si queremos que funcione:
            {
                for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
                {
                    for (int j = i + 1; j < listaVuelos.GetNumAviones(); j++)
                    {
                        FlightPlan v1 = listaVuelos.GetFlightPlan(i);
                        FlightPlan v2 = listaVuelos.GetFlightPlan(j);

                        if (v1.PrediccionConflicto(v2, this.dist)) // Si se detecta conflicto...
                        {
                            //Avisamos al usuario y le preguntamos si quiere resolverlo:
                            DialogResult respuesta = MessageBox.Show("¡Conflicto futuro detectado entre " + v1.GetId() + " y " + v2.GetId() + " ¿Desea resolverlo?", "Resolución Automática", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (respuesta == DialogResult.Yes)
                            {
                                // Intentamos resolverlo cambiando la velocidad de uno de ellos (v2)
                                bool logrado = v2.ResolverConflicto(v1, this.dist);

                                if (logrado)
                                    MessageBox.Show("Conflicto resuelto. " + v2.GetId() + " ha cambiado su velocidad.", "Resolución Conflicto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("No se pudo encontrar solución para el conflicto entre " + v1.GetId() + " y " + v2.GetId(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                // Una vez revisados todos, arrancamos
                TimerSimulación.Start();
                btn_AutoCiclo.Text = "Detener";
            }
        }

        // Método que muestra los datos de un avión al que se le hace click:
        private void Avion_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic) //Comprueba si el sender es un PictureBox i se lo asigna a la variable pic.
            {
                if (pic.Tag is FlightPlan fp) //Comprueba si el Tag del PictureBox es un FlightPlan i se lo asigna a la variable fp.
                {
                    InfoAvion info = new InfoAvion(fp);
                    info.ShowDialog();
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
                MessageBox.Show("No se han detectado conflictos futuros. Ruta segura.", "Predicción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("¡CONFLICTO DE SEPARACIÓN!\nDetectado en trayectoria entre:\n" + informe, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            // Paramos simulación
            TimerSimulación.Stop();
            for (int i = 0; i < listaVuelos.GetNumAviones(); i++) //Reiniciar todos los vuelos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                fp.Reseteo();
            }
            for (int i = 0; i < listaVuelos.GetNumAviones(); i++) //Iconos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();

                misPics[i].Location = new Point(x - 4, y - 4);
                misPics[i].BackColor = Color.Red;
            }
            TimerSimulación.Start(); //Renaudar simulación

            MessageBox.Show("Simulación reiniciada correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Los datos de la simulación se han guardado correctamente.",
                        "¡Guardado exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al intentar guardar el archivo:\n" + ex.Message,
                        "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Boton para cargar la simulación
        // MENSAJE DE ADVERTENCIA DE QUE SE VA A BORRAR TODO --> PREGUNTAR SI DESEA GUARDAR ANTES
        private void btn_CargarSimulacion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas cargar un nuevo archivo? Si lo haces, perderás todo el progreso actual de la simulación.",
                "¡Advertencia!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.OK)
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
                        MessageBox.Show("Los datos de la simulación se han importado correctamente.",
                            "¡Importación exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else if (respuesta == DialogResult.Cancel)
            {
                return;
            }
            

        }
    }
}