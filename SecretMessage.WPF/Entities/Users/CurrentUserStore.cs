using Firebase.Auth;

namespace SecretMessage.WPF.Entities.Users
{
    public class CurrentUserStore
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public User? User { get; private set; }
        public bool IsLoggedIn => User != null;

        public CurrentUserStore(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;

            _firebaseAuthClient.AuthStateChanged += FirebaseAuthClient_AuthStateChanged;
        }

        private void FirebaseAuthClient_AuthStateChanged(object? sender, UserEventArgs e)
        {
            if (_firebaseAuthClient.User == null)
            {
                User = null;
            }
            else
            {
                User = new User(_firebaseAuthClient.User);
            }
        }
    }
}
