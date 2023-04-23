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
            return null;
        }

        public static List<(char, int)> GetBlocks(string text)
        {
            List<(char, int)> line = new List<(char, int)>();
            int l = 0;
            foreach (var item in text)
            {
                switch (item)
                {
                    case '.':
                        l++;
                        break;
                    case ';':
                        l--;
                        break;
                }
                line.Add((item, l));
            }
            return line;
        }
    }
}
