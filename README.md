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