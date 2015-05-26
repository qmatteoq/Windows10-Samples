using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ApiDetection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var ns = "Windows.Phone.UI.Input.HardwareButtons";
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(ns))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += Back_BackPressed;
            }
        }


        private async void Back_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            MessageDialog dialog = new MessageDialog("Hello from the Back button!");
            await dialog.ShowAsync();
        }

        private async void OnGetSensorDataClicked(object sender, RoutedEventArgs e)
        {
            var ns = "Windows.Devices.Gpio.GpioController";
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(ns))
            {
                GpioController controller = GpioController.GetDefault();
                GpioPin pin = controller.OpenPin(5);
                GpioPinValue value = pin.Read();
                Debug.WriteLine(value);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("This isn't an IoT device!");
                await dialog.ShowAsync();
            }
            
        }
    }
}
