using MakeUILib.UI.Containers;
using MakeUILib.VEML;
using System.Text.Unicode;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var win = File.ReadAllText("TextFile1.veml");
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            var vemlFile = start.ToVEML();
            MakeUILib.Utils.UpdateTypes();
            var o = vemlFile.ToReal() as Window;
            o.UpdateLinks();
            o.Open();
        }
    }
    public class Utils
    {
    }
}