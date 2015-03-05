using System;
using Noris.Data.Constants;


namespace Noris.Data.Entity
{
    public class Record : BaseEntity
    {
        /// <summary>
        /// Directory which record owned
        /// </summary>
        public Directory Directory { get; set; }

        public string Code { get; set; }

        public RecordStatuses Status { get; set; }

        /// <summary>
        /// Content in json format what contain fild name with value
        /// </summary>
        public string Contents { get; set; }

        public DirectoryVersion Version { get; set; }
    }
}
