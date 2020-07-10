using System;
using System.Collections.Generic;
using System.Drawing;

namespace Painter.MathFigures
{
    class MathIsoscelesTriangle
    {
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> triangleList = new List<Point>();
            Point next = second;
            next.X = first.X - (second.X - first.X);
            next.Y = second.Y;

            triangleList.Add(first);
            triangleList.Add(next);
            triangleList.Add(second);

            return triangleList;
        }
    }
    
}

