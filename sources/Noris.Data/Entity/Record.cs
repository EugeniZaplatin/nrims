using Noris.Data.Constants;


namespace Noris.Data.Entity
{
    /// <summary>
    /// Record of eny directory
    /// </summary>
    public class Record : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// Unique code of records
        /// </summary>
        public string Code { get; set; }

        public RecordStatuses Status { get; set; }

        /// <summary>
        /// Content in json or xml formats what contain fild name with value additional properties
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Directory which record owned
        /// </summary>
        public virtual Directory Directory { get; set; }

        public virtual DirectoryVersion Version { get; set; }
    }
}
