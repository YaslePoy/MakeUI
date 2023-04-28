using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    internal class VEMLPseudonymAttribute : Attribute
    {
        public string VEMLName;

        public VEMLPseudonymAttribute(string vemlName)
        {
            VEMLName = vemlName;
        }
    }
}
