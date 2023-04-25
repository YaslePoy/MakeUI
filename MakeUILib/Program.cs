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
            Grid plane = new Grid();
            plane.Width = 500;
            plane.Height = 500;
            var cellSize = plane.Width / 3;
            plane.Rows = Enumerable.Repeat(cellSize, 3).ToList();
            plane.Columns = Enumerable.Repeat(cellSize, 3).ToList();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button($"{i}:{j}");

                    var stack = new StackPlane() { Direction = Basics.Orientation.Vertical };
                    stack.AddChild(button);
                    plane.Cells.Add(new Cell() { Col = i, Row = j, ViewId = plane.Children.Count });
                    plane.AddChild(stack);
                }
            }
            window.Content = plane;
            window.Open();
        }
    }
}