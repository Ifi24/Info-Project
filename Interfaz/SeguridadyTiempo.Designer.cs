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
            Distancia = new Label();
            Tiempo = new Label();
            TextBoxTCiclo = new TextBox();
            TextBoxDistSeg = new TextBox();
            Aceptar = new Button();
            SuspendLayout();
            // 
            // Distancia
            // 
            Distancia.AutoSize = true;
            Distancia.Location = new Point(31, 60);
            Distancia.Name = "Distancia";
            Distancia.Size = new Size(163, 20);
            Distancia.TabIndex = 0;
            Distancia.Text = "Distancia de Seguridad";
            // 
            // Tiempo
            // 
            Tiempo.AutoSize = true;
            Tiempo.Location = new Point(31, 99);
            Tiempo.Name = "Tiempo";
            Tiempo.Size = new Size(118, 20);
            Tiempo.TabIndex = 1;
            Tiempo.Text = "Tiempo de Ciclo";
            // 
            // TextBoxTCiclo
            // 
            TextBoxTCiclo.Location = new Point(214, 96);
            TextBoxTCiclo.Name = "TextBoxTCiclo";
            TextBoxTCiclo.Size = new Size(125, 27);
            TextBoxTCiclo.TabIndex = 2;
            // 
            // TextBoxDistSeg
            // 
            TextBoxDistSeg.Location = new Point(214, 57);
            TextBoxDistSeg.Name = "TextBoxDistSeg";
            TextBoxDistSeg.Size = new Size(125, 27);
            TextBoxDistSeg.TabIndex = 3;
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(135, 149);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(94, 29);
            Aceptar.TabIndex = 4;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // SeguridadyTiempo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 231);
            Controls.Add(Aceptar);
            Controls.Add(TextBoxDistSeg);
            Controls.Add(TextBoxTCiclo);
            Controls.Add(Tiempo);
            Controls.Add(Distancia);
            Name = "SeguridadyTiempo";
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
    }
}