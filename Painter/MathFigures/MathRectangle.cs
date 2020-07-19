using System.Collections.Generic;
using System.Drawing;
using System;

namespace Painter.MathFigures
{
    public class MathRectangle
    {
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> rectangleList = new List<Point>();
            Point next = first;
            Point last = second;
            Point center = first;
            next.X = first.X;
            next.Y = second.Y;

            last.X = second.X;
            last.Y = first.Y;

            center.X = first.X + (second.X - first.X) / 2;
            center.Y = first.Y + (second.Y - first.Y) / 2;

            rectangleList.Add(RotateFigure(first, center, angle));
            rectangleList.Add(RotateFigure(next, center, angle));
            rectangleList.Add(RotateFigure(second, center, angle));
            rectangleList.Add(RotateFigure(last, center, angle));

            return rectangleList;
        }

        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;

            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }
    }
}
