using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddHomePageExtensions
    {
        public static IHostBuilder AddHomePage(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<HomeViewModel>(
                    (services) => HomeViewModel.LoadViewModel(
                        services.GetRequiredService<AuthenticationStore>(),
                        services.GetRequiredService<CurrentUserStore>(),
                        services.GetRequiredService<IGetSecretMessageQuery>(),
                        services.GetRequiredService<NavigationService<ProfileViewModel>>(),
                        services.GetRequiredService<NavigationService<LoginViewModel>>()));

                serviceCollection.AddSingleton<NavigationService<HomeViewModel>>(
                    (services) => new NavigationService<HomeViewModel>(
                        services.GetRequiredService<NavigationStore>(),
                        () => services.GetRequiredService<HomeViewModel>()));
            });

            return host;
        }
    }
}
