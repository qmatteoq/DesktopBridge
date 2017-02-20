using GalaSoft.MvvmLight.Messaging;
using Migrate.UWP.Messages;
using System;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Migrate.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Desktop")
    {
        OpenForm.Visibility = Visibility.Collapsed;
    }

    Messenger.Default.Register<ConnectionReadyMessage>(this, message =>
    {
        if (App.Connection != null)
        {
            App.Connection.RequestReceived += Connection_RequestReceived;
        }
    });
}

private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    var deferral = args.GetDeferral();
    string name = args.Request.Message["name"].ToString();
    Result.Text = $"Hello {name}";
    ValueSet valueSet = new ValueSet();
    valueSet.Add("response", "success");
    await args.Request.SendResponseAsync(valueSet);
    deferral.Complete();
}

private async void OnOpenForm(object sender, RoutedEventArgs e)
{
    await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
}

        private void OnSayHello(object sender, RoutedEventArgs e)
        {
            Result.Text = "Hello world!";
        }
    }
}
