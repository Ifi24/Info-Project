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
    public partial class InfoAvion : Form
    {
        public InfoAvion(FlightLib.FlightPlan vueloSeleccionado)
        {
            InitializeComponent();

            Position posicion = vueloSeleccionado.GetCurrentPosition();
            Informacion.Text = "Información del avión: " + vueloSeleccionado.GetId();
            labelID.Text = "ID: " + vueloSeleccionado.GetId();
            labelX.Text = "Posición X: " + posicion.GetX().ToString("N2");
            labelY.Text = "Posición Y: " + posicion.GetY().ToString("N2");
            labelVelocidad.Text = "Velocidad: " + vueloSeleccionado.GetVelocidad().ToString("N2");
            labelAerolinia.Text = "Aerolinia: " + vueloSeleccionado.GetAerolinia();
        }

        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
