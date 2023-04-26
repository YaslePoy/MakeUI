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
            foreach (var s in c.Structures)
            {
                Console.WriteLine(s);
                Console.Write($"{win.Substring(s.Start, 5)}...");
                if (s.End > 0)
                    Console.WriteLine(win.Substring(s.End - 4, 5));
            }
        }
    }
    public class Utils
    {
    }
}