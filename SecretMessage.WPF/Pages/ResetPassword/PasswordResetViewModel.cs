using Firebase.Auth;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class PasswordResetViewModel : ViewModelBase
    {
        public PasswordResetFormViewModel PasswordResetFormViewModel { get; }

        public PasswordResetViewModel(FirebaseAuthClient firebaseAuthClient, INavigationService loginNavigationService)
        {
            PasswordResetFormViewModel = new PasswordResetFormViewModel(firebaseAuthClient, loginNavigationService);
        }
    }
}
