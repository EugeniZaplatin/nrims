using System;
using System.Runtime.Serialization;

namespace Noris.WcfService.Data
    
{
    /// <summary>
    /// Directory record
    /// </summary>
    [DataContract]
    public class RecordSto : BaseSto
    {
        [DataMember]
        public string Version { get; set; }


        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }


    }
}
