using MakeUILib.Basics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static SFML.Graphics.Font;

namespace MakeUILib.UI.Containers
{
    [VEMLPseudonym("Window")]
    public class Window
    {
        RenderWindow _w;
        public string Id { get; set; }
        public string Title { get; set; }
        public ViewElement Content { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Open()
        {
            Stopwatch sw = new Stopwatch();
            _w = new RenderWindow(new SFML.Window.VideoMode((uint)Width, (uint)Height), Title);
            _w.SetFramerateLimit(50);
            _w.SetKeyRepeatEnabled(false);
            _w.Closed += (a, b) => _w.Close();
            //_w.Resized += (a, b) => _w.SetView(new View(new FloatRect(0, 0, b.Width, b.Height)));
            _w.KeyPressed += _w_KeyPressed;
            _w.KeyReleased += _w_KeyReleased;
            _w.SetActive(true);

            Content.toWindow = _w;
            while (_w.IsOpen)
            {
                _w.DispatchEvents();

                _w.Clear(new Color(210, 210, 210));
                if (Content != null)
                {
                    Content.Draw(new DVector2(10, 10));
                }
                _w.Display();
            }
        }

        private void _w_KeyReleased(object? sender, KeyEventArgs e)
        {
            Console.WriteLine($"{e.Code} is released");
        }

        private void _w_KeyPressed(object? sender, KeyEventArgs e)
        {
            Console.WriteLine($"{e.Code} is pressed");
        }
    }
}
