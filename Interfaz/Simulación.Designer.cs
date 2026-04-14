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
            button1 = new Button();
            PanelSimulacion = new Panel();
            labelAlarma = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Automático = new Button();
            TimerSimulación = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            label8 = new Label();
            button3 = new Button();
            cerrarBtn = new Button();
            boton_PredecirConflictos = new Button();
            label7 = new Label();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            PanelSimulacion.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(26, 34);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 1;
            button1.Text = "Avanzar Ciclo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BotonUnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Controls.Add(labelAlarma);
            PanelSimulacion.Controls.Add(label2);
            PanelSimulacion.Controls.Add(label1);
            PanelSimulacion.Location = new Point(199, 12);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(800, 600);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            // 
            // labelAlarma
            // 
            labelAlarma.AutoSize = true;
            labelAlarma.BackColor = Color.Transparent;
            labelAlarma.Enabled = false;
            labelAlarma.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAlarma.ForeColor = Color.LightCoral;
            labelAlarma.Location = new Point(186, 9);
            labelAlarma.Margin = new Padding(2, 0, 2, 0);
            labelAlarma.Name = "labelAlarma";
            labelAlarma.Size = new Size(0, 28);
            labelAlarma.TabIndex = 0;
            labelAlarma.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(-1, 581);
            label1.Name = "label1";
            label1.Size = new Size(18, 18);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(781, -1);
            label2.Name = "label2";
            label2.Size = new Size(18, 18);
            label2.TabIndex = 3;
            label2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(1005, 583);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 4;
            label3.Text = "600";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(957, 615);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 0;
            label4.Text = "800";
            // 
            // Automático
            // 
            Automático.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Automático.ForeColor = SystemColors.ActiveCaptionText;
            Automático.Location = new Point(26, 102);
            Automático.Name = "Automático";
            Automático.Size = new Size(130, 29);
            Automático.TabIndex = 6;
            Automático.Text = "Iniciar";
            Automático.UseVisualStyleBackColor = true;
            Automático.Click += Automático_Click;
            // 
            // TimerSimulación
            // 
            TimerSimulación.Tick += TimerSimulación_Tick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkSlateGray;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(cerrarBtn);
            groupBox1.Controls.Add(boton_PredecirConflictos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(Automático);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(181, 600);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Panel de Simulación";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(6, 262);
            label8.Name = "label8";
            label8.Size = new Size(149, 18);
            label8.TabIndex = 14;
            label8.Text = "Reiniciar la simulación:";
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(40, 283);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 13;
            button3.Text = "Reiniciar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnReinicio_Click;
            // 
            // cerrarBtn
            // 
            cerrarBtn.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarBtn.ForeColor = SystemColors.ActiveCaptionText;
            cerrarBtn.Location = new Point(40, 371);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(94, 29);
            cerrarBtn.TabIndex = 12;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // boton_PredecirConflictos
            // 
            boton_PredecirConflictos.Font = new Font("Tahoma", 9F);
            boton_PredecirConflictos.ForeColor = SystemColors.ActiveCaptionText;
            boton_PredecirConflictos.Location = new Point(26, 222);
            boton_PredecirConflictos.Margin = new Padding(2);
            boton_PredecirConflictos.Name = "boton_PredecirConflictos";
            boton_PredecirConflictos.Size = new Size(130, 29);
            boton_PredecirConflictos.TabIndex = 11;
            boton_PredecirConflictos.Text = "Predecir";
            boton_PredecirConflictos.UseVisualStyleBackColor = true;
            boton_PredecirConflictos.Click += boton_PredecirConflictos_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 202);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(128, 18);
            label7.TabIndex = 10;
            label7.Text = "Predecir conflictos:";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Historic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(26, 162);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(130, 29);
            button2.TabIndex = 9;
            button2.Text = "Mostrar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += boton_MostarDatos;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 142);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(167, 18);
            label6.TabIndex = 8;
            label6.Text = "Mostrar todos los datos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 81);
            label5.Name = "label5";
            label5.Size = new Size(138, 18);
            label5.TabIndex = 7;
            label5.Text = "Avance automático:";
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1045, 646);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PanelSimulacion);
            Name = "Simulación";
            Text = "Simulación";
            Load += Simulación_Load;
            PanelSimulacion.ResumeLayout(false);
            PanelSimulacion.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Panel PanelSimulacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Automático;
        private System.Windows.Forms.Timer TimerSimulación;
        private GroupBox groupBox1;
        private Label label5;
        private Label label6;
        private Button button2;
        private Label labelAlarma;
        private Button boton_PredecirConflictos;
        private Label label7;
        private Button cerrarBtn;
        private Button button3;
        private Label label8;
    }
}