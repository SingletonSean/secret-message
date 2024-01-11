using Firebase.Auth;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public ProfileDetailsViewModel ProfileDetailsViewModel { get; }

        public ProfileViewModel(FirebaseAuthClient firebaseAuthClient,
            CurrentUserStore currentUserStore,
            INavigationService homeNavigationService)
        {
            ProfileDetailsViewModel = new ProfileDetailsViewModel(firebaseAuthClient, currentUserStore, homeNavigationService);
        }
    }
}
