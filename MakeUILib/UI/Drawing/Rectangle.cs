using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int BorderThickness { get; set; }

        public Color MainColor { get; set; }
        public Color BorderColor { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Rectangle) return false;
            var r = obj as Rectangle;
            if (Width != r.Width || Height != r.Height) return false;
            if (BorderThickness != r.BorderThickness) return false;
            if (MainColor != r.MainColor) return false;
            return true;
        }

        public void DrawTo(RenderTexture tx)
        {
            tx.Draw(new RectangleShape(new SFML.System.Vector2f(Width, Height)) { FillColor = MainColor, OutlineColor = BorderColor, OutlineThickness = BorderThickness });
        }
    }
}
