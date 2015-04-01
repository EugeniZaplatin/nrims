using Noris.Diagnostic.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using Noris.Unity.Attributes;
using Noris.Diagnostic.Services.API;

namespace Noris.Diagnostic.Services.BL
{
   
    

    [Service(forInterface: typeof(ISmsCenterService))]
    public class SmsCenterService : ISmsCenterService
    {
        private const string SendMessageURLFormat = "http://smsc.ru/sys/send.php?login={0}&psw={1}&phones={2}&mes={3}";

        private readonly NotificationConfig config;
        
        public SmsCenterService()
        {
            config = (NotificationConfig)ConfigurationManager.GetSection("Notifications");
        }

        public void SendSMS(IEnumerable<string> phones, string message)
        {
            this.MakeRequest(
                string.Format(
                    SendMessageURLFormat,
                    config.SmsLogin,
                    config.SmsPassword,
                    string.Join(";", phones),
                    message));
        }

        public string MakeRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentLength = 0;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = string.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new Exception(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }
    }
}