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
            cargarSimulaciónToolStripMenuItem = new ToolStripMenuItem();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Titulo = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCerrar = new Button();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.WindowFrame;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Opciones });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 3, 0, 3);
            menuStrip1.Size = new Size(193, 1579);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Opciones
            // 
            Opciones.BackColor = Color.DarkSlateGray;
            Opciones.DropDownItems.AddRange(new ToolStripItem[] { cargarListaDeVuelosToolStripMenuItem, introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem, verSimulaciónToolStripMenuItem, cargarSimulaciónToolStripMenuItem, opcionesToolStripMenuItem });
            Opciones.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Opciones.ForeColor = SystemColors.Control;
            Opciones.Name = "Opciones";
            Opciones.Padding = new Padding(10, 10, 5, 0);
            Opciones.Size = new Size(172, 53);
            Opciones.Text = "Opciones";
            // 
            // cargarListaDeVuelosToolStripMenuItem
            // 
            cargarListaDeVuelosToolStripMenuItem.BackColor = Color.DarkSlateGray;
            cargarListaDeVuelosToolStripMenuItem.ForeColor = SystemColors.Control;
            cargarListaDeVuelosToolStripMenuItem.Name = "cargarListaDeVuelosToolStripMenuItem";
            cargarListaDeVuelosToolStripMenuItem.Size = new Size(935, 48);
            cargarListaDeVuelosToolStripMenuItem.Text = "Introducir Datos de Vuelo";
            cargarListaDeVuelosToolStripMenuItem.Click += cargarListaDeVuelosToolStripMenuItem_Click;
            // 
            // introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.BackColor = Color.DarkSlateGray;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.ForeColor = SystemColors.Control;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(935, 48);
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Introducir Distancia Seguridad y Tiempo de Ciclo";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // verSimulaciónToolStripMenuItem
            // 
            verSimulaciónToolStripMenuItem.BackColor = Color.DarkSlateGray;
            verSimulaciónToolStripMenuItem.ForeColor = SystemColors.Control;
            verSimulaciónToolStripMenuItem.Name = "verSimulaciónToolStripMenuItem";
            verSimulaciónToolStripMenuItem.Size = new Size(935, 48);
            verSimulaciónToolStripMenuItem.Text = "Ver Simulación";
            verSimulaciónToolStripMenuItem.Click += verSimulaciónToolStripMenuItem_Click;
            // 
            // cargarSimulaciónToolStripMenuItem
            // 
            cargarSimulaciónToolStripMenuItem.BackColor = Color.White;
            cargarSimulaciónToolStripMenuItem.Name = "cargarSimulaciónToolStripMenuItem";
            cargarSimulaciónToolStripMenuItem.Size = new Size(935, 48);
            cargarSimulaciónToolStripMenuItem.Text = "Cargar Simulación";
            cargarSimulaciónToolStripMenuItem.Click += cargarSimulaciónToolStripMenuItem_Click;
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(935, 48);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSlateGray;
            flowLayoutPanel1.Controls.Add(Titulo);
            flowLayoutPanel1.Location = new Point(211, 62);
            flowLayoutPanel1.Margin = new Padding(5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(2972, 155);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // Titulo
            // 
            Titulo.Anchor = AnchorStyles.None;
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo.ForeColor = SystemColors.Control;
            Titulo.Location = new Point(5, 0);
            Titulo.Margin = new Padding(5, 0, 5, 0);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(748, 77);
            Titulo.TabIndex = 0;
            Titulo.Text = "Simulador de Aviación";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(231, 160);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(710, 39);
            label1.TabIndex = 1;
            label1.Text = "Grupo 8: Ana López, Ifesinachi Egbera, Laia Alba";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(247, 298);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(252, 45);
            label3.TabIndex = 3;
            label3.Text = "¡Bienvenido!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(302, 342);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(615, 39);
            label4.TabIndex = 4;
            label4.Text = "Este es nuestro proyecto de informática II";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(1424, 1587);
            btnCerrar.Margin = new Padding(5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(367, 46);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(2884, 1579);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
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
        private Button btnCerrar;
        private ToolStripMenuItem cargarSimulaciónToolStripMenuItem;
        private ToolStripMenuItem opcionesToolStripMenuItem;
    }
}
