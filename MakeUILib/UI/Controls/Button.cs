using MakeUILib.Basics;
using MakeUILib.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    [VEMLPseudonym("Button")]
    public class Button : ViewElement
    {
        public Color BorderColor { get; set; } = Color.White;

        public int BorderWidth { get; set; }
        public ViewElement Content { get; set; }
        public Indent Padding { get; set; }
        public override Texture Draw()
        {
            Vector2d cSize = new Vector2d();
            if (Content != null)
                cSize = Content.LayoutRect;
            var pSize = Padding.Sum();
            var totalSum = cSize + pSize;
            if(totalSum.IsZero()) totalSum = new Vector2d(20, 20);
            Rectangle rt = new Rectangle() { BorderColor = BorderColor, BorderThickness = BorderWidth, Height = (int)totalSum.Y, Width = (int)totalSum.X, MainColor = Background };
            totalSum.X += BorderWidth * 2;
            totalSum.Y += BorderWidth * 2;
            _texture = new RenderTexture((uint)totalSum.X, (uint)totalSum.Y);
            rt.DrawTo( _texture );
            if (Content != null)
            {
                var ct = Content.Draw();
                _texture.Draw(new Sprite(ct) { Position = new Vector2f((float)(Padding.Left + BorderWidth), (float)(Padding.Top + BorderWidth)) });
            }
            _texture.Display();
            return FinalizeTexture();
        }

        public Button(string text)
        {
            var tv = new TextView(text);
            Content = tv;
            var rect = Content.LayoutRect;
            Width = rect.X + Padding.Horisontal;
            Height = rect.Y + Padding.Vertical;
            Content.Parent = this;
        }
        public Button() : base()
        {
            Width = 50;
            Height = 50;
        }
        public override void UpdateParentLikns()
        {
            Content.Parent = this;
        }
    }
}
