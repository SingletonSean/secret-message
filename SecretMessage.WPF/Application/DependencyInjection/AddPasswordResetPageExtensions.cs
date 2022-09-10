using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.ViewModels;

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

                serviceCollection.AddNavigationService<PasswordResetViewModel>();
            });

            return host;
        }
    }
}
