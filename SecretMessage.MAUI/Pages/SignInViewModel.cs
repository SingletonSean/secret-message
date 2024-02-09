using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Refit;
using SecretMessage.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.MAUI.Pages
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public string Username => _authClient.User?.Info?.DisplayName;

        [ObservableProperty]
        private string _secretMessage;

        public SignInViewModel(FirebaseAuthClient authClient, IGetSecretMessageQuery getSecretMessageQuery)
        {
            _authClient = authClient;
            _getSecretMessageQuery = getSecretMessageQuery;

            _getSecretMessageQuery.Execute().ContinueWith(response =>
            {
                SecretMessage = response?.Result?.Message ?? "";
            });
        }

        [RelayCommand]
        private async Task SignIn()
        {
            await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);

            OnPropertyChanged(nameof(Username));
        }

        [RelayCommand]
        private async Task NavigateSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }

    public interface IGetSecretMessageQuery
    {
        [Get("/")]
        Task<SecretMessageResponse> Execute();
    }
}
