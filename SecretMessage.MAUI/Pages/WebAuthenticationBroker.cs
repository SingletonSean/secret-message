using Firebase.Auth;

namespace SecretMessage.MAUI.Pages
{
    public class WebAuthenticationBroker
    {
        public static Task<string> AuthenticateAsync(string uri, string redirectUri)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            WebAuthenticationBrokerWindow webviewPage = new WebAuthenticationBrokerWindow();

            Window window = new Window(webviewPage)
            {
                MaximumHeight = 650,
                MaximumWidth = 600,
                Parent = Application.Current?.MainPage
            };

            webviewPage.WebView.Navigating += (s, e) =>
            {
                string url = e.Url;

                if (url.StartsWith(redirectUri))
                {
                    tcs.SetResult(url);
                    Application.Current?.CloseWindow(window);
                }
            };
            
            webviewPage.WebView.Loaded += (s, e) => webviewPage.WebView.Source = new Uri(uri);
            
            window.Destroying += (s, e) => {
                if (!tcs.Task.IsCompleted)
                {
                    tcs.SetResult(null);
                }

                Application.Current?.CloseWindow(window);
            };

            Application.Current?.OpenWindow(window);

            return tcs.Task;
        }
    }

    public class WebAuthenticationBrokerWindow : ContentPage
    {
        public WebView WebView { get; }

        public WebAuthenticationBrokerWindow()
        {
            WebView = new WebView();

            Content = new Grid
            {
                Children = 
                {
                    WebView 
                }
            };
        }
    }
}
