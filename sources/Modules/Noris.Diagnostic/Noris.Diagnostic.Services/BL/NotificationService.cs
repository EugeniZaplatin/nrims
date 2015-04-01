using Noris.Diagnostic.Utils;

namespace Noris.Diagnostic.Services.BL
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Configuration;
    using System.Linq;

    using Microsoft.Practices.Unity;

    using Noris.Unity.Attributes;
    using Noris.Diagnostic.Services.API;


    [Service(forInterface: typeof(INotificationService))]

    public class NotificationService : INotificationService
    {
        private readonly NotificationConfig config;

        [Dependency]
        public IMailService MailService { get; set; }

        [Dependency]
        public ISmsCenterService SmsService { get; set; }

        

        public NotificationService()
        {
            config = (NotificationConfig)ConfigurationManager.GetSection("notification");
        }

        public void SendEmailNotification(string subject, string body, IEnumerable<string> emails)
        {
            foreach (var email in config.Emails)
            {
                MailService.SendMailToQueue(new [] { email.ToString() }, subject, body);
            }

            foreach (var email in emails)
            {
                MailService.SendMailToQueue(new[] { email.ToString() }, subject, body);
            }
        }

        public void SendSmsNotification(string body, IEnumerable<string> sms)
        {
            var configSms = config.SMS.Cast<string>().ToList();

            SmsService.SendSMS(configSms, body);
            SmsService.SendSMS(sms, body);
        }
    }
}