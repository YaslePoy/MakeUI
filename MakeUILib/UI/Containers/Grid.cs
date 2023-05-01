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
        public LengthsDefinitions Rows { get; set; } = new List<double>();
        public LengthsDefinitions Columns { get; set; } = new List<double>();
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
                child.Draw(position + new DVector2(Columns.GetGeneralLenght(pos.Col, this), Rows.GetGeneralLenght(pos.Col, this)) + new DVector2(Margin.Left, Margin.Top));
            }
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
                var ret = Lens[i];
                if (ret is double)
                    return (double)ret;
                else return ((SmartVariable<double>)ret).GetValue(g);

            }
        }
        public static implicit operator LengthsDefinitions(List<double> l) => new LengthsDefinitions() { Lens = l.Select(i => (object)i).ToList() };
        public double GetGeneralLenght(int count, Grid g)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += this[i, g];
            }
            return sum;
        }
    }
}
