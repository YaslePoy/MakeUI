namespace MakeUILib.VEML
{
    public class Claster
    {
        public string Data;
        public List<DataStructure> Structures;

        public Claster(string data)
        {
            this.Data = data;
            Data = Data.Replace("\r", "");
            Data = Data.Replace("\t", "");
            Structures = new List<DataStructure>();
        }
        public DataStructure MainStruct()
        {
            var max = Structures.First();
            var zeroLevel = new List<DataStructure>();
            var current = Structures.FirstOrDefault(i => i.Start > max.Start && i.End < max.End);
            while (current != null)
            {
                zeroLevel.Add(current);
                current = Structures.FirstOrDefault(i => i.Start > current.End && i.End < max.End);
            }
            max.Structures = zeroLevel;
            return max;
        }
        public void SearchStructures()
        {
            Structures = new List<DataStructure>();
            List<DataStructure> structStack = new List<DataStructure>();
            void CloseStruct(int end)
            {
                structStack.Last().End = end;
                Structures.Add(structStack.Last());
                structStack.RemoveAt(structStack.Count - 1);
            }
            for (int i = 0; i < Data.Length; i++)
            {
                string c = Data[i].ToString();
                var newStr = StructureType.AllTypes.FirstOrDefault(x => x.Open == c);
                if (newStr != null)
                {
                    if (structStack.Count > 0 && structStack.Last().Type == StructureType.String)
                    {
                        CloseStruct(i);
                    }
                    else
                    {
                        structStack.Add(new DataStructure(newStr, i) { Origin = this });
                    }
                }
                else
                {
                    newStr = StructureType.AllTypes.FirstOrDefault(x => x.Close == c);
                    if (newStr != null)
                    {
                        while (structStack.Count > 1 && structStack.Last().Type != newStr)
                        {
                            structStack.RemoveAt(structStack.Count - 1);
                        }
                        CloseStruct(i);
                    }
                }
            }
            Structures = Structures.OrderBy(i => i.Start).ToList();
        }
    }
}