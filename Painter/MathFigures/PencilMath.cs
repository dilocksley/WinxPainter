using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    public class PencilMath : IMathFigure
    {
        public List<Point> MathFigure(Point first, Point second)
        {
            List<Point> pencilPointsList = new List<Point>();

            Point Delta = new Point(0, 0);
            Delta.X = second.X - first.X;
            Delta.Y = second.Y - first.Y;
            int step;
            if (Math.Abs(Delta.X) > Math.Abs(Delta.Y))
            {
                step = Math.Abs(Delta.X);
            }
            else
            {
                step = Math.Abs(Delta.Y);
            }
            double incrementX = Delta.X / (double)step;
            double incrementY = Delta.Y / (double)step;
            double startX = first.X;
            double startY = first.Y;
            Point start = new Point(0, 0);
            start.X = (int)startX;
            start.Y = (int)startY;

            for (int i = 0; i <= step; i++)
            {
                pencilPointsList.Add(start);
                startX += incrementX;
                startY += incrementY;
                start.X = (int)startX;
                start.Y = (int)startY;
            }

            return pencilPointsList;
        }
    }
}
