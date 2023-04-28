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
                var newText = '\u0001'.ToString() + ((char)(i + 2)).ToString();
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
        object parce(string strValue)
        {
            object value = null;

            if (strValue.StartsWith('\u0001'))
            {
                var vemlValue = Structures[strValue[1] - 2];
                if (vemlValue.Type == StructureType.String)
                {
                    value = vemlValue.Text.Trim('\"');
                }
                else if (vemlValue.Type == StructureType.Array)
                {
                    value = vemlValue.GetArray();
                }
                else if (vemlValue.Type == StructureType.Object)
                {
                    value = vemlValue.ToVEML();
                }
            }
            else
            {
                value = VEMLObject.ParceValue(strValue);
            }
            return value;
        }
        public VEMLObject ToVEML()
        {
            string[] parts;
            List<VEMLProperty> loadProps(string[] parts)
            {
                var vOjb = new List<VEMLProperty>();
                foreach (var part in parts)
                {
                    var splited = part.Split('=');
                    var name = splited[0].Trim('\n');
                    var strValue = splited[1].Trim('\n');
                    object value = parce(strValue);
                    vOjb.Add(new VEMLProperty() { Name = name, Value = value });
                }
                return vOjb;
            }
            List<VEMLObject> loadObjs(string list)
            {
                var structs = list.Split('\u0001', StringSplitOptions.RemoveEmptyEntries);
                return structs.Select(i => Structures[i[0] - 2].ToVEML()).ToList();
            }
            var clearData = ExtendedText[1..^1];
            if (ExtendedText.Contains(':'))
            {

                var splitedCD = clearData.Split(":");
                var propPart = splitedCD[0];
                parts = propPart.Split(" ");
                var main = loadProps(parts[1..]);
                var list = loadObjs(splitedCD[1]);
                var finCol = new VEMLCollection(parts[0]) { Items = list, Properties = main };

                return finCol;
            }
            else
            {
                parts = clearData.Split(' ');
                var props = loadProps(parts[1..]);
                var finOnj = new VEMLObject(parts[0]) { Properties = props };
                return finOnj;
            }
        }
        public override string ToString()
        {
            return $"{Type.Name} start at {Start} end at {End}";
        }
        public object[] GetArray()
        {
            if (Type != StructureType.Array)
            {
                throw new Exception();
            }
            var crearData = ExtendedText[1..^1];
            var splited = crearData.Split(" ");
            var ret = new object[splited.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = parce(splited[i]);
            }
            return ret;
        }
    }
    public class StructureType
    {
        public readonly static StructureType Object = new StructureType("Object", ".", ";");
        public readonly static StructureType Array = new StructureType("Array", "[", "]");
        public readonly static StructureType Expression = new StructureType("Expression", "{", "}");
        public readonly static StructureType String = new StructureType("String", "\"", "\"");
        public readonly static List<StructureType> AllTypes = new List<StructureType>() { Object, Array, Expression, String };
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
