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

namespace MakeUILib.UI
{
    [VEMLPseudonym("Window"), Serializable]
    public class Window
    {
        public MouseMoveEventArgs MouseMoving;
        RenderWindow _w;
        public bool DrawRequest = true;
        public string Id { get; set; }
        public string Title { get; set; }
        public ViewElement Content { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Background { get; set; }
        public void Open()
        {
            Task.Run(() =>
            {
                OpenW();
            });
        }

        public void OpenW()
        {

            Stopwatch sw = new Stopwatch();
            _w = new RenderWindow(new SFML.Window.VideoMode((uint)Width, (uint)Height), Title);
            _w.SetFramerateLimit(50);
            _w.SetKeyRepeatEnabled(false);
            _w.Closed += (a, b) => _w.Close();
            _w.Resized += (a, b) => _w.SetView(new View(new FloatRect(0, 0, b.Width, b.Height)));
            _w.KeyPressed += _w_KeyPressed;
            _w.KeyReleased += _w_KeyReleased;
            _w.MouseMoved += _w_MouseMoved;
            _w.SetActive(true);

            Content.rendWindow = _w;
            Content.HostWindow = this;
            Content.MaxSize = new Vector2d(Width, Height);
            while (_w.IsOpen)
            {
                _w.DispatchEvents();
                if (!DrawRequest)
                    continue;
                _w.Clear(Background);
                if (Content != null)
                {
                    var newFrame = Content.Draw();
                    _w.Draw(new Sprite(newFrame) { Position = new Vector2f((float)Content.Margin.Left, (float)Content.Margin.Top) });
                }
                _w.Display();

                DrawRequest = false;
            }
        }

        private void _w_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            MouseMoving = e;
        }

        public void UpdateLinks()
        {
            Content.UpdateParentLikns();
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
