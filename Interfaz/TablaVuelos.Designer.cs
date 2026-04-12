namespace Interfaz
{
    partial class TablaVuelos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvVuelos = new DataGridView();
            ColumnID = new DataGridViewTextBoxColumn();
            PosX = new DataGridViewTextBoxColumn();
            PosY = new DataGridViewTextBoxColumn();
            ColumnSpeed = new DataGridViewTextBoxColumn();
            cerrarBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).BeginInit();
            SuspendLayout();
            // 
            // dgvVuelos
            // 
            dgvVuelos.BackgroundColor = SystemColors.Desktop;
            dgvVuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVuelos.Columns.AddRange(new DataGridViewColumn[] { ColumnID, PosX, PosY, ColumnSpeed });
            dgvVuelos.Location = new Point(10, 10);
            dgvVuelos.Margin = new Padding(2);
            dgvVuelos.Name = "dgvVuelos";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Desktop;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVuelos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVuelos.RowHeadersWidth = 82;
            dgvVuelos.Size = new Size(500, 200);
            dgvVuelos.TabIndex = 0;
            // 
            // ColumnID
            // 
            ColumnID.HeaderText = "ID";
            ColumnID.MinimumWidth = 10;
            ColumnID.Name = "ColumnID";
            ColumnID.Width = 200;
            // 
            // PosX
            // 
            PosX.HeaderText = "Posición X";
            PosX.MinimumWidth = 10;
            PosX.Name = "PosX";
            PosX.Width = 200;
            // 
            // PosY
            // 
            PosY.HeaderText = "Posición Y";
            PosY.MinimumWidth = 10;
            PosY.Name = "PosY";
            PosY.Width = 200;
            // 
            // ColumnSpeed
            // 
            ColumnSpeed.HeaderText = "Velocidad";
            ColumnSpeed.MinimumWidth = 10;
            ColumnSpeed.Name = "ColumnSpeed";
            ColumnSpeed.Width = 200;
            // 
            // cerrarBtn
            // 
            cerrarBtn.Location = new Point(230, 220);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(94, 29);
            cerrarBtn.TabIndex = 1;
            cerrarBtn.Text = "Cerrar";
            cerrarBtn.UseVisualStyleBackColor = true;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // TablaVuelos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(522, 263);
            Controls.Add(cerrarBtn);
            Controls.Add(dgvVuelos);
            Margin = new Padding(2);
            Name = "TablaVuelos";
            Text = "DatosGridVuelos";
            Load += TablaVuelos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvVuelos;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn PosX;
        private DataGridViewTextBoxColumn PosY;
        private DataGridViewTextBoxColumn ColumnSpeed;
        private Button cerrarBtn;
    }
}