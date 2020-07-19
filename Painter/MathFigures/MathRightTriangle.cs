using System.Collections.Generic;
using System.Drawing;
using System;

namespace Painter.MathFigures
{
    public class MathRightTriangle : IMathFigure
    {        
        public List<Point> MathFigure(Point First, Point Second, int angle)
        {
            List<Point> triangleList = new List<Point>();
            Point first = First;
            Point second = Second;
            Point next = Second;
            Point center = first;
            next.X = first.X;
            next.Y = second.Y;

            center.X = first.X + (second.X - first.X) / 2;
            center.Y = first.Y + (second.Y - first.Y) / 2;

            triangleList.Add(RotateFigure(first, center, angle));
            triangleList.Add(RotateFigure(next, center, angle));
            triangleList.Add(RotateFigure(second, center, angle));

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
