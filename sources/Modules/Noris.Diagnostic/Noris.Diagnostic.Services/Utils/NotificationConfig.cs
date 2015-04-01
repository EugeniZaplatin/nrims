namespace Noris.Diagnostic.Utils
{
    using System.Configuration;

    public class NotificationConfig : ConfigurationSection
    {
        [ConfigurationProperty("Emails")]
        public NotificatioCollection Emails
        {
            get { return ((NotificatioCollection)(base["Emails"])); }
        }

        [ConfigurationProperty("SMS")]
        public NotificatioCollection SMS
        {
            get { return ((NotificatioCollection)(base["SMS"])); }
        }

        [ConfigurationProperty("SmsLogin")]
        public string SmsLogin
        {
            get { return ((string)(base["SmsLogin"])); }
        }

        [ConfigurationProperty("SmsPassword")]
        public string SmsPassword
        {
            get { return ((string)(base["SmsPassword"])); }
        }
    }

    [ConfigurationCollection(typeof(NotificationElement))]
    public class NotificatioCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NotificationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NotificationElement)(element)).Value;
        }

        public NotificationElement this[int idx]
        {
            get { return (NotificationElement)BaseGet(idx); }
        }
    }

    public class NotificationElement : ConfigurationElement
    {

        [ConfigurationProperty("value", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Value
        {
            get { return ((string)(base["value"])); }
            set { base["value"] = value; }
        }
    }
}
