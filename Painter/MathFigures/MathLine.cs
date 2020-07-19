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
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            Point center = first;
            List<Point> lineList = new List<Point>();

            center.X = first.X + (second.X - first.X) / 2;
            center.Y = first.Y + (second.Y - first.Y) / 2;

            lineList.Add(RotateFigure(first, center, angle));
            lineList.Add(RotateFigure(second, center, angle));

            return lineList;
        }

        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;

            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }
    }
}
