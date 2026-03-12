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
            PanelSimulacion = new Panel();
            SuspendLayout();
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Location = new Point(56, 38);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(600, 400);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PanelSimulacion);
            Name = "Simulación";
            Text = "Simulación";
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelSimulacion;
    }
}