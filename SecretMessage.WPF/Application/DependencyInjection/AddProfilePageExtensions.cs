using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;

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

                serviceCollection.AddNavigationService<ProfileViewModel>();
            });

            return host;
        }
    }
}
