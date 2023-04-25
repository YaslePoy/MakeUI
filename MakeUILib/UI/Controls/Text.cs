using MakeUILib.Basics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Controls
{
    public class TextView : ViewElement
    {
        SFML.Graphics.Text inside;
        public SFML.Graphics.Text Raw => inside;
        public string Text { get => inside.DisplayedString; set => inside.DisplayedString = value; }
        public Font Font { get; set; } = StaticValues.StartFont;
        public double FontSize { get => inside.CharacterSize; set => inside.CharacterSize = (uint)value; }
        public Color Color { get => inside.Color; set => inside.Color = value; }
        public TextView(string text) : this()
        {
            Text = text;
            
            Width = inside.FindCharacterPos((uint)(text.Length - 1)).X;
            Height = FontSize;
        }
        public TextView()
        {
            inside = new SFML.Graphics.Text("", Font);
        }
        public override void Draw(DVector2 position)
        {
            var win = GetWindow();
            var txt = new SFML.Graphics.Text(Text, Font);
            txt.CharacterSize = (uint)(FontSize * Utils.PtToPx);
            txt.Color = Color;
            txt.Position = position;
            win.Draw(txt);
        }
    }
}
