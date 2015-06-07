using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using NewBindingSample.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NewBindingSample.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewBindingSample
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

        private void OnStandardBindingClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (StandardBinding));
        }

        private void OnMvvmBindingClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MvvmBinding));
        }

        private void OnEventsBindingClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (EventsBinding));
        }

        private void OnListBindingClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListBinding));
        }
    }
}
