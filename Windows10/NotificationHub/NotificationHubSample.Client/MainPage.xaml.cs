using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.PushNotifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.Messaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotificationHubSample.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string ConnectionString = "Your connection string here";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OnRegisterForNotificationsClicked(object sender, RoutedEventArgs e)
        {
            PushNotificationChannel channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            if (channel != null)
            {
                string result = $"Registration successfull: the channel url is {channel.Uri}";
                Result.Text = result;
                NotificationHub hub = new NotificationHub("uwpsample", ConnectionString);
                await hub.RegisterNativeAsync(channel.Uri);
            }
        }
    }
}
