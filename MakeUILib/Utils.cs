using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib
{
    public static class Utils
    {
        public const double PtToPx = 1.3281472327365;
        public const double ToRad = 0.017453292519943295769236907684886;
        public const double ToDeg = 57.295779513082320876798154814105;
        public const float ToRadF = 0.017453292519943295769236907684886f;
        public const float ToDegF = 57.295779513082320876798154814105f;
        public static double Pow(this double a, int r = 2) => Math.Pow(a, r);

        public static double Round(this double a, int r = 4) => Math.Round(a, r);

        public static double Sin(this double a) => Math.Sin(a * ToRad);

        public static double Cos(this double a) => Math.Cos(a * ToRad);

        public static double Tan(this double a) => Math.Tan(a * ToRad);

        public static double Sqrt(this double a) => Math.Sqrt(a);

        public static double Abs(this double a) => Math.Abs(a);

        public static double ToRadians(this double a)
        {
            return a * ToRad;
        }
        public static double ToDegrees(this double radians)
        {
            return radians * ToDeg;
        }

        public static double ToRads(double angle)
        {

            return angle * ToRad;
        }
    }
}
