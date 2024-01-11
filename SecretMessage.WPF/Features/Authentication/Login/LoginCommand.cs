using Firebase.Auth;
using SecretMessage.WPF.Features.Authentication.Login;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginFormViewModel _loginViewModel;
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly INavigationService _homeNavigationService;

        public LoginCommand(
            LoginFormViewModel loginViewModel,
            FirebaseAuthClient firebaseAuthClient,
            INavigationService homeNavigationService)
        {
            _loginViewModel = loginViewModel;
            _firebaseAuthClient = firebaseAuthClient;
            _homeNavigationService = homeNavigationService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(_loginViewModel.Email, _loginViewModel.Password);

                MessageBox.Show("Successfully logged in!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _homeNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Login failed. Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
