using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    class MathTrapezoid : IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second, int angle)
        {
            List<Point> trapezoidList = new List<Point>();
            Point next = new Point(-1, -1);                      
            Point last = new Point(-1, -1);
            Point center = first;


            
            if (second.X > first.X)
            {
                next.X = first.X + Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                center.X = first.X + (second.X - first.X) / 2;
                center.Y = first.Y + (second.Y - first.Y) / 2;

                second.Y = first.Y;

                

                

                trapezoidList.Add(RotateFigure(first, center, angle));
                trapezoidList.Add(RotateFigure(next, center, angle));
                trapezoidList.Add(RotateFigure(last, center, angle));
                trapezoidList.Add(RotateFigure(second, center, angle));

            }
            else
            {
                next.X = first.X - Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                center.X = first.X + (second.X - first.X) / 2;
                center.Y = first.Y + (second.Y - first.Y) / 2;

                second.Y = first.Y;


                trapezoidList.Add(RotateFigure(first, center, angle));
                trapezoidList.Add(RotateFigure(next, center, angle));
                trapezoidList.Add(RotateFigure(last, center, angle));
                trapezoidList.Add(RotateFigure(second, center, angle));
            }

            
            return trapezoidList;

           
        }
        public Point RotateFigure(Point point, Point center, double angle)
        {

            double X = (point.X - center.X) * Math.Cos(angle) - (point.Y - center.Y) * Math.Sin(angle) + center.X;
            double Y = (point.X - center.X) * Math.Sin(angle) + (point.Y - center.Y) * Math.Cos(angle) + center.Y;

            return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }
    }
}
