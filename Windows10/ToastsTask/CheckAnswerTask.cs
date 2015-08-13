using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ToastsTask
{
    public sealed class CheckAnswerTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
            string arguments = details.Argument;
            var result = details.UserInput;

            if (arguments == "check")
            {
                int sum = int.Parse(result["message"].ToString());
                string message = sum == 15 ? "Congratulations, the answer is correct!" : "Sorry, wrong answer!";

                string xml = $@"<toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <image placement=""appLogoOverride"" src=""Assets/MicrosoftLogo.png"" />
                                  <text>{message}</text>
                                </binding>
                              </visual>
                            </toast>";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                ToastNotification notification = new ToastNotification(doc);
                ToastNotificationManager.CreateToastNotifier().Show(notification);
            }
        }
    }
}
