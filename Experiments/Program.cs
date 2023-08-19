using MakeUILib;
using MakeUILib.UI;
using MakeUILib.VEML;
using System.Text.Unicode;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MakeUILib.Utils.UpdateTypes();

            var win = File.ReadAllText("1.veml");
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            var vemlFile = start.ToVEML();
            TestWindow o = new TestWindow();
            VEMLParcer.LoadUpperLevel(o, vemlFile);
            o.UpdateLinks();
            o.Open();
            while (true) ;
        }
    }
    public class Utils
    {
    }
}