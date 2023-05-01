using MakeUILib.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    [VEMLPseudonym("StackPlane")]
    internal class StackPlane : Container
    {
        public Orientation Direction { get; set; }
        public Indent Spacing { get; set; }
        public override void Draw(DVector2 position)
        {
            double sum = 0;
            var workList = Children.ToArray();
            foreach (var child in workList)
            {
                if (!child.IsActive)
                    continue;
                var delta = new DVector2(0, 0);
                switch (Direction)
                {
                    case Orientation.Horizontal:
                        delta.X = sum;
                        sum += child.LayoutRect.X + Spacing.Horisontal;
                        break;
                    case Orientation.Vertical:
                        delta.Y = sum;
                        sum += child.LayoutRect.Y + Spacing.Vertical;
                        break;
                }
                child.Draw(position + delta);
            }
        }
    }
}
