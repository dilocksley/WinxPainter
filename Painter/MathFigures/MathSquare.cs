using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    public class MathSquare : IMathFigure
    {
              
        public List<Point> MathFigure(Point first, Point second) 
        {
            List<Point> squareList = new List<Point>();
            int length = 0;
            Point next = first;
            Point middle = first;
            Point last = first;
            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                length = second.Y - first.Y;

                next.X = first.X + length;
                next.Y = first.Y;

                middle.X = next.X;
                middle.Y = next.Y + length;

                last.X = middle.X - length;
                last.Y = middle.Y;
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                length = first.X - second.X;
                next.X = first.X - length;
                next.Y = first.Y;

                middle.X = next.X;
                middle.Y = next.Y - length;

                last.X = middle.X + length;
                last.Y = middle.Y;
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                length = first.X - second.X;

                next.X = first.X;
                next.Y = first.Y + length;

                middle.X = next.X - length;
                middle.Y = next.Y;

                last.X = middle.X;
                last.Y = middle.Y - length;
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                length = second.X - first.X;

                next.X = first.X;
                next.Y = first.Y - length;

                middle.X = next.X + length;
                middle.Y = next.Y;

                last.X = middle.X;
                last.Y = middle.Y + length;
            }
            squareList.Add(first);
            squareList.Add(next);
            squareList.Add(middle);
            squareList.Add(last);
            return squareList;
        }
      
    }
}
