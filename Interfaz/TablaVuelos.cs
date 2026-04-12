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
        Simulación simulacion;
        int primerVuelo = -1;
        public TablaVuelos(FlightLib.FlightPlanList miLista, Simulación sim)
        {
            InitializeComponent();
            this.listaVuelos = miLista;
            this.simulacion = sim;

            dgvVuelos.ReadOnly = false; //Si es true no se puede editar
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

        //Pongo un botón para aplicar los cambios (Fase 1.6)
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvVuelos.Rows.Count; i++) //Recorremos cada fila del dgvVuelos (aviones)
            {
                double nuevaVelocidad = Convert.ToDouble(dgvVuelos.Rows[i].Cells[3].Value); //Leemos nueva velocidad

                FlightPlan fp = listaVuelos.GetFlightPlan(i); //El avión real
                fp.SetVelocidad(nuevaVelocidad); //Actualizamos el fp
            }

            MessageBox.Show("Velocidades actualizadas. Reiniciando simulación..."); //Informamos al usuario 
            this.Close();
            simulacion.ReiniciarSimulacion(); //Llamamos a la función que hemos creado en simulación
        }
    }
}
