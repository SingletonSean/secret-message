using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using Refit;
using SecretMessage.WPF.Application.DependencyInjection;
using SecretMessage.WPF.Application.Initialization;
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
    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .AddNavigation()
                .AddUserEntity()
                .AddSecretMessageFeature()
                .AddAuthenticationFeature()
                .AddHomePage()
                .AddRegisterPage()
                .AddLoginPage()
                .AddPasswordResetPage()
                .AddProfilePage()
                .AddMainWindow()
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            ApplicationInitializer applicationInitializer = _host.Services.GetRequiredService<ApplicationInitializer>();
            await applicationInitializer.Initialize();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

       
    }
}
