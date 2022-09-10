using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using SecretMessage.WPF.Stores;
using System.Windows.Input;

namespace SecretMessage.WPF.Features.Authentication.Login
{
    public class LoginFormViewModel : ViewModelBase
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

        public LoginFormViewModel(
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
