using MakeUILib.Basics;
using ManagedCuda.NVRTC;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI
{
    [VEMLPseudonym("Grid")]
    public class Grid : Container
    {
        public GridRows Rows { get; set; }
        public GridColumns Columns { get; set; }
        public List<Cell> Cells;
        public Grid() : base()
        {
            Cells = new List<Cell>();
        }
        public override Texture Draw()
        {
            CreateDefaultTexture();

            var workList = Children.ToArray();
            List<Texture> ts = new List<Texture>();
            int i = 0;
            foreach (var child in workList)
            {
                i++;
                if (!child.IsVisible)
                    continue;
                if (child.Redrawing)
                {
                    var tx = child.Draw();
                    if (!_textures.TryAdd(child, tx))
                        _textures[child] = tx;
                    ts.Add(tx);
                }

                var cell = Cells.FirstOrDefault(c => c.ViewId == i);
                var row = Rows.GetPartStart(cell.Row);
                var col = Columns.GetPartStart(cell.Col);
                var move = new Vector2d(col.start, row.start);

                child.MaxSize = new Vector2d(col.size, row.size);
                _texture.Draw(new Sprite(_textures[child]) { Position = move + child.Margin.Offset });
            }

            return FinalizeTexture();
        }
        public void EndInit()
        {
            Console.WriteLine();
        }
    }
    public struct Cell
    {
        public int Row;
        public int Col;
        public int ViewId;
    }
    public class LengthsDefinitions
    {
        public List<object> Lens = new List<object>();
        public double this[int i, Grid g]
        {
            get
            {
                if (i >= Lens.Count)
                    return -1;
                var ret = Lens[i];
                if (ret is double)
                    return (double)ret;
                else return ((SmartVariable<double>)ret).GetValue(g);

            }
        }
        public static implicit operator LengthsDefinitions(List<double> l) => new LengthsDefinitions() { Lens = l.Select(i => (object)i).ToList() };
        public double GetLenght(int count, Grid g)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += this[i, g];
            }
            return sum;
        }
    }
    public class GridDimensions
    {
        public double AutoPartSize;
        public GridDimensions()
        {
            parts = new List<Partition>();
        }
        public Grid owner;
        public List<Partition> parts;
        public (double start, double size) GetPartStart(int part)
        {
            double start = 0;
            double size = 0;
            for (int i = 0;  i < parts.Count; i++)
            {
                start += size;
                size = parts[i].GetRealSize(this);
            }
            return (start, size);
        }
        public virtual double Maximal() { return 0; }

    }
    public class GridColumns : GridDimensions
    {
        public override double Maximal()
        {
            return owner.Width;
        }
    }

    public class Partition
    {
        double size, min, max;
        public double Size { get => size; set { size = value; IsAuto = false; } }
        public double MaxSize { get; set; }
        public double MinSize { get; set; }
        public double GetRealSize(GridDimensions dimension)
        {
            if (!IsAuto)
                return Size;
            var total = dimension.Maximal();
            var autoCount = dimension.parts.Count(i => i.IsAuto);
            var reserved = dimension.parts.Sum(i => i.Size);
            var divising = total - reserved;
            var partly = divising / autoCount;

            partly = Math.Min(Math.Max(min, partly), max);

            return partly;
        }
        public bool IsAuto { get; set; } = true;
        public override int GetHashCode()
        {
            return IsAuto.GetHashCode() ^ size.GetHashCode() ^ max.GetHashCode() ^ min.GetHashCode();
        }

    }
    public class GridRows : GridDimensions
    {
        public override double Maximal()
        {
            return owner.Height;
        }
    }
}
