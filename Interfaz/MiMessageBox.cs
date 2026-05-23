using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class MiMessageBox : Form
    {
        public MiMessageBox()
        {
            InitializeComponent();

            btnAceptar.DialogResult = DialogResult.Yes;
            btnCancelar.DialogResult = DialogResult.No;
        }

        public void ConfigurarMensaje(string titulo, string mensaje, string tipo)
        {
            lblTitulo.Text = titulo;
            lblMensaje.Text = mensaje;

            if (tipo == "PREGUNTA")
            {
                btnAceptar.Text = "Sí";
                btnCancelar.Text = "No";
                btnCancelar.Visible = true;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
                btnCancelar.Visible = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
