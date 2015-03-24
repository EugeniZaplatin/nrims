using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Xml.Linq;


namespace Noris.Data.Sto
{
    /// <summary>
    /// Universal record of veriouse directories for export data
    /// on reqest client system
    /// </summary>
    [DataContract]
    public class DynamicSto : DynamicObject
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string version { get; set; }

        [DataMember]
        XElement _element;

        public DynamicSto()
        { }

        public DynamicSto(string filename)
        {
            _element = XElement.Load(filename);
        }

        public DynamicSto(XElement el)
        {
            _element = el;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_element == null)
            {
                result = null;
                return false;
            }

            XElement sub = _element.Element(binder.Name);

            if (sub == null)
            {
                result = null;
                return false;
            }
            
            result = new DynamicSto(sub);
            return true;
            
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_element == null)
            {
                return false;
            }

            XElement sub = _element.Element(binder.Name);

            if (sub == null)
            {
                return false;
            }
            else
            {
                sub.SetValue(value);
                return true;
            }
        }
        public override string ToString()
        {
            if (_element != null)
            {
                return _element.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public string this[string attr]
        {
            get
            {
                if (_element == null)
                {
                    return string.Empty;
                }

                return _element.Attribute(attr).Value;
            }
        }
    }

}
