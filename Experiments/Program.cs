namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var str = ".ruyyryurtuyr..tyut;u.468489;yiytiti;;";
            var sh = ObjectReader.GetBlocks(str);
            foreach (var block in sh)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", block.Item2)) + block.Item1);
            }
        }
    }
    public class Utils
    {
    }
}