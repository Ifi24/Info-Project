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
            gestionarCompañíasToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCerrar = new Button();
            dgv_SimulacionesGuardadas = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_SimulacionesGuardadas).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Opciones });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(368, 1055);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Opciones
            // 
            Opciones.BackColor = Color.Transparent;
            Opciones.DropDownItems.AddRange(new ToolStripItem[] { cargarListaDeVuelosToolStripMenuItem, introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem, verSimulaciónToolStripMenuItem, cargarSimulaciónToolStripMenuItem, gestionarCompañíasToolStripMenuItem });
            Opciones.Font = new Font("Myriad Pro", 40.1999969F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Opciones.ForeColor = SystemColors.Control;
            Opciones.Name = "Opciones";
            Opciones.Padding = new Padding(10, 10, 5, 0);
            Opciones.Size = new Size(355, 95);
            Opciones.Text = "OPCIONES";
            // 
            // cargarListaDeVuelosToolStripMenuItem
            // 
            cargarListaDeVuelosToolStripMenuItem.BackColor = Color.SteelBlue;
            cargarListaDeVuelosToolStripMenuItem.Font = new Font("Myriad Pro", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cargarListaDeVuelosToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            cargarListaDeVuelosToolStripMenuItem.Name = "cargarListaDeVuelosToolStripMenuItem";
            cargarListaDeVuelosToolStripMenuItem.Size = new Size(1211, 64);
            cargarListaDeVuelosToolStripMenuItem.Text = "Introducir Datos de Vuelo";
            cargarListaDeVuelosToolStripMenuItem.Click += cargarListaDeVuelosToolStripMenuItem_Click;
            // 
            // introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.BackColor = Color.SteelBlue;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Font = new Font("Myriad Pro", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(1211, 64);
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Introducir Distancia Seguridad y Tiempo de Ciclo";
            introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // verSimulaciónToolStripMenuItem
            // 
            verSimulaciónToolStripMenuItem.BackColor = Color.SteelBlue;
            verSimulaciónToolStripMenuItem.Font = new Font("Myriad Pro", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            verSimulaciónToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            verSimulaciónToolStripMenuItem.Name = "verSimulaciónToolStripMenuItem";
            verSimulaciónToolStripMenuItem.Size = new Size(1211, 64);
            verSimulaciónToolStripMenuItem.Text = "Ver Simulación";
            verSimulaciónToolStripMenuItem.Click += verSimulaciónToolStripMenuItem_Click;
            // 
            // cargarSimulaciónToolStripMenuItem
            // 
            cargarSimulaciónToolStripMenuItem.BackColor = Color.SteelBlue;
            cargarSimulaciónToolStripMenuItem.Font = new Font("Myriad Pro", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cargarSimulaciónToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            cargarSimulaciónToolStripMenuItem.Name = "cargarSimulaciónToolStripMenuItem";
            cargarSimulaciónToolStripMenuItem.Size = new Size(1211, 64);
            cargarSimulaciónToolStripMenuItem.Text = "Cargar Simulación";
            cargarSimulaciónToolStripMenuItem.Click += cargarSimulaciónToolStripMenuItem_Click;
            // 
            // gestionarCompañíasToolStripMenuItem
            // 
            gestionarCompañíasToolStripMenuItem.BackColor = Color.SteelBlue;
            gestionarCompañíasToolStripMenuItem.Font = new Font("Myriad Pro", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gestionarCompañíasToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            gestionarCompañíasToolStripMenuItem.Name = "gestionarCompañíasToolStripMenuItem";
            gestionarCompañíasToolStripMenuItem.Size = new Size(1211, 64);
            gestionarCompañíasToolStripMenuItem.Text = "Gestionar Compañías";
            gestionarCompañíasToolStripMenuItem.Click += gestionarCompañíasToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(142, 496);
            label1.Name = "label1";
            label1.Size = new Size(0, 24);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(152, 186);
            label3.Name = "label3";
            label3.Size = new Size(0, 28);
            label3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(186, 214);
            label4.Name = "label4";
            label4.Size = new Size(0, 24);
            label4.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.FromArgb(64, 64, 64);
            btnCerrar.Location = new Point(1421, 910);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(205, 36);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgv_SimulacionesGuardadas
            // 
            dgv_SimulacionesGuardadas.BackgroundColor = SystemColors.ScrollBar;
            dgv_SimulacionesGuardadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_SimulacionesGuardadas.GridColor = Color.Black;
            dgv_SimulacionesGuardadas.Location = new Point(1283, 271);
            dgv_SimulacionesGuardadas.Name = "dgv_SimulacionesGuardadas";
            dgv_SimulacionesGuardadas.RowHeadersWidth = 51;
            dgv_SimulacionesGuardadas.Size = new Size(489, 575);
            dgv_SimulacionesGuardadas.TabIndex = 6;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = Properties.Resources.PRINCIPAL;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1924, 1055);
            Controls.Add(dgv_SimulacionesGuardadas);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_SimulacionesGuardadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Opciones;
        private ToolStripMenuItem cargarListaDeVuelosToolStripMenuItem;
        private ToolStripMenuItem introducirDistanciaSeguridadYTiempoDeCicloToolStripMenuItem;
        private ToolStripMenuItem verSimulaciónToolStripMenuItem;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button btnCerrar;
        private ToolStripMenuItem cargarSimulaciónToolStripMenuItem;
        private ToolStripMenuItem gestionarCompañíasToolStripMenuItem;
        private DataGridView dgv_SimulacionesGuardadas;
    }
}
