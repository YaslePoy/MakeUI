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

        public object this[string fieldName] => Properties.FirstOrDefault(i => i.Name == fieldName).Value;

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
            return value;
        }
        //public virtual object ToReal()
        //{
        //    var totalAssm = Utils.TotalTypes;
        //    Type curType = null;
        //    foreach (var t in totalAssm)
        //    {
        //        var attrsNP = t.GetCustomAttributes(typeof(VEMLPseudonymAttribute));
        //        if (attrsNP == null) continue;
        //        var attrs = attrsNP.Select(i => i as VEMLPseudonymAttribute).ToList();
        //        var need = attrs.FirstOrDefault(i => i.VEMLName == TypeName);
        //        if (need == null && t.Name != TypeName)
        //            continue;
        //        else
        //        {
        //            curType = t;
        //            break;
        //        }
        //    }
        //    if (curType == null)
        //        return null;
        //    var retObj = Activator.CreateInstance(curType);
        //    foreach (var prop in Properties)
        //    {

        //        var propO = curType.GetProperty(prop.Name);
        //        if (propO.PropertyType.IsEnum)
        //        {
        //            propO.SetValue(retObj, Enum.Parse(propO.PropertyType, prop.Value.ToString()));
        //        }
        //        else
        //        {
        //            var localVal = VEMLToRealParce(prop.Value);
        //            var valueType = localVal.GetType();
        //            if (valueType.IsSubclassOf(propO.PropertyType) || propO.PropertyType == valueType)
        //                propO.SetValue(retObj, VEMLToRealParce(prop.Value));
        //            else
        //            {
        //                var methods = typeof(Parsers).GetMethods();
        //                var m = methods.Where(i => i.GetCustomAttribute(typeof(ParceMethod)) != null).FirstOrDefault(i => (i.GetCustomAttribute(typeof(ParceMethod)) as ParceMethod).IsFor(valueType, propO.PropertyType));
        //                if (m == null)
        //                    return null;
        //                var finalValue = m.Invoke(null, new object[] { prop.Value });
        //                propO.SetValue(retObj, VEMLToRealParce(finalValue));
        //            }
        //        }

        //    }
        //    return retObj;
        //}

        //public void LoadToInstance(object inst)
        //{
        //    var totalAssm = Utils.TotalTypes;
        //    Type curType = null;
        //    foreach (var t in totalAssm)
        //    {
        //        var attrsNP = t.GetCustomAttributes(typeof(VEMLPseudonymAttribute));
        //        if (attrsNP == null) continue;
        //        var attrs = attrsNP.Select(i => i as VEMLPseudonymAttribute).ToList();
        //        var need = attrs.FirstOrDefault(i => i.VEMLName == TypeName);
        //        if (need == null && t.Name != TypeName)
        //            continue;
        //        else
        //        {
        //            curType = t;
        //            break;
        //        }
        //    }
        //    if (curType == null)
        //        return;
        //    var ids = GetIdentifiedObjectsInside();
        //    foreach (var prop in Properties)
        //    {
        //        var propO = curType.GetProperty(prop.Name);
        //        if (propO.PropertyType.IsEnum)
        //        {
        //            propO.SetValue(inst, Enum.Parse(propO.PropertyType, prop.Value.ToString()));
        //        }
        //        else
        //        {
        //            var localVal = VEMLToRealParce(prop.Value);
        //            var valueType = localVal.GetType();
        //            if (valueType.IsSubclassOf(propO.PropertyType) || propO.PropertyType == valueType)
        //                propO.SetValue(inst, VEMLToRealParce(prop.Value));
        //            else
        //            {
        //                var methods = typeof(Parsers).GetMethods();
        //                var m = methods.Where(i => i.GetCustomAttribute(typeof(ParceMethod)) != null).FirstOrDefault(i => (i.GetCustomAttribute(typeof(ParceMethod)) as ParceMethod).IsFor(valueType, propO.PropertyType));
        //                if (m == null)
        //                    return;
        //                var finalValue = m.Invoke(null, new object[] { prop.Value });
        //                propO.SetValue(inst, VEMLToRealParce(finalValue));
        //            }
        //        }
        //    }
        //}
        //public static object VEMLToRealParce(object o)
        //{
        //    if (o is VEMLObject)
        //        return ((VEMLObject)o).ToReal();
        //    if (o is object[])
        //    {
        //        var oArray = (object[])o;
        //        var retArray = new object[oArray.Length];
        //        for (int i = 0; i < retArray.Length; i++)
        //        {
        //            retArray[i] = VEMLToRealParce(oArray[i]);
        //        }
        //        return retArray;
        //    }
        //    return o;
        //}
        public virtual List<VEMLObject> GetIdentifiedObjectsInside()
        {
            var obs = new List<VEMLObject>();
            foreach (var item in Properties)
            {
                if (item.IsObject)
                {
                    obs.AddRange((item.Value as VEMLObject).GetIdentifiedObjectsInside());
                }
                else if(item.Value is List<VEMLObject>)
                {
                    foreach (var i in item.Value as List<VEMLObject>)
                    {
                        obs.AddRange(i.GetIdentifiedObjectsInside());
                    }
                }
                else if (item.Value is string && item.Name == "Id")
                    obs.Add(this);

            }
            return obs;
        }
    }
}
