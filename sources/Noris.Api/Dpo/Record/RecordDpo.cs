using Noris.Data.Constants;


namespace Noris.Data.Dpo
{
    /// <summary>
    /// Record of any directory
    /// </summary>
    public class RecordDpo : BaseDpo
    {
        /// <summary>
        /// Unique code of records
        /// </summary>
        public string Code { get; set; }

        public RecordStatuses Status { get; set; }

        /// <summary>
        /// Content contain verious object with different additional properties depending on directory
        /// </summary>
        public dynamic Contents { get; set; }

        /// <summary>
        /// Directory which record owned
        /// </summary>
        public  DirectoryDpo DirectoryDpo { get; set; }

        public  DirectoryVersionDpo VersionDpo { get; set; }
    }
}
