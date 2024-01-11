using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Application.Database;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddSecretMessageDbContextExtensions
    {
        public static IHostBuilder AddSecretMessageDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, serviceCollection) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");

                serviceCollection.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                serviceCollection.AddSingleton<SecretMessageDbContextFactory>();
            });

            return host;
        }
    }
}
