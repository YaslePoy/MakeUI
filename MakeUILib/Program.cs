using MakeUILib.UI.Containers;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace MakeUILib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Window window = new Window() { Height = 500, Width = 500, Title = "Test" };
            window.Open();
        }
    }
}