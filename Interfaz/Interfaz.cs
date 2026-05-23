using FlightLib;
using Microsoft.VisualBasic.Logging;
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

            this.FormBorderStyle = FormBorderStyle.None; //Quita las opciones de arriba de la ventana.
            this.WindowState = FormWindowState.Maximized; //Se abre en modo Fullscreen.
            // Para evitar lag y que todo cargue a la vez
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

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

                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Cambios aplicados", "Los datos se han actualizado correctamente", "INFO");
                ventanaMensaje.ShowDialog();
            }
        }
        // Abre un form para ver la simulación de los vuelos:
        private void verSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string infoConflictos = miLista.InformeConflictos(distanciaSeguridad);

            if (infoConflictos != "")
            {
                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Conflictos detectados", "Se han detectado los siguientes conflictos: \n" + infoConflictos, "INFO");
                ventanaMensaje.ShowDialog();

            }
            else
            {
                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Conflictos no detectados", "No se ha detectado ningun conflicto futuro", "INFO");
                ventanaMensaje.ShowDialog();
            }

            // Abrimos el form.
            Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
            FormSimulación.ShowDialog();
        }

        // Botón que finaliza la ejecución de la aplicación.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Como usamos .Hide() en el login, hay que forzar a cerrar todo.
        }

        private void cargarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ventanaAbrir = new OpenFileDialog();

            ventanaAbrir.Filter = "Archivo de texto (*.txt)|*.txt|All files(*.*)|*.*";
            ventanaAbrir.Title = "Importar simulación";

            if (ventanaAbrir.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = ventanaAbrir.FileName;

                try
                {
                    miLista.AbrirFichero(rutaArchivo);
                    MiMessageBox ventanaMensaje = new MiMessageBox();
                    ventanaMensaje.ConfigurarMensaje("Datos cargados", "Los datos de la simulación se han importado correctamente", "INFO");
                    ventanaMensaje.ShowDialog();

                    this.distanciaSeguridad = miLista.GetDistanciaCargada();
                    this.tiempoCiclo = miLista.GetTiempoCargado();

                    Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo);
                    FormSimulación.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al intentar importar el fichero:\n" + ex.Message,
                        "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        }
    }

