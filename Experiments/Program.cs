using MakeUILib.VEML;
using SFML.Graphics;
namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var win = File.ReadAllText("TextFile1.veml");
            Console.WriteLine(win);
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            start.ToVEML();
        }
    }
    public class Utils
    {
    }
}