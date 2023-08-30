using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static SFML.Graphics.Font;

namespace MakeUILib.UI
{
    public abstract class Container : ViewElement
    {
        protected List<(ViewElement view, FloatRect collider)> colliders;
        protected Dictionary<ViewElement, Texture> _textures = new Dictionary<ViewElement, Texture>();
        public override bool Redrawing { get => base.Redrawing || Children.Any(i => i.Redrawing); }
        public List<ViewElement> Children { get; set; }
        public virtual void AddChild(ViewElement child)
        {
            Children.Add(child);
            Children.Last().Parent = this;
        }

        public Container()
        {
            Children = new List<ViewElement>();
        }
        public override void UpdateParentLikns()
        {
            Children.ForEach(i => { i.Parent = this; i.rendWindow = rendWindow; i.HostWindow = HostWindow; i.UpdateParentLikns(); });
        }

        protected void CreateDefaultTexture()
        {
            _texture = new RenderTexture((uint)Math.Max(MaxSize.X - Margin.Horisontal, Width), (uint)Math.Max(MaxSize.Y - Margin.Vertical, Height));
            _texture.Clear(Background);
        }

        public List<(ViewElement o, Texture t)> FinalRenderList()
        {
            var workList = Children.ToArray();
            List<(ViewElement, Texture)> ts = new List<(ViewElement, Texture)>();
            foreach (var child in workList)
            {
                if (!child.IsVisible)
                    continue;
                if (child.Redrawing)
                {
                    var tx = child.Draw();
                    if (!_textures.TryAdd(child, tx))
                        _textures[child] = tx;
                    ts.Add((child, tx));
                }
            }
            return ts;
        }
    }
}
