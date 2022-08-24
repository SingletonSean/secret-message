using MVVMEssentials.Commands;
using SecretMessage.Core.Responses;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
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

        public LoadSecretMessageCommand(IViewSecretMessageViewModel viewSecretMessageViewModel, IGetSecretMessageQuery getSecretMessageQuery)
        {
            _viewSecretMessageViewModel = viewSecretMessageViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
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
