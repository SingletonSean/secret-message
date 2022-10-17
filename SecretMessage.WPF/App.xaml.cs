using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessage.WPF.Application.DependencyInjection;
using SecretMessage.WPF.Application.Initialization;
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
                .AddDapperDatabase()
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
