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
    public static class AddProfilePageExtensions
    {
        public static IHostBuilder AddProfilePage(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<ProfileViewModel>(
                    (services) => new ProfileViewModel(
                        services.GetRequiredService<AuthenticationStore>(),
                        services.GetRequiredService<CurrentUserStore>(),
                        services.GetRequiredService<NavigationService<HomeViewModel>>()));

                serviceCollection.AddSingleton<NavigationService<ProfileViewModel>>(
                    (services) => new NavigationService<ProfileViewModel>(
                        services.GetRequiredService<NavigationStore>(),
                        () => services.GetRequiredService<ProfileViewModel>()));
            });

            return host;
        }
    }
}
