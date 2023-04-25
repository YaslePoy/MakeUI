using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public class DVector2
    {
        public readonly static DVector2 Zero = new DVector2(0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public DVector2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(DVector2 p1, DVector2 p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(DVector2 p1, DVector2 p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X != p2.X || p1.Y != p2.Y;
        }

        public static DVector2 operator +(DVector2 p1, DVector2 p2)
        {

            return new DVector2(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static DVector2 operator -(DVector2 p1, DVector2 p2)
        {
            return new DVector2(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static DVector2 operator *(DVector2 p, double k)
        {
            p.X *= k;
            p.Y *= k;
            return p;
        }

        public static DVector2 operator /(DVector2 p, double k)
        {
            p.X /= k;
            p.Y /= k;
            return p;
        }

        public double GetDistanceTo(DVector2 aim)
        {
            return Math.Sqrt(Math.Pow((aim.X - this.X), 2) + Math.Pow((aim.Y - this.Y), 2));
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is DVector2)) return false;
            DVector2 p = (DVector2)obj;
            return this == p;
        }
        public DVector2 Rounded(int a = 4)
        {
            return new DVector2(X.Round(a), Y.Round(a));
        }
        public void Round(int a = 4)
        {
            X = X.Round(a);
            Y = Y.Round(a);
        }
        public override string ToString()
        {
            var r = Rounded();
            return $"{{X:{r.X};Y:{r.Y}}}";
        }

        public static implicit operator Vector2f(DVector2 v)
        {
            return new Vector2f((float)v.X, (float)v.Y);
        }
    }
}
