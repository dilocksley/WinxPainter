using System.Collections.Generic;
using System.Drawing;

namespace Painter.MathFigures
{
    public class MathRectangle
    {
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> rectangleList = new List<Point>();
            Point next = first;
            Point last = second;
            next.X = first.X;
            next.Y = second.Y;

            last.X = second.X;
            last.Y = first.Y;

            rectangleList.Add(first);
            rectangleList.Add(next);
            rectangleList.Add(second);
            rectangleList.Add(last);

            return rectangleList;
        }
    }
}
