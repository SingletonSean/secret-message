using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Stores
{
    public class AuthenticationStore
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        private FirebaseAuthLink _currentFirebaseAuthLink;

        public User? CurrentUser => _currentFirebaseAuthLink?.User;

        public bool IsLoggedIn => (!_currentFirebaseAuthLink?.IsExpired()) ?? false;

        public AuthenticationStore(FirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        public async Task Initialize()
        {
            string firebaseAuthJson = Properties.Settings.Default.FirebaseAuth;

            if (string.IsNullOrEmpty(firebaseAuthJson))
            {
                return;
            }

            FirebaseAuth firebaseAuth = JsonSerializer.Deserialize<FirebaseAuth>(firebaseAuthJson);

            if (firebaseAuth == null)
            {
                return;
            }

            _currentFirebaseAuthLink = new FirebaseAuthLink(_firebaseAuthProvider, firebaseAuth);

            await GetFreshAuthAsync();
        }

        public async Task Login(string email, string password)
        {
            _currentFirebaseAuthLink = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);

            SaveAuthenticationState();
        }

        public void Logout()
        {
            _currentFirebaseAuthLink = null;

            ClearAuthenticationState();
        }

        public async Task<FirebaseAuthLink> GetFreshAuthAsync()
        {
            if (_currentFirebaseAuthLink == null)
            {
                return null;
            }

            _currentFirebaseAuthLink = await _currentFirebaseAuthLink.GetFreshAuthAsync();
            
            SaveAuthenticationState();

            return _currentFirebaseAuthLink;
        }

        private void SaveAuthenticationState()
        {
            string firebaseAuthLinkJson = JsonSerializer.Serialize(_currentFirebaseAuthLink);

            Properties.Settings.Default.FirebaseAuth = firebaseAuthLinkJson;
            Properties.Settings.Default.Save();
        }

        private void ClearAuthenticationState()
        {
            Properties.Settings.Default.FirebaseAuth = null;
            Properties.Settings.Default.Save();
        }
    }
}
