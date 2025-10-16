using Desktop.ExtensionMethod;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class InscripcionesView : Form
    {
        GenericService<Capacitacion> _capacitacionService = new();
        GenericService<Usuario> _usuarioService = new();
        InscripcionService _inscripcionService = new();
        List<Inscripcion>? _inscripciones = new();
        List<Usuario>? _usuarios = new();

        public InscripcionesView()
        {
            InitializeComponent();
            _ = GetAllData();
        }
        private async Task GetAllData()
        {
            await GetComboCapacitaciones();
            await GetGrillaUsuarios();
        }

        private async Task GetGrillaUsuarios()
        {
            _usuarios = (await _usuarioService.GetAllAsync())?.Where(u => _inscripciones != null && !_inscripciones.Any(i => i.UsuarioId == u.Id)).ToList();
            GridUsuarios.DataSource = _usuarios;
            //ocultar columnas Id, DeleteDate", "IsDeleted
            GridUsuarios.HideColumns("Id", "DeleteDate", "IsDeleted");

        }



        private async Task GetComboCapacitaciones()
        {
            var capacitaciones = await _capacitacionService.GetAllAsync();
            CmbCapacitacion.DataSource = capacitaciones?.Where(c => c.InscripcionAbierta).ToList();
            CmbCapacitacion.DisplayMember = "Nombre"; //que campo de esa lista se usa para mostrar
            CmbCapacitacion.ValueMember = "Id"; //que campo de esa lista se usa como valor
        }


        private async void CmbCapacitacion_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //controlamos que no sea null y haya una capacitacion seleccionada
            if (CmbCapacitacion.SelectedItem is Capacitacion selectedCapacitacion)
            {
                _inscripciones = await _inscripcionService.GetInscriptosAsync(selectedCapacitacion.Id);
                GridInscripciones.DataSource = _inscripciones;
                GridInscripciones.HideColumns("Id", "CapacitacionId", "TipoInscripcionId", "Capacitacion", "UsuarioId", "UsuarioCobroId", "IsDeleted");
                await GetGrillaUsuarios();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _usuarios = _usuarios?.Where(u => u.Nombre.Contains(TxtBuscarUsuarios.Text, StringComparison.OrdinalIgnoreCase)
            || u.Apellido.Contains(TxtBuscarUsuarios.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            GridUsuarios.DataSource = _usuarios;
        }

        private async void TxtBuscarUsuarios_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarUsuarios.Text))
            {
                await GetGrillaUsuarios();
            }
        }

        private void TxtBuscarUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnBuscar.PerformClick();
                e.Handled = true; // Evita el sonido de "ding" al presionar Enter
            }
        }
    }
}
