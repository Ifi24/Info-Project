using FlightLib;
using System.Collections.Generic;

namespace Interfaz
{
    public partial class Principal : Form 
    {
        FlightPlanList miLista = new FlightPlanList();
        List<PictureBox> misAviones = new List<PictureBox>();

        //Variables predeterminadas:
        double distanciaSeguridad = 10;
        double tiempoCiclo = 1;

        public Principal()
        {
            InitializeComponent();
        }

        // Abre un form para añadir los datos de los vuelos:
        private void cargarListaDeVuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosVuelos FormDatosVuelos = new DatosVuelos(miLista);
            FormDatosVuelos.ShowDialog();
        }
        // Abre un form para cambiar la distancia de seguridad y el tiempo de ciclo:
        private void introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.3
        {
            SeguridadyTiempo FormSeguridadyTiempo = new SeguridadyTiempo(distanciaSeguridad, tiempoCiclo);
            FormSeguridadyTiempo.ShowDialog();

        }
        // Abre un form para ver la simulación de los vuelos:
        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool conflictos = false;
            string infoConflictos = "";
            int numVuelos = miLista.GetNumAviones();

            if (numVuelos >= 2) //Sólo si hay más de 2 vuelos.
            {
                for (int i = 0; i < numVuelos; i++)
                {
                    for (int j = i + 1; j < numVuelos; j++)
                    {
                        FlightPlan fp1 = miLista.GetFlightPlan(i);
                        FlightPlan fp2 = miLista.GetFlightPlan(j);

                        if (fp1.PrediccionConflicto(fp2, distanciaSeguridad))
                        {
                            conflictos = true;
                            infoConflictos += $"- {fp1.GetId} con {fp2.GetId}\n";
                        }
                    }
                }
                if (conflictos)
                    MessageBox.Show("Se han detectado los siguientes conflictos:" + infoConflictos, "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("No hay conflictos previstos.", "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Abrimos el form.
            Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
            FormSimulación.ShowDialog();
        }
    }
}
