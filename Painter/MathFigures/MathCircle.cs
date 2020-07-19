using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    public class MathCircle: IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> circleList = new List<Point>();
            int length = 0;
            Point next = first;
            Point middle = first;
            Point tmp = first;
            Point center = first;

            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                length = second.Y - first.Y;
                next.X = first.X + length;
                next.Y = first.Y;
                middle.X = next.X - length / 2;
                middle.Y = next.Y;
                center.X = middle.X;
                center.Y = middle.Y + length / 2;
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                length = first.X - second.X;
                next.X = first.X - length;
                next.Y = first.Y;
                middle.X = first.X - length / 2;
                middle.Y = first.Y;
                center.X = middle.X;
                center.Y = middle.Y - length / 2;
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                length = first.X - second.X;
                next.X = first.X;
                next.Y = first.Y + length;
                middle.X = next.X;
                middle.Y = next.Y - length / 2;
                center.X = middle.X - length / 2;
                center.Y = middle.Y;
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                length = second.X - first.X;
                next.X = first.X;
                next.Y = first.Y - length;
                middle.X = first.X;
                middle.Y = first.Y - length / 2;
                center.X = middle.X + length / 2;
                center.Y = middle.Y;
            }
            int radius = length / 2;
            for (int i = 1; i <= 360; i++)
            {
                double a = Math.Cos(2 * Math.PI * i / 360) * radius + 0.5 + center.X;
                double b = Math.Sin(2 * Math.PI * i / 360) * radius + 0.5 + center.Y;
                tmp.X = (int)a;
                tmp.Y = (int)b;
                circleList.Add(tmp);
            }

            return circleList;
        }

    }
}
