using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Application.Initialization;
using SecretMessage.WPF.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddMainWindowExtensions
    {
        public static IHostBuilder AddMainWindow(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<ApplicationInitializer>();

                serviceCollection.AddSingleton<MainViewModel>();

                serviceCollection.AddSingleton<MainWindow>((services) => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainViewModel>()
                });
            });

            return host;
        }
    }
}
