
namespace Noris.Data.Dpo
{
    /// <summary>
    /// Hierarchical categories of directories for grouping their
    /// </summary>
    public class DirectoryCategoryDpo : BaseDpo
    {
        /// <summary>
        /// Parent node of category
        /// </summary>
        public DirectoryCategoryDpo Parent { get; set; }
    }
}
