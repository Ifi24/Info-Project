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
            Usuariotxt.Location = new Point(130, 90);
            Usuariotxt.Name = "Usuariotxt";
            Usuariotxt.Size = new Size(221, 27);
            Usuariotxt.TabIndex = 0;
            // 
            // Contraseñatxt
            // 
            Contraseñatxt.Location = new Point(130, 180);
            Contraseñatxt.Name = "Contraseñatxt";
            Contraseñatxt.PasswordChar = '*';
            Contraseñatxt.Size = new Size(221, 27);
            Contraseñatxt.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(130, 60);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(71, 18);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(130, 152);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(98, 18);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(200, 240);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(70, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(320, 320);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Salir";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(50, 320);
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
            BackColor = SystemColors.Control;
            ClientSize = new Size(482, 403);
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
    }
}
