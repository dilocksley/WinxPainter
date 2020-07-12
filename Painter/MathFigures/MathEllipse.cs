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
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> ellipseList = new List<Point>();
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
                ellipseList.Add(new Point(X, Y));

            }
            for (int X = startX + diameterX; X >= startX; X--)
            {
                int Y = DrawEllipseGetY(X, centerX, centerY, radiusX, radiusY);
                int YMirror = Y - (Y - centerY) * 2;
                ellipseList.Add(new Point(X, YMirror));
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
    }
}
