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
    public partial class DatosVuelos : Form //FASE 2.2
    {
        FlightPlanList listaEnVentana;
        public int contadorVuelos;
        public DatosVuelos(FlightPlanList listaRecibida, int numVuelos)
        {
            InitializeComponent();
            this.listaEnVentana = listaRecibida;
            this.contadorVuelos = numVuelos;

            TextBoxID1.BackColor = Color.Transparent;
            TextBoxID2.BackColor = Color.Transparent;
        }

        //Botón "Guardar" datos de vuelo:
        private void button1_Click(object sender, EventArgs e)
        {
            try //A prueba de errores
            {
                //Datos avión 1:
                string id1 = TextBoxID1.Text;
                double v1 = Convert.ToDouble(TextBoxV1.Text);
                double xi1 = Convert.ToDouble(TextBoxXI1.Text);
                double yi1 = Convert.ToDouble(TextBoxYI1.Text);
                double xf1 = Convert.ToDouble(TextBoxXF1.Text);
                double yf1 = Convert.ToDouble(TextBoxYF1.Text);

                if (xi1 < 0 || xi1 > 600 || yi1 < 0 || yi1 > 400 || xf1 < 0 || xf1 > 600 || yf1 < 0 || yf1 > 400)
                {
                    MessageBox.Show($"Las coordenadas del avión {id1} deben estar dentro del panel (X: 0-600, Y: 0-400).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Aborta la función para que el usuario pueda corregirlo
                }

                FlightPlan avion1 = new FlightPlan(id1, xi1, yi1, xf1, yf1, v1, xi1, yi1);

                //Datos avión 2:
                string id2 = TextBoxID2.Text;
                double v2 = Convert.ToDouble(TextBoxV2.Text);
                double xi2 = Convert.ToDouble(TextBoxXI2.Text);
                double yi2 = Convert.ToDouble(TextBoxYI2.Text);
                double xf2 = Convert.ToDouble(TextBoxXF2.Text);
                double yf2 = Convert.ToDouble(TextBoxYF2.Text);

                if (xi2 < 0 || xi2 > 600 || yi2 < 0 || yi2 > 400 || xf2 < 0 || xf2 > 600 || yf2 < 0 || yf2 > 400)
                {
                    MessageBox.Show($"Las coordenadas del avión {id2} deben estar dentro del panel (X: 0-600, Y: 0-400).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Aborta la función
                }

                FlightPlan avion2 = new FlightPlan(id2, xi2, yi2, xf2, yf2, v2, xi2, yi2);

                //Añadir datos:
                listaEnVentana.AddFlightPlan(avion1);
                listaEnVentana.AddFlightPlan(avion2);

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

        //ADICIÓN: Botón para que se autorellenen los datos (facilita probar el funcionamiento del código)
        private void btnAutorellenar_Click(object sender, EventArgs e)
        {
            try //A prueba de errores
            {
                Random random = new Random(); //Géneramos valores aleatorios.

                //Datos avión 1:
                string id1 = Convert.ToString(contadorVuelos+1);
                double v1 = random.Next(1, 10); //Máximo subjetivo (se puede cambiar)
                double xi1 = random.Next(0, 600);
                double yi1 = random.Next(0, 400);
                double xf1 = random.Next(0, 600);
                double yf1 = random.Next(0, 400);

                FlightPlan avion1 = new FlightPlan(id1, xi1, yi1, xf1, yf1, v1, xi1, yi1);
                listaEnVentana.AddFlightPlan(avion1);
                contadorVuelos++;

                //Datos avión 2:
                string id2 = Convert.ToString(contadorVuelos+1);
                double v2 = random.Next(1, 10);
                double xi2 = random.Next(0, 600);
                double yi2 = random.Next(0, 400);
                double xf2 = random.Next(0, 600);
                double yf2 = random.Next(0, 400);

                FlightPlan avion2 = new FlightPlan(id2, xi2, yi2, xf2, yf2, v2, xi2, yi2);
                listaEnVentana.AddFlightPlan(avion2);
                contadorVuelos++;

                string info = "Se han autorellenado los vuelos con los siguientes datos:\n" +
                      "AVIÓN 1:\n" +
                      "- ID: " + id1 + "\n" +
                      "- Velocidad: " + v1 + "\n" +
                      "- Origen: (" + xi1 + ", " + yi1 + ")\n\n" +
                      "AVIÓN 2:\n" +
                      "- ID: " + id2 + "\n" +
                      "- Velocidad: " + v2 + "\n" +
                      "- Origen: (" + xi2 + ", " + yi2 + ")";

                MessageBox.Show(info, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) //Otros errores
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
