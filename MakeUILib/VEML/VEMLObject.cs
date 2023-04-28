using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.VEML
{
    public class VEMLObject
    {
        public string TypeName;
        public List<VEMLProperty> Properties;
        public VEMLObject(string name)
        {
            TypeName = name;
            Properties = new List<VEMLProperty>();
        }

        public void AddProprety(VEMLProperty property) { Properties.Add(property); }
        public override string ToString()
        {
            return $"{TypeName} {string.Join(' ', Properties.Select(i => i.ToString()))};";
        }

        public static dynamic ParceValue(string value)
        {
            if (value.All(i => char.IsDigit(i) || i == ','))
                return double.Parse(value);
            else if (value.All(char.IsDigit))
                return int.Parse(value);
            else if (value is "true" or "false")
                return bool.Parse(value);
            return null;
        }
        public virtual object ToReal()
        {
            var totalAssm = Utils.TotalTypes;
            Type curType = null;
            foreach (var t in totalAssm)
            {
                var attrsNP = t.GetCustomAttributes(typeof(VEMLPseudonymAttribute));
                if (attrsNP == null) continue;
                var attrs = attrsNP.Select(i => i as VEMLPseudonymAttribute).ToList();
                var need = attrs.FirstOrDefault(i => i.VEMLName == TypeName);
                if (need == null && t.Name != TypeName)
                    continue;
                else
                {
                    curType = t;
                    break;
                }
            }
            if (curType == null)
                return null;
            var retObj = Activator.CreateInstance(curType);
            foreach (var prop in Properties)
            {
                var valueType = prop.Value.GetType();
                var propO = curType.GetProperty(prop.Name);
                if (propO.PropertyType == valueType)
                    propO.SetValue(retObj, VEMLToRealParcer(prop.Value));
                else
                {
                    var methods = typeof(Parsers).GetMethods();
                    var m = methods.Where(i => i.GetCustomAttribute(typeof(ParceMethod)) != null).FirstOrDefault(i => (i.GetCustomAttribute(typeof(ParceMethod)) as ParceMethod).IsFor(valueType, propO.PropertyType));
                    var finalValue = m.Invoke(null, new object[] { prop.Value });
                    propO.SetValue(retObj, VEMLToRealParcer(finalValue));
                }
            }
            return retObj;
        }
        public static object VEMLToRealParcer(object o)
        {
            if (o is VEMLObject)
                return ((VEMLObject)o).ToReal();
            if (o is object[])
            {
                var oArray = (object[])o;
                var retArray = new object[oArray.Length];
                for (int i = 0; i < retArray.Length; i++)
                {
                    retArray[i] = VEMLObject.VEMLToRealParcer(oArray[i]);
                }
                return retArray;
            }
            return o;
        }
    }
}
