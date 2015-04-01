using System;

namespace Urish.Unity.Api
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class FakeImplementableAttribute : Attribute
    {
    }
}
