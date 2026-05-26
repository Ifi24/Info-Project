namespace Interfaz
{
    partial class Simulación
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_UnCiclo = new Button();
            PanelSimulacion = new Panel();
            labelAlarma = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            TimerSimulación = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            btn_CargarSimulacion = new Button();
            btn_GuardarSimulacion = new Button();
            btn_Deshacer = new Button();
            button3 = new Button();
            btn_PredecirConflictos = new Button();
            btn_DatosAviones = new Button();
            cerrarBtn = new Button();
            btnPause = new Button();
            btn_Acelerar = new Button();
            btn_Ralentizar = new Button();
            toolTip1 = new ToolTip(components);
            lblVelocidad = new Label();
            lblCords = new Label();
            button4 = new Button();
            btn_guardarsimcuenta = new Button();
            PanelSimulacion.SuspendLayout();
            SuspendLayout();
            // 
            // btn_UnCiclo
            // 
            btn_UnCiclo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_UnCiclo.ForeColor = Color.FromArgb(64, 64, 64);
            btn_UnCiclo.Location = new Point(51, 123);
            btn_UnCiclo.Margin = new Padding(2);
            btn_UnCiclo.Name = "btn_UnCiclo";
            btn_UnCiclo.Size = new Size(288, 31);
            btn_UnCiclo.TabIndex = 1;
            btn_UnCiclo.Text = "Avanzar un Ciclo";
            btn_UnCiclo.UseVisualStyleBackColor = true;
            btn_UnCiclo.Click += btn_UnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BackgroundImage = Properties.Resources.SIMULATION_GRIDMAP;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Controls.Add(labelAlarma);
            PanelSimulacion.Location = new Point(388, 36);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(1400, 900);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            PanelSimulacion.MouseMove += PanelSimulacion_MouseMove;
            // 
            // labelAlarma
            // 
            labelAlarma.AutoSize = true;
            labelAlarma.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAlarma.ForeColor = Color.Red;
            labelAlarma.Location = new Point(431, 8);
            labelAlarma.Name = "labelAlarma";
            labelAlarma.Size = new Size(0, 46);
            labelAlarma.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(440, 952);
            label1.Name = "label1";
            label1.Size = new Size(0, 18);
            label1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(1837, 925);
            label3.Name = "label3";
            label3.Size = new Size(0, 18);
            label3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(1782, 952);
            label4.Name = "label4";
            label4.Size = new Size(0, 18);
            label4.TabIndex = 0;
            // 
            // TimerSimulación
            // 
            TimerSimulación.Tick += TimerSimulación_Tick;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(64, 64, 64);
            button1.Location = new Point(51, 344);
            button1.Name = "button1";
            button1.Size = new Size(288, 36);
            button1.TabIndex = 18;
            button1.Text = "Cambiar tiempo y distancia";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_CargarSimulacion
            // 
            btn_CargarSimulacion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_CargarSimulacion.ForeColor = Color.FromArgb(64, 64, 64);
            btn_CargarSimulacion.Location = new Point(51, 549);
            btn_CargarSimulacion.Name = "btn_CargarSimulacion";
            btn_CargarSimulacion.Size = new Size(288, 34);
            btn_CargarSimulacion.TabIndex = 20;
            btn_CargarSimulacion.Text = "Cargar Simulación (fichero)\r\n";
            btn_CargarSimulacion.UseVisualStyleBackColor = true;
            btn_CargarSimulacion.Click += btn_CargarSimulacion_Click;
            // 
            // btn_GuardarSimulacion
            // 
            btn_GuardarSimulacion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_GuardarSimulacion.ForeColor = Color.FromArgb(64, 64, 64);
            btn_GuardarSimulacion.Location = new Point(51, 502);
            btn_GuardarSimulacion.Name = "btn_GuardarSimulacion";
            btn_GuardarSimulacion.Size = new Size(288, 31);
            btn_GuardarSimulacion.TabIndex = 18;
            btn_GuardarSimulacion.Text = "Guardar Simulación (fichero)\r\n";
            btn_GuardarSimulacion.UseVisualStyleBackColor = true;
            btn_GuardarSimulacion.Click += btn_GuardarSimulacion_Click;
            // 
            // btn_Deshacer
            // 
            btn_Deshacer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Deshacer.ForeColor = Color.FromArgb(64, 64, 64);
            btn_Deshacer.Location = new Point(51, 171);
            btn_Deshacer.Name = "btn_Deshacer";
            btn_Deshacer.Size = new Size(288, 31);
            btn_Deshacer.TabIndex = 15;
            btn_Deshacer.Text = "Deshacer ciclo";
            btn_Deshacer.UseVisualStyleBackColor = true;
            btn_Deshacer.Click += btn_Deshacer_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(64, 64, 64);
            button3.Location = new Point(51, 430);
            button3.Name = "button3";
            button3.Size = new Size(288, 31);
            button3.TabIndex = 13;
            button3.Text = "Reiniciar Simulación";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnReinicio_Click;
            // 
            // btn_PredecirConflictos
            // 
            btn_PredecirConflictos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_PredecirConflictos.ForeColor = Color.FromArgb(64, 64, 64);
            btn_PredecirConflictos.Location = new Point(51, 246);
            btn_PredecirConflictos.Margin = new Padding(2);
            btn_PredecirConflictos.Name = "btn_PredecirConflictos";
            btn_PredecirConflictos.Size = new Size(288, 31);
            btn_PredecirConflictos.TabIndex = 11;
            btn_PredecirConflictos.Text = "Predecir Conflictos";
            btn_PredecirConflictos.UseVisualStyleBackColor = true;
            btn_PredecirConflictos.Click += btn_PredecirConflictos_Click;
            // 
            // btn_DatosAviones
            // 
            btn_DatosAviones.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_DatosAviones.ForeColor = Color.FromArgb(64, 64, 64);
            btn_DatosAviones.Location = new Point(51, 296);
            btn_DatosAviones.Margin = new Padding(2);
            btn_DatosAviones.Name = "btn_DatosAviones";
            btn_DatosAviones.Size = new Size(288, 30);
            btn_DatosAviones.TabIndex = 9;
            btn_DatosAviones.Text = "Mostrar todos los datos";
            btn_DatosAviones.UseVisualStyleBackColor = true;
            btn_DatosAviones.Click += btn_DatosAviones_Click;
            // 
            // cerrarBtn
            // 
            cerrarBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarBtn.ForeColor = Color.FromArgb(64, 64, 64);
            cerrarBtn.Location = new Point(51, 878);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(288, 32);
            cerrarBtn.TabIndex = 12;
            cerrarBtn.Text = "Cerrar Simulación";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.Transparent;
            btnPause.BackgroundImage = Properties.Resources.play;
            btnPause.BackgroundImageLayout = ImageLayout.Stretch;
            btnPause.FlatStyle = FlatStyle.Popup;
            btnPause.Location = new Point(1103, 981);
            btnPause.Margin = new Padding(2);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(54, 53);
            btnPause.TabIndex = 22;
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btn_Acelerar
            // 
            btn_Acelerar.BackColor = Color.Transparent;
            btn_Acelerar.BackgroundImage = Properties.Resources.acelerar;
            btn_Acelerar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Acelerar.FlatStyle = FlatStyle.Popup;
            btn_Acelerar.Location = new Point(1199, 981);
            btn_Acelerar.Margin = new Padding(2);
            btn_Acelerar.Name = "btn_Acelerar";
            btn_Acelerar.Size = new Size(67, 53);
            btn_Acelerar.TabIndex = 21;
            btn_Acelerar.UseVisualStyleBackColor = false;
            btn_Acelerar.Click += btn_Acelerar_Click;
            // 
            // btn_Ralentizar
            // 
            btn_Ralentizar.BackColor = Color.Transparent;
            btn_Ralentizar.BackgroundImage = Properties.Resources.ralentizar;
            btn_Ralentizar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Ralentizar.FlatStyle = FlatStyle.Popup;
            btn_Ralentizar.Location = new Point(989, 981);
            btn_Ralentizar.Margin = new Padding(2);
            btn_Ralentizar.Name = "btn_Ralentizar";
            btn_Ralentizar.Size = new Size(70, 53);
            btn_Ralentizar.TabIndex = 20;
            btn_Ralentizar.UseVisualStyleBackColor = false;
            btn_Ralentizar.Click += btn_Ralentizar_Click;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.BackColor = Color.Transparent;
            lblVelocidad.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVelocidad.ForeColor = Color.White;
            lblVelocidad.Location = new Point(1633, 993);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(55, 39);
            lblVelocidad.TabIndex = 23;
            lblVelocidad.Text = "x1";
            // 
            // lblCords
            // 
            lblCords.AutoSize = true;
            lblCords.BackColor = Color.Transparent;
            lblCords.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCords.ForeColor = SystemColors.ControlLightLight;
            lblCords.Location = new Point(453, 993);
            lblCords.Name = "lblCords";
            lblCords.Size = new Size(154, 36);
            lblCords.TabIndex = 26;
            lblCords.Text = "X:  0  Y:  0";
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(64, 64, 64);
            button4.Location = new Point(51, 694);
            button4.Name = "button4";
            button4.Size = new Size(288, 31);
            button4.TabIndex = 28;
            button4.Text = "Cambios de velocidad";
            button4.UseVisualStyleBackColor = true;
            // 
            // btn_guardarsimcuenta
            // 
            btn_guardarsimcuenta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_guardarsimcuenta.ForeColor = Color.FromArgb(64, 64, 64);
            btn_guardarsimcuenta.Location = new Point(51, 621);
            btn_guardarsimcuenta.Name = "btn_guardarsimcuenta";
            btn_guardarsimcuenta.Size = new Size(288, 31);
            btn_guardarsimcuenta.TabIndex = 29;
            btn_guardarsimcuenta.Text = "Guardar Simulación (cuenta)";
            btn_guardarsimcuenta.UseVisualStyleBackColor = true;
            btn_guardarsimcuenta.Click += btn_cambiarsimcuenta;
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.SIMULATION;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1599, 890);
            Controls.Add(btn_guardarsimcuenta);
            Controls.Add(button4);
            Controls.Add(lblCords);
            Controls.Add(lblVelocidad);
            Controls.Add(btn_Acelerar);
            Controls.Add(btnPause);
            Controls.Add(btn_Ralentizar);
            Controls.Add(btn_CargarSimulacion);
            Controls.Add(cerrarBtn);
            Controls.Add(btn_GuardarSimulacion);
            Controls.Add(btn_UnCiclo);
            Controls.Add(btn_Deshacer);
            Controls.Add(button1);
            Controls.Add(btn_DatosAviones);
            Controls.Add(button3);
            Controls.Add(btn_PredecirConflictos);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PanelSimulacion);
            Name = "Simulación";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simulación";
            WindowState = FormWindowState.Maximized;
            Load += Simulación_Load;
            PanelSimulacion.ResumeLayout(false);
            PanelSimulacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_UnCiclo;
        private Panel PanelSimulacion;
        private Label label1;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer TimerSimulación;
        private Button btn_DatosAviones;
        private Button btn_PredecirConflictos;
        private Button cerrarBtn;
        private Button button3;
        private Button btn_Deshacer;
        private Button btn_CargarSimulacion;
        private Button btn_GuardarSimulacion;
        private ToolTip toolTip1;
        private Button btn_Ralentizar;
        private Button btnPause;
        private Button btn_Acelerar;
        private Label labelAlarma;
        private Button button1;
        private Label lblVelocidad;
        private Label lblCords;
        private Button button4;
        private Button btn_guardarsimcuenta;
    }
}