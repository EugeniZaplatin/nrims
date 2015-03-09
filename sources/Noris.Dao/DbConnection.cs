using System.Data.Entity;
using Noris.Data.Entity;
using Noris.Unity.Attributes;

namespace Noris.Dao
{
    /// <summary>
    /// Main database context for solution
    /// </summary>
    [Configuration]
    public class DbConnection : DbContext
    {
        public DbConnection()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ModuleMap()); sample
            //...
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() 
            where TEntity : BaseEntity
        {
            return this.Set<TEntity>();
        }

        

    }

}
