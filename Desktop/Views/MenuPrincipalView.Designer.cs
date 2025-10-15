namespace Desktop
{
    partial class MenuPrincipalView
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
            menuPrincipal = new MenuStrip();
            SubMenuPrincipal = new FontAwesome.Sharp.IconMenuItem();
            SubMenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            subMenuCapacitaciones = new FontAwesome.Sharp.IconMenuItem();
            subMenuTiposDeInscripciones = new ToolStripMenuItem();
            SubMenuSalir = new FontAwesome.Sharp.IconMenuItem();
            SubMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            SubMenuInscripciones = new ToolStripMenuItem();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.ImageScalingSize = new Size(24, 24);
            menuPrincipal.Items.AddRange(new ToolStripItem[] { SubMenuPrincipal, SubMenuSalir });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Padding = new Padding(4, 1, 0, 1);
            menuPrincipal.Size = new Size(560, 30);
            menuPrincipal.TabIndex = 1;
            menuPrincipal.Text = "menuStrip1";
            // 
            // SubMenuPrincipal
            // 
            SubMenuPrincipal.DropDownItems.AddRange(new ToolStripItem[] { SubMenuUsuarios, subMenuCapacitaciones, subMenuTiposDeInscripciones, toolStripSeparator1, SubMenuInscripciones });
            SubMenuPrincipal.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            SubMenuPrincipal.IconColor = Color.Black;
            SubMenuPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuPrincipal.Name = "SubMenuPrincipal";
            SubMenuPrincipal.Size = new Size(89, 28);
            SubMenuPrincipal.Text = "Principal";
            // 
            // SubMenuUsuarios
            // 
            SubMenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            SubMenuUsuarios.IconColor = Color.Black;
            SubMenuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuUsuarios.Name = "SubMenuUsuarios";
            SubMenuUsuarios.Size = new Size(198, 30);
            SubMenuUsuarios.Text = "Usuarios";
            SubMenuUsuarios.Click += SubMenuUsuarios_Click;
            // 
            // subMenuCapacitaciones
            // 
            subMenuCapacitaciones.IconChar = FontAwesome.Sharp.IconChar.Book;
            subMenuCapacitaciones.IconColor = Color.Black;
            subMenuCapacitaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuCapacitaciones.Name = "subMenuCapacitaciones";
            subMenuCapacitaciones.Size = new Size(198, 30);
            subMenuCapacitaciones.Text = "Capacitaciones";
            subMenuCapacitaciones.Click += subMenuCapacitaciones_Click;
            // 
            // subMenuTiposDeInscripciones
            // 
            subMenuTiposDeInscripciones.Name = "subMenuTiposDeInscripciones";
            subMenuTiposDeInscripciones.Size = new Size(198, 30);
            subMenuTiposDeInscripciones.Text = "Tipos de Inscripciones";
            subMenuTiposDeInscripciones.Click += subMenuTiposDeInscripciones_Click;
            // 
            // SubMenuSalir
            // 
            SubMenuSalir.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema });
            SubMenuSalir.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            SubMenuSalir.IconColor = Color.Black;
            SubMenuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuSalir.Name = "SubMenuSalir";
            SubMenuSalir.Size = new Size(65, 28);
            SubMenuSalir.Text = "Salir";
            // 
            // SubMenuSalirDelSistema
            // 
            SubMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            SubMenuSalirDelSistema.IconColor = Color.Black;
            SubMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            SubMenuSalirDelSistema.Size = new Size(158, 22);
            SubMenuSalirDelSistema.Text = "Salir del sistema";
            SubMenuSalirDelSistema.Click += SubMenuSalirDelSistema_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Location = new Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(560, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(195, 6);
            // 
            // SubMenuInscripciones
            // 
            SubMenuInscripciones.Name = "SubMenuInscripciones";
            SubMenuInscripciones.Size = new Size(198, 30);
            SubMenuInscripciones.Text = "Inscripciones";
            SubMenuInscripciones.Click += SubMenuInscripciones_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(toolStrip1);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Margin = new Padding(2);
            Name = "MenuPrincipalView";
            Text = "Ágora : Software de Acreditación de Capacitaciones ISP20";
            WindowState = FormWindowState.Maximized;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStrip toolStrip1;
        private FontAwesome.Sharp.IconMenuItem SubMenuPrincipal;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalir;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
        private FontAwesome.Sharp.IconMenuItem SubMenuUsuarios;
        private FontAwesome.Sharp.IconMenuItem subMenuCapacitaciones;
        private ToolStripMenuItem subMenuTiposDeInscripciones;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem SubMenuInscripciones;
    }
}
