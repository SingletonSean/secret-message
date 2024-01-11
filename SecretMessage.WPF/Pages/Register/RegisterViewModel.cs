using Firebase.Auth;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterFormViewModel RegisterFormViewModel { get; }

        public RegisterViewModel(FirebaseAuthClient firebaseAuthClient, INavigationService loginNavigationService)
        {
            RegisterFormViewModel = new RegisterFormViewModel(firebaseAuthClient, loginNavigationService);
        }
    }
}
