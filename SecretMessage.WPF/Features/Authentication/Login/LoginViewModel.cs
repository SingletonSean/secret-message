using Firebase.Auth;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
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
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SubmitCommand { get; }

        public ICommand NavigateRegisterCommand { get; }

        public ICommand NavigatePasswordResetCommand { get; }

        public LoginViewModel(
            AuthenticationStore authenticationStore, 
            INavigationService registerNavigationService, 
            INavigationService homeNavigationService, 
            INavigationService passwordResetNavigationService)
        {
            SubmitCommand = new LoginCommand(this, authenticationStore, homeNavigationService);
            NavigateRegisterCommand = new NavigateCommand(registerNavigationService);
            NavigatePasswordResetCommand = new NavigateCommand(passwordResetNavigationService);
        }
    }
}
