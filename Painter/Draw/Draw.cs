using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Draw
{
    class Draw : IDraw
    {
        StaticBitmap bitmap;
        public void DrawFigures(List<Point> list, Color color) // для любой фигуры - соединение точек по кол-ву в листе
        {
            Point tmp = new Point(-1, -1);
            foreach (Point point in list)
            {
                if (tmp.X != -1)
                {
                    DrawLine(point, tmp, color);
                }
                tmp = point;
            }
            DrawLine(tmp, list[0], color);       // соедиение последней точки с первой
        }

      

        public void DrawLine(Point first, Point second, Color color)
        {
           bitmap.DrawVoluntary(first, second, color);
        }
        public void DrawLineXY(int x1, int y1, int x2, int y2, Color color)
        {
            Point firstPoint = new Point(-1, -1);
            Point secondPoint = new Point(-1, -1);
            firstPoint.X = x1;
            firstPoint.Y = y1;
            secondPoint.X = x2;
            secondPoint.Y = y2;

            bitmap.DrawVoluntary(firstPoint, secondPoint, color);
        }
    }
}
