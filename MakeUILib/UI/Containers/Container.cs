using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    public abstract class Container : ViewElement
    {
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
            Children.ForEach(i => { i.Parent = this; i.UpdateParentLikns(); });
        }
    }
}
