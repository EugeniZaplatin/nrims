
namespace Noris.Data.Entity
{
    /// <summary>
    /// Hierarchical categories of directories for grouping their
    /// </summary>
    public class DirectoryCategory : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// Parent node of category
        /// </summary>
        public virtual DirectoryCategory Parent { get; set; }
    }
}
