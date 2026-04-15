using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form //FASE 2.1
    {
        FlightPlanList miLista = new FlightPlanList();
        PictureBox[] misPics = new PictureBox[10];
        int numPics = 0;

        //Variables predeterminadas (FASE 2.3):
        double distanciaSeguridad = 10;
        double tiempoCiclo = 1;

        //Guardar dibujos aviones:
        PictureBox[] misAviones = new PictureBox[10];
        int numAviones = 0; //Contador de cuantos llevamos.

        public Principal()
        {
            InitializeComponent();
        }

        private void cargarListaDeVuelosToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.2
        {
            DatosVuelos VentanaVuelos = new DatosVuelos(miLista, numAviones);
            VentanaVuelos.ShowDialog();
            this.numAviones = VentanaVuelos.contadorVuelos;
        }

        private void introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.3
        {
            SeguridadyTiempo VentanaSegTiempo = new SeguridadyTiempo(distanciaSeguridad, tiempoCiclo);
            VentanaSegTiempo.ShowDialog();

        }
        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (miLista.GetNum() >= 2)
            {
                bool hayConflictos = false;

                for (int i = 0; i < miLista.GetNum(); i++)
                {
                    for (int j = i + 1; j < miLista.GetNum(); j++)
                    {
                        FlightPlan fp1 = miLista.GetFlightPlan(i);
                        FlightPlan fp2 = miLista.GetFlightPlan(j);
                        if (fp1.ConflictoTrayectoria(fp2, distanciaSeguridad, 10000))
                            hayConflictos = true;
                    }
                }
                if (hayConflictos)
                {
                    MessageBox.Show("Se han detectado conflictos.", "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No hay conflictos previstos. Simulación segura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Simulación VentanaSimulacion = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
            VentanaSimulacion.ShowDialog();
        }
    }
}
