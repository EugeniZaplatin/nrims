namespace Noris.Unity.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        public Type ForInterface { get; set; }

        public ComponentAttribute(Type forInterface)
        {
            ForInterface = forInterface;
        }
    }
}
