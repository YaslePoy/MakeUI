using MakeUILib.UI;
using MakeUILib.VEML;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    [Serializable]
    public class TestWindow : MakeUILib.UI.Window
    {
        public TestWindow()
        {
            VEMLParcer.LoadLayout(this);
            UpdateLinks();
        }
    }
}
