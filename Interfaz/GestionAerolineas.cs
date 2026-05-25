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
    public partial class GestionAerolineas : Form
    {
        private string cadenaConexion = "Data Source=LoginVuelos.db";
        public GestionAerolineas()
        {
            InitializeComponent();

            dgvCompañias.ReadOnly = true;
            dgvCompañias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompañias.RowHeadersVisible = false;
            dgvCompañias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GestionAerolineas_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        // Función auxiliar para leer la base de datos y rellenar la cuadrícula
        private void ActualizarTabla()
        {
            // Limpiamos las filas y columnas previas para no duplicar datos
            dgvCompañias.Rows.Clear();
            dgvCompañias.ColumnCount = 3;
            dgvCompañias.Columns[0].Name = "Aerolínea";
            dgvCompañias.Columns[1].Name = "Teléfono";
            dgvCompañias.Columns[2].Name = "Email";

            SQLiteConnection conexionQuery = new SQLiteConnection(cadenaConexion);
            try
            {
                conexionQuery.Open();

                // Pedimos todas las compañías ordenadas por nombre 
                string query = "SELECT Compañia, Telefono, Email FROM misCompañias";
                SQLiteCommand cmd = new SQLiteCommand(query, conexionQuery);
                SQLiteDataReader reader = cmd.ExecuteReader();

                // Leemos la base de datos fila por fila hasta el final
                while (reader.Read())
                {
                    string nom = reader["Compañia"].ToString();
                    string tel = reader["Telefono"].ToString();
                    string em = reader["Email"].ToString();

                    // Añadimos los datos al DataGridView 
                    dgvCompañias.Rows.Add(nom, tel, em);
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
                MessageBox.Show("Error al cargar las compañías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompañia.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtGmail.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos (Compañía, Teléfono y Gmail).", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SQLiteConnection conexionQuery = new SQLiteConnection(cadenaConexion);
            try
            {
                conexionQuery.Open();

                string query = "INSERT INTO misCompañias (Compañia, Telefono, Email) VALUES ('" + txtCompañia.Text + "', '" + txtTelefono.Text + "', '" + txtGmail.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, conexionQuery);

                // Ejecutamos la orden de inserción
                cmd.ExecuteNonQuery();
                conexionQuery.Close();

                MessageBox.Show("Compañía añadida correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos los cuadros de texto para la siguiente
                txtCompañia.Clear();
                txtTelefono.Clear();
                txtGmail.Clear();

                // Refrescamos la tabla para que aparezca la nueva aerolínea al instante
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                if (conexionQuery.State == ConnectionState.Open)
                {
                    conexionQuery.Close();
                }
                MessageBox.Show("No se pudo añadir. Puede que la compañía ya exista.\nError: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCompañias.SelectedRows.Count > 0)
            {
                // Cogemos el nombre de la compañía que está en la primera celda (columna 0) de la fila seleccionada
                string compañiaSeleccionada = dgvCompañias.SelectedRows[0].Cells[0].Value.ToString();

                // Pedimos confirmación
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar la compañía " + compañiaSeleccionada + "?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    SQLiteConnection conexionQuery = new SQLiteConnection(cadenaConexion);
                    try
                    {
                        conexionQuery.Open();

                        string query = "DELETE FROM misCompañias WHERE Compañia = '" + compañiaSeleccionada + "'";
                        SQLiteCommand cmd = new SQLiteCommand(query, conexionQuery);

                        cmd.ExecuteNonQuery();
                        conexionQuery.Close();

                        MessageBox.Show("Compañía eliminada de la base de datos.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la tabla para que desaparezca visualmente
                        ActualizarTabla();
                    }
                    catch (Exception ex)
                    {
                        if (conexionQuery.State == ConnectionState.Open)
                        {
                            conexionQuery.Close();
                        }
                        MessageBox.Show("Error al eliminar la compañía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione primero una fila de la tabla para poder eliminarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
