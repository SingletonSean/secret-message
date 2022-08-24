using Firebase.Auth;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class SendPasswordResetEmailCommand : AsyncCommandBase
    {
        private readonly PasswordResetFormViewModel _viewModel;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;
        private readonly INavigationService _loginNavigationService;

        public SendPasswordResetEmailCommand(
            PasswordResetFormViewModel viewModel, 
            FirebaseAuthProvider firebaseAuthProvider, 
            INavigationService loginNavigationService)
        {
            _viewModel = viewModel;
            _firebaseAuthProvider = firebaseAuthProvider;
            _loginNavigationService = loginNavigationService;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            string email = _viewModel.Email;

            try
            {
                await _firebaseAuthProvider.SendPasswordResetEmailAsync(email);

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
