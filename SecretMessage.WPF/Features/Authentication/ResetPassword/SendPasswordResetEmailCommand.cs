using Firebase.Auth;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class SendPasswordResetEmailCommand : AsyncCommandBase
    {
        private readonly PasswordResetFormViewModel _viewModel;
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly INavigationService _loginNavigationService;

        public SendPasswordResetEmailCommand(
            PasswordResetFormViewModel viewModel,
            FirebaseAuthClient firebaseAuthClient,
            INavigationService loginNavigationService)
        {
            _viewModel = viewModel;
            _firebaseAuthClient = firebaseAuthClient;
            _loginNavigationService = loginNavigationService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            string email = _viewModel.Email;

            try
            {
                await _firebaseAuthClient.ResetEmailPasswordAsync(email);

                MessageBox.Show("Successfully sent password reset email. Check your email to finish resetting your password.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _loginNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send password reset email. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
