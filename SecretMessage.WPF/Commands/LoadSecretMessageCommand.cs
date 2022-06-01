using MVVMEssentials.Commands;
using SecretMessage.Core.Responses;
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
        private readonly HomeViewModel _homeViewModel;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;

        public LoadSecretMessageCommand(HomeViewModel homeViewModel, IGetSecretMessageQuery getSecretMessageQuery)
        {
            _homeViewModel = homeViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                SecretMessageResponse secretMessageResponse = await _getSecretMessageQuery.Execute();

                _homeViewModel.SecretMessage = secretMessageResponse.Message;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load secret message. Please check your information or try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
