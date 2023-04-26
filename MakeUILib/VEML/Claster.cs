namespace MakeUILib.VEML
{
    public class Claster
    {
        string data;
        public Claster(string data)
        {
            this.data = data;
        }
        public List<DataStructure> Structures;
        public void SearchStructures()
        {
            Structures = new List<DataStructure>();
            List<DataStructure> structStack = new List<DataStructure>();
            for (int i = 0; i < data.Length; i++)
            {
                string c = data[i].ToString();
                var newStr = StructureType.AllTypes.FirstOrDefault(x => x.Open == c);
                if (newStr != null)
                {
                    structStack.Add(new DataStructure(newStr, i));
                }
                else
                {
                    newStr = StructureType.AllTypes.FirstOrDefault(x => x.Close == c);
                    if (newStr != null)
                    {
                        while(structStack.Count > 1 && structStack.Last().Type != newStr)
                        {
                            structStack.RemoveAt(structStack.Count - 1);
                        }
                        structStack.Last().End = i;
                        Structures.Add(structStack.Last());
                        structStack.RemoveAt(structStack.Count - 1);
                    }
                }
            }
            Structures = Structures.OrderBy(i => i.Start).ToList();
        }
    }
}