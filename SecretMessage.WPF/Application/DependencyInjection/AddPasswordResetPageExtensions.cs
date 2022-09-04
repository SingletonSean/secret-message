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
    public static class AddPasswordResetPageExtensions
    {
        public static IHostBuilder AddPasswordResetPage(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            { 
                serviceCollection.AddTransient<PasswordResetViewModel>(
                    (services) => new PasswordResetViewModel(
                        services.GetRequiredService<FirebaseAuthProvider>(),
                        services.GetRequiredService<NavigationService<LoginViewModel>>()));

                serviceCollection.AddSingleton<NavigationService<PasswordResetViewModel>>(
                    (services) => new NavigationService<PasswordResetViewModel>(
                        services.GetRequiredService<NavigationStore>(),
                        () => services.GetRequiredService<PasswordResetViewModel>()));
            });

            return host;
        }
    }
}
