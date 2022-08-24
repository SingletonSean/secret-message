using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public ProfileDetailsViewModel ProfileDetailsViewModel { get; }

        public ProfileViewModel(AuthenticationStore authenticationStore, INavigationService homeNavigationService)
        {
            ProfileDetailsViewModel = new ProfileDetailsViewModel(authenticationStore, homeNavigationService);
        }
    }
}
