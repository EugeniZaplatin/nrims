namespace Noris.Diagnostic.Services.API
{
    using System.IO;

    public interface IMailService
    {
        void StartOrResume();

        void SendMailToQueue(string[] emails, string subject, StringWriter writer);

        void SendMailToQueue(string[] emails, string subject, string body);

        void SendMailToQueue(string[] emails, string subject, string body, byte[] attachment, string fileName);
    }

}
