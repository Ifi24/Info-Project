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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDistancia));
            labelDistancia = new Label();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // labelDistancia
            // 
            labelDistancia.AutoSize = true;
            labelDistancia.BackColor = Color.Transparent;
            labelDistancia.Font = new Font("Myriad Pro", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDistancia.ForeColor = Color.White;
            labelDistancia.Location = new Point(20, 20);
            labelDistancia.Margin = new Padding(2, 0, 2, 0);
            labelDistancia.Name = "labelDistancia";
            labelDistancia.Size = new Size(17, 18);
            labelDistancia.TabIndex = 0;
            labelDistancia.Text = "...";
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(132, 208);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 31);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormDistancia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(354, 265);
            Controls.Add(btnCerrar);
            Controls.Add(labelDistancia);
            Margin = new Padding(2);
            Name = "FormDistancia";
            Text = "FormDistancia";
            Load += FormDistancia_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDistancia;
        private Button btnCerrar;
    }
}