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
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> triangleList = new List<Point>();

            first = list[0];
            second = list[1];
            Point third = list[2];
            Point center = first;

            center.X = (first.X + first.X + second.X) / 3;
            center.Y = (first.Y + second.Y + second.Y) / 3;

            triangleList.Add(RotateFigure(first, center, angle));
            triangleList.Add(RotateFigure(second, center, angle));
            triangleList.Add(RotateFigure(third, center, angle));

            return triangleList;
        }

        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;

            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }
    }
}
