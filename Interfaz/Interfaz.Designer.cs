namespace Interfaz
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            Opciones = new ToolStripMenuItem();
            cargarListaDeVuelosToolStripMenuItem = new ToolStripMenuItem();
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem = new ToolStripMenuItem();
            verSimulaciónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Opciones });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(622, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Opciones
            // 
            Opciones.BackColor = Color.DarkSlateGray;
            Opciones.DropDownItems.AddRange(new ToolStripItem[] { cargarListaDeVuelosToolStripMenuItem, introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem, verSimulaciónToolStripMenuItem });
            Opciones.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Opciones.ForeColor = SystemColors.Control;
            Opciones.Name = "Opciones";
            Opciones.Padding = new Padding(10, 10, 5, 0);
            Opciones.Size = new Size(96, 32);
            Opciones.Text = "Opciones";
            // 
            // cargarListaDeVuelosToolStripMenuItem
            // 
            cargarListaDeVuelosToolStripMenuItem.BackColor = Color.DarkSlateGray;
            cargarListaDeVuelosToolStripMenuItem.ForeColor = SystemColors.Control;
            cargarListaDeVuelosToolStripMenuItem.Name = "cargarListaDeVuelosToolStripMenuItem";
            cargarListaDeVuelosToolStripMenuItem.Size = new Size(454, 26);
            cargarListaDeVuelosToolStripMenuItem.Text = "Introducir Datos de Vuelo";
            cargarListaDeVuelosToolStripMenuItem.Click += cargarListaDeVuelosToolStripMenuItem_Click;
            // 
            // introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.BackColor = Color.DarkSlateGray;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.ForeColor = SystemColors.Control;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(454, 26);
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Introducir Distancia Seguridad y Tiempo de Ciclo";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // verSimulaciónToolStripMenuItem
            // 
            verSimulaciónToolStripMenuItem.BackColor = Color.DarkSlateGray;
            verSimulaciónToolStripMenuItem.ForeColor = SystemColors.Control;
            verSimulaciónToolStripMenuItem.Name = "verSimulaciónToolStripMenuItem";
            verSimulaciónToolStripMenuItem.Size = new Size(454, 26);
            verSimulaciónToolStripMenuItem.Text = "Ver Simulación";
            verSimulaciónToolStripMenuItem.Click += verSimulaciónToolStripMenuItem_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(622, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Text = "Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Opciones;
        private ToolStripMenuItem cargarListaDeVuelosToolStripMenuItem;
        private ToolStripMenuItem introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem;
        private ToolStripMenuItem verSimulaciónToolStripMenuItem;
    }
}
