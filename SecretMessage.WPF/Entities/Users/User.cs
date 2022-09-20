using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Entities.Users
{
    public class User
    {
        public FirebaseAuthLink Auth { get; }

        public string Id => Auth?.User?.LocalId;
        public string DisplayName => Auth?.User?.DisplayName;
        public string Email => Auth?.User?.Email;
        public bool IsEmailVerified => Auth?.User?.IsEmailVerified ?? false;
        public bool IsLoggedIn => (!Auth?.IsExpired()) ?? false;


        public User() { }

        public User(FirebaseAuthLink auth)
        {
            Auth = auth;
        }
    }
}
