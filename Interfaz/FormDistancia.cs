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
    // Clase FormDistancia (Formulario) que define el comportamiento de la ventana que calcula la separación entre aeronaves en el espacio aéreo.
    public partial class FormDistancia : Form
    {
        // Atributos:
        public FlightLib.FlightPlan seleccionado;
        public FlightLib.FlightPlanList lista;

        // Métodos que permite pasar la información desde el formulario principal a este.
        // Parámetros: el plan de vuelo de referencia y la lista global de vuelos.
        public void SetDatos(FlightLib.FlightPlan seleccionado, FlightLib.FlightPlanList lista)
        {
            this.seleccionado = seleccionado;
            this.lista = lista;
        }

        // Constructor:
        public FormDistancia()
        {
            InitializeComponent();
        }

        // Calcula las distancias en tiempo real al cargar el formulario:
        private void FormDistancia_Load(object sender, EventArgs e)
        {
            if ((seleccionado != null) && (lista != null))
            {
                string textoresultado = "";

                double x1 = seleccionado.GetCurrentPosition().GetX();
                double y1 = seleccionado.GetCurrentPosition().GetY();

                for (int i = 0; i < lista.GetNumAviones(); i++)
                {
                    FlightLib.FlightPlan otroVuelo = lista.GetFlightPlan(i);

                    //Nos aseguramos que no es el mismo avión:
                    if (otroVuelo.GetId() != seleccionado.GetId())
                    {
                        //Calculamos Pitágoras
                        double x2 = otroVuelo.GetCurrentPosition().GetX();
                        double y2 = otroVuelo.GetCurrentPosition().GetY();
                        double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                        //Mostramos en el label las distancias.
                        textoresultado += "Distancia al vuelo " + otroVuelo.GetId() + ": " + distancia.ToString("F2") + "m\n";
                    }
                }
                if (textoresultado == "")
                {
                    textoresultado = "No hay otros vuelos cerca.";
                }

                labelDistancia.Text = textoresultado;
            }
        }

        // Botón para cerrar la ventana de distancias:
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
