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
    internal class Button : ViewElement
    {
        public Color Color { get; set; }
        public ViewElement Content { get; set; }
        public Indent Padding { get; set; }
        public override void Draw(DVector2 position)
        {
            RectangleShape shape = new RectangleShape(new SFML.System.Vector2f((float)(Width), (float)(Height)));
            shape.FillColor = Color;
            shape.Position = position;
            Color olc;
            
            var msPos = Mouse.GetPosition(GetWindow());
            var gb = shape.GetGlobalBounds();
            if (gb.Contains(msPos))
            {
                olc = Color.Red;
            }else
            {
                olc = new Color(Color.White - Color) { A = byte.MaxValue };
            }
            shape.OutlineColor = olc;
            shape.OutlineThickness = 1;
            GetWindow().Draw(shape);
            Content.Draw(position + new DVector2(Padding.Left, Padding.Top));

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
