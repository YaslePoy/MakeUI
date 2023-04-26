using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.VEML
{
    public class DataStructure
    {
        public StructureType Type;
        public int Start = -1;
        public int End = -1;

        public DataStructure(StructureType type, int start)
        {
            Type = type;
            Start = start;
        }

        public List<DataStructure> GetInside(Claster total)
        {
            return total.Structures.Where(i => i.Start > Start && i.End < End).ToList();
        }
        public override string ToString()
        {
            return $"{Type.Name} start at {Start} end at {End}";
        }
    }
    public class StructureType
    {
        public readonly static StructureType Object = new StructureType("Object", ".", ";");
        public readonly static StructureType Array = new StructureType("Array", "[", "]");
        public readonly static StructureType Expression = new StructureType("Expression", "{", "}");
        public readonly static List<StructureType> AllTypes = new List<StructureType>() { Object, Array, Expression};
        public string Name;
        public string Open;
        public string Close;
        public StructureType(string name, string open, string close)
        {
            Name = name;
            Open = open;
            Close = close;
        }



    }
}
