using MakeUILib.UI.Containers;
using MakeUILib.UI.Controls;
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
            StackPlane plane = new StackPlane();
            plane.Width = 500;
            plane.Height = 500;
            plane.AddChild(new Button("Text 1"));
            plane.AddChild(new Button("Long text"));
            window.Content = plane;
            window.Open();
        }
    }
}