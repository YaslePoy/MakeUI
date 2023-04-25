using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using MakeUILib.Basics;
using MakeUILib.UI.Controls;
using SelfGraphicsNext.RayGraphics.Graphics3D.Geometry;
using SFML.Graphics;

namespace MakeUILib
{
    public class ViewElement
    {
        public ViewElement Parent { get; set; }
        public RenderWindow toWindow { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public Vector4 Margin { get; set; }
        public virtual void Draw(DVector2 position)
        {
            if (!IsVisible)
                return;
            RectangleShape shape = new RectangleShape(new SFML.System.Vector2f((float)Width, (float)Height));
            shape.Position = position;
            shape.FillColor = new Color(32, 32, 32, 16);
            TextView text = new TextView();
            text.Text = GetType().FullName;
            GetWindow().Draw(shape);
        }

        public RenderWindow GetWindow()
        {
            if (toWindow == null)
            {
                toWindow = Parent.GetWindow();
            }
            return toWindow;
        }
    }
}
