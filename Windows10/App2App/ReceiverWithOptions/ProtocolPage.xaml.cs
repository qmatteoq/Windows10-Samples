using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReceiverWithOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProtocolPage : Page
    {
        private ProtocolForResultsActivatedEventArgs args;

        public ProtocolPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                args = e.Parameter as ProtocolForResultsActivatedEventArgs;
            }
        }

        private void OnSumClicked(object sender, RoutedEventArgs e)
        {
            int num1 = (int)args.Data["num1"];
            int num2 = int.Parse(Number.Text);
            int sum = num1 + num2;

            ValueSet result = new ValueSet();
            result.Add("sum", sum);

            args.ProtocolForResultsOperation.ReportCompleted(result);
        }
    }
}
