
using Noris.Api.Dao;
using Noris.Dao.Dao;
using Noris.Data.Entity;
using Noris.Unity.Attributes;

namespace Noris.Dao.Repositories
{
    [Repository(forInterface: typeof(IDirectoryDao))]
    public class DirectoryDao : BaseDao<Directory>, IDirectoryDao
    {
    }
}
