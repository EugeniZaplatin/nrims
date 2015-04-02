
using Noris.Data.Entity;

namespace Noris.Core.Dao.Mapping
{
    public class DirectoryMap : BaseEntityMap<Directory>
    {
        public DirectoryMap()
        {
            Property(u => u.Name).HasColumnName("name").IsRequired();
            Property(u => u.FeedbackEmail).HasColumnName("feedback_email").IsRequired();
            Property(u => u.BriefDescription).HasColumnName("brief_bescription");
            Property(u => u.FullDescription).HasColumnName("full_description");
            Property(u => u.Owner).HasColumnName("owner");
            Property(u => u.Responser).HasColumnName("responser");
            Property(u => u.XmlStructure).HasColumnName("xml_structure").IsRequired();
            HasRequired(u => u.Category).WithMany().Map(x=>x.MapKey("category_id"));
            
            ToTable("directory");
        }
    }
}
