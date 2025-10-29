using System.Data;
using System.Threading.Tasks;
using Desktop.ExtensionMethod;
using Service.Enums;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        GenericService<Usuario> _usuarioService = new();
        Usuario _currentUsuario;
        List<Usuario>? _usuarios;

        public UsuariosView()
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
                _usuarios = await _usuarioService.GetAllDeletedsAsync("");
            }

            else
            {
                _usuarios = await _usuarioService.GetAllAsync();
            }
            GridUsuarios.DataSource = _usuarios;
            GridUsuarios.Columns["Id"].Visible = false; // Ocultar la columna Usuarios
            GridUsuarios.Columns["IsDeleted"].Visible = false; // Ocultar la columna Eliminado
            GetComboTiposDeUsuarios();

        }

        private void GetComboTiposDeUsuarios()
        {
            //cargo el combo de tipos de usuarios
            CmbTiposDeUsuarios.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
        }

        private void GridPeliculas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (GridUsuarios.RowCount > 0 && GridUsuarios.SelectedRows.Count > 0)
            {
                //Capacitacion peliSeleccionada = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
                //FilmPicture.ImageLocation = peliSeleccionada.portada;
                //para mostrar imagenes seleccionadas
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
            TxtDni.Clear();
            TxtApellido.Clear();
            TxtEmail.Clear();
            GetComboTiposDeUsuarios();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuarioAGuardar = new Usuario
            {
                Id = _currentUsuario?.Id ?? 0,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                TipoUsuario = (TipoUsuarioEnum)(CmbTiposDeUsuarios.SelectedItem?? TipoUsuarioEnum.Asistente) 
                //operador de coalescencia nula por si no hay nada seleccionado en el combo, asigna asistente por defecto
            };


            bool response = false;
            if (_currentUsuario != null)
            {
                response = await _usuarioService.UpdateAsync(usuarioAGuardar);
            }
            else
            {
                var nuevoUsuario = await _usuarioService.AddAsync(usuarioAGuardar);
                response = nuevoUsuario != null; //si es distinto de null es porque se guardo correctamente
            }
            if (response)
            {
                _currentUsuario = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Usuario {usuarioAGuardar.Nombre} guardado correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectedTab = TabPageLista;
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya una capacitacion seleccionada
            if (GridUsuarios.RowCount > 0 && GridUsuarios.SelectedRows.Count > 0) //rowcount filas
            {
                _currentUsuario = (Usuario)GridUsuarios.SelectedRows[0].DataBoundItem; //dataBoundItem trae el usuario seleccionado
                TxtNombre.Text = _currentUsuario.Nombre;
                TxtApellido.Text = _currentUsuario.Apellido;
                TxtDni.Text = _currentUsuario.Dni;
                TxtEmail.Text = _currentUsuario.Email;
                CmbTiposDeUsuarios.SelectedItem = _currentUsuario.TipoUsuario;


                TabControl.SelectedTab = TabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a modificarl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (GridUsuarios.RowCount > 0 && GridUsuarios.SelectedRows.Count > 0)
            {
                Usuario entitySelected = (Usuario)GridUsuarios.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar el usuario {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _usuarioService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} eliminado correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();

        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkVerEliminados.Checked) return;

            if (GridUsuarios.RowCount > 0 && GridUsuarios.SelectedRows.Count > 0)
            {
                Usuario entitySelected = (Usuario)GridUsuarios.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea restaurar al usuario {entitySelected.Nombre}?", "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)//en lo posible poner dentro de un try/catch
                {
                    if (await _usuarioService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} restaurado correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para restaurarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            GridUsuarios.DataSource = await _usuarioService.GetAllAsync(TxtBuscar.Text); //busca sobre los valores cargados en la grilla
        }

        private void TxtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
