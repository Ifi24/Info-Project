using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Simulación : Form
    {
        FlightLib.FlightPlanList listaVuelos; // Creamos una variable que apunte a nuestra lista
        double dist;
        double tiemp;
        PictureBox[] misPics;
        public Simulación(FlightLib.FlightPlanList miLista, double distSeguridad, double tiempoCiclo)
        {
            InitializeComponent();
            this.listaVuelos = miLista; // Inicializamos nuestra lista en el constructor
            this.dist = distSeguridad;
            this.tiemp = tiempoCiclo;
            this.TimerSimulación.Tick += new EventHandler(TimerSimulación_Tick);
            this.TimerSimulación.Interval = (int)(this.tiemp * 1000);
            misPics = new PictureBox[listaVuelos.GetNum()];
        }

        //FASE 4: Lógica y botón para mover los aviones un ciclo:
        private void MoverCiclo() //Método para mover un ciclo, usado para el botón ciclo y el automático
        {
            listaVuelos.Mover(this.tiemp);

            //Loop para calcular la posición
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();
                misPics[i].Location = new Point(x - 5, y - 5); // Movemos el cuadrito existente

                //Reseteo el color por si antes estaba en amarillo por conflicto y ya no lo están.
                misPics[i].BackColor = Color.Red;
            }

            //Detectamos si hay conflictos
            //FASE 10 1a Parte: Mejoro lo que había antes y lo hago menos molesto en caso de conflicto. Solo se muestra un label y los aviones cambian de color.
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
                    //No creo que ocurra nunca, pero por si acaso, que muestre un mensaje de error.
                    MessageBox.Show("Error: Este avión no tiene información de vuelo asociada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Por lo que he ido aprendiendo, lo que he hecho antes es esto de abajo a prueba de errores
            //PictureBox pic = (PictureBox)sender; //es correcto hacerlo de esta manera? o tengo que hacer sender as PictureBox?
            //FlightPlan fp = (FlightPlan)pic.Tag;
            //InfoAvion info = new InfoAvion(fp);
            //info.ShowDialog();

        }


        //FASE 6: Función que dibuja una línia entre la posición inicial i final:
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        // Utilizaremos e.Graphics ya que es la única manera de dibujar línias.
        {
            Graphics g = e.Graphics;
            Pen Lapiz = new Pen(Color.Gray, 1); //Creamos lápiz grosor 1
            Lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            for (int i = 0; i < listaVuelos.GetNum(); i++) //Recorremos la lista de vuelos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i); //Cogemos un FlightPLan por orden
                //Obtenemos posiciones iniciales i finales:
                int xi = (int)fp.GetInitialPosition().GetX();
                int yi = (int)fp.GetInitialPosition().GetY();
                int xf = (int)fp.GetFinalPosition().GetX();
                int yf = (int)fp.GetFinalPosition().GetY();

                g.DrawLine(Lapiz, xi, yi, xf, yf); //Dibujamos
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
                //Y si está funcionando, lo paramos.
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
            if (listaVuelos.GetNum() <= 2)
            {
                TablaVuelos ventanaTabla = new TablaVuelos(listaVuelos);
                ventanaTabla.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay sufiecientes vuelos para mostrar en la tabla. Se necesitan 2 o menos vuelos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
                        if (fp1.ConflictoDistancia(fp2, this.dist))
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
                MessageBox.Show("Se necessitan al menos 2 vuelos para predecir conflictos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}