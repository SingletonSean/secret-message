using Firebase.Auth;
using MVVMEssentials.Services;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Application.Initialization
{
    public class ApplicationInitializer
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly CurrentUserStore _currentUserStore;
        private readonly NavigationService<HomeViewModel> _homeNavigationService;
        private readonly NavigationService<LoginViewModel> _loginNavigationService;

        public ApplicationInitializer(
            AuthenticationStore authenticationStore, 
            CurrentUserStore currentUserStore, 
            NavigationService<HomeViewModel> homeNavigationService, 
            NavigationService<LoginViewModel> loginNavigationService)
        {
            _authenticationStore = authenticationStore;
            _currentUserStore = currentUserStore;
            _homeNavigationService = homeNavigationService;
            _loginNavigationService = loginNavigationService;
        }

        public async Task Initialize()
        {
            try
            {
                await _authenticationStore.Initialize();

                if (_currentUserStore.User.IsLoggedIn)
                {
                    _homeNavigationService.Navigate();
                }
                else
                {
                    _loginNavigationService.Navigate();
                }
            }
            catch (FirebaseAuthException)
            {
                _loginNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load application.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
