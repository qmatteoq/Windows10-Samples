using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace ToastsTask
{
    public sealed class ActionCenterTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            int counter = 0;
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("ToastCounter"))
            {
                counter = 0;
            }
            else
            {
                counter = (int) ApplicationData.Current.LocalSettings.Values["ToastCounter"];
            }

            var details = taskInstance.TriggerDetails as ToastNotificationHistoryChangedTriggerDetail;
            switch (details.ChangeType)
            {
                case ToastHistoryChangedType.Cleared:
                    counter = 0;
                    break;
                case ToastHistoryChangedType.Removed:
                    counter--;
                    break;
                case ToastHistoryChangedType.Expired:
                    counter--;
                    break;
                case ToastHistoryChangedType.Added:
                    counter++;
                    break;
            }

            ApplicationData.Current.LocalSettings.Values["ToastCounter"] = counter;

            // Get the blank badge XML payload for a badge number
            XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);

            // Set the value of the badge in the XML to our number
            XmlElement badgeElement = badgeXml.SelectSingleNode("/badge") as XmlElement;
            badgeElement.SetAttribute("value", counter.ToString());

            // Create the badge notification
            BadgeNotification badge = new BadgeNotification(badgeXml);

            // Create the badge updater for the application
            BadgeUpdater badgeUpdater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();

            // And update the badge
            badgeUpdater.Update(badge);
        }
    }
}
