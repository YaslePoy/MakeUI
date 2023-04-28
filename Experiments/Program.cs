using MakeUILib.VEML;
using System.Text.Unicode;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var win = File.ReadAllText("TextFile1.veml");
            int[] a = new int[] { 1, 2 };
            Console.WriteLine(win);
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            var vemlFile = start.ToVEML();
            MakeUILib.Utils.UpdateTypes();
            var o = vemlFile.ToReal();
        }
    }
    public class Utils
    {
    }
}