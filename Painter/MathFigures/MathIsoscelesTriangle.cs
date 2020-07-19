using System;
using System.Collections.Generic;
using System.Drawing;

namespace Painter.MathFigures
{
    class MathIsoscelesTriangle
    {
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> triangleList = new List<Point>();
            Point next = second;
            next.X = first.X - (second.X - first.X);
            next.Y = second.Y;
            Point center = first;

            center.X = first.X;
            center.Y = first.Y + (second.Y - first.Y) / 2;
            if (second.X > first.X)
            {
                center.X = second.X;
                center.Y = first.Y + (second.Y - first.Y) / 2;
            }
            

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

