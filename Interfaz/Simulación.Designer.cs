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
            button1 = new Button();
            PanelSimulacion = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(684, 180);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 29);
            button1.TabIndex = 1;
            button1.Text = "Ciclo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BotonUnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Location = new Point(56, 38);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(600, 400);
            PanelSimulacion.TabIndex = 0;
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(PanelSimulacion);
            Name = "Simulación";
            Text = "Simulación";
            Load += Simulación_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel PanelSimulacion;
    }
}