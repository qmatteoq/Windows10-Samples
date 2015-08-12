using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sender
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

        private async void OnOpenAnotherAppClicked(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("invoice:?Customer=Contoso&Price=25"));
        }

        private async void OnOpenAnotherAppWithDataClicked(object sender, RoutedEventArgs e)
        {
            LauncherOptions options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "8a1341de-3acd-4d5a-91f2-98d9cd2c1c6e_e8f4dqfvn1be6";

            ValueSet data = new ValueSet();
            data.Add("Customer", "Contoso");
            data.Add("Price", "25");

            await Launcher.LaunchUriAsync(new Uri("invoice:"), options, data);
        }
    }
}
