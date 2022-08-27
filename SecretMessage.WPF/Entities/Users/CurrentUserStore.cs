using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Entities.Users
{
    public class CurrentUserStore
    {
        public User User { get; private set; }

        public CurrentUserStore()
        {
            User = new User();
        }

        public void UpdateAuth(FirebaseAuthLink auth)
        {
            User = new User(auth);
        }
    }
}
