using System.Dynamic;
using System.Xml.Linq;

namespace Noris.Services.Utils
{
    /// <summary>
    /// Building dynamic part of directory record structure
    /// </summary>
    public class DynamicClassBuilder : DynamicObject
    {
        XElement element;

        public DynamicClassBuilder(string filename)
        {
            element = XElement.Load(filename);
        }

        public DynamicClassBuilder(XElement el)
        {
            element = el;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (element == null)
            {
                result = null;
                return false;
            }

            XElement sub = element.Element(binder.Name);

            if (sub == null)
            {
                result = null;
                return false;
            }
            else
            {
                result = new DynamicClassBuilder(sub);
                return true;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (element == null)
            {
                return false;
            }

            XElement sub = element.Element(binder.Name);

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
            if (element != null)
            {
                return element.Value;
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
                if (element == null)
                {
                    return string.Empty;
                }

                return element.Attribute(attr).Value;
            }
        }
    }
}
