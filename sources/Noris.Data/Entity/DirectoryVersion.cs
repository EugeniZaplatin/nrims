using System;

namespace Noris.Data.Entity
{
    /// <summary>
    /// Version of directory. Each record should has link to any directory version
    /// </summary>
    public class DirectoryVersion : BaseEntity
    {
        public Directory Directory { get; set; }

        /// <summary>
        /// Record version in x.y.z.s format, ehat can be converted in Version type
        /// </summary>
        public string VersionNumber { get; set; }

        public DateTime VersionDate { get; set; }

        public string Description { get; set; }
    }
}
