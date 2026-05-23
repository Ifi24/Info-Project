namespace Interfaz
{
    partial class SeguridadyTiempo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguridadyTiempo));
            Distancia = new Label();
            Tiempo = new Label();
            TextBoxTCiclo = new TextBox();
            TextBoxDistSeg = new TextBox();
            Aceptar = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Distancia
            // 
            Distancia.AutoSize = true;
            Distancia.BackColor = Color.Transparent;
            Distancia.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Distancia.ForeColor = SystemColors.Control;
            Distancia.Location = new Point(50, 106);
            Distancia.Name = "Distancia";
            Distancia.Size = new Size(203, 24);
            Distancia.TabIndex = 0;
            Distancia.Text = "Distancia de Seguridad";
            // 
            // Tiempo
            // 
            Tiempo.AutoSize = true;
            Tiempo.BackColor = Color.Transparent;
            Tiempo.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tiempo.ForeColor = SystemColors.Control;
            Tiempo.Location = new Point(50, 151);
            Tiempo.Name = "Tiempo";
            Tiempo.Size = new Size(145, 24);
            Tiempo.TabIndex = 1;
            Tiempo.Text = "Tiempo de Ciclo";
            // 
            // TextBoxTCiclo
            // 
            TextBoxTCiclo.Location = new Point(303, 151);
            TextBoxTCiclo.Name = "TextBoxTCiclo";
            TextBoxTCiclo.Size = new Size(125, 27);
            TextBoxTCiclo.TabIndex = 2;
            // 
            // TextBoxDistSeg
            // 
            TextBoxDistSeg.Location = new Point(303, 106);
            TextBoxDistSeg.Name = "TextBoxDistSeg";
            TextBoxDistSeg.Size = new Size(125, 27);
            TextBoxDistSeg.TabIndex = 3;
            // 
            // Aceptar
            // 
            Aceptar.Font = new Font("Myriad Pro", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Aceptar.Location = new Point(101, 198);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(94, 29);
            Aceptar.TabIndex = 4;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Myriad Pro", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(50, 35);
            label1.MaximumSize = new Size(430, 0);
            label1.Name = "label1";
            label1.Size = new Size(369, 20);
            label1.TabIndex = 5;
            label1.Text = "Inserte distancia de seguridad y tiempo de ciclo:";
            // 
            // button1
            // 
            button1.Font = new Font("Myriad Pro", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(263, 198);
            button1.Name = "button1";
            button1.Size = new Size(100, 29);
            button1.TabIndex = 6;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SeguridadyTiempo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(479, 265);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(Aceptar);
            Controls.Add(TextBoxDistSeg);
            Controls.Add(TextBoxTCiclo);
            Controls.Add(Tiempo);
            Controls.Add(Distancia);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SeguridadyTiempo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeguridadyTiempo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Distancia;
        private Label Tiempo;
        private TextBox TextBoxTCiclo;
        private TextBox TextBoxDistSeg;
        private Button Aceptar;
        private Label label1;
        private Button button1;
    }
}