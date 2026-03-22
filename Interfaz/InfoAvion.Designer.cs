namespace Interfaz
{
    partial class InfoAvion
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
            labelTitulo = new Label();
            labelID = new Label();
            labelX = new Label();
            labelY = new Label();
            labelVelocidad = new Label();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Location = new Point(387, 60);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(126, 32);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "labelTitulo";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(95, 130);
            labelID.Name = "labelID";
            labelID.Size = new Size(88, 32);
            labelID.TabIndex = 1;
            labelID.Text = "labelID";
            labelID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(95, 190);
            labelX.Name = "labelX";
            labelX.Size = new Size(79, 32);
            labelX.TabIndex = 2;
            labelX.Text = "labelX";
            labelX.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new Point(95, 250);
            labelY.Name = "labelY";
            labelY.Size = new Size(78, 32);
            labelY.TabIndex = 3;
            labelY.Text = "labelY";
            labelY.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVelocidad
            // 
            labelVelocidad.AutoSize = true;
            labelVelocidad.Location = new Point(95, 310);
            labelVelocidad.Name = "labelVelocidad";
            labelVelocidad.Size = new Size(156, 32);
            labelVelocidad.TabIndex = 4;
            labelVelocidad.Text = "labelVelocitat";
            labelVelocidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // InfoAvion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 419);
            Controls.Add(labelVelocidad);
            Controls.Add(labelY);
            Controls.Add(labelX);
            Controls.Add(labelID);
            Controls.Add(labelTitulo);
            Name = "InfoAvion";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelID;
        private Label labelX;
        private Label labelY;
        private Label labelVelocidad;
    }
}