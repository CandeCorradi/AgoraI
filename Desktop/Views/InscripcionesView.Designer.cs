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
            AddInscripcion = new Panel();
            label5 = new Label();
            TxtCosto = new TextBox();
            label4 = new Label();
            CmbTipoInscripcion = new ComboBox();
            BtnAgregarUsuario = new Button();
            BtnBuscar = new Button();
            TxtBuscarUsuarios = new TextBox();
            GridUsuarios = new DataGridView();
            label3 = new Label();
            panel2 = new Panel();
            GridInscripciones = new DataGridView();
            CmbCapacitacion = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            AddInscripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsuarios).BeginInit();
            panel2.SuspendLayout();
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
            panel1.Size = new Size(928, 47);
            panel1.TabIndex = 8;
            // 
            // AddInscripcion
            // 
            AddInscripcion.BorderStyle = BorderStyle.Fixed3D;
            AddInscripcion.Controls.Add(label5);
            AddInscripcion.Controls.Add(TxtCosto);
            AddInscripcion.Controls.Add(label4);
            AddInscripcion.Controls.Add(CmbTipoInscripcion);
            AddInscripcion.Controls.Add(BtnAgregarUsuario);
            AddInscripcion.Controls.Add(BtnBuscar);
            AddInscripcion.Controls.Add(TxtBuscarUsuarios);
            AddInscripcion.Controls.Add(GridUsuarios);
            AddInscripcion.Controls.Add(label3);
            AddInscripcion.Location = new Point(506, 73);
            AddInscripcion.Name = "AddInscripcion";
            AddInscripcion.Size = new Size(412, 347);
            AddInscripcion.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 255);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 20;
            label5.Text = "Importe:";
            // 
            // TxtCosto
            // 
            TxtCosto.Enabled = false;
            TxtCosto.Location = new Point(16, 273);
            TxtCosto.Name = "TxtCosto";
            TxtCosto.ReadOnly = true;
            TxtCosto.Size = new Size(100, 23);
            TxtCosto.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 196);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 16;
            label4.Text = "Tipo de Inscripción:";
            // 
            // CmbTipoInscripcion
            // 
            CmbTipoInscripcion.FormattingEnabled = true;
            CmbTipoInscripcion.Location = new Point(5, 217);
            CmbTipoInscripcion.Name = "CmbTipoInscripcion";
            CmbTipoInscripcion.Size = new Size(392, 23);
            CmbTipoInscripcion.TabIndex = 15;
            // 
            // BtnAgregarUsuario
            // 
            BtnAgregarUsuario.Location = new Point(270, 39);
            BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            BtnAgregarUsuario.Size = new Size(127, 23);
            BtnAgregarUsuario.TabIndex = 14;
            BtnAgregarUsuario.Text = "Agregar Inscripto...";
            BtnAgregarUsuario.UseVisualStyleBackColor = true;
            BtnAgregarUsuario.Click += BtnAgregarUsuario_Click;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(124, 39);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 13;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtBuscarUsuarios
            // 
            TxtBuscarUsuarios.Location = new Point(124, 10);
            TxtBuscarUsuarios.Name = "TxtBuscarUsuarios";
            TxtBuscarUsuarios.PlaceholderText = "Buscar inscripto...";
            TxtBuscarUsuarios.Size = new Size(273, 23);
            TxtBuscarUsuarios.TabIndex = 12;
            TxtBuscarUsuarios.TextChanged += TxtBuscarUsuarios_TextChanged;
            TxtBuscarUsuarios.KeyPress += TxtBuscarUsuarios_KeyPress;
            // 
            // GridUsuarios
            // 
            GridUsuarios.AllowUserToAddRows = false;
            GridUsuarios.AllowUserToDeleteRows = false;
            GridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridUsuarios.Location = new Point(5, 68);
            GridUsuarios.Name = "GridUsuarios";
            GridUsuarios.ReadOnly = true;
            GridUsuarios.RowHeadersVisible = false;
            GridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridUsuarios.Size = new Size(392, 118);
            GridUsuarios.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 13);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 10;
            label3.Text = "Agregar inscripción:";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(GridInscripciones);
            panel2.Controls.Add(CmbCapacitacion);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(17, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(458, 347);
            panel2.TabIndex = 14;
            // 
            // GridInscripciones
            // 
            GridInscripciones.AllowUserToAddRows = false;
            GridInscripciones.AllowUserToDeleteRows = false;
            GridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInscripciones.Location = new Point(9, 39);
            GridInscripciones.Name = "GridInscripciones";
            GridInscripciones.ReadOnly = true;
            GridInscripciones.RowHeadersVisible = false;
            GridInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridInscripciones.Size = new Size(435, 294);
            GridInscripciones.TabIndex = 15;
            // 
            // CmbCapacitacion
            // 
            CmbCapacitacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CmbCapacitacion.FormattingEnabled = true;
            CmbCapacitacion.Location = new Point(94, 10);
            CmbCapacitacion.Name = "CmbCapacitacion";
            CmbCapacitacion.Size = new Size(350, 23);
            CmbCapacitacion.TabIndex = 14;
            CmbCapacitacion.SelectedIndexChanged += CmbCapacitacion_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 13);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 13;
            label2.Text = "Capacitación:";
            // 
            // InscripcionesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 450);
            Controls.Add(panel2);
            Controls.Add(AddInscripcion);
            Controls.Add(panel1);
            Name = "InscripcionesView";
            Text = "Inscripciones";
            WindowState = FormWindowState.Minimized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            AddInscripcion.ResumeLayout(false);
            AddInscripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsuarios).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel AddInscripcion;
        private DataGridView GridUsuarios;
        private Label label3;
        private Button BtnAgregarUsuario;
        private Button BtnBuscar;
        private TextBox TxtBuscarUsuarios;
        private Panel panel2;
        private DataGridView GridInscripciones;
        private ComboBox CmbCapacitacion;
        private Label label2;
        private Label label4;
        private ComboBox CmbTipoInscripcion;
        private Label label5;
        private TextBox TxtCosto;
    }
}