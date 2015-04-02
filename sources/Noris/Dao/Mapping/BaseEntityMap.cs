using System.Data.Entity.ModelConfiguration;
using Noris.Data.Entity;


namespace Noris.Core.Dao.Mapping
{
    public abstract class BaseEntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        protected BaseEntityMap()
        {
            Property(u => u.Id).HasColumnName("id");
            Property(u => u.CreatedDate).HasColumnName("created_date");
            Property(u => u.ModifiedDate).HasColumnName("modified_date");
            Property(u => u.DeletedDate).HasColumnName("deleted_date");
            Ignore(u => u.CreatedBy);
            Ignore(u => u.ModifiedBy);
        }
    }
}
