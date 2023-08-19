using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using MakeUILib.Basics;
using MakeUILib.UI;
using SFML.Graphics;
using SFML.Window;

namespace MakeUILib.UI
{
    public class ViewElement
    {
        private bool redrawing = true;
        public virtual bool Redrawing { get; }
        public string Id { get; set; }
        public ViewElement Parent { get; set; }
        public RenderWindow rendWindow { get; set; }
        public Window HostWindow { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public Indent Margin { get; set; } = StaticValues.DefauldIndent;
        public virtual Color Background { get; set; }
        public virtual DVector2 LayoutRect { get => new DVector2(Width + Margin.Horisontal, Height + Margin.Vertical); }
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
            if (rendWindow == null)
            {
                rendWindow = Parent.GetWindow();
            }
            return rendWindow;
        }
        public virtual void UpdateParentLikns() { }

        public event EventHandler<MouseButtonEventArgs> MouseDown;
        public event EventHandler<MouseButtonEventArgs> MouseUp;
        public event EventHandler<MouseMoveEventArgs> MouseMove;

        public event EventHandler<MouseMoveEventArgs> MouseEnter;
        public event EventHandler<MouseMoveEventArgs> MouseLeave;

        public void OnMouseDown(MouseButtonEventArgs e)
        {
            MouseDown?.Invoke(this, e);
        }
        public void OnMouseUp(MouseButtonEventArgs e)
        {
            MouseUp?.Invoke(this, e);
        }
        public void OnMouseMove(MouseMoveEventArgs e)
        {
            MouseMove?.Invoke(this, e);
        }
        public void OnMouseEnter(MouseMoveEventArgs e)
        {
            MouseEnter?.Invoke(this, e);
        }
        public void OnMouseLeave(MouseMoveEventArgs e)
        {
            MouseLeave?.Invoke(this, e);
        }

        public bool IsEME => MouseEnter != null;
        public int Hash => GetHashCode();
        public void RedrawWindow()
        {
            this.HostWindow.DrawRequest = true;
        }
    }
}
