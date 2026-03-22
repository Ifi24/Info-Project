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
            dgvVuelos = new DataGridView();
            ColumnID = new DataGridViewTextBoxColumn();
            PosX = new DataGridViewTextBoxColumn();
            PosY = new DataGridViewTextBoxColumn();
            ColumnSpeed = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).BeginInit();
            SuspendLayout();
            // 
            // dgvVuelos
            // 
            dgvVuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVuelos.Columns.AddRange(new DataGridViewColumn[] { ColumnID, PosX, PosY, ColumnSpeed });
            dgvVuelos.Location = new Point(25, 43);
            dgvVuelos.Name = "dgvVuelos";
            dgvVuelos.RowHeadersWidth = 82;
            dgvVuelos.Size = new Size(886, 300);
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
            // TablaVuelos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 450);
            Controls.Add(dgvVuelos);
            Name = "TablaVuelos";
            Text = "DatosGridVuelos";
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvVuelos;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn PosX;
        private DataGridViewTextBoxColumn PosY;
        private DataGridViewTextBoxColumn ColumnSpeed;
    }
}