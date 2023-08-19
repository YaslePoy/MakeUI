using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    public abstract class Container : ViewElement
    {
        private Dictionary<ViewElement, RenderTexture> _textures;
        public override bool Redrawing { get => base.Redrawing || Children.Any(i => i.Redrawing);}
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
    }
}
