
using Noris.Api.Dao;
using Noris.Dao.Dao;
using Noris.Data.Entity;
using Noris.Unity.Attributes;

namespace Noris.Dao.Repositories
{
    [Repository(forInterface: typeof(IRecordDao))]
    public class RecordDao : BaseDao<Record>, IRecordDao
    {
    }
}
