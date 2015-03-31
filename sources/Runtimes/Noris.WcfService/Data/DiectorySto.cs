using System;
using System.Runtime.Serialization;

namespace Noris.WcfService.Data
    
{
    [DataContract]
    public class DiectorySto : BaseSto
    {
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Brief descrition display on list form
        /// </summary>
        [DataMember]
        public string BriefDescription { get; set; }

    }
}
