using MakeUILib.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUILib.UI.Containers
{
    [VEMLPseudonym("Grid")]
    public class Grid : Container
    {
        public List<double> Rows { get; set; } = new List<double>();
        public List<double> Columns { get; set; } = new List<double>();
        public List<Cell> Cells;
        public Grid() : base()
        {
            Cells = new List<Cell>();
        }
        public override void Draw(DVector2 position)
        {
            foreach (var child in Children)
            {
                if (!child.IsActive)
                    continue;
                int id = Children.IndexOf(child);
                var pos = Cells.FirstOrDefault(i => i.ViewId == id);
                child.Draw(position + new DVector2(Columns.Take(pos.Col).Sum(), Rows.Take(pos.Row).Sum()));
            }
        }
    }
    public struct Cell
    {
        public int Row;
        public int Col;
        public int ViewId;
    }
}
