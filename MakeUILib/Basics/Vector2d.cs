using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public class Vector2d
    {
        public readonly static Vector2d Zero = new Vector2d(0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public Vector2d()
        {
            X = 0;
            Y = 0;
        }
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Vector2d p1, Vector2d p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Vector2d p1, Vector2d p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X != p2.X || p1.Y != p2.Y;
        }

        public static Vector2d operator +(Vector2d p1, Vector2d p2)
        {

            return new Vector2d(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Vector2d operator -(Vector2d p1, Vector2d p2)
        {
            return new Vector2d(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Vector2d operator *(Vector2d p, double k)
        {
            p.X *= k;
            p.Y *= k;
            return p;
        }

        public static Vector2d operator /(Vector2d p, double k)
        {
            p.X /= k;
            p.Y /= k;
            return p;
        }

        public double GetDistanceTo(Vector2d aim)
        {
            return Math.Sqrt(Math.Pow((aim.X - this.X), 2) + Math.Pow((aim.Y - this.Y), 2));
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Vector2d)) return false;
            Vector2d p = (Vector2d)obj;
            return this == p;
        }
        public Vector2d Rounded(int a = 4)
        {
            return new Vector2d(X.Round(a), Y.Round(a));
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

        public static implicit operator Vector2f(Vector2d v)
        {
            return new Vector2f((float)v.X, (float)v.Y);
        }

        public bool IsZero() => X == 0 && Y == 0;
    }
}
