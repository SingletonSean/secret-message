using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;
using SecretMessage.WPF.Stores;

namespace SecretMessage.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public ProfileDetailsViewModel ProfileDetailsViewModel { get; }

        public ProfileViewModel(AuthenticationStore authenticationStore, 
            CurrentUserStore currentUserStore,
            INavigationService homeNavigationService)
        {
            ProfileDetailsViewModel = new ProfileDetailsViewModel(authenticationStore, currentUserStore, homeNavigationService);
        }
    }
}
