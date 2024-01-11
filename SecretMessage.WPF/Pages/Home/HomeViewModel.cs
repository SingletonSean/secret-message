﻿using Firebase.Auth;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
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
            FirebaseAuthClient firebaseAuthClient,
            CurrentUserStore currentUserStore,
            IGetSecretMessageQuery getSecretMessageQuery,
            INavigationService profileNavigationService,
            INavigationService loginNavigationService,
            IViewSecretMessageDbContextFactory dbContextFactory)
        {
            _currentUserStore = currentUserStore;

            LoadSecretMessageCommand = new LoadSecretMessageCommand(this, getSecretMessageQuery, currentUserStore, dbContextFactory);
            NavigateProfileCommand = new NavigateCommand(profileNavigationService);
            LogoutCommand = new LogoutCommand(firebaseAuthClient, loginNavigationService);
        }

        public static HomeViewModel LoadViewModel(
            FirebaseAuthClient firebaseAuthClient,
            CurrentUserStore currentUserStore,
            IGetSecretMessageQuery getSecretMessageQuery,
            INavigationService profileNavigationService,
            INavigationService loginNavigationService,
            IViewSecretMessageDbContextFactory dbContextFactory)
        {
            HomeViewModel homeViewModel = new HomeViewModel(firebaseAuthClient, currentUserStore, getSecretMessageQuery, profileNavigationService, loginNavigationService, dbContextFactory);

            homeViewModel.LoadSecretMessageCommand.Execute(null);

            return homeViewModel;
        }
    }
}
