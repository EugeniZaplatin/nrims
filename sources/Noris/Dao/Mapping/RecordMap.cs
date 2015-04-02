
using Noris.Data.Entity;

namespace Noris.Core.Dao.Mapping
{
    public class RecordMap : BaseEntityMap<Record>
    {
        public RecordMap()
        {
            Property(u => u.Name).HasColumnName("name").IsRequired();
            Property(u => u.Code).HasColumnName("code").IsRequired();
            Property(u => u.Contents).HasColumnName("contents");
            Property(u => u.Status).HasColumnName("status");
            HasRequired(u => u.Version).WithMany().Map(x=>x.MapKey("directory_version_id"));
            
            ToTable("record");
        }
    }
}
