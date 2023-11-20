using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace AW_AuthClient
{
    public partial class Window : Form
    {
        private WebView2 webView;
        private string url;

        public Window(string url)
        {
            InitializeComponent();
            this.url = url;
            InitializeWebView2();
        }

        /// <summary>
        /// Fill the entire form with WebView2
        /// </summary>
        private void InitializeWebView2()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);
            InitializeAsync();
        }

        /// <summary>
        /// Initialize a user settings folder in %localappdata% so we don't leak credentials if somebody is stupid and shares the package without checking here.
        /// After this launch the WebView2 window using the argument as a URL
        /// </summary>
        private async void InitializeAsync()
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var userDataFolderPath = Path.Combine(localAppData, "ANGELWARE", "Client");
            if (!Directory.Exists(userDataFolderPath))
                Directory.CreateDirectory(userDataFolderPath);

            var env = await CoreWebView2Environment.CreateAsync(userDataFolder: userDataFolderPath);
            await webView.EnsureCoreWebView2Async(env);

            webView.CoreWebView2.Navigate(url);
        }

    }
}