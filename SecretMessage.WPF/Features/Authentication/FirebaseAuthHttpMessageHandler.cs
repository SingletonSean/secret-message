using Firebase.Auth;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Http
{
    public class FirebaseAuthHttpMessageHandler : DelegatingHandler
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public FirebaseAuthHttpMessageHandler(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_firebaseAuthClient.User == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            string firebaseToken = await _firebaseAuthClient.User.GetIdTokenAsync();

            if (firebaseToken != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", firebaseToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
