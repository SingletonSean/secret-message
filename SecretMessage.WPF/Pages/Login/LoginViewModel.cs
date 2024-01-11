using Firebase.Auth;
using SecretMessage.WPF.Features.Authentication.Login;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginFormViewModel LoginFormViewModel { get; }

        public LoginViewModel(
            FirebaseAuthClient firebaseAuthClient,
            INavigationService registerNavigationService,
            INavigationService homeNavigationService,
            INavigationService passwordResetNavigationService)
        {
            LoginFormViewModel = new LoginFormViewModel(
                firebaseAuthClient,
                registerNavigationService,
                homeNavigationService,
                passwordResetNavigationService);
        }
    }
}
