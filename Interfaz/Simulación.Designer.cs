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
            button1.Location = new Point(1111, 288);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 1;
            button1.Text = "Ciclo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BotonUnCiclo_Click;
            // 
            // PanelSimulacion
            // 
            PanelSimulacion.BackColor = Color.Black;
            PanelSimulacion.BorderStyle = BorderStyle.FixedSingle;
            PanelSimulacion.Location = new Point(91, 61);
            PanelSimulacion.Margin = new Padding(5);
            PanelSimulacion.Name = "PanelSimulacion";
            PanelSimulacion.Size = new Size(974, 639);
            PanelSimulacion.TabIndex = 0;
            PanelSimulacion.Paint += PanelSimulacion_Paint;
            PanelSimulacion.MouseClick += PanelSimulacion_MouseClick;
            // 
            // Simulación
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
            Controls.Add(button1);
            Controls.Add(PanelSimulacion);
            Margin = new Padding(5);
            Name = "Simulación";
            Text = "Simulación";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel PanelSimulacion;
    }
}