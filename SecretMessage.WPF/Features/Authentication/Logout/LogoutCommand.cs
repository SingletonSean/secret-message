using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;
using SecretMessage.WPF.Stores;

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

        public override void Execute(object? parameter)
        {
            _authenticationStore.Logout();

            _loginNavigationService.Navigate();
        }
    }
}
