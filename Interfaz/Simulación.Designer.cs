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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btn_AutoCiclo = new Button();
            TimerSimulación = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            label12 = new Label();
            groupBox2 = new GroupBox();
            label11 = new Label();
            btn_CargarSimulacion = new Button();
            label10 = new Label();
            btn_GuardarSimulacion = new Button();
            label9 = new Label();
            btn_Deshacer = new Button();
            label8 = new Label();
            button3 = new Button();
            cerrarBtn = new Button();
            btn_PredecirConflictos = new Button();
            label7 = new Label();
            btn_DatosAviones = new Button();
            label6 = new Label();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            btn_Ralentizar = new Button();
            btn_Acelerar = new Button();
            button4 = new Button();
            label_VelVisual = new Label();
            PanelSimulacion.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_UnCiclo
            // 
            btn_UnCiclo.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_UnCiclo.ForeColor = SystemColors.ActiveCaptionText;
            btn_UnCiclo.Location = new Point(42, 54);
            btn_UnCiclo.Name = "btn_UnCiclo";
            btn_UnCiclo.Size = new Size(211, 46);
            btn_UnCiclo.TabIndex = 1;
            btn_UnCiclo.Text = "Avanzar un Ciclo";
            btn_UnCiclo.UseVisualStyleBackColor = true;
            btn_UnCiclo.Click += btn_UnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Controls.Add(label2);
            PanelSimulacion.Controls.Add(label1);
            PanelSimulacion.Location = new Point(701, 19);
            PanelSimulacion.Margin = new Padding(5);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(1299, 959);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(1269, -2);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(28, 29);
            label2.TabIndex = 3;
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(-2, 930);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(28, 29);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(1633, 936);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 29);
            label3.TabIndex = 4;
            label3.Text = "600";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(1555, 984);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 29);
            label4.TabIndex = 0;
            label4.Text = "800";
            // 
            // btn_AutoCiclo
            // 
            btn_AutoCiclo.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AutoCiclo.ForeColor = SystemColors.ActiveCaptionText;
            btn_AutoCiclo.Location = new Point(42, 163);
            btn_AutoCiclo.Margin = new Padding(5);
            btn_AutoCiclo.Name = "btn_AutoCiclo";
            btn_AutoCiclo.Size = new Size(211, 46);
            btn_AutoCiclo.TabIndex = 6;
            btn_AutoCiclo.Text = "Iniciar";
            btn_AutoCiclo.UseVisualStyleBackColor = true;
            btn_AutoCiclo.Click += btnAutoCiclo_Click;
            // 
            // TimerSimulación
            // 
            TimerSimulación.Tick += TimerSimulación_Tick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkSlateGray;
            groupBox1.Controls.Add(label_VelVisual);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(btn_Acelerar);
            groupBox1.Controls.Add(btn_Ralentizar);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btn_Deshacer);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(cerrarBtn);
            groupBox1.Controls.Add(btn_PredecirConflictos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btn_DatosAviones);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btn_UnCiclo);
            groupBox1.Controls.Add(btn_AutoCiclo);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(20, 19);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(670, 960);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Panel de Simulación";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(301, 130);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(222, 29);
            label12.TabIndex = 19;
            label12.Text = "Ralentizar/Acelerar:";
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
            groupBox2.Location = new Point(10, 612);
            groupBox2.Margin = new Padding(5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5);
            groupBox2.Size = new Size(272, 253);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Desde ficheros";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 132);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(209, 29);
            label11.TabIndex = 21;
            label11.Text = "Cargar simulación:";
            // 
            // btn_CargarSimulacion
            // 
            btn_CargarSimulacion.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_CargarSimulacion.ForeColor = SystemColors.ActiveCaptionText;
            btn_CargarSimulacion.Location = new Point(44, 166);
            btn_CargarSimulacion.Margin = new Padding(5);
            btn_CargarSimulacion.Name = "btn_CargarSimulacion";
            btn_CargarSimulacion.Size = new Size(211, 46);
            btn_CargarSimulacion.TabIndex = 20;
            btn_CargarSimulacion.Text = "Cargar";
            btn_CargarSimulacion.UseVisualStyleBackColor = true;
            btn_CargarSimulacion.Click += btn_CargarSimulacion_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 34);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(224, 29);
            label10.TabIndex = 19;
            label10.Text = "Guardar simulación:";
            // 
            // btn_GuardarSimulacion
            // 
            btn_GuardarSimulacion.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_GuardarSimulacion.ForeColor = SystemColors.ActiveCaptionText;
            btn_GuardarSimulacion.Location = new Point(44, 68);
            btn_GuardarSimulacion.Margin = new Padding(5);
            btn_GuardarSimulacion.Name = "btn_GuardarSimulacion";
            btn_GuardarSimulacion.Size = new Size(211, 46);
            btn_GuardarSimulacion.TabIndex = 18;
            btn_GuardarSimulacion.Text = "Guardar";
            btn_GuardarSimulacion.UseVisualStyleBackColor = true;
            btn_GuardarSimulacion.Click += btn_GuardarSimulacion_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(10, 517);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(250, 29);
            label9.TabIndex = 16;
            label9.Text = "Deshacer último paso:";
            // 
            // btn_Deshacer
            // 
            btn_Deshacer.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Deshacer.ForeColor = SystemColors.ActiveCaptionText;
            btn_Deshacer.Location = new Point(42, 551);
            btn_Deshacer.Margin = new Padding(5);
            btn_Deshacer.Name = "btn_Deshacer";
            btn_Deshacer.Size = new Size(211, 46);
            btn_Deshacer.TabIndex = 15;
            btn_Deshacer.Text = "Deshacer";
            btn_Deshacer.UseVisualStyleBackColor = true;
            btn_Deshacer.Click += btn_Deshacer_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 419);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(253, 29);
            label8.TabIndex = 14;
            label8.Text = "Reiniciar la simulación:";
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(42, 453);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(211, 46);
            button3.TabIndex = 13;
            button3.Text = "Reiniciar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnReinicio_Click;
            // 
            // cerrarBtn
            // 
            cerrarBtn.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarBtn.ForeColor = SystemColors.ActiveCaptionText;
            cerrarBtn.Location = new Point(65, 885);
            cerrarBtn.Margin = new Padding(5);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(153, 46);
            cerrarBtn.TabIndex = 12;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // btn_PredecirConflictos
            // 
            btn_PredecirConflictos.Font = new Font("Tahoma", 9F);
            btn_PredecirConflictos.ForeColor = SystemColors.ActiveCaptionText;
            btn_PredecirConflictos.Location = new Point(42, 355);
            btn_PredecirConflictos.Name = "btn_PredecirConflictos";
            btn_PredecirConflictos.Size = new Size(211, 46);
            btn_PredecirConflictos.TabIndex = 11;
            btn_PredecirConflictos.Text = "Predecir";
            btn_PredecirConflictos.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(10, 323);
            label7.Name = "label7";
            label7.Size = new Size(213, 29);
            label7.TabIndex = 10;
            label7.Text = "Predecir conflictos:";
            // 
            // btn_DatosAviones
            // 
            btn_DatosAviones.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_DatosAviones.ForeColor = SystemColors.ActiveCaptionText;
            btn_DatosAviones.Location = new Point(42, 259);
            btn_DatosAviones.Name = "btn_DatosAviones";
            btn_DatosAviones.Size = new Size(211, 46);
            btn_DatosAviones.TabIndex = 9;
            btn_DatosAviones.Text = "Mostrar";
            btn_DatosAviones.UseVisualStyleBackColor = true;
            btn_DatosAviones.Click += btn_DatosAviones_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 227);
            label6.Name = "label6";
            label6.Size = new Size(272, 29);
            label6.TabIndex = 8;
            label6.Text = "Mostrar todos los datos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 130);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(222, 29);
            label5.TabIndex = 7;
            label5.Text = "Avance automático:";
            // 
            // btn_Ralentizar
            // 
            btn_Ralentizar.BackgroundImage = Properties.Resources.ralentizar;
            btn_Ralentizar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Ralentizar.Location = new Point(340, 163);
            btn_Ralentizar.Name = "btn_Ralentizar";
            btn_Ralentizar.Size = new Size(46, 46);
            btn_Ralentizar.TabIndex = 20;
            btn_Ralentizar.UseVisualStyleBackColor = true;
            // 
            // btn_Acelerar
            // 
            btn_Acelerar.BackgroundImage = Properties.Resources.acelerar;
            btn_Acelerar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Acelerar.Location = new Point(444, 163);
            btn_Acelerar.Name = "btn_Acelerar";
            btn_Acelerar.Size = new Size(46, 46);
            btn_Acelerar.TabIndex = 21;
            btn_Acelerar.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.pausa;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.Location = new Point(392, 163);
            button4.Name = "button4";
            button4.Size = new Size(46, 46);
            button4.TabIndex = 22;
            button4.UseVisualStyleBackColor = true;
            // 
            // label_VelVisual
            // 
            label_VelVisual.AutoSize = true;
            label_VelVisual.Location = new Point(507, 172);
            label_VelVisual.Name = "label_VelVisual";
            label_VelVisual.Size = new Size(100, 29);
            label_VelVisual.TabIndex = 23;
            label_VelVisual.Text = "label13";
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(2344, 1186);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PanelSimulacion);
            Margin = new Padding(5);
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
        private Button btn_AutoCiclo;
        private System.Windows.Forms.Timer TimerSimulación;
        private GroupBox groupBox1;
        private Label label5;
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
        private Label label12;
        private ToolTip toolTip1;
        private Button btn_Ralentizar;
        private Button button4;
        private Button btn_Acelerar;
        private Label label_VelVisual;
    }
}