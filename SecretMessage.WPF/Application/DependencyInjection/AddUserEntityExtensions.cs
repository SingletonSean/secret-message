using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddUserEntityExtensions
    {
        public static IHostBuilder AddUserEntity(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<CurrentUserStore>();
            });

            return host;
        }
    }
}
