using System;

namespace Noris.Data.Dpo
{
    /// <summary>
    /// Version of directory. Each record should has link to any directory version
    /// </summary>
    public class DirectoryVersionDpo : BaseDpo
    {
        /// <summary>
        /// Record version in x.y.z.s format, ehat can be converted in Version type
        /// </summary>
        public string VersionNumber { get; set; }

        public DateTime VersionDate { get; set; }

    }
}
