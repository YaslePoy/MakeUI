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
        public List<ViewElement> Children => throw new NotImplementedException();
        Dictionary<ViewElement, Vector2> coordinates;
        public override void Draw(ViewElement parent)
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
        public void SetPosition(Vector2 position, ViewElement element) {
            if (!coordinates.ContainsKey(element))
                return;
            coordinates[element] = position;
        }
    }
}
