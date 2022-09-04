using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddRegisterPageExtensions
    {
        public static IHostBuilder AddRegisterPage(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<RegisterViewModel>(
                    (services) => new RegisterViewModel(
                        services.GetRequiredService<FirebaseAuthProvider>(),
                        services.GetRequiredService<NavigationService<LoginViewModel>>()));

                serviceCollection.AddSingleton<NavigationService<RegisterViewModel>>(
                    (services) => new NavigationService<RegisterViewModel>(
                        services.GetRequiredService<NavigationStore>(),
                        () => services.GetRequiredService<RegisterViewModel>()));
            });

            return host;
        }
    }
}
