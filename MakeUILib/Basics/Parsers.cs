using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public static partial class Parsers
    {
        [ParceMethod(typeof(int), typeof(double))]
        public static double ToInt(int a)
        {
            return (double)a;
        }
        [ParceMethod(typeof(double), typeof(int))]
        public static int ToDouble(double a)
        {
            return (int)a;
        }
    }
}
