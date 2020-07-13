using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    public class MathOpenPolygon : IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> pencilPointsList = new List<Point>();

            pencilPointsList.Add(first);
            first = second;
            pencilPointsList.Add(second);
            return pencilPointsList;
        }
    }
}
