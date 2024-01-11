using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using SecretMessage.WPF.Application.Database;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using SecretMessage.WPF.Http;
using SecretMessage.WPF.Queries;
using System;

namespace SecretMessage.WPF.Application.DependencyInjection
{
    public static class AddSecretMessageFeatureExtensions
    {
        public static IHostBuilder AddSecretMessageFeature(this IHostBuilder host)
        {
            host.ConfigureServices((context, serviceCollection) =>
            {
                serviceCollection.AddRefitClient<IGetSecretMessageQuery>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetValue<string>("SECRET_MESSAGE_API_BASE_URL")))
                    .AddHttpMessageHandler<FirebaseAuthHttpMessageHandler>();

                serviceCollection.AddSingleton<IViewSecretMessageDbContextFactory, SecretMessageDbContextFactory>();
            });

            return host;
        }
    }
}
