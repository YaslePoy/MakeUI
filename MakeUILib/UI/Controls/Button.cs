using MakeUILib.Basics;
using MakeUILib.UI;
using SFML.Graphics;
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
        Color lastBorder;
        public ViewElement Content { get; set; }
        public Indent Padding { get; set; }
        public override void Draw(DVector2 position)
        {
            RectangleShape shape = new RectangleShape(new SFML.System.Vector2f((float)(Width + (Padding + Content.Margin).Horisontal), (float)(Height + (Padding + Content.Margin).Vertical)));
            shape.FillColor = Background;
            shape.Position = position;
            Color olc = Color.Transparent;

            var msPos = Mouse.GetPosition(GetWindow());
            var gb = shape.GetGlobalBounds();
            if (gb.Contains(msPos))
            {
                if (lastBorder != Color.Red)
                {
                    base.OnMouseEnter(HostWindow.MouseMoving);
                    olc = Color.Red;
                    lastBorder = olc;
                }

            }
            else
            {
                if (lastBorder != BorderColor)
                {
                    base.OnMouseLeave(HostWindow.MouseMoving);
                    olc = BorderColor;
                    lastBorder = olc;

                }
            }
            lastBorder = olc;
            shape.OutlineColor = olc;
            shape.OutlineThickness = 1;
            GetWindow().Draw(shape);
            if (Content != null)
                Content.Draw(position + new DVector2(Padding.Left + Content.Margin.Left, Padding.Top + Content.Margin.Top));
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
        public Button()
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
