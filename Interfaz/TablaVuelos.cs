using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class TablaVuelos : Form //Mostrar datos vuelos.
    {
        FlightLib.FlightPlanList listaVuelos;
        Simulación simulacion;
        private string cadenaConexion = "Data Source=LoginVuelos.db";

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
            dgvVuelos.ColumnCount = 7;
            dgvVuelos.Columns[0].Name = "ID";
            dgvVuelos.Columns[1].Name = "Posición X";
            dgvVuelos.Columns[2].Name = "Posición Y";
            dgvVuelos.Columns[3].Name = "Velocidad";
            dgvVuelos.Columns[4].Name = "Aerolinia";
            dgvVuelos.Columns[5].Name = "Teléfono"; 
            dgvVuelos.Columns[6].Name = "Email";
            dgvVuelos.RowHeadersVisible = false;
            dgvVuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVuelos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVuelos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            int numVuelos = listaVuelos.GetNumAviones();

            for (int i = 0; i < numVuelos; i++)
            {
                FlightPlan fp = listaVuelos.GetFlightPlan(i);

                string id = fp.GetId();
                double x = fp.GetCurrentPosition().GetX();
                double y = fp.GetCurrentPosition().GetY();
                double speed = fp.GetVelocidad();
                string compañia = fp.GetAerolinia();
                string telefono = "No asignado";
                string email = "No asignado";

                SQLiteConnection conexionQuery = new SQLiteConnection(cadenaConexion);
                try
                {
                    conexionQuery.Open();
                    string query = "SELECT Telefono, Email FROM misCompanias WHERE Nombre = '" + compañia + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexionQuery);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        telefono = reader["Telefono"].ToString();
                        email = reader["Email"].ToString();
                    }

                    reader.Close();
                    conexionQuery.Close();
                }
                catch (Exception ex)
                {
                    if (conexionQuery.State == ConnectionState.Open)
                    {
                        conexionQuery.Close();
                    }
                    telefono = "Error";
                    email = "Error";
                }

                dgvVuelos.Rows.Add(id, x, y, speed, compañia, telefono, email);
                dgvVuelos.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        private void dgvVuelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            bool algunError = false; // Para saber si algún avión tuvo velocidad incorrecta
            for (int i = 0; i < listaVuelos.GetNumAviones(); i++)
            {
                try
                {
                    double nuevaVelocidad = Convert.ToDouble(dgvVuelos.Rows[i].Cells[3].Value); //Leemos nueva velocidad
                    if (nuevaVelocidad <= 0)
                    {
                        string idAvion = dgvVuelos.Rows[i].Cells[0].Value.ToString();
                        MessageBox.Show($"Error en el avión {idAvion}: La velocidad debe ser mayor que 0.", "Velocidad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        algunError = true;
                        continue; // Saltamos este avión y seguimos con el siguiente
                    }
                    FlightPlan fp = listaVuelos.GetFlightPlan(i); //El avión real
                    if (fp != null && !algunError)
                    {
                        fp.SetVelocidad(nuevaVelocidad);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("No se ha podido cambiar la velocidad por un error de formato.\nIntroduzca correctamente los datos de la velocidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    algunError = true;
                }
            }
            if (!algunError)
            {
                MessageBox.Show("Velocidades actualizándose. Reiniciando simulación...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); //Informamos al usuario 
                this.Close();
                simulacion.ReiniciarSimulacion(); //Llamamos a la función que hemos creado en simulación
            }
            else
            {
                MessageBox.Show("Algunos cambios no se aplicaron debido a errores. Revise los valores marcados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dgvVuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
