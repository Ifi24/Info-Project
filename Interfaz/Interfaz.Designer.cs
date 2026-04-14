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
            flowLayoutPanel1 = new FlowLayoutPanel();
            Titulo = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.WindowFrame;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Opciones });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(624, 36);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSlateGray;
            flowLayoutPanel1.Controls.Add(Titulo);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Location = new Point(0, 39);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(622, 52);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // Titulo
            // 
            Titulo.Anchor = AnchorStyles.None;
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo.ForeColor = SystemColors.Control;
            Titulo.Location = new Point(3, 0);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(317, 28);
            Titulo.TabIndex = 0;
            Titulo.Text = "Proyecto de Programación";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(326, 18);
            label1.TabIndex = 1;
            label1.Text = "Grupo 8: Ana López, Ifesinachi Egbera, Laia Alba";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(101, 18);
            label3.TabIndex = 3;
            label3.Text = "¡Bienvenido!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(21, 136);
            label4.Name = "label4";
            label4.Size = new Size(286, 18);
            label4.TabIndex = 4;
            label4.Text = "Este es nuestro proyecto de informática II";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(624, 390);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Text = "Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Opciones;
        private ToolStripMenuItem cargarListaDeVuelosToolStripMenuItem;
        private ToolStripMenuItem introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem;
        private ToolStripMenuItem verSimulaciónToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label Titulo;
        private Label label1;
        private Label label3;
        private Label label4;
    }
}
