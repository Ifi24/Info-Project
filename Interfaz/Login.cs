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

            SQLiteCommand cmd1 = new SQLiteCommand(sqlUsuarios, cnx);
            cmd1.ExecuteNonQuery(); //Ejecuta la acción y muestra cuantos cambios ha habido.
            SQLiteCommand cmd2 = new SQLiteCommand(sqlDatos, cnx);
            cmd2.ExecuteNonQuery();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la base de datos: " + ex.Message);
            }
        }

        public Login()
        {
            InitializeComponent();
            PrepararBaseDatos();
        }

        // Botón para iniciar sesión:
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM misUsuarios WHERE Username = '" + Usuariotxt.Text + "' AND Password = '" + Contraseñatxt.Text + "'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuario encontrado con éxito.\nBienvenido/a, " + Usuariotxt.Text);
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
            try
            {
                string sql = "INSERT INTO misUsuarios (Username, Password) VALUES ('" + Usuariotxt.Text + "','" + Contraseñatxt.Text + "')";
                SQLiteCommand command = new SQLiteCommand(sql, cnx);
                int filasModificadas = command.ExecuteNonQuery();
                if (filasModificadas == 1)
                {
                    DialogResult mensaje = MessageBox.Show("Usuario registrado con éxito.\n¿Desea iniciar sesión?", "Registro de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
