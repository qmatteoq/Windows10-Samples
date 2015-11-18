using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AsyncSample
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

        private void OnStartBlockingOperation(object sender, RoutedEventArgs e)
        {
            Status.Text = "Operation started";
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            Status.Text = "Operation completed";
        }

        private async void OnAsyncAwaitOperation(object sender, RoutedEventArgs e)
        {
            Status.Text = "Operation started";
            await Task.Delay(TimeSpan.FromSeconds(5));
            Status.Text = "Operation completed";
        }

        private void OnLocalizeMeClicked(object sender, RoutedEventArgs e)
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracy = PositionAccuracy.High;
            locator.DesiredAccuracyInMeters = 100;
            locator.PositionChanged += Locator_PositionChanged;
        }

        private async void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Status.Text =
                $"Latitude: {args.Position.Coordinate.Point.Position.Latitude} - Longitude: {args.Position.Coordinate.Point.Position.Longitude}";
            });
            

        }
    }
}
