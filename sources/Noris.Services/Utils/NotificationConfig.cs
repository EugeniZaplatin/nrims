using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Urish.Diagnostic.Services.Utils
{
    using System.Configuration;

    public class NotificationConfig : ConfigurationSection
    {
        [ConfigurationProperty("Emails")]
        public NotificatioCollection EmailItems
        {
            get { return ((NotificatioCollection)(base["Emails"])); }
        }

        [ConfigurationProperty("SMS")]
        public NotificatioCollection SmsItems
        {
            get { return ((NotificatioCollection)(base["SMS"])); }
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
