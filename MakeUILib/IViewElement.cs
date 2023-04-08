using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using SelfGraphicsNext.RayGraphics.Graphics3D.Geometry;

namespace MakeUILib
{
    public abstract class ViewElement
    {
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Margin { get; set; }
        public abstract void Draw(ViewElement parent);

    }
}
