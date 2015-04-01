namespace Noris.Diagnostic.Services.API
{
    using System.Collections.Generic;

    public interface INotificationService
    {
        void SendEmailNotification(string subject, string body, IEnumerable<string> emails);

        void SendSmsNotification(string body, IEnumerable<string> sms);
    }
}