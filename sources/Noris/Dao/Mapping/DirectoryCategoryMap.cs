
using Noris.Data.Entity;

namespace Noris.Core.Dao.Mapping
{
    public class DirectoryCategoryMap : BaseEntityMap<DirectoryCategory>
    {
        public DirectoryCategoryMap()
        {
            Property(u => u.Name).HasColumnName("name").IsRequired();
            HasOptional(u => u.Parent).WithMany().Map(x=>x.MapKey("parent_id"));
            
            ToTable("directory_category");
        }
    }
}
