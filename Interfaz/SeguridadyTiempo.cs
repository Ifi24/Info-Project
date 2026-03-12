using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class SeguridadyTiempo : Form
    {
        double dist;
        double tiempo;

        public SeguridadyTiempo(double distActual, double tActual)
        {
            InitializeComponent();
            //Pasamos lo escrito en las TextBox a las variables actuales:
            TextBoxDistSeg.Text = distActual.ToString();
            TextBoxTCiclo.Text = tActual.ToString();
        }

        //Métodos Get para leer los resultados:
        public double GetDistancia()
        { 
            return this.dist;
        }
        public double GetTiempo()
        {
            return this.tiempo; 
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.dist = Convert.ToDouble(TextBoxDistSeg.Text);
                this.tiempo = Convert.ToDouble(TextBoxTCiclo.Text);

                if (dist < 0 || tiempo <=0)
                {
                    MessageBox.Show("Introduce valores positivos.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Datos introducidos incorrectos.");
            }
        }
    }
}
