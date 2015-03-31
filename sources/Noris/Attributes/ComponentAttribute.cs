namespace Noris.Unity.Attributes
{
    using System;

    /// <summary>
    /// Base attribute for many attributes is using in Unity
    /// </summary>
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
