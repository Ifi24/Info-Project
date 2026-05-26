using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    // Clase DatosVuelos (Formulario) que proporciona una interfaz para que el usuario introduzca manualmente planes de vuelo, genere datos aleatorios o cree escenarios de conflicto.
    public partial class DatosVuelos : Form
    {
        // Atributos
        FlightPlanList misAviones;
        Random random = new Random(); //Géneramos valores aleatorios para el autorrelleno.

        // Constructor que inicializa el formulario y vincula la lista de vuelos compartida:
        public DatosVuelos(FlightPlanList p)
        {
            InitializeComponent();
            this.misAviones = p;

            //Pone el focus en escribir el primer ID.
            this.TextBoxID1.Focus();

            //Hacemos que se puedan leer las teclas (para añadir en un futuro funcion de escribir sin usar ratón).
            this.KeyPreview = true;

            // 1. Cargamos las aerolíneas existentes en ambos desplegables
            CargarAerolineas(comboBoxAerolinia1);
            CargarAerolineas(comboBoxAerolinia2);

            // 2. Enlazamos el evento para cuando seleccionen una opción
            comboBoxAerolinia1.SelectedIndexChanged += comboBoxAerolinia_SelectedIndexChanged;
            comboBoxAerolinia2.SelectedIndexChanged += comboBoxAerolinia_SelectedIndexChanged;
        }

        // Métodos:

        // Método para borrar los datos del form para que el usuario pueda escribir nuevos:
        public void LimpiarFormulario()
        {
            TextBoxID1.Clear();
            TextBoxV1.Clear();
            TextBoxXI1.Clear();
            TextBoxYI1.Clear();
            TextBoxXF1.Clear();
            TextBoxYF1.Clear();
            comboBoxAerolinia1.SelectedIndex = -1;

            TextBoxID2.Clear();
            TextBoxV2.Clear();
            TextBoxXI2.Clear();
            TextBoxYI2.Clear();
            TextBoxXF2.Clear();
            TextBoxYF2.Clear();
            comboBoxAerolinia2.SelectedIndex = -1;

            TextBoxID1.Focus();
        }
        // Método para rellenar los COmboBox desde la base de datos
        private void CargarAerolineas(ComboBox combo)
        {
            combo.Items.Clear();
            string DataSource = "Data Source=LoginVuelos.db";

            try
            {
                using (SQLiteConnection cnx = new SQLiteConnection(DataSource))
                {
                    string sql = "SELECT Compañia FROM misCompañias ORDER BY Compañia ASC";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        combo.Items.Add(fila["Compañia"].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las aerolíneas: " + ex.Message);
            }

            combo.Items.Add("[Añadir una compañía...]");
        }
        
        // Método para preguntar si se quieren añadir más datos (para evitar repeticiones):
        public void ProponerMasDatos()
        {
            //Mensaje de éxito y proponemos al usuario añadir más datos o no.
            MiMessageBox ventanaMensaje = new MiMessageBox();
            ventanaMensaje.ConfigurarMensaje("Datos guardados", "¿Desea añadir más datos?", "PREGUNTA");
            DialogResult respuesta = ventanaMensaje.ShowDialog();
            if (respuesta == DialogResult.No) //Si no quiere, cerramos el form.
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                LimpiarFormulario();
        }
        // Evento que slata cuando el usuario escoge uuna opcion del desplegable
        private void comboBoxAerolinia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboActual = (ComboBox)sender;
            //Si seleccionan la opcion de añadir una compañía:
            if (comboActual.SelectedItem != null && comboActual.SelectedItem.ToString() == "[Añadir una compañía...]")
            {
                GestionAerolineas ventanaGestion = new GestionAerolineas();
                ventanaGestion.ShowDialog();
                CargarAerolineas(comboBoxAerolinia1);
                CargarAerolineas(comboBoxAerolinia2);

                //Como una sleccion automatica, si el usuario añadio una compañia la dejamos seleccionada automaticamente
                if (!string.IsNullOrEmpty(ventanaGestion.GetUltimaCompañiaAñadida()))
                {
                    comboActual.SelectedItem = ventanaGestion.GetUltimaCompañiaAñadida();
                }
                else
                {
                    //si cerró la ventana sin añadir ninguna, deseleccionamos la opción especial
                    comboActual.SelectedIndex = -1;
                }
            }
        }
        //Botón para guardar los datos de vuelo:
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Datos avión 1:
                string id1 = TextBoxID1.Text;
                double v1 = Convert.ToDouble(TextBoxV1.Text);
                double xi1 = Convert.ToDouble(TextBoxXI1.Text);
                double yi1 = Convert.ToDouble(TextBoxYI1.Text);
                double xf1 = Convert.ToDouble(TextBoxXF1.Text);
                double yf1 = Convert.ToDouble(TextBoxYF1.Text);
                string al1 = ""; //al = aerolinia
                if (comboBoxAerolinia1.SelectedItem != null)
                    al1 = comboBoxAerolinia1.SelectedItem.ToString();

                misAviones.CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1, al1);

                //Datos avión 2:
                string id2 = TextBoxID2.Text;
                double v2 = Convert.ToDouble(TextBoxV2.Text);
                double xi2 = Convert.ToDouble(TextBoxXI2.Text);
                double yi2 = Convert.ToDouble(TextBoxYI2.Text);
                double xf2 = Convert.ToDouble(TextBoxXF2.Text);
                double yf2 = Convert.ToDouble(TextBoxYF2.Text);
                string al2 = ""; //al = aerolinia
                if (comboBoxAerolinia2.SelectedItem != null)
                    al1 = comboBoxAerolinia2.SelectedItem.ToString();

                misAviones.CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2, al2);

                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Vuelos cargados", "Pareja de vuelos cargados correctamente.", "INFO");
                ventanaMensaje.ShowDialog();

                ProponerMasDatos();
            }
            catch (FormatException) //Error de formato
            {
                MessageBox.Show("Error:\nDatos introducidos incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) //Otros errores
            {
                MessageBox.Show("Error:\nAlgo no ha salido bien." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón para que se autorellenen los datos (facilita probar el funcionamiento del código)
        private void btnAutorellenar_Click(object sender, EventArgs e)
        {
            int numVuelos = misAviones.GetNumAviones();
            try
            {
                //Datos avión 1:
                string id1 = Convert.ToString(numVuelos + 1); //Empezamos con ID = 1
                double v1 = random.Next(1, 10); //Máximo subjetivo (se puede cambiar)
                double xi1 = random.Next(0, 1400);
                double yi1 = random.Next(0, 900);
                double xf1 = random.Next(0, 1400);
                double yf1 = random.Next(0, 900);
                string al1 = "EETAC Air";

                TextBoxID1.Text = id1;
                TextBoxV1.Text = Convert.ToString(v1);
                TextBoxXI1.Text = Convert.ToString(xi1);
                TextBoxYI1.Text = Convert.ToString(yi1);
                TextBoxXF1.Text = Convert.ToString(xf1);
                TextBoxYF1.Text = Convert.ToString(yf1);
                comboBoxAerolinia1.SelectedItem = al1;

                misAviones.CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1, al1);

                //Datos avión 2:
                string id2 = Convert.ToString(numVuelos + 2);
                double v2 = random.Next(1, 10);
                double xi2 = random.Next(0, 1400);
                double yi2 = random.Next(0, 900);
                double xf2 = random.Next(0, 1400);
                double yf2 = random.Next(0, 900);
                string al2 = "UPC Airlines";

                TextBoxID2.Text = id2;
                TextBoxV2.Text = Convert.ToString(v2);
                TextBoxXI2.Text = Convert.ToString(xi2);
                TextBoxYI2.Text = Convert.ToString(yi2);
                TextBoxXF2.Text = Convert.ToString(xf2);
                TextBoxYF2.Text = Convert.ToString(yf2);
                comboBoxAerolinia1.SelectedItem = al2;

                misAviones.CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2, al2);

                string info = "Se han autorellenado los vuelos con los siguientes datos:\n" +
                      "AVIÓN 1: " + id1 + "\n" +
                      "· Velocidad: " + v1 + "\n" +
                      "· Origen: (" + xi1 + ", " + yi1 + ")\n" +
                      "· Final: (" + xf1 + ", " + yf1 + ")\n\n" +
                      "AVIÓN 2: " + id2 + "\n" +
                      "· Velocidad: " + v2 + "\n" +
                      "· Origen: (" + xi2 + ", " + yi2 + ")\n" +
                      "· Final: (" + xf2 + ", " + yf2 + ")";

                MiMessageBox ventanaMensaje = new MiMessageBox();
                ventanaMensaje.ConfigurarMensaje("Vuelos generados", info, "INFO");
                ventanaMensaje.Size = new Size(450, 480);
                ventanaMensaje.ShowDialog();

                ProponerMasDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\nError al generar datos." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón que cierra el formulario actual:
        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón que genera un conflicto:
        private void btnConflicto_Click(object sender, EventArgs e)
        {
            misAviones.GenerarConflicto();

            MiMessageBox ventanaMensaje = new MiMessageBox();
            ventanaMensaje.ConfigurarMensaje("Escenario generado", "Un escenario de conflicto se ha generado correctamente", "INFO");
            ventanaMensaje.ShowDialog();

            ProponerMasDatos();
        }

       
    }
}
