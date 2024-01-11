namespace SecretMessage.WPF.Entities.Users
{
    public class User
    {
        private readonly Firebase.Auth.User _user;

        public string Id => _user?.Uid;
        public string DisplayName => _user?.Info?.DisplayName;
        public string Email => _user?.Info?.Email;
        public bool IsEmailVerified => _user?.Info?.IsEmailVerified ?? false;
        public bool IsCredentialExpired => (!_user?.Credential?.IsExpired()) ?? false;

        public User(Firebase.Auth.User user)
        {
            _user = user;
        }
    }
}
