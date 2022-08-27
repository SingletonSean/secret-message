using Firebase.Auth;
using SecretMessage.WPF.Entities.Users;
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
        private readonly CurrentUserStore _currentUserStore;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public AuthenticationStore(CurrentUserStore currentUserStore, FirebaseAuthProvider firebaseAuthProvider)
        {
            _currentUserStore = currentUserStore;
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

            _currentUserStore.UpdateAuth(new FirebaseAuthLink(_firebaseAuthProvider, firebaseAuth));

            await GetFreshAuthAsync();
        }

        public async Task Login(string email, string password)
        {
            _currentUserStore.UpdateAuth(await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password));
            
            SaveAuthenticationState();
        }

        public void Logout()
        {
            _currentUserStore.UpdateAuth(null);

            ClearAuthenticationState();
        }

        public async Task<FirebaseAuthLink> GetFreshAuthAsync()
        {
            if (_currentUserStore.User.Auth == null)
            {
                return null;
            }

            _currentUserStore.UpdateAuth(await _currentUserStore.User.Auth.GetFreshAuthAsync());
            
            SaveAuthenticationState();

            return _currentUserStore.User.Auth;
        }

        public async Task SendEmailVerificationEmail()
        {
            if (_currentUserStore.User.Auth == null)
            {
                throw new Exception("User is not authenticated.");
            }

            await GetFreshAuthAsync();

            await _firebaseAuthProvider.SendEmailVerificationAsync(_currentUserStore.User.Auth.FirebaseToken);
        }

        private void SaveAuthenticationState()
        {
            string firebaseAuthLinkJson = JsonSerializer.Serialize(_currentUserStore.User.Auth);

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
