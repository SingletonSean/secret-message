using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Entities.Users;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddUserEntityExtensions
    {
        public static IHostBuilder AddUserEntity(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<CurrentUserStore>();
            });

            return host;
        }
    }
}
