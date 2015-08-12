using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TheBackgroundTask
{
    public sealed class MyBackgroundTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            string xml = $@"
            <toast activationType='foreground' launch='args'>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>Device status changed!</text>
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
