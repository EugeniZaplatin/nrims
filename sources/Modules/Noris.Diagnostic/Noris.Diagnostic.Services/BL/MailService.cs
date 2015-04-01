using Noris.Unity.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Common.Logging;
using Noris.Diagnostic.Services.API;

namespace Noris.Diagnostic.Services.BL
{
    [Service(forInterface: typeof(IMailService))]
    public class MailService : IMailService
    {
        private static IList<EmailQueueItem> _queue;

        private static readonly ILog LOGGER = LogManager.GetLogger<MailService>();

        private IList<EmailQueueItem> queue
        {
            get { return _queue ?? (_queue = new List<EmailQueueItem>()); }
        }

        public void StartOrResume()
        {
            Task.Factory.StartNew(this.startOrResume);
        }

        private void startOrResume()
        {
            lock (this.queue)
            {
                var now = DateTime.Now;

                var items = this.queue.Where(x => x.lastAttempt == null || now.Subtract(x.lastAttempt.Value).Minutes >= 3).ToList();
                foreach (var emailQueueItem in items)
                {
                    emailQueueItem.attemptCount += 1;
                    emailQueueItem.lastAttempt = now;
                    try
                    {
                        LOGGER.InfoFormat("message: {0}. trying to send message to {1}.", new object[] { emailQueueItem.Id.ToString(), string.Join(", ", emailQueueItem.emails) });

                        this._sendMail(emailQueueItem.emails, emailQueueItem.subject, emailQueueItem.message, emailQueueItem.Attachment, emailQueueItem.FileName);

                        LOGGER.InfoFormat("message: {0}. message has been sent successfuly.", new object[] { emailQueueItem.Id.ToString() });

                        LOGGER.InfoFormat("message: {0}. removing from queue.", new object[] { emailQueueItem.Id.ToString() });
                        this.queue.Remove(emailQueueItem);
                    }
                    catch (Exception ex)
                    {
                        LOGGER.ErrorFormat("message: {0}. failed sending. attempt: {1}", ex.Message, new object[] { emailQueueItem.Id.ToString(), emailQueueItem.attemptCount.ToString(CultureInfo.InvariantCulture) });
                        if (emailQueueItem.attemptCount >= 3)
                        {
                            LOGGER.InfoFormat("message: {0}. removing from queue after {1} attempts.", new object[] { emailQueueItem.Id.ToString(), emailQueueItem.attemptCount.ToString(CultureInfo.InvariantCulture) });
                            this.queue.Remove(emailQueueItem);
                        }
                    }
                }
            }
        }

        public void SendMailToQueue(string[] emails, string subject, string body)
        {
            if (emails == null || !emails.Any())
            {
                throw new Exception("Emails list is empty.");
            }

            this.queue.Add(new EmailQueueItem
            {
                Id = Guid.NewGuid(),
                emails = emails,
                message = body,
                attemptCount = 0,
                lastAttempt = null,
                subject = subject
            });
        }

        public void SendMailToQueue(string[] emails, string subject, string body, byte[] attachment, string fileName)
        {
            if (emails == null || !emails.Any())
            {
                throw new Exception("Emails list is empty.");
            }

            this.queue.Add(new EmailQueueItem
            {
                Id = Guid.NewGuid(),
                emails = emails,
                message = body,
                attemptCount = 0,
                lastAttempt = null,
                subject = subject,
                Attachment = attachment,
                FileName = fileName
            });
        }

        public void SendMailToQueue(string[] emails, string subject, StringWriter writer)
        {
            this.SendMailToQueue(emails, subject, writer.GetStringBuilder().ToString());
        }

        private void _sendMail(IEnumerable<string> emails, string subject, string message, byte[] attachemnts = null, string fileName = null)
        {
            var emailList = emails as IList<string> ?? emails.ToList();
            if (!emailList.Any())
            {
                return;
            }

            var emailMessage = new MailMessage
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            
            int emailCount = 0;
            foreach (var email in emailList)
            {
                emailMessage.To.Add(email);
                emailCount++;
            }

            if (emailCount > 0)
            {
                using (var smtpClient = new SmtpClient())
                {
                    if (attachemnts != null && !string.IsNullOrEmpty(fileName))
                    {
                        using (var stream = new MemoryStream(attachemnts))
                        {
                            emailMessage.Attachments.Add(new Attachment(stream, fileName));
                            smtpClient.Send(emailMessage);
                        }
                    }
                    {
                        smtpClient.Send(emailMessage);
                    }

                }
            }
        }
    }

    public class EmailQueueItem
    {
        public Guid Id { get; set; }

        public string[] emails { get; set; }

        public string subject { get; set; }

        public string message { get; set; }

        public int attemptCount { get; set; }

        public DateTime? lastAttempt { get; set; }

        public byte[] Attachment { get; set; }

        public string FileName { get; set; }
    }
}
