using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly AuthenticationStore _authenticationStore;

        public string Username => _authenticationStore.CurrentUser?.DisplayName ?? "Unknown";

        private string _secretMessage;
        public string SecretMessage
        {
            get
            {
                return _secretMessage;
            }
            set
            {
                _secretMessage = value;
                OnPropertyChanged(nameof(SecretMessage));
            }
        }

        public ICommand LoadSecretMessageCommand { get; }
        public ICommand LogoutCommand { get; }

        public HomeViewModel(
            AuthenticationStore authenticationStore, 
            IGetSecretMessageQuery getSecretMessageQuery, 
            INavigationService loginNavigationService)
        {
            _authenticationStore = authenticationStore;

            LoadSecretMessageCommand = new LoadSecretMessageCommand(this, getSecretMessageQuery);
            LogoutCommand = new LogoutCommand(authenticationStore, loginNavigationService);
        }

        public static HomeViewModel LoadViewModel(
            AuthenticationStore authenticationStore, 
            IGetSecretMessageQuery getSecretMessageQuery,
            INavigationService loginNavigationService)
        {
            HomeViewModel homeViewModel = new HomeViewModel(authenticationStore, getSecretMessageQuery, loginNavigationService);

            homeViewModel.LoadSecretMessageCommand.Execute(null);

            return homeViewModel;
        }
    }
}
