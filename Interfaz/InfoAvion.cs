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
    // Clase InfoAvion (formulario) que muestra el estado actual de una aeronave específica, incluyendo su posición en tiempo real, velocidad e información corporativa.
    public partial class InfoAvion : Form
    {
        // Constructor que inicializa el formulario y extrae los datos del plan de vuelo seleccionado para cargarlos en la interfaz visual.
        // Parámetros: vueloSeleccionado (FlightPlan) objeto del cual se extraerá la información.
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

        // Botón que cierra la ventana de información:
        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
