using Noris.Data.Constants;


namespace Noris.Data.Dto
{
    /// <summary>
    /// Record of any directory for exchange with external applications
    /// </summary>
    public class RecordDto : BaseDto
    {
        
        public RecordStatuses Status { get; set; }

        /// <summary>
        /// Content contain verious object with different additional properties depending on directory
        /// </summary>
        
        public dynamic Contents { get; set; }
       
    }
}
