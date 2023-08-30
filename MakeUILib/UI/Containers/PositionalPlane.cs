using MakeUILib.Basics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    [VEMLPseudonym("PositionalPlane")]
    internal class PositionalPlane : Container
    {
        Dictionary<ViewElement, Vector2d> coordinates;
        public override Texture Draw()
        {
            CreateDefaultTexture();

            var workList = Children.ToArray();
            List<Texture> ts = new List<Texture>();
            foreach (var child in workList)
            {
                if (!child.IsVisible)
                    continue;
                if (child.Redrawing)
                {
                    var tx = child.Draw();
                    if (!_textures.TryAdd(child, tx))
                        _textures[child] = tx;
                    ts.Add(tx);
                }
                _texture.Draw(new Sprite(_textures[child]) { Position = coordinates[child] });
            }

            return _texture.Texture;
        }

        public List<(ViewElement element, Vector2d position)> GetComposition()
        {
            return coordinates.Select(i => (i.Key, i.Value)).ToList();
        }
        public override void AddChild(ViewElement child)
        {
            base.AddChild(child);
            coordinates.Add(Children.Last(), Vector2d.Zero);
        }
        public void SetPosition(ViewElement element, Vector2d position)
        {
            if (!coordinates.ContainsKey(element))
                return;
            coordinates[element] = position;
        }
    }
}
