using MakeUILib.Basics;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    internal class Window
    {
        RenderWindow _w;
        public string Title { get; set; }
        public ViewElement Content { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public void Open()
        {
            _w = new RenderWindow(new SFML.Window.VideoMode((uint)Width, (uint)Height), Title);
            _w.SetFramerateLimit(60);
            _w.SetActive(true);
            _w.Closed += (a, b) => _w.Close();
            Content.toWindow = _w;
            while (_w.IsOpen)
            {
                _w.DispatchEvents();

                _w.Clear();
                
                if(Content != null)
                {
                    Content.Draw(new DVector2(100, 100));
                }
                _w.Display();
            }
        }
        
    }
}
