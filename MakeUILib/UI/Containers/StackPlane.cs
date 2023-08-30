using MakeUILib.Basics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    [VEMLPseudonym("StackPlane")]
    public class StackPlane : Container
    {
        public Orientation Direction { get; set; }
        public Indent Spacing { get; set; }
        public override Texture Draw()
        {
            CreateDefaultTexture();

            var workList = Children.ToArray();
            List<(ViewElement, Texture)> ts = FinalRenderList();
            var move = new Vector2d(Spacing.Left, Spacing.Top);
            foreach (var child in ts)
            {
                var c = child.Item1;
                var t = child.Item2;
                var finalPosition = move + new Vector2d(c.Margin.Left, c.Margin.Top);
                _texture.Draw(new Sprite(child.Item2) { Position = finalPosition });
                move += Direction switch { Orientation.Vertical => new Vector2d(0, t.Size.Y + Spacing.Vertical + c.Margin.Vertical), Orientation.Horizontal => new Vector2d(t.Size.X + Spacing.Horisontal + c.Margin.Horisontal, 0) };
            }

            return FinalizeTexture();
        }
    }
}
