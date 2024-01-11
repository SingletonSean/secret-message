using Firebase.Auth;
using SecretMessage.WPF.Shared.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class SendEmailVerificationEmailCommand : AsyncCommandBase
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public SendEmailVerificationEmailCommand(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                //await _firebaseAuthClient.SendEmailVerificationEmail();

                MessageBox.Show("Successfully sent email verification email. Check your email to verify.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send email verification email. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
