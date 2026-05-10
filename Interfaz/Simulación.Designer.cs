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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            TimerSimulación = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label11 = new Label();
            btn_CargarSimulacion = new Button();
            label10 = new Label();
            btn_GuardarSimulacion = new Button();
            label9 = new Label();
            btn_Deshacer = new Button();
            label8 = new Label();
            button3 = new Button();
            btn_PredecirConflictos = new Button();
            label7 = new Label();
            btn_DatosAviones = new Button();
            label6 = new Label();
            cerrarBtn = new Button();
            btnPause = new Button();
            btn_Acelerar = new Button();
            btn_Ralentizar = new Button();
            toolTip1 = new ToolTip(components);
            PanelSimulacion.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_UnCiclo
            // 
            btn_UnCiclo.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_UnCiclo.ForeColor = SystemColors.ActiveCaptionText;
            btn_UnCiclo.Location = new Point(26, 34);
            btn_UnCiclo.Margin = new Padding(2);
            btn_UnCiclo.Name = "btn_UnCiclo";
            btn_UnCiclo.Size = new Size(130, 29);
            btn_UnCiclo.TabIndex = 1;
            btn_UnCiclo.Text = "Avanzar un Ciclo";
            btn_UnCiclo.UseVisualStyleBackColor = true;
            btn_UnCiclo.Click += btn_UnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Controls.Add(labelAlarma);
            PanelSimulacion.Location = new Point(431, 12);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(1400, 900);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            // 
            // labelAlarma
            // 
            labelAlarma.AutoSize = true;
            labelAlarma.Location = new Point(389, 33);
            labelAlarma.Name = "labelAlarma";
            labelAlarma.Size = new Size(58, 20);
            labelAlarma.TabIndex = 0;
            labelAlarma.Text = "label13";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(1837, 9);
            label2.Name = "label2";
            label2.Size = new Size(18, 18);
            label2.TabIndex = 3;
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(431, 915);
            label1.Name = "label1";
            label1.Size = new Size(18, 18);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(1837, 894);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 4;
            label3.Text = "900";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(1783, 915);
            label4.Name = "label4";
            label4.Size = new Size(48, 18);
            label4.TabIndex = 0;
            label4.Text = "1400";
            // 
            // TimerSimulación
            // 
            TimerSimulación.Tick += TimerSimulación_Tick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkSlateGray;
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btn_Deshacer);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(btn_PredecirConflictos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btn_DatosAviones);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btn_UnCiclo);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 1009);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Panel de Simulación";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.DarkSlateGray;
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btn_CargarSimulacion);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(btn_GuardarSimulacion);
            groupBox2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = SystemColors.Control;
            groupBox2.Location = new Point(199, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(192, 167);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Desde ficheros";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(7, 82);
            label11.Name = "label11";
            label11.Size = new Size(126, 18);
            label11.TabIndex = 21;
            label11.Text = "Cargar simulación:";
            // 
            // btn_CargarSimulacion
            // 
            btn_CargarSimulacion.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_CargarSimulacion.ForeColor = SystemColors.ActiveCaptionText;
            btn_CargarSimulacion.Location = new Point(27, 110);
            btn_CargarSimulacion.Name = "btn_CargarSimulacion";
            btn_CargarSimulacion.Size = new Size(130, 29);
            btn_CargarSimulacion.TabIndex = 20;
            btn_CargarSimulacion.Text = "Cargar";
            btn_CargarSimulacion.UseVisualStyleBackColor = true;
            btn_CargarSimulacion.Click += btn_CargarSimulacion_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(7, 21);
            label10.Name = "label10";
            label10.Size = new Size(135, 18);
            label10.TabIndex = 19;
            label10.Text = "Guardar simulación:";
            // 
            // btn_GuardarSimulacion
            // 
            btn_GuardarSimulacion.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_GuardarSimulacion.ForeColor = SystemColors.ActiveCaptionText;
            btn_GuardarSimulacion.Location = new Point(27, 47);
            btn_GuardarSimulacion.Name = "btn_GuardarSimulacion";
            btn_GuardarSimulacion.Size = new Size(130, 29);
            btn_GuardarSimulacion.TabIndex = 18;
            btn_GuardarSimulacion.Text = "Guardar";
            btn_GuardarSimulacion.UseVisualStyleBackColor = true;
            btn_GuardarSimulacion.Click += btn_GuardarSimulacion_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 278);
            label9.Name = "label9";
            label9.Size = new Size(153, 18);
            label9.TabIndex = 16;
            label9.Text = "Deshacer último paso:";
            // 
            // btn_Deshacer
            // 
            btn_Deshacer.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Deshacer.ForeColor = SystemColors.ActiveCaptionText;
            btn_Deshacer.Location = new Point(26, 309);
            btn_Deshacer.Name = "btn_Deshacer";
            btn_Deshacer.Size = new Size(130, 29);
            btn_Deshacer.TabIndex = 15;
            btn_Deshacer.Text = "Deshacer";
            btn_Deshacer.UseVisualStyleBackColor = true;
            btn_Deshacer.Click += btn_Deshacer_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 206);
            label8.Name = "label8";
            label8.Size = new Size(149, 18);
            label8.TabIndex = 14;
            label8.Text = "Reiniciar la simulación:";
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(26, 236);
            button3.Name = "button3";
            button3.Size = new Size(130, 29);
            button3.TabIndex = 13;
            button3.Text = "Reiniciar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnReinicio_Click;
            // 
            // btn_PredecirConflictos
            // 
            btn_PredecirConflictos.Font = new Font("Tahoma", 9F);
            btn_PredecirConflictos.ForeColor = SystemColors.ActiveCaptionText;
            btn_PredecirConflictos.Location = new Point(25, 163);
            btn_PredecirConflictos.Margin = new Padding(2);
            btn_PredecirConflictos.Name = "btn_PredecirConflictos";
            btn_PredecirConflictos.Size = new Size(130, 29);
            btn_PredecirConflictos.TabIndex = 11;
            btn_PredecirConflictos.Text = "Predecir";
            btn_PredecirConflictos.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 140);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(128, 18);
            label7.TabIndex = 10;
            label7.Text = "Predecir conflictos:";
            // 
            // btn_DatosAviones
            // 
            btn_DatosAviones.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_DatosAviones.ForeColor = SystemColors.ActiveCaptionText;
            btn_DatosAviones.Location = new Point(25, 102);
            btn_DatosAviones.Margin = new Padding(2);
            btn_DatosAviones.Name = "btn_DatosAviones";
            btn_DatosAviones.Size = new Size(130, 29);
            btn_DatosAviones.TabIndex = 9;
            btn_DatosAviones.Text = "Mostrar";
            btn_DatosAviones.UseVisualStyleBackColor = true;
            btn_DatosAviones.Click += btn_DatosAviones_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 72);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(167, 18);
            label6.TabIndex = 8;
            label6.Text = "Mostrar todos los datos:";
            // 
            // cerrarBtn
            // 
            cerrarBtn.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarBtn.ForeColor = SystemColors.ActiveCaptionText;
            cerrarBtn.Location = new Point(1741, 989);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(134, 32);
            cerrarBtn.TabIndex = 12;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // btnPause
            // 
            btnPause.BackgroundImage = Properties.Resources.pausa;
            btnPause.BackgroundImageLayout = ImageLayout.Zoom;
            btnPause.Location = new Point(1089, 930);
            btnPause.Margin = new Padding(2);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(54, 53);
            btnPause.TabIndex = 22;
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btn_Acelerar
            // 
            btn_Acelerar.BackgroundImage = Properties.Resources.acelerar;
            btn_Acelerar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Acelerar.Location = new Point(1147, 930);
            btn_Acelerar.Margin = new Padding(2);
            btn_Acelerar.Name = "btn_Acelerar";
            btn_Acelerar.Size = new Size(54, 53);
            btn_Acelerar.TabIndex = 21;
            btn_Acelerar.UseVisualStyleBackColor = true;
            // 
            // btn_Ralentizar
            // 
            btn_Ralentizar.BackgroundImage = Properties.Resources.ralentizar;
            btn_Ralentizar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Ralentizar.Location = new Point(1031, 930);
            btn_Ralentizar.Margin = new Padding(2);
            btn_Ralentizar.Name = "btn_Ralentizar";
            btn_Ralentizar.Size = new Size(54, 53);
            btn_Ralentizar.TabIndex = 20;
            btn_Ralentizar.UseVisualStyleBackColor = true;
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label2);
            Controls.Add(btn_Ralentizar);
            Controls.Add(btn_Acelerar);
            Controls.Add(btnPause);
            Controls.Add(groupBox1);
            Controls.Add(cerrarBtn);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_UnCiclo;
        private Panel PanelSimulacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer TimerSimulación;
        private GroupBox groupBox1;
        private Label label6;
        private Button btn_DatosAviones;
        private Button btn_PredecirConflictos;
        private Label label7;
        private Button cerrarBtn;
        private Button button3;
        private Label label8;
        private Label label9;
        private Button btn_Deshacer;
        private GroupBox groupBox2;
        private Label label11;
        private Button btn_CargarSimulacion;
        private Label label10;
        private Button btn_GuardarSimulacion;
        private ToolTip toolTip1;
        private Button btn_Ralentizar;
        private Button btnPause;
        private Button btn_Acelerar;
        private Label labelAlarma;
    }
}