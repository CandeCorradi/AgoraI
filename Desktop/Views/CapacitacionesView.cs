using System.Data;
using System.Threading.Tasks;
using Desktop.ExtensionMethod;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class CapacitacionesView : Form
    {
        GenericService<Capacitacion> _capacitacionService = new();
        GenericService<TipoInscripcion> _tipoInscripcionService = new();
        Capacitacion _currentCapacitacion;
        List<Capacitacion>? _capacitaciones;

        public CapacitacionesView()
        {
            InitializeComponent();
            _ = GetAllData();
            checkVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
        }

        private void DisplayHideControlsRestoreButton(object? sender, EventArgs e)
        {
            btnRestaurar.Visible = checkVerEliminados.Checked;
            TxtBuscar.Enabled = !checkVerEliminados.Checked;
            BtnBuscar.Enabled = !checkVerEliminados.Checked;
            BtnAgregar.Enabled = !checkVerEliminados.Checked;
            BtnModificar.Enabled = !checkVerEliminados.Checked;
            BtnEliminar.Enabled = !checkVerEliminados.Checked;

        }

        private async Task GetAllData()
        {
            if (checkVerEliminados.Checked)
            {
                _capacitaciones = await _capacitacionService.GetAllDeletedsAsync("");
            }

            else
            {
                _capacitaciones = await _capacitacionService.GetAllAsync();
            }
            GridCapacitaciones.DataSource = _capacitaciones;
            GridCapacitaciones.Columns["Id"].Visible = false; // Ocultar la columna Capacitaciones
            GridCapacitaciones.Columns["IsDeleted"].Visible = false; // Ocultar la columna Eliminado
            await GetComboTiposDeInscripciones();

        }

        private async Task GetComboTiposDeInscripciones()
        {
            CmbTiposInscripciones.DataSource = await _tipoInscripcionService.GetAllAsync();
            CmbTiposInscripciones.DisplayMember = "Nombre";
            CmbTiposInscripciones.ValueMember = "Id";
        }

        private void GridPeliculas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                //Capacitacion peliSeleccionada = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
                //FilmPicture.ImageLocation = peliSeleccionada.portada;
            }
        }


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlesAgregarEditar();
            TabControl.SelectedTab = TabPageAgregarEditar;
        }

        private void LimpiarControlesAgregarEditar()
        {
            TxtNombre.Clear();
            TxtPonente.Clear();
            dateTimeFechaHora.Value = DateTime.Now;
            checkInscripcionAbierta.Checked = false;
            numericCupo.Value = 1;
            TxtDetalle.Clear();
            GridTiposDeInscripciones.DataSource = null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            Capacitacion capacitacionAGuardar = new Capacitacion
            {
                Id = _currentCapacitacion?.Id ?? 0,
                Nombre = TxtNombre.Text,
                Detalle = TxtDetalle.Text,
                Ponente = TxtPonente.Text,
                FechaHora = dateTimeFechaHora.Value,
                Cupo = (int)numericCupo.Value, // int - conversion de tipos (typecast) para igualarlo y que se pueda asignar en el campo
                InscripcionAbierta = checkInscripcionAbierta.Checked
            };


            bool response = false;
            if (_currentCapacitacion != null)
            {
                response = await _capacitacionService.UpdateAsync(capacitacionAGuardar);
            }
            else
            {
                var nuevaCapacitacion = await _capacitacionService.AddAsync(capacitacionAGuardar);
                response = nuevaCapacitacion != null; //si es distinto de null es porque se guardo correctamente
            }
            if (response)
            {
                _currentCapacitacion = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Capacitación {capacitacionAGuardar.Nombre} guardada correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectedTab = TabPageLista;
            }
            else
            {
                MessageBox.Show("Error al guardar la capacitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya una capacitacion seleccionada
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0) //rowcount filas
            {
                _currentCapacitacion = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem; //dataBoundItem trae la capacitacion seleccionada
                TxtNombre.Text = _currentCapacitacion.Nombre;
                TxtDetalle.Text = _currentCapacitacion.Detalle;
                TxtPonente.Text = _currentCapacitacion.Ponente;
                dateTimeFechaHora.Value = _currentCapacitacion.FechaHora;
                numericCupo.Value = _currentCapacitacion.Cupo;
                checkInscripcionAbierta.Checked = _currentCapacitacion.InscripcionAbierta;


                TabControl.SelectedTab = TabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para modificarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //        BtnBuscar.PerformClick();
        }

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            //    LabelStatusMessage.Text = string.Empty;
            //    TimerStatusBar.Stop(); // Detener el temporizador después de mostrar el mensaje
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            //checheamos que haya peliculas seleccionadas
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                Capacitacion entitySelected = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar la capacitación {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _capacitacionService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Capacitación {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la capacitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para eliminarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();

        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkVerEliminados.Checked) return;

            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0)
            {
                Capacitacion entitySelected = (Capacitacion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea restaurar la capacitacion {entitySelected.Nombre}?", "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)//en lo posible poner dentro de un try/catch
                {
                    if (await _capacitacionService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Capacitación {entitySelected.Nombre} restaurada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar la capcitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para restaurarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            GridCapacitaciones.DataSource = await _capacitacionService.GetAllAsync(TxtBuscar.Text);
        }

        private void TxtBuscar_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            var tipoInscripcionCapacitacion = new TipoInscripcionCapacitacion
            {
                TipoInscripcionId = (int)CmbTiposInscripciones.SelectedValue,
                TipoInscripcion = (TipoInscripcion)CmbTiposInscripciones.SelectedItem,
                CapacitacionId = _currentCapacitacion?.Id ?? 0,
                Capacitacion = _currentCapacitacion,
                Costo = numericCosto.Value

            };
            _currentCapacitacion?.TiposDeInscripciones.Add(tipoInscripcionCapacitacion);
            GridTiposDeInscripciones.DataSource = null;
            GridTiposDeInscripciones.HideColumns("Id", "CapacitacionId", "Capacitacion", "TipoInscripcionId", "IsDeleted");
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            var tipoInscripcionCapacitacionSeleccionada = (TipoInscripcionCapacitacion)GridTiposDeInscripciones.SelectedRows[0].DataBoundItem;
            _currentCapacitacion?.TiposDeInscripciones.Remove(tipoInscripcionCapacitacionSeleccionada);
            GridTiposDeInscripciones.DataSource = _currentCapacitacion?.TiposDeInscripciones.ToList();
        }
    }
}
