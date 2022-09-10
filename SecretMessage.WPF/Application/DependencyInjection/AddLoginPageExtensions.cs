using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;

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

                serviceCollection.AddNavigationService<LoginViewModel>();
            });

            return host;
        }
    }
}
