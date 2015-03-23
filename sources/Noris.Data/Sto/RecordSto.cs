using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;


namespace Noris.Data.Sto
{
    /// <summary>
    /// Universal record of veriouse directories for export data
    /// on reqest client system
    /// </summary>
    [DataContract]
    public class RecordSto : DynamicObject
    {
        #region mandatory properties for all diretories records

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string version { get; set; }

        #endregion

        #region dynamically generated properties

        [DataMember]
        Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();

            return _dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name.ToLower()] = value;

            return true;
        }

        #endregion
    }
}
