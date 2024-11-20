using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebViewStarter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += InitializeAsync;
        }


        private void AppWindowLoaded()
        {
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            Debug.WriteLine(appDir);
            var frontendPath = System.IO.Path.Combine(appDir, "frontend");

            if (!Directory.Exists(frontendPath))
            {
                Debug.WriteLine("Frontend directory does not exist.", "ERROR");
                return;
            };
            WebView2.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.example", frontendPath, CoreWebView2HostResourceAccessKind.Allow);
            var source = new Uri("https://appassets.example/index.html");
            WebView2.Source = new Uri(source.ToString());

        }

        async void InitializeAsync(object sender, RoutedEventArgs e)
        {
            await WebView2.EnsureCoreWebView2Async();
            WebView2.CoreWebView2.Settings.AreDevToolsEnabled = false;
            AppWindowLoaded();
        }
    }
}
