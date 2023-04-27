using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.VEML
{
    public class DataStructure
    {
        public Claster Origin;
        public StructureType Type;
        public string Text;
        public List<DataStructure> Structures;
        public int Start = -1;
        public int End = -1;
        public string ExtendedText;
        public DataStructure(StructureType type, int start)
        {
            Type = type;
            Start = start;
            Structures = new List<DataStructure>();
        }
        public List<DataStructure> GetInside(Claster total)
        {
            return total.Structures.Where(i => i.Start > Start && i.End < End).ToList();
        }

        public void UpdateStructures()
        {
            foreach (var i in Structures)
            {
                i.LoadText();
                var zeroLevel = new List<DataStructure>();
                var current = Origin.Structures.FirstOrDefault(j => j.Start > i.Start && j.End < i.End);
                while (current != null)
                {
                    current.LoadText();
                    zeroLevel.Add(current);
                    current = Origin.Structures.FirstOrDefault(j => j.Start > current.End && j.End < i.End);
                }
                i.Structures = zeroLevel;
                i.UpdateStructures();
            }
        }
        public void LoadText()
        {
            Text = Origin.Data.Substring(Start, End - Start + 1);
        }
        public void Extend()
        {
            ExtendedText = Text;
            for (int i = 0; i < Structures.Count; i++)
            {
                var toReplace = Structures[i].Text;
                var newText = '\u0001'.ToString() + ((char)i).ToString();
                ExtendedText = ExtendedText.Replace(toReplace, newText);
                Structures[i].Extend();
            }
        }
        public void ToLocalPositions()
        {
            foreach (var s in Structures)
            {
                s.ToLocalPositions();
                s.Start = s.Start - Start;
                s.End = s.Start + s.Text.Length - 1;
            }
        }
        public VEMLObject ToVEML()
        {

            var parts = ExtendedText[1..^1].Split(" ");
            VEMLObject ret = new VEMLObject(parts[0]);

            return null;
        }
        public override string ToString()
        {
            return $"{Type.Name} start at {Start} end at {End}";
        }
        public object[] GetArray()
        {
            if(Type != StructureType.Array)
            {
                throw new Exception();
            }
            
            return null;
        }
    }
    public class StructureType
    {
        public readonly static StructureType Object = new StructureType("Object", ".", ";");
        public readonly static StructureType Array = new StructureType("Array", "[", "]");
        public readonly static StructureType Expression = new StructureType("Expression", "{", "}");
        public readonly static StructureType String = new StructureType("String", "\"", "\"");
        public readonly static List<StructureType> AllTypes = new List<StructureType>() { Object, Array, Expression, String};
        public string Name;
        public string Open;
        public string Close;
        public StructureType(string name, string open, string close)
        {
            Name = name;
            Open = open;
            Close = close;
        }
        public override string ToString()
        {
            return $"{Name} type";
        }
    }
}
