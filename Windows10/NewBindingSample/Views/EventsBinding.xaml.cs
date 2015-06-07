using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewBindingSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsBinding : Page
    {
        public EventsBinding()
        {
            this.InitializeComponent();
        }

        public async void OnShowMessageClicked()
        {
            MessageDialog dialog = new MessageDialog("Single tap!");
            await dialog.ShowAsync();
        }

        public async void OnDoubleTapMessage()
        {
            MessageDialog dialog = new MessageDialog("Double tap!");
            await dialog.ShowAsync();
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
