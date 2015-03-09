namespace Noris.Unity.Attributes
{
    using System;

    /// <summary>
    /// Hung on Dao repository classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : ComponentAttribute
    {
        public RepositoryAttribute(Type forInterface) : base(forInterface)
        { 
        }
    }
}
