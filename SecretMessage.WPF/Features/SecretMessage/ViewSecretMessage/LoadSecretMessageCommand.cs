using SecretMessage.Core.Responses;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class LoadSecretMessageCommand : AsyncCommandBase
    {
        private readonly IViewSecretMessageViewModel _viewSecretMessageViewModel;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;
        private readonly CurrentUserStore _currentUserStore;

        public LoadSecretMessageCommand(
            IViewSecretMessageViewModel viewSecretMessageViewModel,
            IGetSecretMessageQuery getSecretMessageQuery,
            CurrentUserStore currentUserStore)
        {
            _viewSecretMessageViewModel = viewSecretMessageViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
            _currentUserStore = currentUserStore;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            if(!_currentUserStore.User.IsLoggedIn)
            {
                MessageBox.Show("You must login to view the secret message.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                SecretMessageResponse secretMessageResponse = await _getSecretMessageQuery.Execute();

                _viewSecretMessageViewModel.SecretMessage = secretMessageResponse.Message;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load secret message. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
