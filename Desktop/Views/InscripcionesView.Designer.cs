namespace Desktop.Views
{
    partial class InscripcionesView
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
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            CmbCapacitacion = new ComboBox();
            GridInscripciones = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 8);
            label1.Name = "label1";
            label1.Size = new Size(187, 31);
            label1.TabIndex = 1;
            label1.Text = "Inscripciones";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 11);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 47);
            panel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 98);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 9;
            label2.Text = "Capacitación:";
            // 
            // CmbCapacitacion
            // 
            CmbCapacitacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CmbCapacitacion.FormattingEnabled = true;
            CmbCapacitacion.Location = new Point(109, 87);
            CmbCapacitacion.Name = "CmbCapacitacion";
            CmbCapacitacion.Size = new Size(456, 33);
            CmbCapacitacion.TabIndex = 11;
            CmbCapacitacion.SelectedIndexChanged += CmbCapacitacion_SelectedIndexChanged;
            // 
            // GridInscripciones
            // 
            GridInscripciones.AllowUserToAddRows = false;
            GridInscripciones.AllowUserToDeleteRows = false;
            GridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInscripciones.Location = new Point(17, 154);
            GridInscripciones.Name = "GridInscripciones";
            GridInscripciones.ReadOnly = true;
            GridInscripciones.Size = new Size(726, 256);
            GridInscripciones.TabIndex = 12;
            // 
            // InscripcionesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(GridInscripciones);
            Controls.Add(CmbCapacitacion);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "InscripcionesView";
            Text = "Inscripciones";
            WindowState = FormWindowState.Minimized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox CmbCapacitacion;
        private DataGridView GridInscripciones;
    }
}