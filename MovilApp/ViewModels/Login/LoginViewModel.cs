using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Storage;
using MovilApp.Views;

namespace MovilApp.ViewModels.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContraseña;

        [ObservableProperty]
        private bool estaDescargando;


        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public LoginViewModel()
        {

            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("AgoraMovilApp"); //fileUser... almacena cosas
            ChequearSiHayUsuarioAlmacenado();
            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            if (Application.Current?.MainPage is AgoraShell shell)
            {
                await Shell.Current.GoToAsync("//Registrarse");
            }
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            //_userRepository.DeleteUser(); // Descomentar para probar el login siempre
            //if la aplicación se ejecuta en android o iOS chequea si hay un usuario almacenado
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            try
            {
                if (_userRepository.UserExists())
                {
                    (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                    if (Application.Current?.MainPage is AgoraShell shell)
                    {
                        shell.SetLoginState(true);
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo leer el usuario almacenado: " + ex.Message, "Ok");
            }
        }

        private bool PermitirIniciarSesion()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion()
        {
            try
            {
                estaDescargando = true;

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);
                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    estaDescargando = false;
                    return;
                }

                if (recordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                if (Application.Current?.MainPage is AgoraShell shell)
                {
                    shell.SetLoginState(true);
                }
                EstaDescargando = false;


            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");

            }

        }
    }
}

