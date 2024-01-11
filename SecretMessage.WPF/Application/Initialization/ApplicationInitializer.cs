using Firebase.Auth;
using Microsoft.EntityFrameworkCore;
using SecretMessage.WPF.Application.Database;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Application.Initialization
{
    public class ApplicationInitializer
    {
        private readonly CurrentUserStore _currentUserStore;
        private readonly NavigationService<HomeViewModel> _homeNavigationService;
        private readonly NavigationService<LoginViewModel> _loginNavigationService;
        private readonly SecretMessageDbContextFactory _dbContextFactory;

        public ApplicationInitializer(
            CurrentUserStore currentUserStore,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<LoginViewModel> loginNavigationService,
            SecretMessageDbContextFactory dbContextFactory)
        {
            _currentUserStore = currentUserStore;
            _homeNavigationService = homeNavigationService;
            _loginNavigationService = loginNavigationService;
            _dbContextFactory = dbContextFactory;
        }

        public async Task Initialize()
        {
            try
            {
                using (SecretMessageDbContext context = _dbContextFactory.Create())
                {
                    await context.Database.MigrateAsync();
                }

                if (_currentUserStore.IsLoggedIn)
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
