using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.VEML
{
    public class VEMLCollection : VEMLObject
    {
        public List<VEMLObject> Items;
        public VEMLCollection(string name) : base(name) {
            Items = new List<VEMLObject>();
        }
        public void AddItem(VEMLObject item)
        {
            Items.Add(item);
        }
        public override string ToString()
        {
            return $"{TypeName} {string.Join(' ', Properties.Select(i => i.ToString()))}" + (Items.Count > 0 ? $":{string.Join("", Items.Select(i => i.ToString()))}" : 0) + ";";
        }
    }
}
