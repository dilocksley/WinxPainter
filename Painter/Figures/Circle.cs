using System;
using System.Collections.Generic;
using Painter.Instruments;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Painter.MathFigures;
using System.Runtime.InteropServices;

namespace Painter.Figures
{
    public class Circle : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;
        Point e;
        Color fillColor = Color.Transparent;
        public Circle(Point first, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.color = color;
            this.second = first;
            this.thickness = thickness;
            this.fillColor = fillColor;
        }

        public override List<Point> DoFigureMath()
        {
            return new MathCircle().MathFigure(first, second);
        }

        public override Color SetColor()
        {
            return color;
        }
        public override int SetThickness()
        {
            return thickness;
        }
        public override void Update(Point e)
        {
            second = e;
        }

        public override bool IsPointInFigure(Point mousePoint)
        {
            int maxX = second.X;
            int minX = first.X;
            if (first.X > second.X)
            {
                maxX = first.X;
                minX = second.X;
            }
            int maxY = second.Y;
            int minY = first.Y;
            if (first.Y > second.Y)
            {
                maxY = first.Y;
                minY = second.Y;
            }
            //int midX = minX + ((maxX - minX) / 2);
            //int midY = minY + ((maxY - minY) / 2);
            int radius = (maxX - minX) / 2;
            Point center = new Point(minX + radius, minY + radius);
            Point right = new Point(center.X + radius, center.Y);
            Point left = new Point(center.X - radius, center.Y);
            Point top = new Point(center.X, center.Y - radius);
            Point bottom = new Point(center.X, center.Y + radius);
            if (mousePoint == center || mousePoint == right || mousePoint == left || mousePoint == top || mousePoint == bottom)
            {
                return true;
            }
            else if(mousePoint.X <= right.X && mousePoint.X >= top.X && mousePoint.Y <= right.Y && mousePoint.Y >= top.Y) // top right quarter
            {
                return true;
            }
            else if (mousePoint.X <= right.X && mousePoint.X >= bottom.X && mousePoint.Y >= right.Y && mousePoint.Y <= bottom.Y) //bottom right quarter
            {
                return true;
            }
            else if (mousePoint.X <= bottom.X && mousePoint.X >= left.X && mousePoint.Y <= bottom.Y && mousePoint.Y >= left.Y) //bottom left quarter
            {
                return true;
            }
            else if (mousePoint.X >= left.X & mousePoint.X <= top.X && mousePoint.Y <= left.Y && mousePoint.Y >= top.Y) // top left quarter
            {
                return true;
            }
            return false;
            //return (mousePoint.X <= right.X && mousePoint.X >= left.X && mousePoint.Y <= bottom.Y && mousePoint.Y >= top.Y);
        }

        public override void Move(Point point)
        {
            first.X += point.X;
            first.Y += point.Y;
            second.X += point.X;
            second.Y += point.Y; 
        }

        public override Color FillSetColor()
        {
            return fillColor;
        }

        public override Point FindPoint()
        {
            e = new Fill().FindPointFigure(first, second);
            return e;
        }

        public override void FillFigure()
        {
            new Fill().FillFigure(e, fillColor);
        }

        public override void ChangeFillColor(Color color)
        {
            throw new NotImplementedException();
        }

        //public override void FillFigure()
        //{
        //    throw new NotImplementedException();
        //}



        #region CircleMathCode
        //public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        //{
        //    circleList = FindCirclePoints(first, second);
        //    return circleList;
        //}
        //private List<Point> FindCirclePoints(Point first, Point second)
        //{
        //    Point next = second;
        //    Point middle = second;
        //    Point center = second;
        //    Point tmp = second;
        //    int length = 0;

        //    if (first.X < second.X && first.Y < second.Y) // IV четверть
        //    {
        //        length = second.Y - first.Y;
        //        next.X = first.X + length;
        //        next.Y = first.Y;
        //        middle.X = next.X - length / 2;
        //        middle.Y = next.Y;
        //        center.X = middle.X;
        //        center.Y = middle.Y + length / 2;
        //    }
        //    if (first.X > second.X && first.Y > second.Y) // II четверть
        //    {
        //        length = first.X - second.X;
        //        next.X = first.X - length;
        //        next.Y = first.Y;
        //        middle.X = first.X - length / 2;
        //        middle.Y = first.Y;
        //        center.X = middle.X;
        //        center.Y = middle.Y - length / 2;
        //    }
        //    if (first.X > second.X && first.Y < second.Y) // III четверть
        //    {
        //        length = first.X - second.X;
        //        next.X = first.X;
        //        next.Y = first.Y + length;
        //        middle.X = next.X;
        //        middle.Y = next.Y - length / 2;
        //        center.X = middle.X - length / 2;
        //        center.Y = middle.Y;
        //    }
        //    if (first.X < second.X && first.Y > second.Y) // I четверть
        //    {
        //        length = second.X - first.X;
        //        next.X = first.X;
        //        next.Y = first.Y - length;
        //        middle.X = first.X;
        //        middle.Y = first.Y - length / 2;
        //        center.X = middle.X + length / 2;
        //        center.Y = middle.Y;
        //    }
        //    int radius = length / 2;
        //    for (int i = 1; i <= 360; i++)
        //    {
        //        double a = Math.Cos(2 * Math.PI * i / 360) * radius + 0.5 + center.X;
        //        double b = Math.Sin(2 * Math.PI * i / 360) * radius + 0.5 + center.Y;
        //        tmp.X = (int)a;
        //        tmp.Y = (int)b;
        //        circleList.Add(tmp);

        //    }

        //    return circleList;
        //}
        #endregion
    }
}
