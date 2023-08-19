using MakeUILib.UI;
using SFML.Graphics;
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

        [ParceMethod(typeof(string), typeof(Color))]
        public static Color ToColorHEX(string a)
        {
            return new Color(Convert.ToUInt32(a.Length == 8 ? a : a + "ff", 16));
        }
        [ParceMethod(typeof(int[]), typeof(Color))]
        public static Color ToColorRGB(int[] a)
        {
            switch (a.Length)
            {
                case 3:
                    return new Color((byte)a[0], (byte)a[1], (byte)a[2]);
                case 4:
                    return new Color((byte)a[0], (byte)a[1], (byte)a[2], (byte)a[3]);
                case 1:
                    return new Color((byte)a[0], (byte)a[0], (byte)a[0]);
                default:
                    return Color.Transparent;
            }
        }
    }
}
