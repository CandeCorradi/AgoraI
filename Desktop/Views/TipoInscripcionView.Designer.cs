
namespace Desktop.Views
{
    partial class TipoInscripcionView
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
            components = new System.ComponentModel.Container();
            TabControl = new TabControl();
            TabPageLista = new TabPage();
            btnRestaurar = new Button();
            checkVerEliminados = new CheckBox();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            TxtBuscar = new TextBox();
            label2 = new Label();
            BtnSalir = new FontAwesome.Sharp.IconButton();
            GridCapacitaciones = new DataGridView();
            BtnEliminar = new FontAwesome.Sharp.IconButton();
            BtnAgregar = new FontAwesome.Sharp.IconButton();
            BtnModificar = new FontAwesome.Sharp.IconButton();
            TabPageAgregarEditar = new TabPage();
            TxtNombre = new TextBox();
            label3 = new Label();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            LabelStatusMessage = new ToolStripStatusLabel();
            TimerStatusBar = new System.Windows.Forms.Timer(components);
            TabControl.SuspendLayout();
            TabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridCapacitaciones).BeginInit();
            TabPageAgregarEditar.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControl.Controls.Add(TabPageLista);
            TabControl.Controls.Add(TabPageAgregarEditar);
            TabControl.Location = new Point(15, 50);
            TabControl.Margin = new Padding(2);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(844, 298);
            TabControl.TabIndex = 6;
            // 
            // TabPageLista
            // 
            TabPageLista.Controls.Add(btnRestaurar);
            TabPageLista.Controls.Add(checkVerEliminados);
            TabPageLista.Controls.Add(BtnBuscar);
            TabPageLista.Controls.Add(TxtBuscar);
            TabPageLista.Controls.Add(label2);
            TabPageLista.Controls.Add(BtnSalir);
            TabPageLista.Controls.Add(GridCapacitaciones);
            TabPageLista.Controls.Add(BtnEliminar);
            TabPageLista.Controls.Add(BtnAgregar);
            TabPageLista.Controls.Add(BtnModificar);
            TabPageLista.Location = new Point(4, 24);
            TabPageLista.Margin = new Padding(2);
            TabPageLista.Name = "TabPageLista";
            TabPageLista.Padding = new Padding(2);
            TabPageLista.Size = new Size(836, 270);
            TabPageLista.TabIndex = 1;
            TabPageLista.Text = "Lista";
            TabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Location = new Point(707, 172);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(95, 28);
            btnRestaurar.TabIndex = 6;
            btnRestaurar.Text = "Restaurar";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Visible = false;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // checkVerEliminados
            // 
            checkVerEliminados.AutoSize = true;
            checkVerEliminados.Location = new Point(508, 15);
            checkVerEliminados.Name = "checkVerEliminados";
            checkVerEliminados.Size = new Size(103, 19);
            checkVerEliminados.TabIndex = 1;
            checkVerEliminados.Text = "Ver Eliminados";
            checkVerEliminados.UseVisualStyleBackColor = true;
            checkVerEliminados.CheckedChanged += checkVerEliminados_CheckedChanged;
            // 
            // BtnBuscar
            // 
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnBuscar.IconColor = Color.Black;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.Location = new Point(701, 13);
            BtnBuscar.Margin = new Padding(2);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(101, 32);
            BtnBuscar.TabIndex = 2;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.Click += BtnBuscar_Click_1;
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(56, 13);
            TxtBuscar.Margin = new Padding(2);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(428, 23);
            TxtBuscar.TabIndex = 0;
            TxtBuscar.TextChanged += TxtBuscar_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 16);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 13;
            label2.Text = "Buscar:";
            // 
            // BtnSalir
            // 
            BtnSalir.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnSalir.IconColor = Color.Black;
            BtnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSalir.Location = new Point(701, 228);
            BtnSalir.Margin = new Padding(2);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(117, 33);
            BtnSalir.TabIndex = 7;
            BtnSalir.Text = "Salir";
            // 
            // GridCapacitaciones
            // 
            GridCapacitaciones.AllowUserToAddRows = false;
            GridCapacitaciones.AllowUserToDeleteRows = false;
            GridCapacitaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridCapacitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridCapacitaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCapacitaciones.Location = new Point(12, 43);
            GridCapacitaciones.Margin = new Padding(2);
            GridCapacitaciones.MultiSelect = false;
            GridCapacitaciones.Name = "GridCapacitaciones";
            GridCapacitaciones.ReadOnly = true;
            GridCapacitaciones.RowHeadersWidth = 62;
            GridCapacitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridCapacitaciones.Size = new Size(674, 218);
            GridCapacitaciones.TabIndex = 7;
            // 
            // BtnEliminar
            // 
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnEliminar.IconColor = Color.Black;
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.Location = new Point(707, 135);
            BtnEliminar.Margin = new Padding(2);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(95, 32);
            BtnEliminar.TabIndex = 5;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnAgregar
            // 
            BtnAgregar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnAgregar.IconColor = Color.Black;
            BtnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregar.Location = new Point(707, 66);
            BtnAgregar.Margin = new Padding(2);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(95, 31);
            BtnAgregar.TabIndex = 3;
            BtnAgregar.Text = "Agregar";
            // 
            // BtnModificar
            // 
            BtnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnModificar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtnModificar.IconColor = Color.Black;
            BtnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnModificar.Location = new Point(707, 101);
            BtnModificar.Margin = new Padding(2);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(95, 30);
            BtnModificar.TabIndex = 4;
            BtnModificar.Text = "&Modificar";
            BtnModificar.TextAlign = ContentAlignment.MiddleRight;
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // TabPageAgregarEditar
            // 
            TabPageAgregarEditar.Controls.Add(TxtNombre);
            TabPageAgregarEditar.Controls.Add(label3);
            TabPageAgregarEditar.Controls.Add(BtnCancelar);
            TabPageAgregarEditar.Controls.Add(BtnGuardar);
            TabPageAgregarEditar.Location = new Point(4, 24);
            TabPageAgregarEditar.Margin = new Padding(2);
            TabPageAgregarEditar.Name = "TabPageAgregarEditar";
            TabPageAgregarEditar.Padding = new Padding(2);
            TabPageAgregarEditar.Size = new Size(836, 270);
            TabPageAgregarEditar.TabIndex = 0;
            TabPageAgregarEditar.Text = "Agregar/Editar";
            TabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(144, 107);
            TxtNombre.Margin = new Padding(2);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(628, 23);
            TxtNombre.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 110);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 11;
            label3.Text = "Nombre:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Bottom;
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(401, 190);
            BtnCancelar.Margin = new Padding(2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(111, 48);
            BtnCancelar.TabIndex = 7;
            BtnCancelar.Text = "&Cancelar";
            BtnCancelar.TextAlign = ContentAlignment.MiddleRight;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.Bottom;
            BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnGuardar.IconColor = Color.Black;
            BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.Location = new Point(228, 190);
            BtnGuardar.Margin = new Padding(2);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(119, 48);
            BtnGuardar.TabIndex = 6;
            BtnGuardar.Text = "&Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 47);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 10);
            label1.Name = "label1";
            label1.Size = new Size(307, 31);
            label1.TabIndex = 1;
            label1.Text = "Tipos de Inscripciones";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { LabelStatusMessage });
            statusStrip1.Location = new Point(0, 369);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(867, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // LabelStatusMessage
            // 
            LabelStatusMessage.Name = "LabelStatusMessage";
            LabelStatusMessage.Size = new Size(0, 17);
            // 
            // TimerStatusBar
            // 
            TimerStatusBar.Interval = 5000;
            TimerStatusBar.Tick += TimerStatusBar_Tick;
            // 
            // TipoInscripcionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 391);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(TabControl);
            Margin = new Padding(2);
            Name = "TipoInscripcionView";
            TabControl.ResumeLayout(false);
            TabPageLista.ResumeLayout(false);
            TabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridCapacitaciones).EndInit();
            TabPageAgregarEditar.ResumeLayout(false);
            TabPageAgregarEditar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private TabControl TabControl;
        private TabPage TabPageLista;
        private TabPage TabPageAgregarEditar;
        private Panel panel1;
        private Label label1;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private DataGridView GridCapacitaciones;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnAgregar;
        private FontAwesome.Sharp.IconButton BtnModificar;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private TextBox TxtBuscar;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private TextBox TxtNombre;
        private Label label3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelStatusMessage;
        private System.Windows.Forms.Timer TimerStatusBar;
        private Button btnRestaurar;
        private CheckBox checkVerEliminados;
    }
}