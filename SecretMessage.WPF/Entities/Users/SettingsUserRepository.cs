using Firebase.Auth;
using Firebase.Auth.Repository;
using System;
using System.Text.Json;

namespace SecretMessage.WPF.Entities.Users
{
    public class SettingsUserRepository : IUserRepository
    {
        public (UserInfo? userInfo, FirebaseCredential? credential) ReadUser()
        {
            string userInfoJson = Properties.Settings.Default.UserInfo;
            string userCredentialJson = Properties.Settings.Default.UserCredential;

            try
            {
                UserInfo userInfo = JsonSerializer.Deserialize<UserInfo>(userInfoJson);
                FirebaseCredential userCredential = JsonSerializer.Deserialize<FirebaseCredential>(userCredentialJson);

                return (userInfo, userCredential);
            }
            catch (Exception)
            {
                return (null, null);
            }
        }

        public void SaveUser(Firebase.Auth.User user)
        {
            try
            {
                string userInfoJson = JsonSerializer.Serialize(user.Info);
                string userCredentialJson = JsonSerializer.Serialize(user.Credential);

                Properties.Settings.Default.UserInfo = userInfoJson;
                Properties.Settings.Default.UserCredential = userCredentialJson;

                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

            }
        }

        public bool UserExists()
        {
            (UserInfo userInfo, FirebaseCredential credential) = ReadUser();

            return userInfo != null && credential != null;
        }

        public void DeleteUser()
        {
            try
            {
                Properties.Settings.Default.UserInfo = null;
                Properties.Settings.Default.UserCredential = null;

                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

            }
        }
    }
}
