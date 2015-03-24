using System.Dynamic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Noris.Data
{
    /// <summary>
    /// Building dynamic part of directory record structure
    /// </summary>
    [DataContract]
    public class DynamicSto : DynamicObject
    {
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
            else
            {
                result = new DynamicXml(sub);
                return true;
            }
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

    }
}
