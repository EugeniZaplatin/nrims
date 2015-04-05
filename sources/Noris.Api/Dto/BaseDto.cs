namespace Noris.Data.Dto
{
    /// <summary>
    /// Base data transfer object for input directories data from external sources
    /// </summary>
    public abstract class BaseDto
    {
        public string Name { get; set; }

        /// <summary>
        /// Unique code of records
        /// </summary>
        public string Code { get; set; }

    }
}
