using MVVMEssentials.Commands;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class SendEmailVerificationEmailCommand : AsyncCommandBase
    {
        private readonly AuthenticationStore _authenticationStore;

        public SendEmailVerificationEmailCommand(AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticationStore.SendEmailVerificationEmail();

                MessageBox.Show("Successfully sent email verification email. Check your email to verify.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send email verification email. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
