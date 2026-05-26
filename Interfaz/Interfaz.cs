using FlightLib;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

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
        private void Principal_Load(object sender, EventArgs e)
        {
            ConfigurarDGVSimulaciones();
            ActualizarDGVSimulaciones();
        }
        public void ConfigurarDGVSimulaciones()
        {
            dgv_SimulacionesGuardadas.Columns.Clear();
            dgv_SimulacionesGuardadas.AutoGenerateColumns = false;
            dgv_SimulacionesGuardadas.AllowUserToAddRows = false;
            dgv_SimulacionesGuardadas.ReadOnly = true;
            dgv_SimulacionesGuardadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Columna de nombre de simulación
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "NombreSimulacion";
            colNombre.Width = 180;
            dgv_SimulacionesGuardadas.Columns.Add(colNombre);

            // Columna de fecha
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.HeaderText = "Fecha guardado";
            colFecha.DataPropertyName = "FechaGuardado";
            colFecha.Width = 140;
            dgv_SimulacionesGuardadas.Columns.Add(colFecha);

            dgv_SimulacionesGuardadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SimulacionesGuardadas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_SimulacionesGuardadas.CellDoubleClick += dgv_SimulacionesGuardadas_CellDoubleClick;

        }
        public void ActualizarDGVSimulaciones()
        {
            try
            {
                string dataSource = "Data Source=LoginVuelos.db";
                using (SQLiteConnection cnx = new SQLiteConnection(dataSource))
                {
                    cnx.Open();

                    string sql = "SELECT NombreSimulacion, FechaGuardado FROM misSimulaciones " +
                                 "WHERE Username = @user ORDER BY IdSimulacion DESC";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                    adapter.SelectCommand.Parameters.AddWithValue("@user", this.Usuario);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv_SimulacionesGuardadas.DataSource = dt;

                    // Reajusta columnas y el alto del propio control según las filas que haya:
                    dgv_SimulacionesGuardadas.AutoResizeColumns();
                    dgv_SimulacionesGuardadas.AutoResizeRows();

                    int alturaFilas = dgv_SimulacionesGuardadas.Rows
                        .Cast<DataGridViewRow>()
                        .Sum(r => r.Height);

                    int alturaTotal = dgv_SimulacionesGuardadas.ColumnHeadersHeight + alturaFilas + 2;
                    dgv_SimulacionesGuardadas.Height = alturaTotal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las simulaciones: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_SimulacionesGuardadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreSimulacion = dgv_SimulacionesGuardadas.Rows[e.RowIndex].Cells[0].Value.ToString();

                try
                {
                    string dataSource = "Data Source=LoginVuelos.db";
                    using (SQLiteConnection cnx = new SQLiteConnection(dataSource))
                    {
                        cnx.Open();
                        string sql = "SELECT ContenidoTexto FROM misSimulaciones WHERE Username = @user AND NombreSimulacion = @nombre";

                        using (SQLiteCommand cmd = new SQLiteCommand(sql, cnx))
                        {
                            cmd.Parameters.AddWithValue("@user", this.Usuario);
                            cmd.Parameters.AddWithValue("@nombre", nombreSimulacion);

                            object resultado = cmd.ExecuteScalar();

                            if (resultado != null && resultado != DBNull.Value)
                            {
                                string datosSimulacion = resultado.ToString().Trim();

                                if (string.IsNullOrEmpty(datosSimulacion))
                                {
                                    MessageBox.Show("Esta simulación está vacía o se guardó incorrectamente antes de los cambios.", "Simulación sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string rutaTemporal = Path.Combine(Path.GetTempPath(), "temp_radar.txt");
                                File.WriteAllText(rutaTemporal, datosSimulacion);
                                miLista.AbrirFichero(rutaTemporal);

                                File.Delete(rutaTemporal);

                                this.distanciaSeguridad = miLista.GetDistanciaCargada();
                                this.tiempoCiclo = miLista.GetTiempoCargado();

                                MiMessageBox ventanaMensaje = new MiMessageBox();
                                ventanaMensaje.ConfigurarMensaje("Simulación Cargada", $"Se ha cargado: {nombreSimulacion}", "INFO");
                                ventanaMensaje.ShowDialog();

                                this.FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo, Usuario);
                                this.FormSimulación.ShowDialog();
                                ActualizarDGVSimulaciones();
                            }
                            else
                            {
                                MessageBox.Show("No se han encontrado los datos de esta simulación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al procesar la simulación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (miLista.GetNumAviones() == 0)
            {
                Simulación FormSim = new Simulación(miLista, distanciaSeguridad, tiempoCiclo, Usuario);
                FormSim.ShowDialog();
                return;
            }

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
            Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo, Usuario);
            FormSimulación.ShowDialog();
            ActualizarDGVSimulaciones();
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

                    Simulación FormSimulación = new Simulación(miLista, distanciaSeguridad, tiempoCiclo, Usuario);
                    FormSimulación.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al intentar importar el fichero:\n" + ex.Message,
                        "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionarCompañíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionAerolineas ventanaGestion = new GestionAerolineas();
            ventanaGestion.ShowDialog();
        }
    }
}

