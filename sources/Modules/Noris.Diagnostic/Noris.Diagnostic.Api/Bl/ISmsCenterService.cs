namespace Noris.Diagnostic.Services.API
{
    using System.Collections.Generic;

    public interface ISmsCenterService
    {
        void SendSMS(IEnumerable<string> phones, string message);
    }
}