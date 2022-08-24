using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
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
        private readonly AuthenticationStore _authenticationStore;

        public string Username => _authenticationStore.CurrentUser?.DisplayName ?? string.Empty;
        public string Email => _authenticationStore.CurrentUser?.Email ?? string.Empty;
        public bool IsEmailVerified => _authenticationStore.CurrentUser?.IsEmailVerified ?? false;

        public ICommand SendEmailVerificationEmailCommand { get; }
        public ICommand NavigateHomeCommand { get; }

        public ProfileDetailsViewModel(AuthenticationStore authenticationStore, INavigationService homeNavigationService)
        {
            _authenticationStore = authenticationStore;

            SendEmailVerificationEmailCommand = new SendEmailVerificationEmailCommand(authenticationStore);
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}
