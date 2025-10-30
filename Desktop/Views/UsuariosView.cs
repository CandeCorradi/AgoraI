using Desktop.ExtensionMethod;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Service.Enums;
using Service.Models;
using Service.Services;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        GenericService<Usuario> _usuarioService = new();
        Usuario _currentUsuario;
        List<Usuario>? _usuarios;
        FirebaseAuthClient _firebaseAuthClient;

        public UsuariosView()
        {
            InitializeComponent();
            _ = GetAllData();
            SettingFirebase();
            checkVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;
        }

        private void SettingFirebase()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            _firebaseAuthClient = new FirebaseAuthClient(config);
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
            GridUsuarios.Columns["DeleteDate"].Visible = false; // Ocultar la columna FechaEliminacion
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
            TxtPassword.Clear();
            TxtVerifyPassword.Clear();
            GetComboTiposDeUsuarios();
            LblPassword.Text = "Contraseña:";
            LblRepeatPassword.Text = "Repetir Contraseña:";
            TxtPassword.PlaceholderText = "Mínimo 6 caracteres";
            TxtVerifyPassword.PlaceholderText = "Mínimo 6 caracteres";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!DataControl())
                return;
            Usuario usuarioAGuardar = GetUserDataFromScreen();
            bool responseSuccessfull = false;
            if (_currentUsuario != null)//modificando un usuario existente
            {
                try
                {
                    responseSuccessfull = await _usuarioService.UpdateAsync(usuarioAGuardar);
                    if (responseSuccessfull && !string.IsNullOrWhiteSpace(TxtPassword.Text))
                        await UpdatePasswordInFirebase(usuarioAGuardar);// Actualizar pass en Firebase
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (_currentUsuario == null)//agregando un nuevo usuario
            {
                var nuevoUsuario = await _usuarioService.AddAsync(usuarioAGuardar);
                responseSuccessfull = nuevoUsuario != null;
                if (responseSuccessfull)
                    await CreateUserInFirebase(nuevoUsuario);// Crear el usuario en Firebase Authentication
            }

            if (!responseSuccessfull)
            {
                MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentUsuario = null; // Reset the modified movie after saving
            LabelStatusMessage.Text = $"Usuario {usuarioAGuardar.Nombre} guardado correctamente";
            TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
            await GetAllData();
            LimpiarControlesAgregarEditar();
            TabControl.SelectedTab = TabPageLista;

        }

        private async Task CreateUserInFirebase(Usuario? nuevoUsuario)
        {
            try
            {
                var userCredential = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(
                    nuevoUsuario.Email,
                    TxtPassword.Text.Trim(),
                    nuevoUsuario.Nombre + " " + nuevoUsuario.Apellido// Contraseña por defecto, se recomienda cambiarla luego
                );
                await SendVerificationEmailAsync(userCredential.User.GetIdTokenAsync().Result); // Enviar correo de verificación
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al crear el usuario en Firebase: {ex.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdatePasswordInFirebase(Usuario usuarioAGuardar)
        {
            try
            {
                var userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(
                    usuarioAGuardar.Email,
                    TxtPassword.Text.Trim()
                );
                await userCredential.User.ChangePasswordAsync(TxtVerifyPassword.Text.Trim());


            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al actualizar la contraseña en Firebase: {ex.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario GetUserDataFromScreen()
        {
            return new Usuario
            {
                Id = _currentUsuario?.Id ?? 0,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                TipoUsuario = (TipoUsuarioEnum)(CmbTiposDeUsuarios.SelectedItem ?? TipoUsuarioEnum.Asistente)
                //operador de coalescencia nula por si no hay nada seleccionado en el combo, asigna Asistente por defecto
            };
        }
       

        private bool DataControl()
        {
            // Validaciones simples
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtApellido.Text))
            {
                MessageBox.Show("El apellido no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                MessageBox.Show("El DNI no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("El email no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_currentUsuario == null && (TxtPassword.Text != TxtVerifyPassword.Text))
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_currentUsuario == null && (string.IsNullOrWhiteSpace(TxtPassword.Text) || string.IsNullOrWhiteSpace(TxtVerifyPassword.Text)))
            {
                MessageBox.Show("Debe completar el campo contraseña y verificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_currentUsuario != null && (string.IsNullOrWhiteSpace(TxtPassword.Text) && string.IsNullOrWhiteSpace(TxtVerifyPassword.Text))) //modificacion que no cambia la contraseña
            {
                return true;
            }

            if (_currentUsuario != null && (string.IsNullOrWhiteSpace(TxtPassword.Text) || string.IsNullOrWhiteSpace(TxtVerifyPassword.Text)))
            {
                MessageBox.Show("Para modificar la contraseña debe completar la contraseña anterior y nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((TxtPassword.Text.Length < 6) || (TxtVerifyPassword.Text.Length < 6))
            {
                MessageBox.Show("Las contraseñas deben tener al menos 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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

                LblPassword.Text = "Contraseña anterior:";
                LblRepeatPassword.Text = "Nueva contraseña:";
                TxtPassword.PlaceholderText = "Dejar en blanco para no modificar";
                TxtVerifyPassword.PlaceholderText = "Dejar en blanco para no modificar";
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
        public async Task SendVerificationEmailAsync(string idToken)
        {
            var FirebaseApiKey = Service.Properties.Resources.ApiKeyFirebase;
            var RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey; using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }

}
