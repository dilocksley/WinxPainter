using System.Collections.Generic;
using System.Drawing;

namespace Painter.MathFigures
{
    public class MathRightTriangle : IMathFigure
    {        
        public List<Point> MathFigure(Point First, Point Second)
        {
            List<Point> triangleList = new List<Point>();
            Point first = First;
            Point second = Second;
            Point next = Second;
            next.X = first.X;
            next.Y = second.Y;

            triangleList.Add(first);
            triangleList.Add(next);
            triangleList.Add(second);

            return triangleList;
        }
    }
}
