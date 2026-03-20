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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Automático = new Button();
            TimerSimulación = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            label5 = new Label();
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
            PanelSimulacion.Location = new Point(199, 12);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(600, 400);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(199, 415);
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
            label2.Location = new Point(805, 12);
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
            label3.Location = new Point(805, 392);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 4;
            label3.Text = "400";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(766, 415);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 0;
            label4.Text = "600";
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
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(Automático);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(181, 419);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Panel de Simulación";
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
            ClientSize = new Size(850, 443);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PanelSimulacion);
            Name = "Simulación";
            Text = "Simulación";
            Load += Simulación_Load;
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
    }
}