using MakeUILib.Basics;
using MakeUILib.UI.Containers;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Controls
{
    [VEMLPseudonym("Button")]
    internal class Button : ViewElement
    {
        public ViewElement Content { get; set; }
        public Indent Padding { get; set; }
        public override void Draw(DVector2 position)
        {
            RectangleShape shape = new RectangleShape(new SFML.System.Vector2f((float)(Width + (Padding + Content.Margin).Horisontal), (float)(Height + (Padding + Content.Margin).Vertical)));
            shape.FillColor = Background;
            shape.Position = position;
            Color olc;
            
            var msPos = Mouse.GetPosition(GetWindow());
            var gb = shape.GetGlobalBounds();
            if (gb.Contains(msPos))
            {
                olc = Color.Red;
            }else
            {
                olc = new Color(Color.White - Background) { A = byte.MaxValue };
            }
            shape.OutlineColor = olc;
            shape.OutlineThickness = 1;
            GetWindow().Draw(shape);
            Content.Draw(position + new DVector2(Padding.Left + Content.Margin.Left, Padding.Top + Content.Margin.Top));
        }

        public Button(string text)
        {
            var tv = new TextView(text);
            Content = tv;
            Width = Content.Width + Padding.Left + Padding.Right;
            Height = Content.Height + Padding.Top + Padding.Bottom;
            Content.Parent = this;
        }
    }
}
