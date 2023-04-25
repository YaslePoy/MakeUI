using MakeUILib.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    internal class PositionalPlane : Container
    {
        Dictionary<ViewElement, DVector2> coordinates;
        public override void Draw(DVector2 position)
        {
            foreach (var item in coordinates)
            {
                item.Key.Draw(item.Value);
            }
        }

        public List<(ViewElement element, DVector2 position)> GetComposition()
        {
            return coordinates.Select(i => (i.Key, i.Value)).ToList();
        }
        public override void AddChild(ViewElement child)
        {
            base.AddChild(child);
            coordinates.Add(Children.Last(), DVector2.Zero);
        }
        public void SetPosition(ViewElement element, DVector2 position) {
            if (!coordinates.ContainsKey(element))
                return;
            coordinates[element] = position;
        }
    }
}
