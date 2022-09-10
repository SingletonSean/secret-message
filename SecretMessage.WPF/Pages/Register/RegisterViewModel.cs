using Firebase.Auth;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterFormViewModel RegisterFormViewModel { get; }

        public RegisterViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            RegisterFormViewModel = new RegisterFormViewModel(firebaseAuthProvider, loginNavigationService);
        }
    }
}
