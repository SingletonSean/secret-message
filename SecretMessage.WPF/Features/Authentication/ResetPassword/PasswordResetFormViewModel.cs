using Firebase.Auth;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class PasswordResetFormViewModel : ViewModelBase
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

        public ICommand SendPasswordResetEmailCommand { get; }

        public ICommand NavigateLoginCommand { get; }

        public PasswordResetFormViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            SendPasswordResetEmailCommand = new SendPasswordResetEmailCommand(this, firebaseAuthProvider, loginNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
