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
        }

        // Métodos:
        // Método que crea los vuelos segun datos proporcionados:
        public void CrearVuelo(string id, double xi, double yi, double cx, double cy, double xf, double yf, double v)
        {
            // Comprovamos que los datos se pueden mostrar:
            if (xi < 0 || xi > 800 || yi < 0 || yi > 600 || xf < 0 || xf > 800 || yf < 0 || yf > 600)
            {
                MessageBox.Show($"Las coordenadas del avión {id} deben estar dentro del panel (X: 0-800, Y: 0-600).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FlightPlan avion = new FlightPlan(id, xi, yi, xi, yi, xf, yf, v);
            misAviones.AddFlightPlan(avion);
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
                
                CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1);
                
                //Datos avión 2:
                string id2 = TextBoxID2.Text;
                double v2 = Convert.ToDouble(TextBoxV2.Text);
                double xi2 = Convert.ToDouble(TextBoxXI2.Text);
                double yi2 = Convert.ToDouble(TextBoxYI2.Text);
                double xf2 = Convert.ToDouble(TextBoxXF2.Text);
                double yf2 = Convert.ToDouble(TextBoxYF2.Text);

                CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2);
                
                //Mensaje de éxito:
                MessageBox.Show("Pareja de planes de vuelos cargados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; //Indica que los datos se han guardado
                this.Close();
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
                string id1 = Convert.ToString(numVuelos+1); //Empezamos con ID = 1
                double v1 = random.Next(1, 10); //Máximo subjetivo (se puede cambiar)
                double xi1 = random.Next(0, 600);
                double yi1 = random.Next(0, 400);
                double xf1 = random.Next(0, 600);
                double yf1 = random.Next(0, 400);

                CrearVuelo(id1, xi1, yi1, xi1, yi1, xf1, yf1, v1);

                //Datos avión 2:
                string id2 = Convert.ToString(numVuelos+1);
                double v2 = random.Next(1, 10);
                double xi2 = random.Next(0, 600);
                double yi2 = random.Next(0, 400);
                double xf2 = random.Next(0, 600);
                double yf2 = random.Next(0, 400);

                CrearVuelo(id2, xi2, yi2, xi2, yi2, xf2, yf2, v2);

                string info = "Se han autorellenado los vuelos con los siguientes datos:\n" +
                      "AVIÓN 1:" + id1 + "\n" +
                      "- Velocidad: " + v1 + "\n" +
                      "- Origen: (" + xi1 + ", " + yi1 + ")\n" +
                      "- Final: (" + xf1 + ", " + yf1 + ")\n\n" +
                      "AVIÓN 1¡2:" + id2 + "\n" +
                      "- Velocidad: " + v2 + "\n" +
                      "- Origen: (" + xi2 + ", " + yi2 + ")\n" +
                      "- Final: (" + xf2 + ", " + yf2 + ")";

                MessageBox.Show(info, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
