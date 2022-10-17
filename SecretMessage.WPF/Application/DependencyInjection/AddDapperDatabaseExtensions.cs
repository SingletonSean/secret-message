using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Application.Database;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddDapperDatabaseExtensions
    {
        public static IHostBuilder AddDapperDatabase(this IHostBuilder host)
        {
            host.ConfigureServices((context, serviceCollection) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");

                serviceCollection.AddSingleton<SqliteDbConnectionFactory>(new SqliteDbConnectionFactory(connectionString));
                serviceCollection.AddSingleton<SqliteDbInitializer>();
            });

            return host;
        }
    }
}
