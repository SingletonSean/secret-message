using Dapper;
using SecretMessage.Core.Responses;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Database;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF.Commands
{
    public class LoadSecretMessageCommand : AsyncCommandBase
    {
        private const string INSERT_VIEWED_SECRET_MESSAGE_SQL = @"
            INSERT INTO
            ViewedSecretMessages (Id, UserId, Content, DateViewed)
            VALUES (@Id, @UserId, @Content, @DateViewed)";

        private readonly IViewSecretMessageViewModel _viewSecretMessageViewModel;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;
        private readonly CurrentUserStore _currentUserStore;
        private readonly SqliteDbConnectionFactory _dbConnectionFactory;

        public LoadSecretMessageCommand(
            IViewSecretMessageViewModel viewSecretMessageViewModel,
            IGetSecretMessageQuery getSecretMessageQuery,
            CurrentUserStore currentUserStore,
            SqliteDbConnectionFactory dbConnectionFactory)
        {
            _viewSecretMessageViewModel = viewSecretMessageViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
            _currentUserStore = currentUserStore;
            _dbConnectionFactory = dbConnectionFactory;
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

                using (IDbConnection database = _dbConnectionFactory.Connect())
                {
                    object parameters = new
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = _currentUserStore.User.Id,
                        Content = secretMessageResponse.Message,
                        DateViewed = DateTimeOffset.UtcNow
                    };

                    await database.ExecuteAsync(INSERT_VIEWED_SECRET_MESSAGE_SQL, parameters);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load secret message. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
