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
              
        public List<Point> MathFigure(Point first, Point second, int angle) 
        {
            List<Point> squareList = new List<Point>();

            Point middle = first;
            Point last = first;
            Point center = first;

            int length = Math.Abs(second.Y - first.Y);

            if(second.X < first.X)
            {
                second.X = first.X - length;
            }
            else
            {
                second.X = first.X + length;
            }

            center.X = first.X + (second.X - first.X) / 2;
            center.Y = first.Y + (second.Y - first.Y) / 2;

            middle.X = first.X;
            middle.Y = second.Y;
            last.X = second.X;
            last.Y = first.Y;


            //if (first.X < second.X && first.Y < second.Y) // IV четверть
            //{
            //    center.X = first.X + (second.X - first.X) / 2;
            //    center.Y = first.Y + (second.Y - first.Y) / 2;




            //    length = second.Y - first.Y;

            //    next.X = first.X + length;
            //    next.Y = first.Y;

            //    middle.X = next.X;
            //    middle.Y = next.Y + length;

            //    last.X = middle.X - length;
            //    last.Y = middle.Y;
            //}
            //if (first.X > second.X && first.Y > second.Y) // II четверть
            //{
            //    center.X = first.X + (second.X - first.X) / 2;
            //    center.Y = first.Y + (second.Y - first.Y) / 2;

            //    length = first.X - second.X;
            //    next.X = first.X - length;
            //    next.Y = first.Y;

            //    middle.X = next.X;
            //    middle.Y = next.Y - length;

            //    last.X = middle.X + length;
            //    last.Y = middle.Y;
            //}
            //if (first.X > second.X && first.Y < second.Y) // III четверть
            //{
            //    length = first.X - second.X;

            //    next.X = first.X;
            //    next.Y = first.Y + length;

            //    middle.X = next.X - length;
            //    middle.Y = next.Y;

            //    last.X = middle.X;
            //    last.Y = middle.Y - length;
            //}
            //if (first.X < second.X && first.Y > second.Y) // I четверть
            //{
            //    length = second.X - first.X;

            //    next.X = first.X;
            //    next.Y = first.Y - length;

            //    middle.X = next.X + length;
            //    middle.Y = next.Y;

            //    last.X = middle.X;
            //    last.Y = middle.Y + length;
            //}

            squareList.Add(RotateFigure(first, center, angle));
            squareList.Add(RotateFigure(middle, center, angle));
            squareList.Add(RotateFigure(second, center, angle));
            squareList.Add(RotateFigure(last, center, angle));
            return squareList;
        }

        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;
            
            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }








    }
}
