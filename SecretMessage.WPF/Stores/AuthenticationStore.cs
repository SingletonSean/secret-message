using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Stores
{
    public class AuthenticationStore
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        private FirebaseAuthLink _currentFirebaseAuthLink;

        public AuthenticationStore(FirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        public User? CurrentUser => _currentFirebaseAuthLink?.User;

        public async Task Login(string email, string password)
        {
            _currentFirebaseAuthLink = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
        }

        public void Logout()
        {
            _currentFirebaseAuthLink = null;
        }

        public async Task<FirebaseAuthLink> GetFreshAuthAsync()
        {
            if (_currentFirebaseAuthLink == null)
            {
                return null;
            }

            return await _currentFirebaseAuthLink.GetFreshAuthAsync();
        }
    }
}
