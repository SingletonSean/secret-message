using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;

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

                serviceCollection.AddNavigationService<HomeViewModel>();
            });

            return host;
        }
    }
}
