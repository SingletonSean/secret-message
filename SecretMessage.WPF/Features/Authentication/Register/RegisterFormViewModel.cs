using Firebase.Auth;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class RegisterFormViewModel : ViewModelBase
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

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private bool _shouldSendVerificationEmail = true;
        public bool ShouldSendVerificationEmail
        {
            get
            {
                return _shouldSendVerificationEmail;
            }
            set
            {
                _shouldSendVerificationEmail = value;
                OnPropertyChanged(nameof(ShouldSendVerificationEmail));
            }
        }

        public ICommand SubmitCommand { get; }

        public ICommand NavigateLoginCommand { get; }

        public RegisterFormViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            SubmitCommand = new RegisterCommand(this, firebaseAuthProvider, loginNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
