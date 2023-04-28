using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
