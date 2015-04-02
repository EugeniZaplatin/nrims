
using Noris.Data.Entity;

namespace Noris.Core.Dao.Mapping
{
    public class DirectoryVersionMap : BaseEntityMap<DirectoryVersion>
    {
        public DirectoryVersionMap()
        {
            Property(u => u.Description).HasColumnName("description");
            Property(u => u.VersionDate).HasColumnName("version_date").IsRequired();
            Property(u => u.VersionNumber).HasColumnName("version_number");
            HasRequired(u => u.Directory).WithMany().Map(x=>x.MapKey("category_id"));
            
            ToTable("directory_version");
        }
    }
}
