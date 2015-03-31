
namespace Noris.Data.Dpo
{
    /// <summary>
    /// Detail, full form presentation dpo
    /// </summary>
    public class DirectoryDetailDpo : DirectoryDpo
    {
        /// <summary>
        /// Full descrition display on list form
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Any organization to whom belongs directory
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Person conducting directory
        /// </summary>
        public string Responser { get; set; }

        /// <summary>
        /// Email for feedback about eny errors, inuccuracies
        /// </summary>
        public string FeedbackEmail { get; set; }

        public DirectoryCategoryDpo CategoryDpo { get; set; }
    }
}
