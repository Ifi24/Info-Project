using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class DatosVuelos : Form
    {
        FlightPlanList misAviones;
        Random random = new Random(); //Géneramos valores aleatorios para el autorrelleno.

        // Constructor:
        public DatosVuelos(FlightPlanList p)
        {
            InitializeComponent();
            this.misAviones = p;

            //Pone el focus en escribir el primer ID.
            this.TextBoxID1.Focus();

            //Hacemos que se puedan leer las teclas (para añadir en un futuro funcion de escribir sin usar ratón).
            this.KeyPreview = true;
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

            TextBoxID2.Clear();
            TextBoxV2.Clear();
            TextBoxXI2.Clear();
            TextBoxYI2.Clear();
            TextBoxXF2.Clear();
            TextBoxYF2.Clear();

            TextBoxID1.Focus();
        }

        // Método para preguntar si se quieren añadir más datos (para evitar repeticiones):
        public void ProponerMasDatos()
        {
            //Mensaje de éxito y proponemos al usuario añadir más datos o no.
            DialogResult respuesta = MessageBox.Show("¿Desea añadir más datos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No) //Si no quiere, cerramos el form.
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                LimpiarFormulario();
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
                string al1 = TextBoxAerolinia1.Text; //AL = aerolinia

                misAviones.CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1, al1);

                //Datos avión 2:
                string id2 = TextBoxID2.Text;
                double v2 = Convert.ToDouble(TextBoxV2.Text);
                double xi2 = Convert.ToDouble(TextBoxXI2.Text);
                double yi2 = Convert.ToDouble(TextBoxYI2.Text);
                double xf2 = Convert.ToDouble(TextBoxXF2.Text);
                double yf2 = Convert.ToDouble(TextBoxYF2.Text);
                string al2 = TextBoxAerolinia2.Text;

                misAviones.CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2, al2);
                MessageBox.Show("Pareja de planes de vuelos cargados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                double xi1 = random.Next(0, 600);
                double yi1 = random.Next(0, 400);
                double xf1 = random.Next(0, 600);
                double yf1 = random.Next(0, 400);
                string al1 = "EETAC Air";

                misAviones.CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1, al1);

                //Datos avión 2:
                string id2 = Convert.ToString(numVuelos + 2);
                double v2 = random.Next(1, 10);
                double xi2 = random.Next(0, 600);
                double yi2 = random.Next(0, 400);
                double xf2 = random.Next(0, 600);
                double yf2 = random.Next(0, 400);
                string al2 = "UPC Airlines";

                misAviones.CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2, al2);

                string info = "Se han autorellenado los vuelos con los siguientes datos:\n" +
                      "AVIÓN 1: " + id1 + "\n" +
                      "- Velocidad: " + v1 + "\n" +
                      "- Origen: (" + xi1 + ", " + yi1 + ")\n" +
                      "- Final: (" + xf1 + ", " + yf1 + ")\n\n" +
                      "AVIÓN 2: " + id2 + "\n" +
                      "- Velocidad: " + v2 + "\n" +
                      "- Origen: (" + xi2 + ", " + yi2 + ")\n" +
                      "- Final: (" + xf2 + ", " + yf2 + ")";

                MessageBox.Show(info, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProponerMasDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\nError al generar datos." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConflicto_Click(object sender, EventArgs e)
        {
            misAviones.GenerarConflicto();

            MessageBox.Show("Escenario de conflicto generado automáticamente.", "Conflicto generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProponerMasDatos();
        }
    }
}
