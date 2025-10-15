using System.Data;
using System.Threading.Tasks;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class TipoInscripcionView : Form
    {
        GenericService<TipoInscripcion> _tipoInscripcionService = new();
        TipoInscripcion _currentTipoInscripcion;
        List<TipoInscripcion>? _tiposInscripciones;

        public TipoInscripcionView()
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
                _tiposInscripciones = await _tipoInscripcionService.GetAllDeletedsAsync("");
            }

            else
            {
                _tiposInscripciones = await _tipoInscripcionService.GetAllAsync();
            }
            GridCapacitaciones.DataSource = _tiposInscripciones;
            GridCapacitaciones.Columns["Id"].Visible = false; // Ocultar la columna Capacitaciones
            GridCapacitaciones.Columns["IsDeleted"].Visible = false; // Ocultar la columna Eliminado

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
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            TipoInscripcion entidadAGuardar = new TipoInscripcion
            {
                Nombre = TxtNombre.Text,            
            };


            bool response = false;
            if (_currentTipoInscripcion != null)
            {
                response = await _tipoInscripcionService.UpdateAsync(entidadAGuardar);
            }
            else
            {
                var nuevaCapacitacion = await _tipoInscripcionService.AddAsync(entidadAGuardar);
                response = nuevaCapacitacion != null; //si es distinto de null es porque se guardo correctamente
            }
            if (response)
            {
                _currentTipoInscripcion = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Tipo de inscripción {entidadAGuardar.Nombre} guardada correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectedTab = TabPageLista;
            }
            else
            {
                MessageBox.Show("Error al guardar el tipo de inscripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya una capacitacion seleccionada
            if (GridCapacitaciones.RowCount > 0 && GridCapacitaciones.SelectedRows.Count > 0) //rowcount filas
            {
                _currentTipoInscripcion = (TipoInscripcion)GridCapacitaciones.SelectedRows[0].DataBoundItem; //dataBoundItem trae la capacitacion seleccionada
                TxtNombre.Text = _currentTipoInscripcion.Nombre;
                


                TabControl.SelectedTab = TabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de inscripcion a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
                  //  BtnBuscar.PerformClick();
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
                TipoInscripcion entitySelected = (TipoInscripcion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar el tipo de inscripción {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _tipoInscripcionService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Tipo inscripción {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el tipo de inscripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de inscripción para eliminarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TipoInscripcion entitySelected = (TipoInscripcion)GridCapacitaciones.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea restaurar este tipo de inscripcion {entitySelected.Nombre}?", "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)//en lo posible poner dentro de un try/catch
                {
                    if (await _tipoInscripcionService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Tipo de inscripción {entitySelected.Nombre} restaurada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar el tipo de inscripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de inscripción para restaurarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            GridCapacitaciones.DataSource = await _tipoInscripcionService.GetAllAsync(TxtBuscar.Text);
        }

        private void TxtBuscar_TextChanged_1(object sender, EventArgs e)
        {

        }
        //private void BtnBuscar_Click(object sender, EventArgs e)
        //{
        //    GridCapacitaciones.DataSource = _capacitaciones.Where(p => p.Nombre.ToUpper().Contains(TxtBuscar.Text.ToUpper())).ToList();
        //} busqueda con datos locales linq
    }
}
