using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    internal class ParceMethod : Attribute
    {
        public Type From;
        public Type To;
        public ParceMethod(Type from, Type to) 
        {
            From = from;
            To = to;
        }
        public bool IsFor(Type t1, Type t2) => t1 == From && t2 == To;
    }
}
