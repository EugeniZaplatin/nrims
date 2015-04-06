using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Noris;
using Noris.Api.Entity;
using Noris.Core.Unity;
using Noris.Dao.Repositories;
using Noris.RunTest;
using Noris.Unity;


namespace Urish.Diagnostic.Run
{
    class Program
    {
        

        private static void Main(string[] args)
        {
            
            var modules = new List<IModule> {new NorisModule(), new DiagnosticModule()};

            var assemblies = modules.SelectMany(x => x.GetAssembliesForUnityContainer()).ToList();

            var container = UnityConfigurer.UnityContainerBuilder(assemblies);

            modules.ForEach(m => m.Initialize(container));
            
            container.BuildUp(new TestLocalDb()).WorkWithLocalDb();

            //TestWithDynamicType.CreateDynamic();
        }


    }
}
