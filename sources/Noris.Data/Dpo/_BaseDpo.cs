using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noris.Data.Dpo
{
    /// <summary>
    /// Base class for data presentation object to exchange data with UI
    /// </summary>
    public abstract class BaseDpo
    {
        public Guid Id { get; set; }
    }
}
