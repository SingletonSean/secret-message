using Firebase.Auth;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Features.Authentication.Login;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
