using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.ViewModels;

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
                        services.GetRequiredService<FirebaseAuthClient>(),
                        services.GetRequiredService<NavigationService<LoginViewModel>>()));

                serviceCollection.AddNavigationService<RegisterViewModel>();
            });

            return host;
        }
    }
}
