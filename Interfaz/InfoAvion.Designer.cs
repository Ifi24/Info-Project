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
            labelID = new Label();
            labelX = new Label();
            labelY = new Label();
            labelVelocidad = new Label();
            Informacion = new GroupBox();
            cerrarBtn = new Button();
            Informacion.SuspendLayout();
            SuspendLayout();
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelID.Location = new Point(17, 30);
            labelID.Margin = new Padding(2, 0, 2, 0);
            labelID.Name = "labelID";
            labelID.Size = new Size(52, 18);
            labelID.TabIndex = 1;
            labelID.Text = "labelID";
            labelID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelX.Location = new Point(17, 60);
            labelX.Margin = new Padding(2, 0, 2, 0);
            labelX.Name = "labelX";
            labelX.Size = new Size(45, 18);
            labelX.TabIndex = 2;
            labelX.Text = "labelX";
            labelX.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelY.Location = new Point(148, 60);
            labelY.Margin = new Padding(2, 0, 2, 0);
            labelY.Name = "labelY";
            labelY.Size = new Size(46, 18);
            labelY.TabIndex = 3;
            labelY.Text = "labelY";
            labelY.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVelocidad
            // 
            labelVelocidad.AutoSize = true;
            labelVelocidad.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVelocidad.Location = new Point(17, 90);
            labelVelocidad.Margin = new Padding(2, 0, 2, 0);
            labelVelocidad.Name = "labelVelocidad";
            labelVelocidad.Size = new Size(90, 18);
            labelVelocidad.TabIndex = 4;
            labelVelocidad.Text = "labelVelocitat";
            labelVelocidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Informacion
            // 
            Informacion.BackColor = Color.DarkSlateGray;
            Informacion.CausesValidation = false;
            Informacion.Controls.Add(labelID);
            Informacion.Controls.Add(labelVelocidad);
            Informacion.Controls.Add(labelX);
            Informacion.Controls.Add(labelY);
            Informacion.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Informacion.ForeColor = SystemColors.Control;
            Informacion.Location = new Point(10, 10);
            Informacion.Name = "Informacion";
            Informacion.Size = new Size(300, 140);
            Informacion.TabIndex = 5;
            Informacion.TabStop = false;
            Informacion.Text = "Información del Avión";
            // 
            // cerrarBtn
            // 
            cerrarBtn.Location = new Point(110, 160);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(94, 29);
            cerrarBtn.TabIndex = 5;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // InfoAvion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(322, 203);
            Controls.Add(cerrarBtn);
            Controls.Add(Informacion);
            Margin = new Padding(2);
            Name = "InfoAvion";
            Text = "Información avión";
            Informacion.ResumeLayout(false);
            Informacion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label labelID;
        private Label labelX;
        private Label labelY;
        private Label labelVelocidad;
        private GroupBox Informacion;
        private Button cerrarBtn;
    }
}