namespace Noris.Utils.Transaction
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    public class TransactionalCallHandler : ICallHandler
    {
        private readonly IUnityContainer _container;

        public TransactionalCallHandler(IUnityContainer container)
        {
            this._container = container;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var connection = this._container.Resolve<DbConnection>();

            using (var transaction = connection.Database.BeginTransaction())
            {
                var result = getNext().Invoke(input, getNext);

                if (result.Exception == null)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }

                return result;
            }
        }

        public int Order { get; set; }
    }
}
