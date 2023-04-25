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
        List<ViewElement> children { get; set; }
        public List<ViewElement> Children { get => children; }
        public virtual void AddChild(ViewElement child)
        {
            children.Add(child);
            children.Last().Parent = this;
        }

        public Container()
        {
            children = new List<ViewElement>();
        }
    }
}
