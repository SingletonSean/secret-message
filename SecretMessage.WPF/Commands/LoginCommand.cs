using Firebase.Auth;
using MVVMEssentials.Commands;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public LoginCommand(LoginViewModel loginViewModel, FirebaseAuthProvider firebaseAuthProvider)
        {
            _loginViewModel = loginViewModel;
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(_loginViewModel.Email, _loginViewModel.Password);

                MessageBox.Show("Successfully logged in!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Login failed. Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
