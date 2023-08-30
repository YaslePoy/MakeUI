using MakeUILib.Basics;
using MakeUILib.VEML;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
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
                if (inside.DisplayedString == value)
                    return;
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
        public TextView(string text) : this()
        {
            Text = text;
            //UpdateRect();
        }
        void UpdateRect()
        {
            var gb = inside.GetGlobalBounds().Sum();
            Width = gb.X;
            Height = gb.Y;
        }
        public TextView() : base()
        {
            inside = new SFML.Graphics.Text("", Font);
        }
        public override Texture Draw()
        {

            var bounds = inside.GetLocalBounds().Sum();
            _texture = new RenderTexture((uint)bounds.X, (uint)bounds.Y);
            _texture.Clear(Background);
            _texture.Draw(inside);

            return FinalizeTexture();
        }
        public void EndInit()
        {
            Console.WriteLine("here");
        }
    }
}