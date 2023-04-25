using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    internal struct Indent
    {
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public Indent()
        { 
            Top = 0;
            Bottom = 0;
            Left = 0;
            Right = 0;
        }
    }
}
