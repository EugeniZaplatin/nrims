using System;

namespace Noris.Unity.Api
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class FakeImplementableAttribute : Attribute
    {
    }
}
