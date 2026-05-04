using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    // Clase SeguridadyTiempo (Formulario) que permite ajustar los parámetros de la simulación: la distancia mínima de seguridad y el diferencial de tiempo por ciclo.
    public partial class SeguridadyTiempo : Form
    {
        // Atributos: 
        double dist;
        double tiempo;

        // Constructor que inicializa el formulario cargando los valores actuales en los campos de texto:
        public SeguridadyTiempo(double distActual, double tActual)
        {
            InitializeComponent();

            //Pasamos lo escrito en las TextBox a las variables actuales:
            TextBoxDistSeg.Text = distActual.ToString();
            TextBoxTCiclo.Text = tActual.ToString();
        }

        // Métodos
        // Gets y Sets:
        public double GetDistancia()
        { 
            return this.dist;
        }
        public void SetDistancia(double d)
        {
            this.dist = d;
        }

        public double GetTiempo()
        {
            return this.tiempo; 
        }
        public void SetTiempo(double t)
        {
            this.tiempo = t;
        }

        // Botón para guardar los cambios:
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.dist = Convert.ToDouble(TextBoxDistSeg.Text);
                this.tiempo = Convert.ToDouble(TextBoxTCiclo.Text);

                if (dist < 0 || tiempo <=0)
                {
                    MessageBox.Show("Error:\nIntroduce valores positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error:\nDatos introducidos incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Para crear el formato al guardar:
        public string GuardarSegTiempo()
        {
            return $"{dist} {tiempo}";
        }
    }
}
