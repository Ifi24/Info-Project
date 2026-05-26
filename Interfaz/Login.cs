using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Interfaz
{
    // Clase Login (Formulario) que gestiona la autentificación de usuarios y la inicialización de la base de datos para el almacenamiento persistente de credenciales y datos de vuelo.
    public partial class Login : Form
    {
        private SQLiteConnection cnx;

        //Creamos DataBase y Tabla si no existen:
        public void CrearBaseDatos()
        {
            if (!System.IO.File.Exists("LoginVuelos.db"))
                SQLiteConnection.CreateFile("LoginVuelos.db");
        }

        // Define la estructura de las tablas 'misUsuarios' y 'misDatosVuelos' si no existen.
        public void CrearTabla()
        {
            string sqlUsuarios = "CREATE TABLE IF NOT EXISTS misUsuarios " +
                "(Username varchar(20) PRIMARY KEY NOT NULL, " + //Espacio para nombres de usuario de un máximo de 20 carácteres, que no se repita ni sea nulo.
                "Password varchar(20) NOT NULL)"; //Espacio para contraseñas de un máximo de 20 caracteres, que no sea nulo.
            string sqlDatos = "CREATE TABLE IF NOT EXISTS misDatosVuelos (" +
                "nVuelo INTEGER PRIMARY KEY AUTOINCREMENT, " + //Le asigna un número a cada vuelo para facilitar trabajar con ellos.
                "Username varchar(20), " +
                "IdAvion varchar(10), " +
                "CurrentX float, CurrentY float, " +
                "InitialX float, InitialY float, " +
                "FinalX float, FinalY float, " +
                "Velocidad float, " +
                "FOREIGN KEY(Username) REFERENCES misUsuarios(Username))"; //El usuario también debe existir en la tabla de usuarios
            string sqlCompanias = "CREATE TABLE IF NOT EXISTS misCompañias (" +
                "Compañia varchar(50) PRIMARY KEY NOT NULL, " + // Espacio para el nombre de la aerolínea (máx 50 caracteres).
                "Telefono varchar(20) NOT NULL, " +           // Teléfono de contacto de la compañía.
                "Email varchar(50) NOT NULL)";
            string sqlSimulaciones = "CREATE TABLE IF NOT EXISTS misSimulaciones (" +
                "IdSimulacion INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Username varchar(20), " +
                "NombreSimulacion varchar(50), " +
                "ContenidoTexto TEXT, " +
                "FechaGuardado varchar(20), " +
                "FOREIGN KEY(Username) REFERENCES misUsuarios(Username))"; //El usuario también debe existir en la tabla de usuarios

            SQLiteCommand cmd1 = new SQLiteCommand(sqlUsuarios, cnx);
            cmd1.ExecuteNonQuery(); //Ejecuta la acción y muestra cuantos cambios ha habido.
            SQLiteCommand cmd2 = new SQLiteCommand(sqlDatos, cnx);
            cmd2.ExecuteNonQuery();
            SQLiteCommand cmd3 = new SQLiteCommand(sqlCompanias, cnx);
            cmd3.ExecuteNonQuery();
            SQLiteCommand cmd4 = new SQLiteCommand(sqlSimulaciones, cnx);
            cmd4.ExecuteNonQuery();
        }

        //Método para buscar y abrir la DataBase:
        public void AbrirBaseDatos()
        {
            string dataSource = "Data Source=LoginVuelos.db"; //Busca el archivo independientemente de donde esté.
            cnx = new SQLiteConnection(dataSource);
            cnx.Open();
        }

        //Método para ejecutar los anteriores y preparar correctamente la base de datos:
        public void PrepararBaseDatos()
        {
            try
            {
                CrearBaseDatos();
                AbrirBaseDatos();
                CrearTabla();
                string query = "INSERT OR IGNORE INTO misCompañias VALUES ('EETAC Air', '934137000', 'eetac.web@upc.edu')";
                string query2 = "INSERT OR IGNORE INTO misCompañias VALUES ('UPC Airlines', '934016200', 'rector@upc.edu')";
                SQLiteCommand cmd1 = new SQLiteCommand(query, cnx);
                cmd1.ExecuteNonQuery();
                SQLiteCommand cmd2 = new SQLiteCommand(query2, cnx);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la base de datos: " + ex.Message);
            }
        }

        public Login()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; //Quita las opciones de arriba de la ventana.
            this.WindowState = FormWindowState.Maximized; //Se abre en modo Fullscreen.
            // Para evitar lag y que todo cargue a la vez
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            PrepararBaseDatos();
        }

        // Botón para iniciar sesión:
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Usuariotxt.Text) || string.IsNullOrWhiteSpace(Contraseñatxt.Text))
            {
                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Campos incompletos", "Por favor, rellene todos los campos. No se permiten espacios en blanco.", "INFO");
                ventanaMensaje.ShowDialog();
                return; // Salimos del método para que no ejecute el SQL
            }

            try
            {
                string sql = "SELECT * FROM misUsuarios WHERE Username = '" + Usuariotxt.Text + "' AND Password = '" + Contraseñatxt.Text + "'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MiMessageBox ventanaMensaje = new MiMessageBox();
                    ventanaMensaje.ConfigurarMensaje("Usuario encontrado",  "\nBienvenido / a, " + Usuariotxt.Text, "INFO");
                    ventanaMensaje.ShowDialog();
                    // Creamos el form principal:
                    Principal FormInterfaz = new Principal(Usuariotxt.Text);
                    FormInterfaz.Show();
                    this.Hide(); //Sólo lo ocultamos para que pueda seguir funcionando el código.
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión." + ex.Message);
            }
        }

        // Botón para registrarse como usuario:
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Usuariotxt.Text) || string.IsNullOrWhiteSpace(Contraseñatxt.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos. No se permiten espacios en blanco.",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salimos del método para que no ejecute el SQL
            }

            try
            {
                string sql = "INSERT INTO misUsuarios (Username, Password) VALUES ('" + Usuariotxt.Text + "','" + Contraseñatxt.Text + "')";
                SQLiteCommand command = new SQLiteCommand(sql, cnx);
                int filasModificadas = command.ExecuteNonQuery();
                if (filasModificadas == 1)
                {
                    MiMessageBox ventanaMensaje = new MiMessageBox();
                    ventanaMensaje.ConfigurarMensaje("Usuario registrado", "Se ha registrado su usuario exitosamente.\n¿Desea iniciar sesión?", "PREGUNTA");
                    DialogResult mensaje = ventanaMensaje.ShowDialog();
                    if (mensaje == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        // Creamos el form principal:
                        Principal FormInterfaz = new Principal(Usuariotxt.Text);
                        FormInterfaz.Show();
                        this.Hide(); //Sólo lo ocultamos para que pueda seguir funcionando el código.
                    }
                    else
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: El usuario ya existe o hubo un error." + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
