using System;
using System.Runtime.Serialization;

namespace Noris.WcfService.Data
    
{
    /// <summary>
    /// Category of directories
    /// </summary>
    [DataContract]
    public class CategorySto : BaseSto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid Parent { get; set; }
    }
}
