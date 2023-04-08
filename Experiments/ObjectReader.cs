using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    internal class ObjectReader
    {
        string filePath;
        public ObjectReader(string path)
        {
            filePath = path;
        }

        public VEMLObject Read()
        {
            var text = File.ReadAllText(filePath);

        }

        public static List<(int start, int end)> GetBlocks()
        {

        }
    }

    class VEMLObject : List<VELMProperty>
    {
        public string Name;
    }
    class VELMProperty
    {
        public string Name;
        public object Value;
    }
}
