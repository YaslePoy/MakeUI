using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public struct Indent
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

        public Indent(double a)
        {
            Top = a;
            Bottom = a;
            Left = a;
            Right = a;
        }

        public Indent(double horizontal, double vertical)
        {
            Left = horizontal;
            Right = horizontal;
            Top = vertical;
            Bottom = vertical;

        }

        public Indent(double top, double bottom, double left, double right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }

        public double Horisontal => Right + Left;
        public double Vertical => Top + Bottom;
    }
}
