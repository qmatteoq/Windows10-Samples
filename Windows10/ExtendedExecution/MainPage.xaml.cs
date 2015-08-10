using System;
using System.Diagnostics;
using Windows.ApplicationModel.ExtendedExecution;
using Windows.Data.Xml.Dom;
using Windows.Devices.Geolocation;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExtendedExecution
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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                var extendedSession = new ExtendedExecutionSession();
                extendedSession.Reason = ExtendedExecutionReason.LocationTracking;
                extendedSession.Description = "Location tracking";

                ExtendedExecutionResult result = await extendedSession.RequestExtensionAsync();
                if (result == ExtendedExecutionResult.Allowed)
                {
                    Debug.WriteLine("Background execution approved");
                }
                else
                {
                    Debug.WriteLine("Background execution denied");
                }

                Geolocator locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 0;
                locator.MovementThreshold = 500;
                locator.DesiredAccuracy = PositionAccuracy.High;
                locator.PositionChanged += Locator_PositionChanged;
            }
        }

        private void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            string xml = $@"
                <toast activationType='foreground' launch='args'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>This is a toast notification</text>
                            <text>Latitude: {args.Position.Coordinate.Point.Position.Latitude} - Longitude: {args.Position.Coordinate.Point.Position.Longitude}</text>
                        </binding>
                    </visual>
                </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification notification = new ToastNotification(doc);
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(notification);
        }
    }
}
