namespace Noris.Data.Entity
{
    /// <summary>
    /// One of many directories 
    ///  </summary>
    public class Directory : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Any organization to whom belongs directory
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Person conducting directory
        /// </summary>
        public string Responser { get; set; }
    }
}
