namespace Noris.Unity.Attributes
{
    using System;

    /// <summary>
    /// Attribute for any configuration classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttribute : ComponentAttribute
    {
        public ConfigurationAttribute() :
            base(null)
        {
        }
    }
}
