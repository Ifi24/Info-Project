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
    public partial class FormDistancia : Form
    {
        public FormDistancia(FlightPlan vueloBase, FlightPlanList listaVuelos)
        {
            InitializeComponent();

            string texto = "Distancias desde el vuelo " + vueloBase.GetId() + ":\n\n";

            double x1 = vueloBase.GetCurrentPosition().GetX();
            double y1 = vueloBase.GetCurrentPosition().GetY();

            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                FlightPlan otroVuelo = listaVuelos.GetFlightPlan(i);

                if (vueloBase != otroVuelo)
                {
                    double x2 = otroVuelo.GetCurrentPosition().GetX();
                    double y2 = otroVuelo.GetCurrentPosition().GetY();
                    double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                    texto += "Distancia a " + otroVuelo.GetId() + ": " + Math.Round(distancia, 3) + " unidades\n";
                }
            }
            labelDistancia.Text = texto;

        }
    }
}
