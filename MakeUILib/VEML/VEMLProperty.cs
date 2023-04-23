using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.VEML
{
    public class VEMLProperty
    {
        public string Name;
        public object Value;

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
