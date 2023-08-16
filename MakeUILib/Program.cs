using MakeUILib.UI.Containers;
using MakeUILib.UI.Controls;
using MakeUILib.VEML;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace MakeUILib
{
    internal class Program
    {
        public static Button tempBut;

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Window window = new Window() { Height = 700, Width = 1000, Title = "Test" };
            //Grid plane = new Grid();
            //plane.Width = 500;
            //plane.Height = 500;
            //var cellSize = plane.Width / 3;
            //plane.Rows = Enumerable.Repeat(cellSize, 3).ToList();
            //plane.Columns = Enumerable.Repeat(cellSize, 3).ToList();
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Button button = new Button($"{i}:{j}");

            //        var stack = new StackPlane() { Direction = Basics.Orientation.Vertical };
            //        stack.AddChild(button);
            //        plane.Cells.Add(new Cell() { Col = i, Row = j, ViewId = plane.Children.Count });
            //        plane.AddChild(stack);
            //    }
            //}
            //window.Content = plane;
            //window.Open();
            MakeUILib.Utils.UpdateTypes();
            var win = File.ReadAllText("C:\\Users\\Mimm\\Projects\\VisualStudioProjects\\MakeUI\\Experiments\\TextFile1.veml");
            Claster c = new Claster(win);
            c.SearchStructures();
            var start = c.MainStruct();
            start.UpdateStructures();
            start.LoadText();
            start.Extend();
            var vemlFile = start.ToVEML();
            TestWindow o = new TestWindow();
            VEMLParcer.LoadUpperLevel(o, vemlFile);
            tempBut = o.B1;
            o.B1.OnMouseEnter(null);
            o.UpdateLinks();
            o.Open();
            while (true) ;


        }
    }
}