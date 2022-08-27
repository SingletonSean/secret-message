using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
