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
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> trapezoidList = new List<Point>();
            Point next = new Point(-1, -1);                      
            Point last = new Point(-1, -1);

            if (second.X > first.X)
            {
                next.X = first.X + Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                second.Y = first.Y;

                trapezoidList.Add(first);
                trapezoidList.Add(next);
                trapezoidList.Add(last);
                trapezoidList.Add(second);

            }
            else
            {
                next.X = first.X - Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                second.Y = first.Y;

                trapezoidList.Add(first);
                trapezoidList.Add(next);
                trapezoidList.Add(last);
                trapezoidList.Add(second);
            }

            return trapezoidList;
        }
    }
}
