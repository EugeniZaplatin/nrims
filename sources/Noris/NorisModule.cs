using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Noris.Api.Entity;
using Noris.Dao;
using Noris.Dao.Migrations;
using Noris.Dao.Repositories;
using Noris.Services;
using Noris.Unity;

namespace Noris
{
    /// <summary>
    /// Core module
    /// </summary>
    public class NorisModule : IModule
    {
        /// <summary>
        /// In task of method include prepare module and
        /// add dependencies to container
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public void Initialize(IUnityContainer container)
        {
            
            //Накатывание миграций
            var config = (DbMigrationsConfiguration)
                            container.BuildUp(typeof(Configuration), new Configuration());
            var migrator = new DbMigrator(config);

            migrator.Update();

            container.RegisterType(typeof(DbConnection), new ContainerControlledLifetimeManager());


        }

        public IList<Assembly> GetAssembliesForUnityContainer()
        {
            return new List<Assembly>
            {
                typeof (RecordDao).Assembly
            };
        }

    }
}
