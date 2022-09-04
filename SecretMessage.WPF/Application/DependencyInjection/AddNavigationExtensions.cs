using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Stores;
using SecretMessage.WPF.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddNavigationExtensions
    {
        public static IHostBuilder AddNavigation(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<NavigationStore>();
                serviceCollection.AddSingleton<ModalNavigationStore>();
            });

            return host;
        }
    }
}
