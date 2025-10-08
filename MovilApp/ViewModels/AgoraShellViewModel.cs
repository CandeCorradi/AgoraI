using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovilApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.ViewModels
{
    public partial class AgoraShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool userIsLogged = false;       

        public IRelayCommand LogoutCommand { get; }

        public AgoraShellViewModel()
        {
            LogoutCommand = new RelayCommand(OnLogout); //metodo que se llama igual que la clase que no devuelve valores y se ejecuta siempre que la clase se instancia
            SetLoginState(false);
        }

        public void SetLoginState(bool isLoggedIn)
        {
            if (Application.Current?.MainPage is AgoraShell shell)
            {
                if (isLoggedIn)
                    shell.FlyoutBehavior = FlyoutBehavior.Flyout;
                else
                    shell.FlyoutBehavior = FlyoutBehavior.Disabled;

                UserIsLogged = isLoggedIn;
                if (isLoggedIn)
                    shell.GoToAsync("//MainPage");  // Cambio a MainPage (pantalla de inicio)
                else
                    shell.GoToAsync("//Login");
            }

        }

        private void OnLogout()
        {
            SetLoginState(false);
        }
    }
}
