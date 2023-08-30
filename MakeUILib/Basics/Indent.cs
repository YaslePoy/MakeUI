using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public struct Indent
    {

        public double t, b, l, r;

        public event EventHandler Changed;

        public double Top
        {
            get => t; set
            {
                t = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        public double Bottom
        {
            get => b; set
            {
                b = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        public double Left
        {
            get => l; set
            {
                l = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        public double Right
        {
            get => r; set
            {
                r = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public Vector2d Offset => new Vector2d(Left, Top);
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

        public Vector2d Sum() => new Vector2d(Horisontal, Vertical);
        public static Indent operator +(Indent left, Indent right) => new Indent(left.Top + right.Top, left.Bottom + right.Bottom, left.Left + right.Left, left.Right + right.Right);
    }
}
