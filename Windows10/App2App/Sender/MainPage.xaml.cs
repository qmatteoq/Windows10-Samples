using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
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

        private async void OnOpenAnotherAppWithResultsClicked(object sender, RoutedEventArgs e)
        {
            ValueSet data = new ValueSet();
            data.Add("num1", 10);

            LauncherOptions options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "467a521c-d93f-4c82-bfab-d18f4a8482f0_e8f4dqfvn1be6";

            LaunchUriResult result = await Launcher.LaunchUriForResultsAsync(new Uri("sum:"), options, data);
            if (result.Status == LaunchUriStatus.Success)
            {
                ValueSet resultData = result.Result;
                int sum = (int)resultData["sum"];
                MessageDialog dialog = new MessageDialog($"The sum is {sum}");
                await dialog.ShowAsync();
            }
        }

        private async void OnOpenAnotherAppWithFileClicked(object sender, RoutedEventArgs e)
        {
            StorageFile textfile = await Package.Current.InstalledLocation.GetFileAsync("textfile.txt");
            string token = SharedStorageAccessManager.AddFile(textfile);

            ValueSet data = new ValueSet();
            data.Add("token", token);

            LauncherOptions options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "a29b22b7-2ea6-424d-8c3b-4f6112d9caef_e8f4dqfvn1be6";

            await Launcher.LaunchUriAsync(new Uri("textfile:"), options, data);
        }
    }
}
