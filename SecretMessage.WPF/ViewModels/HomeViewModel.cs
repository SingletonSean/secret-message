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

        public HomeViewModel(AuthenticationStore authenticationStore, IGetSecretMessageQuery getSecretMessageQuery)
        {
            _authenticationStore = authenticationStore;

            LoadSecretMessageCommand = new LoadSecretMessageCommand(this, getSecretMessageQuery);
        }

        public static HomeViewModel LoadViewModel(AuthenticationStore authenticationStore, IGetSecretMessageQuery getSecretMessageQuery)
        {
            HomeViewModel homeViewModel = new HomeViewModel(authenticationStore, getSecretMessageQuery);

            homeViewModel.LoadSecretMessageCommand.Execute(null);

            return homeViewModel;
        }
    }
}
