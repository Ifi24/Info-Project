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
            SuspendLayout();
            // 
            // Usuariotxt
            // 
            Usuariotxt.Location = new Point(363, 122);
            Usuariotxt.Name = "Usuariotxt";
            Usuariotxt.Size = new Size(125, 27);
            Usuariotxt.TabIndex = 0;
            // 
            // Contraseñatxt
            // 
            Contraseñatxt.Location = new Point(363, 215);
            Contraseñatxt.Name = "Contraseñatxt";
            Contraseñatxt.PasswordChar = '*';
            Contraseñatxt.Size = new Size(125, 27);
            Contraseñatxt.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(363, 87);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(363, 178);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(86, 20);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(267, 288);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(471, 288);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Salir";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(127, 288);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Registrarse";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(btnCerrar);
            Controls.Add(btnLogin);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(Contraseñatxt);
            Controls.Add(Usuariotxt);
            Name = "Login";
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
    }
}
