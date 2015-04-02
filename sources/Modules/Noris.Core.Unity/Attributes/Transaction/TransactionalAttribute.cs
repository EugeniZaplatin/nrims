using Noris.Utils.Transaction;
using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Noris.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TransactionalCallHandler(container);
        }
    }
}
