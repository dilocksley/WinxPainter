using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Instruments
{
    public class Fill : IFillFigure
    {
        StaticBitmap bitmap = StaticBitmap.GetInstance();
        public Point FindPointFigure(Point first, Point second)
        {
            Point point = new Point();

            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                point.X = first.X - (first.Y - second.Y) / 2;
                point.Y = first.Y - (first.Y - second.Y) / 2;
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                point.X = first.X + (second.X - first.X) / 2;
                point.Y = first.Y + (second.X - first.X) / 2;
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                point.X = first.X - (first.X - second.X) / 2;
                point.Y = first.Y + (first.X - second.X) / 2;
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                point.X = first.X + (second.X - first.X) / 2;
                point.Y = first.Y - (second.X - first.X) / 2;
            }
            return point;
        }
        public Point FindPointFigureRE(Point first, Point second)
        {
            Point point = new Point();
            point.X = (first.X + second.X) / 2;
            point.Y = (first.Y + second.Y) / 2;
            return point;
        }
            public Point FindPointFigure(Point first, Point second, Point thrid)
        {
            Point point = new Point();
           
            point.X = (int)((first.X + second.X + thrid.X) / 3);
            point.Y = (int)((first.Y + second.Y + thrid.Y) / 3);

            return point;
        }
        public Point FindCenterPointInEllipse(Point first, Point second)
        {
            Point center = new Point();
            int diameterY = Math.Abs(second.Y - first.Y);
            int diameterX = Math.Abs(second.X - first.X);
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
            if (first.X > second.X)
            {
                centerX = radiusX + second.X;
            }
            center.Y = centerY;
            center.X = centerX;
            return center;
        }
        public void FillFigure(Point e, Color fillColor)
        {
            Color startColor = bitmap.tmpBitmap.GetPixel(e.X, e.Y);
            Point left = new Point(e.X, e.Y);
            Point right = new Point(e.X, e.Y);

            while (left.X - 1 > 0 && bitmap.tmpBitmap.GetPixel(left.X - 1, left.Y) == startColor)
            {
                left.X--;

            }

            while (right.X + 1 <= bitmap.tmpBitmap.Width - 1 && bitmap.tmpBitmap.GetPixel(right.X + 1, right.Y) == startColor)
            {

                right.X++;

            }


            bitmap.DrawLine(left, right, fillColor);

            for (int i = left.X; i <= right.X; i++)
            {
                if (bitmap.tmpBitmap.Height - 1 >= e.Y + 1 && bitmap.tmpBitmap.GetPixel(i, e.Y + 1) == startColor)
                {
                    Point up = new Point(i, e.Y + 1);

                    FillFigure(up, fillColor);

                }
                if (e.Y - 1 >= 0 && bitmap.tmpBitmap.GetPixel(i, e.Y - 1) == startColor)
                {

                    Point down = new Point(i, e.Y - 1);

                    FillFigure(down, fillColor);

                }
            }
        }

       
    }
}
