using MakeUILib.UI.Containers;
using MakeUILib.UI.Controls;
using SFML.Window;

namespace MakeUILib
{
    public class TestWindow : MakeUILib.UI.Containers.Window
    {
        public Grid BaseGrid;
        public StackPlane SP1;
        public Button B1;

        public void OnMD(object sender, MouseMoveEventArgs e)
        {
            Console.WriteLine("Here");
        }
    }
}