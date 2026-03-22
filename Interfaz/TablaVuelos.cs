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
    public partial class TablaVuelos : Form
    {
        FlightLib.FlightPlanList listaVuelos;
        int primerVuelo = -1;
        public TablaVuelos(FlightLib.FlightPlanList miLista)
        {
            InitializeComponent();
            this.listaVuelos = miLista;

            dgvVuelos.ReadOnly = true;
            dgvVuelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Hago que recorra toda la lista de vuelos, pensando a futuro para que se puedan agregar más vuelos, y los muestre en la tabla:
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                string id = fp.GetId();
                double x = fp.GetCurrentPosition().GetX();
                double y = fp.GetCurrentPosition().GetY();
                double speed = fp.GetVelocidad();

                dgvVuelos.Rows.Add(id, x, y, speed);

            }

            dgvVuelos.CellClick += new DataGridViewCellEventHandler(dgvVuelos_CellClick);

        }
        public void dgvVuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FlightPlan vueloClick = listaVuelos.GetFlightPlan(e.RowIndex);

                FormDistancia ventanaDistancia = new FormDistancia(vueloClick, listaVuelos);
                ventanaDistancia.ShowDialog();
            }
        }
    }
}
