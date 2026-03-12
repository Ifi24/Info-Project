using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form //FASE 2.1
    {
        FlightPlanList miLista = new FlightPlanList();

        //Variables predeterminadas Fase 2.3:
        double distanciaSeguridad = 10;
        double tiempoCiclo = 1;
        public Principal()
        {
            InitializeComponent();
        }

        private void cargarListaDeVuelosToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.2
        {
            DatosVuelos VentanaVuelos = new DatosVuelos(miLista);
            VentanaVuelos.ShowDialog();
        }

        private void introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.3
        {
            SeguridadyTiempo VentanaSegTiempo = new SeguridadyTiempo(distanciaSeguridad, tiempoCiclo);
            VentanaSegTiempo.ShowDialog();

        }
    }
}
