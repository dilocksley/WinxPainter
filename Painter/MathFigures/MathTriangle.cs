using System;
using System.Collections.Generic;
using System.Drawing;

namespace Painter.MathFigures
{
    public class MathTriangle : IMathFigure
    {
        List<Point> list;
        public MathTriangle(List<Point> list)
        {
            this.list = list;
        }
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> triangleList = new List<Point>();

            first = list[0];
            second = list[1];
            Point third = list[2];

            triangleList.Add(first);
            triangleList.Add(second);
            triangleList.Add(third);

            return triangleList;
        }
    }
}
