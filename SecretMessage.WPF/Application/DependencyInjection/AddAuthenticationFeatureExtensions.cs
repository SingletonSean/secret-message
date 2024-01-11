using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Http;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddAuthenticationFeatureExtensions
    {
        public static IHostBuilder AddAuthenticationFeature(this IHostBuilder host)
        {
            host.ConfigureServices((context, serviceCollection) =>
            {
                string firebaseApiKey = context.Configuration.GetValue<string>("FIREBASE_API_KEY");
                string firebaseAuthDomain = context.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN");

                serviceCollection.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
                {
                    ApiKey = firebaseApiKey,
                    AuthDomain = firebaseAuthDomain,
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    },
                    UserRepository = new SettingsUserRepository()
                }));

                serviceCollection.AddTransient<FirebaseAuthHttpMessageHandler>();
            });

            return host;
        }
    }
}
