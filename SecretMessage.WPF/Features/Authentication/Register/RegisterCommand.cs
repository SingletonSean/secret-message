using Firebase.Auth;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterFormViewModel _registerViewModel;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;
        private readonly INavigationService _loginNavigationService;

        public RegisterCommand(
            RegisterFormViewModel registerViewModel, 
            FirebaseAuthProvider firebaseAuthProvider, 
            INavigationService loginNavigationService)
        {
            _registerViewModel = registerViewModel;
            _firebaseAuthProvider = firebaseAuthProvider;
            _loginNavigationService = loginNavigationService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            string password = _registerViewModel.Password;
            string confirmPassword = _registerViewModel.ConfirmPassword;

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password must match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(
                    _registerViewModel.Email,
                    password,
                    _registerViewModel.Username,
                    _registerViewModel.ShouldSendVerificationEmail);

                MessageBox.Show("Successfully registered!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _loginNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Registration failed. Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
