using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Shared.Navigation;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddNavigationExtensions
    {
        public static IHostBuilder AddNavigation(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<NavigationStore>();
                serviceCollection.AddSingleton<ModalNavigationStore>();
            });

            return host;
        }
    }
}
