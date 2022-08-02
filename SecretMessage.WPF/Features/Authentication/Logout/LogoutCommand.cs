using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using SecretMessage.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly INavigationService _loginNavigationService;

        public LogoutCommand(AuthenticationStore authenticationStore, INavigationService loginNavigationService)
        {
            _authenticationStore = authenticationStore;
            _loginNavigationService = loginNavigationService;
        }

        public override void Execute(object parameter)
        {
            _authenticationStore.Logout();

            _loginNavigationService.Navigate();
        }
    }
}
