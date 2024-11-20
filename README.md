## Webview Starter



## Installation(nuget)


Microsoft.Web.WebView2
Microsoft.UI.Xaml    



## Setup


MainPage.xaml


```xml

<Page
    x:Class="World_Radioo.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:World_Radioo"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:controls="using:Microsoft.UI.Xaml.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Grid>

        <controls:WebView2 x:Name="WebView2" Source=""/>


    </Grid>
</Page>
```

In MainPage.xaml.cs

1) Wait for the webview to fully load 


```c#

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += InitializeAsync;
        }

      // wait for the webview to load
        async void InitializeAsync(object sender, RoutedEventArgs e)
        {
            await WebView2.EnsureCoreWebView2Async();
            WebView2.CoreWebView2.Settings.AreDevToolsEnabled = false;
            AppWindowLoaded();
        }



```

2) Mount the html app onto webview 


```c#
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

```