using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using Refit;
using SecretMessage.WPF.Entities.Users;
using SecretMessage.WPF.Http;
using SecretMessage.WPF.Queries;
using SecretMessage.WPF.Stores;
using SecretMessage.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SecretMessage.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, serviceCollection) =>
                {
                    string firebaseApiKey = context.Configuration.GetValue<string>("FIREBASE_API_KEY");

                    serviceCollection.AddSingleton(new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey)));

                    serviceCollection.AddTransient<FirebaseAuthHttpMessageHandler>();

                    serviceCollection.AddRefitClient<IGetSecretMessageQuery>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetValue<string>("SECRET_MESSAGE_API_BASE_URL")))
                        .AddHttpMessageHandler<FirebaseAuthHttpMessageHandler>();

                    serviceCollection.AddSingleton<NavigationStore>();
                    serviceCollection.AddSingleton<ModalNavigationStore>();
                    serviceCollection.AddSingleton<AuthenticationStore>();
                    serviceCollection.AddSingleton<CurrentUserStore>();

                    serviceCollection.AddSingleton<NavigationService<RegisterViewModel>>(
                        (services) => new NavigationService<RegisterViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => new RegisterViewModel(
                                services.GetRequiredService<FirebaseAuthProvider>(),
                                services.GetRequiredService<NavigationService<LoginViewModel>>())));
                    serviceCollection.AddSingleton<NavigationService<LoginViewModel>>(
                        (services) => new NavigationService<LoginViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => new LoginViewModel(
                                services.GetRequiredService<AuthenticationStore>(),
                                services.GetRequiredService<NavigationService<RegisterViewModel>>(),
                                services.GetRequiredService<NavigationService<HomeViewModel>>(),
                                services.GetRequiredService<NavigationService<PasswordResetViewModel>>())));
                    serviceCollection.AddSingleton<NavigationService<HomeViewModel>>(
                        (services) => new NavigationService<HomeViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => HomeViewModel.LoadViewModel(
                                services.GetRequiredService<AuthenticationStore>(),
                                services.GetRequiredService<CurrentUserStore>(),
                                services.GetRequiredService<IGetSecretMessageQuery>(),
                                services.GetRequiredService<NavigationService<ProfileViewModel>>(),
                                services.GetRequiredService<NavigationService<LoginViewModel>>())));
                    serviceCollection.AddSingleton<NavigationService<PasswordResetViewModel>>(
                        (services) => new NavigationService<PasswordResetViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => new PasswordResetViewModel(
                                services.GetRequiredService<FirebaseAuthProvider>(),
                                services.GetRequiredService<NavigationService<LoginViewModel>>())));
                    serviceCollection.AddSingleton<NavigationService<ProfileViewModel>>(
                        (services) => new NavigationService<ProfileViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => new ProfileViewModel(
                                services.GetRequiredService<AuthenticationStore>(),
                                services.GetRequiredService<CurrentUserStore>(),
                                services.GetRequiredService<NavigationService<HomeViewModel>>())));

                    serviceCollection.AddSingleton<MainViewModel>();

                    serviceCollection.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Initialize();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private async Task Initialize()
        {
            AuthenticationStore authenticationStore = _host.Services.GetRequiredService<AuthenticationStore>();
            CurrentUserStore currentUserStore = _host.Services.GetRequiredService<CurrentUserStore>();

            try
            {
                await authenticationStore.Initialize();

                if (currentUserStore.User.IsLoggedIn)
                {
                    INavigationService navigationService = _host.Services.GetRequiredService<NavigationService<HomeViewModel>>();
                    navigationService.Navigate();
                }
                else
                {
                    INavigationService navigationService = _host.Services.GetRequiredService<NavigationService<LoginViewModel>>();
                    navigationService.Navigate();
                }
            }
            catch (FirebaseAuthException)
            {
                INavigationService navigationService = _host.Services.GetRequiredService<NavigationService<LoginViewModel>>();
                navigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load application.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
