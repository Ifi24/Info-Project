namespace Interfaz
{
    partial class FormDistancia
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
            labelDistancia = new Label();
            SuspendLayout();
            // 
            // labelDistancia
            // 
            labelDistancia.AutoSize = true;
            labelDistancia.Location = new Point(76, 55);
            labelDistancia.Name = "labelDistancia";
            labelDistancia.Size = new Size(78, 32);
            labelDistancia.TabIndex = 0;
            labelDistancia.Text = "label1";
            // 
            // FormDistancia
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDistancia);
            Name = "FormDistancia";
            Text = "FormDistancia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDistancia;
    }
}