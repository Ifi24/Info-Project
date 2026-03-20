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
            misPics = new PictureBox[listaVuelos.GetNum()];
        }

        private void BotonUnCiclo_Click(object sender, EventArgs e)
        {
            listaVuelos.Mover(this.tiemp);

            //Loop para calcular la posición
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);
                int x = (int)fp.GetCurrentPosition().GetX();
                int y = (int)fp.GetCurrentPosition().GetY();
                misPics[i].Location = new Point(x - 5, y - 5); // Movemos el cuadrito existente
            }

            //Detectamos si hay conflictos
            if (listaVuelos.GetNum() >= 2)
            {
                FlightPlan planA = listaVuelos.GetFlightPlan(0);
                FlightPlan planB = listaVuelos.GetFlightPlan(1);
                if (planA.ConflictoDistancia(planB, dist))
                    MessageBox.Show("Atención: Conflicto con distancia de seguridad.");
            }
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

                PanelSimulacion.Controls.Add(pic);

                misPics[i] = pic;

                PanelSimulacion.Invalidate(); //Ejecute el evento Paint
            }
        }

        //FASE 6: Función que dibuja una línia entre la posición inicial i final.
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        // Utilizaremos e.Graphics ya que es la única manera de dibujar línias.
        {
            Graphics g = e.Graphics;
            Pen Lapiz = new Pen(Color.Gray, 1); //Creamos lápiz grosor 1

            for (int i = 0; i < listaVuelos.GetNum(); i++) //Recorremos la lista de vuelos
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i); //Cogemos un FlightPLan por orden
                //Obtenemos posiciones iniciales i finales:
                int xi = (int)fp.GetInitialPosition().GetX();
                int yi = (int)fp.GetInitialPosition().GetY();
                int xf = (int)fp.GetFinalPosition().GetX();
                int yf = (int)fp.GetFinalPosition().GetY();

                g.DrawLine(Lapiz,xi, yi, xf, yf); //Dibujamos
            }
        }
    }
}