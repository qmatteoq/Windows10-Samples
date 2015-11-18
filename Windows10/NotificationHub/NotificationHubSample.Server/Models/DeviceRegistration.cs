using System;

namespace NotificationHubSample.Server.Models
{
    public class DeviceRegistration
    {
        public string RegistrationId { get; set; }

        public string Tags { get; set; }

        public DateTime ExpirationTime { get; set; }

    }
}
