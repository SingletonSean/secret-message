using Firebase.Auth;
using SecretMessage.WPF.Shared.Commands;
using SecretMessage.WPF.Shared.Navigation;

namespace SecretMessage.WPF.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        private readonly INavigationService _loginNavigationService;

        public LogoutCommand(FirebaseAuthClient firebaseAuthClient, INavigationService loginNavigationService)
        {
            _firebaseAuthClient = firebaseAuthClient;
            _loginNavigationService = loginNavigationService;
        }

        public override void Execute(object? parameter)
        {
            _firebaseAuthClient.SignOut();

            _loginNavigationService.Navigate();
        }
    }
}
