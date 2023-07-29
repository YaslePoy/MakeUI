using MakeUILib.Basics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Controls
{
    [VEMLPseudonym("TextView")]
    public class TextView : ViewElement
    {
        SFML.Graphics.Text inside;
        public SFML.Graphics.Text Raw => inside;
        public string Text
        {
            get => inside.DisplayedString; set
            {
                inside.DisplayedString = value;
                UpdateRect();
            }
        }
        public Font Font { get; set; } = StaticValues.StartFont;
        public double FontSize
        {
            get => inside.CharacterSize; set
            {
                inside.CharacterSize = (uint)value;
                UpdateRect();
            }
        }
        public override Color Background { get => inside.Color; set => inside.Color = value; }
        public TextView(string text) : this()
        {
            Text = text;
            //UpdateRect();
        }
        void UpdateRect()
        {
            //Task.Run(() =>
            //{
                var gb = inside.GetGlobalBounds();
                Width = gb.Left + gb.Width;
                Height = gb.Top + gb.Height;
                
            //});
        }
        public TextView()
        {
            inside = new SFML.Graphics.Text("", Font);
        }
        public override void Draw(DVector2 position)
        {
            var win = GetWindow();

            inside.Position = position;
            win.Draw(inside);
        }
    }
}
