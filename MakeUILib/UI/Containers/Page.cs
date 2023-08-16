using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    [VEMLPseudonym("Page")]
    public class Page : ViewElement
    {
        public ViewElement Content { get; set; }
        public override void Draw(DVector2 position)
        {
            Content.Draw(position);
        }
    }
}
