namespace Noris.Unity.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : ComponentAttribute
    {
        public string ModuleName { get; set; }
        
        public ServiceAttribute(Type forInterface) 
            : base(forInterface)
        {
        }

        public ServiceAttribute(Type forInterface, string moduleName)
            : base(forInterface)
        {
            this.ModuleName = moduleName;
        }
    }
}