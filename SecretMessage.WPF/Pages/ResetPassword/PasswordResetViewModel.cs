using Firebase.Auth;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class PasswordResetViewModel : ViewModelBase
    {
        public PasswordResetFormViewModel PasswordResetFormViewModel { get; }

        public PasswordResetViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            PasswordResetFormViewModel = new PasswordResetFormViewModel(firebaseAuthProvider, loginNavigationService);
        }
    }
}
