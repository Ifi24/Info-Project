using FlightLib;
using System.Collections.Generic;

namespace Interfaz
{
    // Clase Principal (Formulario) que actúa como el centro de control de la aplicación, gestionando el acceso a la entrada de datos, la configuración de parámetros y el lanzamiento de la simulación.
    public partial class Principal : Form
    {
        // Atributos: 
        FlightPlanList miLista = new FlightPlanList();
        List<PictureBox> misAviones = new List<PictureBox>();

        Simulación FormSimulación; //Para guardar el form de simulación.
        string Usuario;

        //Variables predeterminadas:
        double distanciaSeguridad = 10;
        double tiempoCiclo = 1;

        // Constructor que inicializa el formulario principal con el nombre del usuario.
        public Principal(string nombreUsuario)
        {
            InitializeComponent();
            this.Usuario = nombreUsuario;
        }
        // Métodos:
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
            if (FormSeguridadyTiempo.ShowDialog() == DialogResult.OK)
            {
                this.distanciaSeguridad = FormSeguridadyTiempo.GetDistancia();
                this.tiempoCiclo = FormSeguridadyTiempo.GetTiempo();

                MessageBox.Show("Cambios aplicados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Abre un form para ver la simulación de los vuelos:
        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string infoConflictos = miLista.InformeConflictos(distanciaSeguridad);

            if (infoConflictos != "")
                MessageBox.Show("Se han detectado los siguientes conflictos: \n" + infoConflictos, "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("No hay conflictos previstos.", "Predicción de Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Abrimos el form.
            Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
            FormSimulación.ShowDialog();
        }

        // Botón que finaliza la ejecución de la aplicación.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Como usamos .Hide() en el login, hay que forzar a cerrar todo.
        }
    }
}
