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
            labelAerolinia = new Label();
            Informacion.SuspendLayout();
            SuspendLayout();
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelID.Location = new Point(28, 48);
            labelID.Name = "labelID";
            labelID.Size = new Size(87, 29);
            labelID.TabIndex = 1;
            labelID.Text = "labelID";
            labelID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelX.Location = new Point(28, 96);
            labelX.Name = "labelX";
            labelX.Size = new Size(76, 29);
            labelX.TabIndex = 2;
            labelX.Text = "labelX";
            labelX.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelY.Location = new Point(240, 96);
            labelY.Name = "labelY";
            labelY.Size = new Size(76, 29);
            labelY.TabIndex = 3;
            labelY.Text = "labelY";
            labelY.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVelocidad
            // 
            labelVelocidad.AutoSize = true;
            labelVelocidad.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVelocidad.Location = new Point(28, 144);
            labelVelocidad.Name = "labelVelocidad";
            labelVelocidad.Size = new Size(152, 29);
            labelVelocidad.TabIndex = 4;
            labelVelocidad.Text = "labelVelocitat";
            labelVelocidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Informacion
            // 
            Informacion.BackColor = Color.DarkSlateGray;
            Informacion.CausesValidation = false;
            Informacion.Controls.Add(labelAerolinia);
            Informacion.Controls.Add(labelID);
            Informacion.Controls.Add(labelVelocidad);
            Informacion.Controls.Add(labelX);
            Informacion.Controls.Add(labelY);
            Informacion.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Informacion.ForeColor = SystemColors.Control;
            Informacion.Location = new Point(16, 16);
            Informacion.Margin = new Padding(5, 5, 5, 5);
            Informacion.Name = "Informacion";
            Informacion.Padding = new Padding(5, 5, 5, 5);
            Informacion.Size = new Size(488, 224);
            Informacion.TabIndex = 5;
            Informacion.TabStop = false;
            Informacion.Text = "Información del Avión";
            // 
            // cerrarBtn
            // 
            cerrarBtn.Location = new Point(179, 256);
            cerrarBtn.Margin = new Padding(5, 5, 5, 5);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(153, 46);
            cerrarBtn.TabIndex = 5;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // labelAerolinia
            // 
            labelAerolinia.AutoSize = true;
            labelAerolinia.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAerolinia.Location = new Point(240, 144);
            labelAerolinia.Name = "labelAerolinia";
            labelAerolinia.Size = new Size(147, 29);
            labelAerolinia.TabIndex = 5;
            labelAerolinia.Text = "labelAerolina";
            labelAerolinia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // InfoAvion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(523, 325);
            Controls.Add(cerrarBtn);
            Controls.Add(Informacion);
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
        private Label labelAerolinia;
    }
}