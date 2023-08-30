using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib
{
    public static class Utils
    {
        public static List<Type> TotalTypes;
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

        public static bool Contains(this FloatRect rect, Vector2i point)
        {
            var dX = point.X - rect.Left;
            var dY = point.Y - rect.Top;
            return dX >= 0 && dX < rect.Width && dY >= 0 && dY < rect.Height;
        }

        public static Vector2f Sum(this FloatRect rect) { return new Vector2f((rect.Left + rect.Width), (rect.Top + rect.Height)); }
        public static void UpdateTypes()
        {
            var local = Assembly.GetExecutingAssembly().GetTypes().ToList();
            local.AddRange(Assembly.GetEntryAssembly().GetTypes().ToList());
            TotalTypes = local;
        }

        public static FieldInfo GetFieldDeep(this Type t, string fieldName)
        {
            var searchField = t.GetField(fieldName);
            if (searchField != null)
                return searchField;
            var bType = t.BaseType;
            while (bType != null)
            {
                searchField = bType.GetField(fieldName);
                if (searchField != null) return searchField;
                bType = bType.BaseType;
            }
            return null;
        }
        public static PropertyInfo GetProperyDeep(this Type t, string propName)
        {
            var searchField = t.GetProperty(propName);
            if (searchField != null)
                return searchField;
            var bType = t.BaseType;
            while (bType != null)
            {
                searchField = bType.GetProperty(propName);
                if (searchField != null) return searchField;
                bType = bType.BaseType;
            }
            return null;
        }
        public static int GetSequenceHashCode<T>(this List<T> sequence)
        {
            return sequence
                .Select(item => item.GetHashCode())
                .Aggregate((total, nextCode) => total ^ nextCode);
        }
    }
}
