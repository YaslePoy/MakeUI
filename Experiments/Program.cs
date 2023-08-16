using MakeUILib;
using MakeUILib.UI;
using MakeUILib.UI.Containers;
using MakeUILib.UI.Controls;
using MakeUILib.VEML;
using System.Text.Unicode;

namespace Experiments
{
    internal class Program
    {
        public static Button tempBut;
        static void Main(string[] args)
        {
            MakeUILib.Utils.UpdateTypes();

            var win = File.ReadAllText("TextFile1.veml");
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            var vemlFile = start.ToVEML();
            TestWindow o = new TestWindow();
            VEMLParcer.LoadUpperLevel(o, vemlFile);
            tempBut = o.B1;
            o.B1.OnMouseEnter(null);
            o.UpdateLinks();
            o.Open();
            while (true) ;
        }
    }
    public class Utils
    {
    }
}