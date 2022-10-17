using Firebase.Auth;
using SecretMessage.WPF.Application.Database;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
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
        private readonly SqliteDbInitializer _dbInitializer;

        public ApplicationInitializer(
            AuthenticationStore authenticationStore,
            CurrentUserStore currentUserStore,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<LoginViewModel> loginNavigationService,
            SqliteDbInitializer dbInitializer)
        {
            _authenticationStore = authenticationStore;
            _currentUserStore = currentUserStore;
            _homeNavigationService = homeNavigationService;
            _loginNavigationService = loginNavigationService;
            _dbInitializer = dbInitializer;
        }

        public async Task Initialize()
        {
            try
            {
                await _dbInitializer.Initialize();

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
