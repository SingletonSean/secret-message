using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Application.Initialization;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddMainWindowExtensions
    {
        public static IHostBuilder AddMainWindow(this IHostBuilder host)
        {
            host.ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddSingleton<ApplicationInitializer>();

                serviceCollection.AddSingleton<MainViewModel>();

                serviceCollection.AddSingleton<MainWindow>((services) => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainViewModel>()
                });
            });

            return host;
        }
    }
}
