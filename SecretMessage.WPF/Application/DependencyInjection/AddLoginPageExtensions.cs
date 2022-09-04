using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddLoginPageExtensions
    {
        public static IHostBuilder AddLoginPage(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<LoginViewModel>(
                    (services) => new LoginViewModel(
                        services.GetRequiredService<AuthenticationStore>(),
                        services.GetRequiredService<NavigationService<RegisterViewModel>>(),
                        services.GetRequiredService<NavigationService<HomeViewModel>>(),
                        services.GetRequiredService<NavigationService<PasswordResetViewModel>>()));

                serviceCollection.AddSingleton<NavigationService<LoginViewModel>>(
                    (services) => new NavigationService<LoginViewModel>(
                        services.GetRequiredService<NavigationStore>(),
                        () => services.GetRequiredService<LoginViewModel>()));
            });

            return host;
        }
    }
}
