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
        FlightLib.FlightPlanList listaVuelos; // Creamos una variable que apunte a nuestra lista (queremos usarla para dinujar los aviones y moverlos)
        int tamañoAvion = 10; // Qué tan grande se verá nuestro "avión"
        double distanciaSeguridad;
        public Simulación(FlightLib.FlightPlanList miLista, double distSeguridad)
        {
            InitializeComponent();
            this.listaVuelos = miLista; // Inicializamos nuestra lista en el constructor
            this.distanciaSeguridad = distSeguridad;
        }


        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Obtenemos "lienzo virtual" donde podremos dibujar
            g.Clear(Color.Black); // Borra todo lo que había y deja un fondo negro

            for (int i = 0; i < listaVuelos.GetNum(); i++) // Recorre todos los vuelos en la lista (listaVuelos), siendo i el índice del vuelo actual. listaVuelos.GetNum() devuelve cuántos vuelos hay en la lista
            {
                FlightLib.FlightPlan plan = listaVuelos.GetFlightPlan(i); // Objeto plan de la clase FlightPlan del vuelo actual
                Position pos = plan.GetCurrentPosition(); // Posición actual del avión dentro del vuelo

                // Dibujamos el avión como un círculo
                Brush brush;

                if (i == 0)
                {
                    brush = Brushes.Red;
                }
                else
                {
                    brush = Brushes.Blue;
                }
                // Si el avión es el primero se dibuja rojo y si no, azul 
                g.FillEllipse(brush, (float)pos.GetX() - tamañoAvion, (float)pos.GetY() - tamañoAvion, tamañoAvion * 2, tamañoAvion * 2);
                // Hacemos que la esquina izqda del rectángulo que rodea el círculo sea la coordenada X del avión, la superior dcha la Y, y le restamos tamañoAvion para que quede en el centro y establecemos el ancho y el alto del círculo

            }
        }

        private void BotonUnCiclo_Click(object sender, EventArgs e)
        {
            listaVuelos.Mover(1); // tiempo = 1 ciclo
            PanelSimulacion.Invalidate(); // redibujamos para dejar de ver las antiguas posiciones de los aviones
            // Detectar conflictos
            if (listaVuelos.GetNum() >= 2)
            {
                FlightPlan planA = listaVuelos.GetFlightPlan(0);
                FlightPlan planB = listaVuelos.GetFlightPlan(1);

                if (planA.ConflictoDistancia(planB, distanciaSeguridad))
                    MessageBox.Show("¡Conflicto de distancia de seguridad!");
            }

        }
    }
}