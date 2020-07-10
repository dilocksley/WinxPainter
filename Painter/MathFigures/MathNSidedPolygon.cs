using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    class MathNSidedPolygon : IMathFigure
    {
        int n;
        public MathNSidedPolygon(int n)
        {
            this.n = n;
        }
        public List<Point> MathFigure(Point first, Point second)
        {
            double angle = (double)(360.0 / (double)n);
            List<Point> polygonList = new List<Point>();
            Point tmp = new Point(-1, -1);
            int R = 0;
            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                R = second.Y - first.Y;
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                R = first.Y - second.Y;
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                R = first.Y - second.Y;
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                R = second.X - first.X;
            }
            double z = 0; int i = 0;
            while (i < n)
            {
                tmp.X = first.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
                tmp.Y = first.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
                polygonList.Add(tmp);
                z = z + angle;
                i++;
            }
            return polygonList;
        }
    }
}
