using Noris.Data.Constants;


namespace Noris.Data.Dpo
{
    /// <summary>
    /// Record of eny directory
    /// </summary>
    public class RecordDpo : BaseDpo
    {
        /// <summary>
        /// Unique code of records
        /// </summary>
        public string Code { get; set; }

        public RecordStatuses Status { get; set; }

        /// <summary>
        /// Content in json format what contain fild name with value additional properties
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Directory which record owned
        /// </summary>
        public  DirectoryDpo DirectoryDpo { get; set; }

        public  DirectoryVersionDpo VersionDpo { get; set; }
    }
}
