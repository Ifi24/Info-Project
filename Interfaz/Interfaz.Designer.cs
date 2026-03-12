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
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            cargarListaDeVuelosToolStripMenuItem = new ToolStripMenuItem();
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem = new ToolStripMenuItem();
            verSimulaciónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarListaDeVuelosToolStripMenuItem, introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem, verSimulaciónToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(85, 24);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // cargarListaDeVuelosToolStripMenuItem
            // 
            cargarListaDeVuelosToolStripMenuItem.Name = "cargarListaDeVuelosToolStripMenuItem";
            cargarListaDeVuelosToolStripMenuItem.Size = new Size(417, 26);
            cargarListaDeVuelosToolStripMenuItem.Text = "Introducir Datos de Vuelo";
            cargarListaDeVuelosToolStripMenuItem.Click += cargarListaDeVuelosToolStripMenuItem_Click;
            // 
            // introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(417, 26);
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Introducir Distancia Seguridad y Tiempo de Ciclo";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // verSimulaciónToolStripMenuItem
            // 
            verSimulaciónToolStripMenuItem.Name = "verSimulaciónToolStripMenuItem";
            verSimulaciónToolStripMenuItem.Size = new Size(417, 26);
            verSimulaciónToolStripMenuItem.Text = "Ver Simulación";
            verSimulaciónToolStripMenuItem.Click += verSimulaciónToolStripMenuItem_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem cargarListaDeVuelosToolStripMenuItem;
        private ToolStripMenuItem introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem;
        private ToolStripMenuItem verSimulaciónToolStripMenuItem;
    }
}
