using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
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

namespace AdaptiveTiles
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

public void OnUpdateTileClicked(object sender, RoutedEventArgs e)
{
    string xml = @"<tile>
        <visual>
        <binding template=""TileMedium"">
            <group>
            <subgroup>
                <text hint-style=""subtitle"">John Doe</text>
                <text hint-style=""subtle"">Photos from our trip</text>
                <text hint-style=""subtle"">Thought you might like to see all of</text>
            </subgroup>
            </group>
            <group>
            <subgroup>
                <text hint-style=""subtitle"">Jane Doe</text>
                <text hint-style=""subtle"">Questions about your blog</text>
                <text hint-style=""subtle\"">Have you ever considered writing a</text>
            </subgroup>
            </group>
        </binding>
        </visual>
    </tile>";



    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    TileNotification notification = new TileNotification(doc);
    TileUpdater updater = TileUpdateManager.CreateTileUpdaterForApplication();

    updater.Update(notification);
}
    }
}
