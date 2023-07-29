using MakeUILib.UI.Containers;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    public class TestWindow : MakeUILib.UI.Containers.Window
    {
        public Grid BaseGrid;
        public StackPlane SP1;

        public void OnMD(object sender, MouseMoveEventArgs e)
        {
            Console.WriteLine("Here");
        }
    }
}
