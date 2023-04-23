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
        Dictionary<ViewElement, Vector2> coordinates;
        public override void Draw(Vector2 position)
        {

        }

        public List<(ViewElement element, Vector2 position)> GetComposition()
        {
            return coordinates.Select(i => (i.Key, i.Value)).ToList();
        }
        public override void AddChild(ViewElement child)
        {
            base.AddChild(child);
            coordinates.Add(Children.Last(), Vector2.Zero);
        }
        public void SetPosition(ViewElement element, Vector2 position) {
            if (!coordinates.ContainsKey(element))
                return;
            coordinates[element] = position;
        }
    }
}
