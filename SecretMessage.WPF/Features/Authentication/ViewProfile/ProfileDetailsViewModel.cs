using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using SecretMessage.WPF.Stores;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class ProfileDetailsViewModel : ViewModelBase
    {
        private readonly CurrentUserStore _currentUserStore;

        public string Username => _currentUserStore.User?.DisplayName ?? string.Empty;
        public string Email => _currentUserStore.User?.Email ?? string.Empty;
        public bool IsEmailVerified => _currentUserStore.User?.IsEmailVerified ?? false;

        public ICommand SendEmailVerificationEmailCommand { get; }
        public ICommand NavigateHomeCommand { get; }

        public ProfileDetailsViewModel(
            AuthenticationStore authenticationStore,
            CurrentUserStore currentUserStore, 
            INavigationService homeNavigationService)
        {
            _currentUserStore = currentUserStore;

            SendEmailVerificationEmailCommand = new SendEmailVerificationEmailCommand(authenticationStore);
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}
