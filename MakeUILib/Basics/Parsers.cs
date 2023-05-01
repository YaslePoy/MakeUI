using MakeUILib.UI;
using MakeUILib.UI.Containers;
using MakeUILib.UI.Controls;
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
        [ParceMethod(typeof(object[]), typeof(LengthsDefinitions))]
        public static LengthsDefinitions ToLD(object[] array)
        {
            return new LengthsDefinitions() { Lens = array.Select(i => (object)i).ToList() };
        }
        [ParceMethod(typeof(double), typeof(Indent))]
        public static Indent ToIndent(double a)
        {
            return new Indent(a);
        }
        [ParceMethod(typeof(string), typeof(ViewElement))]
        public static ViewElement ToInt(string text)
        {
            return new TextView(text) as ViewElement;
        }
    }
}
