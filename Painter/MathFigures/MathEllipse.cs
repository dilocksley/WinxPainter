using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter.MathFigures
{
    public class MathEllipse : IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> ellipseList = new List<Point>();
            Point center = first;

            center.X = first.X + (second.X - first.X) / 2;
            center.Y = first.Y + (second.Y - first.Y) / 2;


            int diameterY = Math.Abs(second.Y - first.Y);
            int diameterX = Math.Abs(second.X - first.X);
            if (diameterY < 2 || diameterX < 2) // Для новой отрисовки, что бы не было деление на 0
            {
                ellipseList.Add(new Point(0, 0));
                return ellipseList;
            }
            //ищем радиус
            int radiusY = diameterY / 2;
            int radiusX = diameterX / 2;

            //ищем центр эллипса, определяем старт рисования
            int centerY = radiusY + first.Y;
            if (first.Y > second.Y)
            {
                centerY = radiusY + second.Y;
            }

            int centerX = radiusX + first.X;
            int startX = first.X;
            if (first.X > second.X)
            {
                centerX = radiusX + second.X;
                startX = second.X;
            }

            for (int X = startX; X <= startX + diameterX; X++)
            {
                int Y = DrawEllipseGetY(X, centerX, centerY, radiusX, radiusY);
                ellipseList.Add(RotateFigure(new Point(X, Y), center, angle));

            }
            for (int X = startX + diameterX; X >= startX; X--)
            {
                int Y = DrawEllipseGetY(X, centerX, centerY, radiusX, radiusY);
                int YMirror = Y - (Y - centerY) * 2;
                ellipseList.Add(RotateFigure(new Point(X, YMirror), center, angle));
            }

            return ellipseList;
        }
        private int DrawEllipseGetY(int X, int centerX, int centerY, int radiusX, int radiusY)
        {
            double ch = ((X - centerX) * (X - centerX));
            double zn = (radiusX * radiusX);
            double p = ch / zn;

            if (p > 1)
            {
                p = 1;
            }

            double YD = Math.Sqrt((1 - p) * radiusY * radiusY) + centerY;
            return Convert.ToInt32(YD);
        }

        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;

            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }

        public List<Point> FindFocusPoints(Point first, Point second)
        {
            List<Point> focusPoints = new List<Point>();
            int diameterY = Math.Abs(second.Y - first.Y);
            int diameterX = Math.Abs(second.X - first.X);
            int radiusX = diameterX / 2;
            int radiusY = diameterY / 2;
            int minX = first.X;
            if (first.X > second.X)
            {
                minX = second.X;
            }
            int minY = first.Y;
            if (first.Y > second.Y)
            {
                minY = second.Y;
            }
            Point center = new Point(minX + radiusX, minY + radiusY);
            focusPoints.Add(center);
            Point right = new Point(center.X + radiusX, center.Y);
            focusPoints.Add(right);
            Point left = new Point(center.X - radiusX, center.Y);
            focusPoints.Add(left);
            Point top = new Point(center.X, center.Y - radiusY);
            focusPoints.Add(top);
            Point bottom = new Point(center.X, center.Y + radiusY);
            focusPoints.Add(bottom);
            return focusPoints;
        }
    }
}
