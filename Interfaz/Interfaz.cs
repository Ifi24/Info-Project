using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form //FASE 2.1
    {
        FlightPlanList miLista = new FlightPlanList();

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

            //Para representar aviones:
            for (int i = numAviones; i < miLista.GetNum(); i++)
            {
                
            }

        }

        private void introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e) //Fase 2.3
        {
            SeguridadyTiempo VentanaSegTiempo = new SeguridadyTiempo(distanciaSeguridad, tiempoCiclo);
            VentanaSegTiempo.ShowDialog();

        }

        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulacion VentanaSimulacion = new Simulacion(miLista);
            VentanaSimulacion.ShowDialog();
        }
    }
}
