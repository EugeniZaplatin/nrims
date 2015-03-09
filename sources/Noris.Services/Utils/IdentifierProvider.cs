using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Noris.Dao.Api;
using Noris.Unity.Attributes;

namespace Noris.Dao
{
    [Service(typeof(IIdentifierProvider))]
    public class IdentifierProvider : IIdentifierProvider
    {
        private readonly object _lock = new object();
        private readonly SequentialGuidGenerator _generator = new SequentialGuidGenerator();
        public Guid NewIdentifier()
        {
            lock (_lock)
            {
                Thread.Sleep(1);
                return _generator.NewGuid(SequentialGuidType.SequentialAsString);
            }
        }

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
