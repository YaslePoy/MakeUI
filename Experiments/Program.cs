using MakeUILib;
using MakeUILib.Basics;
using MakeUILib.UI;
using MakeUILib.VEML;
using System.Text.Unicode;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            //var win = File.ReadAllText("3.veml");
            //Claster c = new Claster(win);
            //c.SearchStructures();
            //var start = c.MainStruct();
            //start.UpdateStructures();
            //start.LoadText();
            //start.Extend();
            //var vemlFile = start.ToVEML();
            //TestWindow o = new TestWindow();
            //VEMLParcer.LoadUpperLevel(o, vemlFile);
            //o.UpdateLinks();
            //o.OpenW();
            TestWindow w = new TestWindow();
            w.OpenW();
        }
    }
    public class Utils
    {
    }
}