using Microsoft.Extensions.DependencyInjection;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.Shared.Navigation
{
    public static class AddNavigationServiceExtensions
    {
        public static IServiceCollection AddNavigationService<TViewModel>(this IServiceCollection serviceCollection)
            where TViewModel : ViewModelBase
        {
            return serviceCollection.AddSingleton<NavigationService<TViewModel>>(
                (services) => new NavigationService<TViewModel>(
                    services.GetRequiredService<NavigationStore>(),
                    () => services.GetRequiredService<TViewModel>()));
        }
    }
}
