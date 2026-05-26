namespace Interfaz
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Usuariotxt = new TextBox();
            Contraseñatxt = new TextBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            btnLogin = new Button();
            btnCerrar = new Button();
            btnRegister = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // Usuariotxt
            // 
            Usuariotxt.BackColor = Color.WhiteSmoke;
            Usuariotxt.BorderStyle = BorderStyle.None;
            Usuariotxt.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Usuariotxt.Location = new Point(753, 593);
            Usuariotxt.Name = "Usuariotxt";
            Usuariotxt.Size = new Size(407, 24);
            Usuariotxt.TabIndex = 0;
            // 
            // Contraseñatxt
            // 
            Contraseñatxt.BackColor = Color.WhiteSmoke;
            Contraseñatxt.BorderStyle = BorderStyle.None;
            Contraseñatxt.Font = new Font("Myriad Pro", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Contraseñatxt.Location = new Point(753, 736);
            Contraseñatxt.Name = "Contraseñatxt";
            Contraseñatxt.PasswordChar = '*';
            Contraseñatxt.Size = new Size(407, 24);
            Contraseñatxt.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(130, 60);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 18);
            lblUsuario.TabIndex = 2;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = Color.White;
            lblContraseña.Location = new Point(130, 152);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(0, 18);
            lblContraseña.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogin.Location = new Point(772, 830);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 39);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.FromArgb(64, 64, 64);
            btnCerrar.Location = new Point(851, 942);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(205, 37);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "SALIR";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(64, 64, 64);
            btnRegister.Location = new Point(997, 830);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(175, 39);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "REGISTRARSE";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(997, 795);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 7;
            label1.Text = "¿No estás registrado?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.LOGIN;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1924, 1055);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(btnCerrar);
            Controls.Add(btnLogin);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(Contraseñatxt);
            Controls.Add(Usuariotxt);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Usuariotxt;
        private TextBox Contraseñatxt;
        private Label lblUsuario;
        private Label lblContraseña;
        private Button btnLogin;
        private Button btnCerrar;
        private Button btnRegister;
        private Label label1;
    }
}
