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
    public partial class TablaVuelos : Form //Mostrar datos vuelos.
    {
        FlightLib.FlightPlanList listaVuelos;
        Simulación simulacion;

        public TablaVuelos(FlightLib.FlightPlanList miLista, Simulación sim)
        {
            InitializeComponent();

            //Gets:
            this.listaVuelos = miLista;
            this.simulacion = sim;

            dgvVuelos.ReadOnly = false; //Si es true no se puede editar
            dgvVuelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVuelos.CellClick += new DataGridViewCellEventHandler(dgvVuelos_CellClick);

        }
        private void TablaVuelos_Load(object sender, EventArgs e)
        {
            dgvVuelos.ColumnCount = 4;
            dgvVuelos.Columns[0].Name = "ID";
            dgvVuelos.Columns[1].Name = "Posición X";
            dgvVuelos.Columns[2].Name = "Posición Y";
            dgvVuelos.Columns[3].Name = "Velocidad";
            dgvVuelos.RowHeadersVisible = false;
            dgvVuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVuelos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVuelos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            int numVuelos = listaVuelos.GetNum();

            for (int i = 0; i < numVuelos; i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                string id = fp.GetId();
                double x = fp.GetCurrentPosition().GetX();
                double y = fp.GetCurrentPosition().GetY();
                double speed = fp.GetVelocidad();

                dgvVuelos.Rows.Add(id, x, y, speed);
                dgvVuelos.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }
        public void dgvVuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FlightPlan vueloClick = listaVuelos.GetFlightPlan(e.RowIndex);

                FormDistancia ventanaDistancia = new FormDistancia();
                ventanaDistancia.SetDatos(vueloClick, listaVuelos);
                ventanaDistancia.ShowDialog();
            }
        }


        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //FASE 1.6: Pongo un botón para aplicar los cambios

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaVuelos.GetNum(); i++)
            {
                double nuevaVelocidad = Convert.ToDouble(dgvVuelos.Rows[i].Cells[3].Value); //Leemos nueva velocidad

                FlightPlan fp = listaVuelos.GetFlightPlan(i); //El avión real
                if (fp != null)
                {
                    fp.SetVelocidad(nuevaVelocidad);
                }
                //Actualizamos el fp
            }

            MessageBox.Show("Velocidades actualizadas. Reiniciando simulación...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); //Informamos al usuario 
            this.Close();
            simulacion.ReiniciarSimulacion(); //Llamamos a la función que hemos creado en simulación
        }
    }
}
