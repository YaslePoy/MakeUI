using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.Basics
{
    public class DVector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public DVector3(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }
        public DVector3(double x, double y, double z) : this(x, y)
        {
            Z = z;
        }

        public static bool operator ==(DVector3 p1, DVector3 p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        public static bool operator !=(DVector3 p1, DVector3 p2)
        {
            if (p1 is null || p2 is null)
                return false;
            return p1.X != p2.X || p1.Y != p2.Y || p1.Z != p2.Z;
        }

        public static DVector3 operator +(DVector3 p1, DVector3 p2)
        {

            return new DVector3(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static DVector3 operator -(DVector3 p1, DVector3 p2)
        {
            return new DVector3(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static DVector3 operator *(DVector3 p, double k)
        {

            return new DVector3(p.X * k, p.Y * k, p.Z * k);
        }

        public static DVector3 operator /(DVector3 p, double k)
        {
            return new DVector3(p.X / k, p.Y / k, p.Z / k);
        }

        public double GetDistanceTo(DVector3 aim)
        {
            return Math.Sqrt((aim.X - X).Pow() + (aim.Y - Y).Pow() + (aim.Z - Z));
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is DVector3)) return false;
            DVector3 p = (DVector3)obj;
            return this == p;
        }
        public DVector3 Rounded(int a = 4)
        {
            return new DVector3(X.Round(a), Y.Round(a), Z.Round(a));
        }
        public void Round(int a = 4)
        {
            X = X.Round(a);
            Y = Y.Round(a);
            Z = Z.Round(a);
        }
        public override string ToString()
        {
            var r = Rounded();
            return $"{{X:{r.X};Y:{r.Y};Z:{r.Z}}}";
        }
    }
}
