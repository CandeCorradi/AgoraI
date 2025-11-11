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
            var GetComboTask = GetComboCapacitaciones();
            var GetGrillaTask = GetGrillaUsuarios();
            await Task.WhenAll(GetComboTask, GetGrillaTask);
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
                RefreshInscripciones(selectedCapacitacion);
                GetComboTiposDeInscripciones(selectedCapacitacion);

            }
        }

        private void GetComboTiposDeInscripciones(Capacitacion selectedCapacitacion)
        {
            CmbTipoInscripcion.DataSource = selectedCapacitacion.TiposDeInscripciones.ToList();
            CmbTipoInscripcion.DisplayMember = "TipoInscripcion"; //que campo de esa lista se usa para mostrar
            CmbTipoInscripcion.ValueMember = "TipoInscripcionId"; //que campo de esa lista se usa como valor
            CmbTipoInscripcion.SelectedIndex = -1;
        }

        private async void RefreshInscripciones(Capacitacion selectedCapacitacion)
        {
            _inscripciones = selectedCapacitacion.Inscripciones.ToList();
            //_inscripciones = await _inscripcionService.GetInscriptosAsync(selectedCapacitacion.Id);
            GridInscripciones.DataSource = _inscripciones;
            //ocultamos las columnas Id, UsuarioId, TipoInscripcionId,CapacitacionId, Capacitacion
            GridInscripciones.HideColumns("Id", "UsuarioId", "TipoInscripcionId", "CapacitacionId", "Capacitacion", "UsuarioCobroId", "IsDeleted", "UsuarioCobro", "Pagado");
            if (GridInscripciones.Columns.Contains("Importe"))
            {
                GridInscripciones.Columns["Importe"].DefaultCellStyle.Format = "C2";
                GridInscripciones.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }


            await GetGrillaUsuarios();
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

        private async void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            //si no hay un usuario seleccionado advierte y sale
            if (GridUsuarios.CurrentRow?.DataBoundItem is not Usuario selectedUsuario)
            {
                MessageBox.Show("Seleccione un usuario para inscribir.");
                return;
            }
            //si no hay una capacitación seleccionada advierte y sale
            if (CmbCapacitacion.SelectedItem is not Capacitacion selectedCapacitacion)
            {
                MessageBox.Show("Seleccione una capacitación para inscribir el usuario.");
                return;
            }
            //si no hay un tipo de inscripción seleccionado advierte y sale
            if (CmbTipoInscripcion.SelectedItem is not TipoInscripcionCapacitacion selectedTipoInscripcion)
            {
                MessageBox.Show("Seleccione un tipo de inscripción para el usuario.");
                return;
            }
            var nuevaInscripcion = new Inscripcion
            {
                UsuarioId = selectedUsuario.Id,
                Usuario = selectedUsuario,
                Importe = selectedTipoInscripcion.Costo,
                CapacitacionId = selectedCapacitacion.Id,
                TipoInscripcionId = selectedTipoInscripcion.TipoInscripcionId,
                TipoInscripcion = selectedTipoInscripcion.TipoInscripcion,
                UsuarioCobroId = null // Asignar el ID del usuario que realiza el cobro si es necesario
            };
            selectedCapacitacion.Inscripciones.Add(nuevaInscripcion);
            RefreshInscripciones(selectedCapacitacion);
            try
            {
                await _capacitacionService.UpdateAsync(selectedCapacitacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inscribir el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
