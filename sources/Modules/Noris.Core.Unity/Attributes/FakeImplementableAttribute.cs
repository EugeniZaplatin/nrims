using System;

namespace Noris.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class FakeImplementableAttribute : Attribute
    {
    }
}
