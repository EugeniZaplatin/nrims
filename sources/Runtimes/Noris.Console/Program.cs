using Noris.RunTest;


namespace Urish.Diagnostic.Run
{
    class Program
    {
        private static void Main(string[] args)
        {
            TestLocalDb.WorkWithLocalDb();

            TestWithDynamicType.CreateDynamic();
        }


    }
}
