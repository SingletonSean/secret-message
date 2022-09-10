using Microsoft.Extensions.DependencyInjection;
using SecretMessage.WPF.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
