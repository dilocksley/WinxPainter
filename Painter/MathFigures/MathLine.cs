using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    class MathLine : IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> lineList = new List<Point>();
            lineList.Add(first);
            lineList.Add(second);

            return lineList;
        }
    }
}
