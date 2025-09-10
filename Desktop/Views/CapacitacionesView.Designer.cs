
namespace Desktop.Views
{
    partial class CapacitacionesView
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
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            TxtBuscar = new TextBox();
            label2 = new Label();
            BtnSalir = new FontAwesome.Sharp.IconButton();
            GridCapacitaciones = new DataGridView();
            BtnEliminar = new FontAwesome.Sharp.IconButton();
            BtnAgregar = new FontAwesome.Sharp.IconButton();
            BtnModificar = new FontAwesome.Sharp.IconButton();
            TabPageAgregarEditar = new TabPage();
            label7 = new Label();
            ComboPaises = new ComboBox();
            label6 = new Label();
            NumericCalificacion = new NumericUpDown();
            label5 = new Label();
            NumericDuracion = new NumericUpDown();
            TxtPortada = new TextBox();
            label4 = new Label();
            TxtTitulo = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)NumericCalificacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericDuracion).BeginInit();
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
            TabControl.Size = new Size(844, 293);
            TabControl.TabIndex = 6;
            // 
            // TabPageLista
            // 
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
            TabPageLista.Size = new Size(836, 265);
            TabPageLista.TabIndex = 1;
            TabPageLista.Text = "Lista";
            TabPageLista.UseVisualStyleBackColor = true;
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
            BtnBuscar.TabIndex = 0;
            BtnBuscar.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(56, 13);
            TxtBuscar.Margin = new Padding(2);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(551, 23);
            TxtBuscar.TabIndex = 1;
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
            BtnSalir.Location = new Point(701, 216);
            BtnSalir.Margin = new Padding(2);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(117, 33);
            BtnSalir.TabIndex = 14;
            BtnSalir.Text = "Salir";
            // 
            // GridCapacitaciones
            // 
            GridCapacitaciones.AllowUserToAddRows = false;
            GridCapacitaciones.AllowUserToDeleteRows = false;
            GridCapacitaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridCapacitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridCapacitaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCapacitaciones.Location = new Point(4, 37);
            GridCapacitaciones.Margin = new Padding(2);
            GridCapacitaciones.MultiSelect = false;
            GridCapacitaciones.Name = "GridCapacitaciones";
            GridCapacitaciones.ReadOnly = true;
            GridCapacitaciones.RowHeadersWidth = 62;
            GridCapacitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridCapacitaciones.Size = new Size(602, 230);
            GridCapacitaciones.TabIndex = 7;
            GridCapacitaciones.SelectionChanged += subMenuCapacitaciones;
            // 
            // BtnEliminar
            // 
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnEliminar.IconColor = Color.Black;
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.Location = new Point(707, 158);
            BtnEliminar.Margin = new Padding(2);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(95, 32);
            BtnEliminar.TabIndex = 15;
            BtnEliminar.Text = "Eliminar";
            // 
            // BtnAgregar
            // 
            BtnAgregar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnAgregar.IconColor = Color.Black;
            BtnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregar.Location = new Point(707, 70);
            BtnAgregar.Margin = new Padding(2);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(95, 38);
            BtnAgregar.TabIndex = 16;
            BtnAgregar.Text = "Agregar";
            // 
            // BtnModificar
            // 
            BtnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnModificar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtnModificar.IconColor = Color.Black;
            BtnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnModificar.Location = new Point(707, 112);
            BtnModificar.Margin = new Padding(2);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(95, 30);
            BtnModificar.TabIndex = 9;
            BtnModificar.Text = "&Modificar";
            BtnModificar.TextAlign = ContentAlignment.MiddleRight;
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // TabPageAgregarEditar
            // 
            TabPageAgregarEditar.Controls.Add(label7);
            TabPageAgregarEditar.Controls.Add(ComboPaises);
            TabPageAgregarEditar.Controls.Add(label6);
            TabPageAgregarEditar.Controls.Add(NumericCalificacion);
            TabPageAgregarEditar.Controls.Add(label5);
            TabPageAgregarEditar.Controls.Add(NumericDuracion);
            TabPageAgregarEditar.Controls.Add(TxtPortada);
            TabPageAgregarEditar.Controls.Add(label4);
            TabPageAgregarEditar.Controls.Add(TxtTitulo);
            TabPageAgregarEditar.Controls.Add(label3);
            TabPageAgregarEditar.Controls.Add(BtnCancelar);
            TabPageAgregarEditar.Controls.Add(BtnGuardar);
            TabPageAgregarEditar.Location = new Point(4, 24);
            TabPageAgregarEditar.Margin = new Padding(2);
            TabPageAgregarEditar.Name = "TabPageAgregarEditar";
            TabPageAgregarEditar.Padding = new Padding(2);
            TabPageAgregarEditar.Size = new Size(836, 265);
            TabPageAgregarEditar.TabIndex = 0;
            TabPageAgregarEditar.Text = "Agregar/Editar";
            TabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(555, 130);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 23;
            label7.Text = "País:";
            // 
            // ComboPaises
            // 
            ComboPaises.FormattingEnabled = true;
            ComboPaises.Location = new Point(592, 128);
            ComboPaises.Margin = new Padding(2);
            ComboPaises.Name = "ComboPaises";
            ComboPaises.Size = new Size(190, 23);
            ComboPaises.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(74, 172);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 21;
            label6.Text = "Calificación:";
            // 
            // NumericCalificacion
            // 
            NumericCalificacion.DecimalPlaces = 2;
            NumericCalificacion.Location = new Point(153, 172);
            NumericCalificacion.Margin = new Padding(2);
            NumericCalificacion.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericCalificacion.Name = "NumericCalificacion";
            NumericCalificacion.Size = new Size(126, 23);
            NumericCalificacion.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 128);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 19;
            label5.Text = "Duración en minutos:";
            // 
            // NumericDuracion
            // 
            NumericDuracion.Location = new Point(153, 128);
            NumericDuracion.Margin = new Padding(2);
            NumericDuracion.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NumericDuracion.Name = "NumericDuracion";
            NumericDuracion.Size = new Size(126, 23);
            NumericDuracion.TabIndex = 18;
            // 
            // TxtPortada
            // 
            TxtPortada.Location = new Point(153, 80);
            TxtPortada.Margin = new Padding(2);
            TxtPortada.Name = "TxtPortada";
            TxtPortada.Size = new Size(628, 23);
            TxtPortada.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 82);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 16;
            label4.Text = "Portada:";
            // 
            // TxtTitulo
            // 
            TxtTitulo.Location = new Point(153, 37);
            TxtTitulo.Margin = new Padding(2);
            TxtTitulo.Name = "TxtTitulo";
            TxtTitulo.Size = new Size(628, 23);
            TxtTitulo.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 40);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 11;
            label3.Text = "Título:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Bottom;
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(437, 226);
            BtnCancelar.Margin = new Padding(2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(95, 32);
            BtnCancelar.TabIndex = 10;
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
            BtnGuardar.Location = new Point(297, 226);
            BtnGuardar.Margin = new Padding(2);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(95, 32);
            BtnGuardar.TabIndex = 9;
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
            label1.Location = new Point(17, 7);
            label1.Name = "label1";
            label1.Size = new Size(215, 31);
            label1.TabIndex = 1;
            label1.Text = "Capacitaciones";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { LabelStatusMessage });
            statusStrip1.Location = new Point(0, 354);
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
            // CapacitacionesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 376);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(TabControl);
            Margin = new Padding(2);
            Name = "CapacitacionesView";
            TabControl.ResumeLayout(false);
            TabPageLista.ResumeLayout(false);
            TabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridCapacitaciones).EndInit();
            TabPageAgregarEditar.ResumeLayout(false);
            TabPageAgregarEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericCalificacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericDuracion).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void subMenuCapacitaciones(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        private TextBox TxtPortada;
        private Label label4;
        private TextBox TxtTitulo;
        private Label label3;
        private Label label5;
        private NumericUpDown NumericDuracion;
        private Label label6;
        private NumericUpDown NumericCalificacion;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelStatusMessage;
        private System.Windows.Forms.Timer TimerStatusBar;
        private Label label7;
        private ComboBox ComboPaises;
    }
}