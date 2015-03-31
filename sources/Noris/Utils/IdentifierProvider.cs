using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Noris.Dao.Api;
using Noris.Unity.Attributes;

namespace Noris.Utils
{
    /// <summary>
    /// Provide generation unique value for Guid type structure
    /// </summary>
    [Service(typeof(IIdentifierProvider))]
    public class IdentifierProvider : IIdentifierProvider
    {
        private readonly object _lock = new object();

        private readonly SequentialGuidGenerator _generator = new SequentialGuidGenerator();

        /// <summary>
        /// Generate one value
        /// </summary>
        /// <returns></returns>
        public Guid NewIdentifier()
        {
            lock (_lock)
            {
                Thread.Sleep(1);
                return _generator.NewGuid(SequentialGuidType.SequentialAsString);
            }
        }

        /// <summary>
        /// Generate list unique values
        /// </summary>
        /// <param name="count">Count needed values</param>
        /// <returns></returns>
        public IEnumerable<Guid> NewIdentifiers(int count)
        {
            lock (_lock)
            {
                Thread.Sleep(1);
                var guids = new HashSet<Guid>();
                while (guids.Count < count)
                {
                    guids.Add(_generator.NewGuid(SequentialGuidType.SequentialAsString));
                }
                return guids.OrderBy(o => o);
            }
        }
    }
}
