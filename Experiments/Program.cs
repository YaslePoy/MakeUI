using MakeUILib.VEML;
using SFML.Graphics;
namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Font font = new Font("C:\\Windows\\Fonts\\consola.ttf");
            var text = new Text("test string", font);
            var a = text.GetLocalBounds();
            text.CharacterSize = 20;
            var b = text.GetLocalBounds();
            Console.WriteLine("Hello, World!");
        }
    }
    public class Utils
    {
    }
}