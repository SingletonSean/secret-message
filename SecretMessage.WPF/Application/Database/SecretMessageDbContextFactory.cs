using Microsoft.EntityFrameworkCore;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;

namespace SecretMessage.WPF.Application.Database
{
    public class SecretMessageDbContextFactory : IViewSecretMessageDbContextFactory
    {
        private readonly DbContextOptions _options;

        public SecretMessageDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public SecretMessageDbContext Create()
        {
            return new SecretMessageDbContext(_options);
        }

        IViewSecretMessageDbContext IViewSecretMessageDbContextFactory.Create()
        {
            return Create();
        }
    }
}
