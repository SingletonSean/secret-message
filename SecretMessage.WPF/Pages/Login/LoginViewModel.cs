using SecretMessage.WPF.Features.Authentication.Login;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using SecretMessage.WPF.Stores;

namespace SecretMessage.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginFormViewModel LoginFormViewModel { get; }

        public LoginViewModel(
            AuthenticationStore authenticationStore, 
            INavigationService registerNavigationService, 
            INavigationService homeNavigationService, 
            INavigationService passwordResetNavigationService)
        {
            LoginFormViewModel = new LoginFormViewModel(
                authenticationStore,
                registerNavigationService,
                homeNavigationService,
                passwordResetNavigationService);
        }
    }
}
