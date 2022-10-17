using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Database;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using SecretMessage.WPF.Stores;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase, IViewSecretMessageViewModel
    {
        private readonly CurrentUserStore _currentUserStore;

        public string Username => _currentUserStore.User?.DisplayName ?? "Unknown";

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
        public ICommand NavigateProfileCommand { get; }
        public ICommand LogoutCommand { get; }

        public HomeViewModel(
            AuthenticationStore authenticationStore, 
            CurrentUserStore currentUserStore,
            IGetSecretMessageQuery getSecretMessageQuery,
            INavigationService profileNavigationService,
            INavigationService loginNavigationService,
            SqliteDbConnectionFactory dbConnectionFactory)
        {
            _currentUserStore = currentUserStore;

            LoadSecretMessageCommand = new LoadSecretMessageCommand(this, getSecretMessageQuery, currentUserStore, dbConnectionFactory);
            NavigateProfileCommand = new NavigateCommand(profileNavigationService);
            LogoutCommand = new LogoutCommand(authenticationStore, loginNavigationService);
        }

        public static HomeViewModel LoadViewModel(
            AuthenticationStore authenticationStore, 
            CurrentUserStore currentUserStore,
            IGetSecretMessageQuery getSecretMessageQuery,
            INavigationService profileNavigationService,
            INavigationService loginNavigationService,
            SqliteDbConnectionFactory dbConnectionFactory)
        {
            HomeViewModel homeViewModel = new HomeViewModel(
                authenticationStore, 
                currentUserStore, 
                getSecretMessageQuery, 
                profileNavigationService, 
                loginNavigationService, 
                dbConnectionFactory);

            homeViewModel.LoadSecretMessageCommand.Execute(null);

            return homeViewModel;
        }
    }
}
