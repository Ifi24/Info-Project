namespace Interfaz
{
    partial class GestionAerolineas
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
            dgvCompañias = new DataGridView();
            txtCompañia = new TextBox();
            lblCompañia = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtGmail = new TextBox();
            lblGmail = new Label();
            btnAñadir = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompañias).BeginInit();
            SuspendLayout();
            // 
            // dgvCompañias
            // 
            dgvCompañias.BackgroundColor = Color.DimGray;
            dgvCompañias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompañias.Location = new Point(152, 0);
            dgvCompañias.Name = "dgvCompañias";
            dgvCompañias.RowHeadersWidth = 51;
            dgvCompañias.Size = new Size(650, 451);
            dgvCompañias.TabIndex = 0;
            // 
            // txtCompañia
            // 
            txtCompañia.Location = new Point(12, 49);
            txtCompañia.Name = "txtCompañia";
            txtCompañia.Size = new Size(125, 27);
            txtCompañia.TabIndex = 1;
            // 
            // lblCompañia
            // 
            lblCompañia.AutoSize = true;
            lblCompañia.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompañia.ForeColor = Color.White;
            lblCompañia.Location = new Point(12, 26);
            lblCompañia.Name = "lblCompañia";
            lblCompañia.Size = new Size(90, 20);
            lblCompañia.TabIndex = 2;
            lblCompañia.Text = "Compañía:";
            lblCompañia.Click += label1_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 138);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 3;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.ForeColor = Color.White;
            lblTelefono.Location = new Point(12, 115);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(90, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtGmail
            // 
            txtGmail.Location = new Point(12, 231);
            txtGmail.Name = "txtGmail";
            txtGmail.Size = new Size(125, 27);
            txtGmail.TabIndex = 5;
            txtGmail.TextChanged += txtGmail_TextChanged;
            // 
            // lblGmail
            // 
            lblGmail.AutoSize = true;
            lblGmail.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGmail.ForeColor = Color.White;
            lblGmail.Location = new Point(12, 208);
            lblGmail.Name = "lblGmail";
            lblGmail.Size = new Size(63, 20);
            lblGmail.TabIndex = 6;
            lblGmail.Text = "Gmail:";
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(29, 325);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(94, 29);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(29, 360);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(29, 395);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 9;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // GestionAerolineas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAñadir);
            Controls.Add(lblGmail);
            Controls.Add(txtGmail);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblCompañia);
            Controls.Add(txtCompañia);
            Controls.Add(dgvCompañias);
            Name = "GestionAerolineas";
            Text = "GestionAerolineas";
            Load += GestionAerolineas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompañias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCompañias;
        private TextBox txtCompañia;
        private Label lblCompañia;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtGmail;
        private Label lblGmail;
        private Button btnAñadir;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}