using SecretMessage.Core.Responses;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class LoadSecretMessageCommand : AsyncCommandBase
    {
        private readonly IViewSecretMessageViewModel _viewSecretMessageViewModel;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;
        private readonly CurrentUserStore _currentUserStore;
        private readonly IViewSecretMessageDbContextFactory _dbContextFactory;

        public LoadSecretMessageCommand(
            IViewSecretMessageViewModel viewSecretMessageViewModel,
            IGetSecretMessageQuery getSecretMessageQuery,
            CurrentUserStore currentUserStore,
            IViewSecretMessageDbContextFactory dbContextFactory)
        {
            _viewSecretMessageViewModel = viewSecretMessageViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
            _currentUserStore = currentUserStore;
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            if (!_currentUserStore.IsLoggedIn)
            {
                MessageBox.Show("You must login to view the secret message.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                SecretMessageResponse secretMessageResponse = await _getSecretMessageQuery.Execute();

                _viewSecretMessageViewModel.SecretMessage = secretMessageResponse.Message;

                ViewedSecretMessageDto viewedSecretMessageDto = new ViewedSecretMessageDto()
                {
                    Id = Guid.NewGuid(),
                    UserId = _currentUserStore.User?.Id ?? "",
                    Content = secretMessageResponse.Message,
                    DateViewed = DateTimeOffset.UtcNow,
                };

                using (IViewSecretMessageDbContext context = _dbContextFactory.Create())
                {
                    context.ViewedSecretMessages.Add(viewedSecretMessageDto);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load secret message. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
