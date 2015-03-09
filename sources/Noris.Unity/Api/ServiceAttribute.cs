namespace Noris.Unity.Attributes
{
    using System;

    /// <summary>
    /// Hung on Services classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : ComponentAttribute
    {
        public ServiceAttribute(Type forInterface) 
            : base(forInterface)
        {
        }

        
    }
}