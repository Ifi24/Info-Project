namespace Interfaz
{
    partial class MiMessageBox
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
            lblTitulo = new Label();
            lblMensaje = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Myriad Pro", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(40, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(110, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TÍTULO";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.BackColor = Color.Transparent;
            lblMensaje.Font = new Font("Myriad Pro", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensaje.ForeColor = SystemColors.ControlLightLight;
            lblMensaje.Location = new Point(49, 86);
            lblMensaje.MaximumSize = new Size(380, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(101, 28);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "MENSAJE";
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAceptar.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(70, 281);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(104, 37);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(452, 281);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(104, 37);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // MiMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.AVION;
            ClientSize = new Size(645, 356);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MiMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MessageBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMensaje;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}