using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Noris.Api.Entity
{
    /// <summary>
    /// For all modules
    /// </summary>
    public interface IModule
    {
        IList<Assembly> GetAssembliesForUnityContainer();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void Initialize(IUnityContainer container);

    }
}
