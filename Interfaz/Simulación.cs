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
        PictureBox[] misPics;
        Label[] misLabels;
        Simulación sim;
        public Simulación(FlightLib.FlightPlanList miLista, double distSeguridad, double tiempoCiclo)
        {
            InitializeComponent();
            this.listaVuelos = miLista;
            this.dist = distSeguridad;
            this.tiemp = tiempoCiclo;
            this.TimerSimulación.Tick += new EventHandler(TimerSimulación_Tick);
            this.TimerSimulación.Interval = (int)(this.tiemp * 1000);
            misPics = new PictureBox[listaVuelos.GetNum()];
            misLabels = new Label[listaVuelos.GetNum()];

            this.DoubleBuffered = true; //Para evitar el parpadeo al dibujar elementos.
        }

        //FASE 4: Lógica y botón para mover los aviones un ciclo:
        private void MoverCiclo() //Método para mover un ciclo, usado para el botón ciclo y el automático
        {
            listaVuelos.Mover(this.tiemp);

            labelAlarma.Visible = false;

            //Loop para calcular la posición
            for (int i = 0; i < listaVuelos.GetNum() && i < misPics.Length; i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                int x = (int)Math.Round(fp.GetCurrentPosition().GetX()); //Redondeamos porque no se puede dibujar entre píxeles.
                int y = (int)Math.Round(fp.GetCurrentPosition().GetY());
                //Actualizaciones:
                misPics[i].Location = new Point(x - 5, y - 5); // Movemos el cuadrito existente
                misLabels[i].Location = new Point(x, y - 15);
                //Reseteo el color por si antes estaba en amarillo por conflicto y ya no lo están.
                misPics[i].BackColor = Color.Red;
            }
            PanelSimulacion.Invalidate(); //Borra elipses y linias anteriores y dibuja las nuevas.

            //Detectamos si hay conflictos
            //FASE 10 (1a Parte): Mejoro lo que había antes y lo hago menos molesto en caso de conflicto. Solo se muestra un label y los aviones cambian de color.
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                for (int j = i + 1; j < listaVuelos.GetNum(); j++) //Lo hago asi pensando en multiples vuelos a futuro
                {
                    FlightPlan fp1 = listaVuelos.GetFlightPlan(i);
                    FlightPlan fp2 = listaVuelos.GetFlightPlan(j);
                    if (fp1.ConflictoDistancia(fp2, this.dist))
                    {
                        //Si hay conflicto, cambiamos el color de los aviones a amarillo y mostramos el label.
                        misPics[i].BackColor = Color.Yellow;
                        misPics[j].BackColor = Color.Yellow;
                        labelAlarma.Text = $"¡Conflicto entre {fp1.GetId()} y {fp2.GetId()}!";
                        labelAlarma.Visible = true;
                    }
                }
            }
        }

        private void BotonUnCiclo_Click(object sender, EventArgs e)
        {
            MoverCiclo();
        }

        private void Simulación_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                PictureBox pic = new PictureBox();
                pic.Size = new Size(10, 10);
                pic.BackColor = Color.Red;

                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();
                pic.Location = new Point(x - 5, y - 5);

                //Para la fase 5
                pic.Tag = fp;
                pic.Click += new EventHandler(Avion_Click);

                PanelSimulacion.Controls.Add(pic);

                misPics[i] = pic;

                //Etiquetas para los aviones
                Label lbl = new Label();
                lbl.Text = fp.GetId();
                lbl.AutoSize = true;
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Transparent;
                lbl.Location = new Point(x, y - 15);
                PanelSimulacion.Controls.Add(lbl);
                misLabels[i] = lbl;

                PanelSimulacion.Invalidate(); //Ejecute el evento Paint
            }
        }     

        //FASE 5: Creamos el evento click para mostrar la información del vuelo
        private void Avion_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic) //Comprova si el sender es un PictureBox i l'assigna a la variable pic
            {
                if (pic.Tag is FlightPlan fp) //Comprova si el Tag del PictureBox es un FlightPlan i l'assigna a la variable fp
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

        //FASE 6: Función que dibuja una línia entre la posición inicial i final:
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        // Utilizaremos e.Graphics ya que es la única manera de dibujar línias.
        {
            Graphics g = e.Graphics;
            Pen Lapiz = new Pen(Color.Gray, 1); //Creamos lápiz grosor 1
            Lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //FASE 7: Parte de la función que dibuja una elipse de distancia de seguridad alrededor del avión seleccionado
            Pen Rotulador = new Pen(Color.Blue, 2);

            for (int i = 0; i < listaVuelos.GetNum(); i++) //Recorremos la lista de vuelos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i); //Cogemos un FlightPLan por orden
                //Obtenemos posiciones iniciales i finales:
                int xi = (int)fp.GetInitialPosition().GetX();
                int yi = (int)fp.GetInitialPosition().GetY();
                int xf = (int)fp.GetFinalPosition().GetX();
                int yf = (int)fp.GetFinalPosition().GetY();

                g.DrawLine(Lapiz, xi, yi, xf, yf); //Dibujamos

                //FASE 7: Parte de la función que dibuja una elipse de distancia de seguridad alrededor del avión seleccionado
                double x = fp.GetCurrentPosition().GetX();
                double y = fp.GetCurrentPosition().GetY();
                double radio = this.dist;
                g.DrawEllipse(Rotulador, (float)(x - radio), (float)(y - radio), (float)(radio * 2), (float)(radio * 2));
                //Quiero mejorar como se ve la elipse y que a medida que avance se borre la elipse anterior, pero lo arreglo más tarde, que ahora quiero avanzar con las demás fases.
            }
        }

        //FASE 8: Botón de ciclo automático:
        private void Automático_Click(object sender, EventArgs e)
        {
            if (TimerSimulación.Enabled)
            {
                //Para cuando no funcione, lo iniciamos.
                TimerSimulación.Stop();
                Automático.Text = "Iniciar";
            }
            else
            {
                // Añadimos aquí lo de preguntarle al usuario si quiere resolver conflictos (FASE 11)
                // Recorremos todos contra todos para no dejar ningún conflicto sin revisar
                for (int i = 0; i < listaVuelos.GetNum(); i++)
                {
                    for (int j = i + 1; j < listaVuelos.GetNum(); j++)
                    {
                        FlightPlan v1 = listaVuelos.GetFlightPlan(i);
                        FlightPlan v2 = listaVuelos.GetFlightPlan(j);

                        if (v1.ConflictoTrayectoria(v2, this.dist, 1.0)) // Con ConflictoTrayectoria vemos si hay algún conflicto a resolver
                        {
                            DialogResult respuesta = MessageBox.Show(
                                "¡Conflicto futuro detectado entre " + v1.GetId() + " y " + v2.GetId() + " ¿Desea resolverlo?",
                                "Resolución Automática",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (respuesta == DialogResult.Yes)
                            {
                                // Intentamos resolverlo cambiando la velocidad de uno de ellos (v2)
                                bool logrado = v2.ResolverConflicto(v1, this.dist, 1.0);

                                if (logrado)
                                    MessageBox.Show("Resuelto: " + v2.GetId() + " ha cambiado su velocidad.");
                                else
                                    MessageBox.Show("No se pudo encontrar solución para " + v1.GetId() + " y " + v2.GetId(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }

                // Una vez revisados todos, arrancamos
                TimerSimulación.Start();
                Automático.Text = "Detener";
            }
        }

        private void TimerSimulación_Tick(object sender, EventArgs e)
        {
            MoverCiclo();
        }

        //FASE 9: Botón para mostrar todos los datos de los vuelos
        private void boton_MostarDatos(object sender, EventArgs e)
        {
            TablaVuelos ventanaTabla = new TablaVuelos(listaVuelos, this);
            ventanaTabla.ShowDialog();
        }

        //FASE 10 (2a Parte): Botón para predecir conflictos futuros entre los vuelos
        private void boton_PredecirConflictos_Click(object sender, EventArgs e)
        {
            if (listaVuelos.GetNum() >= 2)
            {
                bool hayConflictos = false;
                string mensajeConflictos = "¡CONFLICTO DE SEPARACIÓN!\nConflictos futuros detectados entre los siguientes vuelos:\n";

                for (int i = 0; i < listaVuelos.GetNum(); i++)
                {
                    for (int j = i + 1; j < listaVuelos.GetNum(); j++)
                    {
                        FlightPlan fp1 = listaVuelos.GetFlightPlan(i);
                        FlightPlan fp2 = listaVuelos.GetFlightPlan(j);
                        if (fp1.ConflictoTrayectoria(fp2, this.dist, 10000))
                        {
                            hayConflictos = true;
                            mensajeConflictos += $"- {fp1.GetId()} y {fp2.GetId()}\n";
                        }

                    }
                }
                if (hayConflictos)
                {
                    MessageBox.Show(mensajeConflictos, "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No se han detectado conflictos futuros entre los vuelos.\nEs una ruta segura.", "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Se necesitan al menos 2 vuelos para predecir conflictos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ReiniciarSimulacion()
        {
            TimerSimulación.Stop(); //Detiene el movimiento automático (si no los paramos, los aviones se seguirán moviendo mientras reiniciamos)
            Automático.Text = "Iniciar";

            for (int i = 0; i < listaVuelos.GetNum(); i++) //Recorremos todos los aviones
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i); //Obtenemos cada avión real
                fp.Restart(); //Reiniciamos posición
            }

            //Volver a dibujar posiciones iniciales
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                //Obtenemos posiciones del avión ya reiniciado
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();

                misPics[i].Location = new Point(x - 5, y - 5); //Mueve el icono
                misPics[i].BackColor = Color.Red; 
                misLabels[i].Location = new Point(x, y - 15);
            }

            labelAlarma.Visible = false;
            PanelSimulacion.Invalidate();
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            // 1. Parar simulación
            TimerSimulación.Stop();
            for (int i = 0; i < listaVuelos.GetNum(); i++) //Reiniciar todos los vuelos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                fp.Restart();
            }
            for (int i = 0; i < listaVuelos.GetNum(); i++) //Iconos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();

                misPics[i].Location = new Point(x - 5, y - 5);
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
    }
}