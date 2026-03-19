using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form //FASE 2.1
    {
        FlightPlanList miLista = new FlightPlanList();
        PictureBox[] misPics = new PictureBox[10]; //10 como número máximo de prueba
        int numPics = 0;

        //Variables predeterminadas Fase 2.3:
        double distanciaSeguridad = 10;
        double tiempoCiclo = 1;

        //Guardar dibujos aviones:
        PictureBox[] misAviones = new PictureBox[10]; //Ejemplo: Máx 10
        int numAviones = 0; //Contador de cuantos llevamos.

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
        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulación VentanaSimulacion = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
            VentanaSimulacion.ShowDialog();
        }
    }
}
