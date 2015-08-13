using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Toasts
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

        private void OnSendStandardToastClicked(object sender, RoutedEventArgs e)
        {
            string xml = @"<toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <image placement=""appLogoOverride"" src=""Assets/MicrosoftLogo.png"" />
                                  <text>Hello insiders!</text>
                                  <image placement=""inline"" src=""Assets/TRexInsider.png"" />
                                  <text>Check out this image. Isn’t it awesome?</text>
                                </binding>
                              </visual>
                            </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification notification = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }

        private void OnSendToastWithAlarmClicked(object sender, RoutedEventArgs e)
        {
            string xml = $@"
                <toast activationType='foreground' launch='args' scenario='reminder'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <image placement=""appLogoOverride"" src=""Assets/MicrosoftLogo.png"" />
                            <text>It's time to go!</text>
                            <text>Leave now if you want to arrive in time.</text>
                        </binding>
                    </visual>
                    <actions hint-systemCommands = 'SnoozeAndDismiss' />
                </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification notification = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }

        private void OnSendToastWithBackgroundService(object sender, RoutedEventArgs e)
        {
            string xml= $@"
                <toast>
                    <visual>
                        <binding template='ToastGeneric'>
                            <image placement=""appLogoOverride"" src=""Assets/MicrosoftLogo.png"" />
                            <text>How much is 10 + 5?</text>
                        </binding>
                    </visual>
                    <actions>

                        <input
                            id = 'message'
                            type = 'text'
                            placeHolderContent = 'Enter the result' />

                        <action
                            content='check'
                            activationType='background'
                            arguments='check'
                            />

                    </actions>
                </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification notification = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(notification);

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (BackgroundTaskRegistration.AllTasks.All(x => x.Value.Name != "ToastTask"))
            {
                BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
                builder.Name = "ToastTask";
                builder.TaskEntryPoint = "ToastsTask.CheckAnswerTask";
                builder.SetTrigger(new ToastNotificationActionTrigger());
                var status = await BackgroundExecutionManager.RequestAccessAsync();
                if (status != BackgroundAccessStatus.Denied)
                {
                    builder.Register();
                }
            }
        }
    }
}
