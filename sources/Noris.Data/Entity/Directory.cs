namespace Noris.Data.Entity
{
    /// <summary>
    /// One of many directories 
    ///  </summary>
    public class Directory : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// Description directory structure in Xml format
        /// Based on this structure, will be created directory record class
        /// </summary>
        public string XmlStructere { get; set; }

        /// <summary>
        /// Brief descrition display on list form
        /// </summary>
        public string BriefDescription { get; set; }

        /// <summary>
        /// Full descrition display on detail form
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

        public virtual DirectoryCategory Category { get; set; }

    }
}
