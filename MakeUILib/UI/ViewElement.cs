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

        protected RenderTexture _texture;
        protected bool redrawing = true;
        public virtual bool Redrawing { get => redrawing; }
        public string Id { get; set; }
        public ViewElement Parent { get; set; }
        public RenderWindow rendWindow { get; set; }
        public Window HostWindow { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public Indent Margin { get; set; } = StaticValues.DefauldIndent;

        public Vector2d MaxSize { get; set; }

        public virtual Color Background { get => background; set => background = value; }
        Color background = Color.Transparent;
        public virtual Vector2d LayoutRect { get => new Vector2d(Width + Margin.Horisontal, Height + Margin.Vertical); }

        public ViewElement()
        {
            Margin.Changed += (o, e) => { if (IsVisible) RedrawWindow(); Parent.redrawing = true; };
        }
        public virtual Texture Draw()
        {
            if (!IsVisible)
                return new Texture(0, 0);

            TextView text = new TextView();
            text.Text = GetType().FullName;
            return text.Draw();
            
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
        public Texture FinalizeTexture()
        {
            _texture.Display();
            redrawing = false;
            return _texture.Texture;
        }
    }
}
