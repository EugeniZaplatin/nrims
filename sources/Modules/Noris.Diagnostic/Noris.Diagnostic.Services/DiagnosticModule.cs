using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Noris.Api.Entity;
using Noris.Core.Unity;
using Noris.Dao;
using Noris.Diagnostic.Services.BL;
using Noris.Services;
using Noris.Unity;

namespace Noris
{
    /// <summary>
    /// Diagnostic module
    /// </summary>
    public class DiagnosticModule : IModule
    {
        public IList<Assembly> GetAssembliesForUnityContainer()
        {
            return new List<Assembly>
            {
                typeof (LoggingService).Assembly
            };
        }

        public void Initialize(IUnityContainer container)
        {
            //Add any think to container
        }
    }
}
