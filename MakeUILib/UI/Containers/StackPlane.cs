using MakeUILib.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    internal class StackPlane : Container
    {
        public Orientation Direction { get; set; }
        public override void Draw(DVector2 position)
        {
            double sum = 0;
            foreach (var child in Children)
            {
                if (!child.IsActive)
                    continue;
                var delta = new DVector2(0, 0);
                switch (Direction)
                {
                    case Orientation.Horizontal:
                        delta.X = sum;
                        sum += child.Width;
                        break;
                    case Orientation.Vertical:
                        delta.Y = sum;
                        sum += child.Height;
                        break;
                }
                child.Draw(position + delta);
            }
        }
    }
}
