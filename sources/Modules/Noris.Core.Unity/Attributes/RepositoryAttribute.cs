namespace Noris.Unity.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : ComponentAttribute
    {
        public RepositoryAttribute(Type forInterface) : base(forInterface)
        { 
        }
    }
}
