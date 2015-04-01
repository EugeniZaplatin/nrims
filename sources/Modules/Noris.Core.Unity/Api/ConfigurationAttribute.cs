namespace Noris.Unity.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttribute : ComponentAttribute
    {
        public ConfigurationAttribute() :
            base(null)
        {
        }
    }
}
