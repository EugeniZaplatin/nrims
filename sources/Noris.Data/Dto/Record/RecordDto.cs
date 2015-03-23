using System;
using Noris.Data.Constants;


namespace Noris.Data.Dto
{
    /// <summary>
    /// Record of any directory for exchange with external applications
    /// </summary>
    [Serializable]
    public class RecordDto : BaseDto
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
       
    }
}
