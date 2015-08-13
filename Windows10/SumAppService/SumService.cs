using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace SumAppService
{
    public sealed class SumService: IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();

            var triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if (triggerDetails.Name == "SumService")
            {
                triggerDetails.AppServiceConnection.RequestReceived += AppServiceConnection_RequestReceived;
            }
        }

        private async void AppServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var appServiceDeferral = args.GetDeferral();
            var message = args.Request.Message;
            int num1 = (int)message["num1"];
            int num2 = (int) message["num2"];

            int sum = num1 + num2;

            ValueSet result = new ValueSet();
            result.Add("result", sum);

            await args.Request.SendResponseAsync(result);
            appServiceDeferral.Complete();
        }
    }
}
