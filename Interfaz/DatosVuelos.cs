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
        public DatosVuelos(FlightPlanList listaRecibida)
        {
            InitializeComponent();
            this.listaEnVentana = listaRecibida;
        }

        private void DatosVuelos_Load(object sender, EventArgs e)
        {

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

                FlightPlan avion1 = new FlightPlan(id1, xi1, yi1, xf1, yf1, v1, xi1, yi1);

                //Datos avión 2:
                string id2 = TextBoxID2.Text;
                double v2 = Convert.ToDouble(TextBoxV2.Text);
                double xi2 = Convert.ToDouble(TextBoxXI2.Text);
                double yi2 = Convert.ToDouble(TextBoxYI2.Text);
                double xf2 = Convert.ToDouble(TextBoxXF2.Text);
                double yf2 = Convert.ToDouble(TextBoxYF2.Text);

                FlightPlan avion2 = new FlightPlan(id2, xi2, yi2, xf2, yf2, v2, xi2, yi2);

                //Añadir datos:
                listaEnVentana.AddFlightPlan(avion1);
                listaEnVentana.AddFlightPlan(avion2);

                //Mensaje de éxito:
                MessageBox.Show("Pareja de planes de vuelos cargados correctamente.");
                this.DialogResult = DialogResult.OK; //Indica que los datos se han guardado
                this.Close();
            }
            catch (FormatException) //Error de formato
            {
                MessageBox.Show("Error: Datos introducidos incorrectos.");
            }
            catch (Exception ex) //Otros errores
            {
                MessageBox.Show("Error: Algo no ha salido bien." + ex.Message);
            }
        }
    }
}
