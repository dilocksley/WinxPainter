using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Painter.MathFigures;
using System.Deployment.Application;

namespace Painter.Figures
{
    public class Square : AFigure
    {
        Point first;
        Point second;
        public Color color;
       
       public Square(Point first, Color color)
       {
            this.first = first;
            this.color = color;
            this.second = first;
       }

       public override List<Point> Math()
       {
            return new MathSquare().MathFigure(first,second);
       }

        public override Color SetColor ()
        {
            return color;
        }
        public override void Update(Point e)
        {
            second = e;
        }

        public override bool IsPointInFigure(Point mousePoint) //ищем пренадлежит ли точка квадрату
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
            return (minX <= mousePoint.X && minY <= mousePoint.Y && maxX >= mousePoint.X && maxY >= mousePoint.Y);

            //    if (first.X <= mousePoint.X && first.Y <= mousePoint.Y && second.X >= mousePoint.X && second.Y >= mousePoint.Y)
            //    return true;
            //else return false;

        }

        public override void Move(Point point)
        {

            //Point delta = new Point();
            //delta.X = (first.X - second.X) / 2;
            //first.X = point.X + delta.X;
            //second.X = point.X - delta.X;
            //if (second.X > first.X)
            //{
            //    delta.X = (second.X - first.X)/2;
            //    first.X = point.X - delta.X;
            //    second.X = point.X + delta.X;
            //}
            //delta.Y = (first.Y - second.Y) / 2;
            //first.Y = point.Y - delta.Y;
            //second.Y = point.Y + delta.Y;

            //if (second.Y < first.Y)
            //{
            //    delta.Y = (first.Y - second.Y) / 2;
            //    first.Y = point.Y + delta.Y;
            //    second.Y = point.Y - delta.Y;
            //}


            //delta.X = point.X - FirstPoint.X;
            //delta.Y = point.Y - FirstPoint.Y;

            first.X += point.X;
            first.Y += point.Y;
            second.X += point.X;
            second.Y += point.Y;

        }





        #region SquareMathCode
        //public Square (Point FirstPoint, Point SecondPoint)
        //{
        //    this.first = FirstPoint;
        //    this.second = SecondPoint;
        //}
        //public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        //{           
        //    squareList = FindSquarePoints(first, second);
        //    return squareList;
        //}
        //private List<Point> FindSquarePoints(Point first, Point second) // вся матемтика метода поиска точек для квадрата
        //{
        //    int length = 0;
        //    Point next = first;
        //    Point middle = first;
        //    Point last = first;          
        //    if (first.X < second.X && first.Y < second.Y) // IV четверть
        //    {
        //        length = second.Y - first.Y;

        //        next.X = first.X + length;
        //        next.Y = first.Y;

        //        middle.X = next.X;
        //        middle.Y = next.Y + length;

        //        last.X = middle.X - length;
        //        last.Y = middle.Y;
        //    }
        //    if (first.X > second.X && first.Y > second.Y) // II четверть
        //    {
        //        length = first.X - second.X;
        //        next.X = first.X - length;
        //        next.Y = first.Y;

        //        middle.X = next.X;
        //        middle.Y = next.Y - length;

        //        last.X = middle.X + length;
        //        last.Y = middle.Y;
        //    }
        //    if (first.X > second.X && first.Y < second.Y) // III четверть
        //    {
        //        length = first.X - second.X;

        //        next.X = first.X;
        //        next.Y = first.Y + length;

        //        middle.X = next.X - length;
        //        middle.Y = next.Y;

        //        last.X = middle.X;
        //        last.Y = middle.Y - length;
        //    }
        //    if (first.X < second.X && first.Y > second.Y) // I четверть
        //    {
        //        length = second.X - first.X;

        //        next.X = first.X;
        //        next.Y = first.Y - length;

        //        middle.X = next.X + length;
        //        middle.Y = next.Y;

        //        last.X = middle.X;
        //        last.Y = middle.Y + length;
        //    }
        //    squareList.Add(first);
        //    squareList.Add(next);
        //    squareList.Add(middle);
        //    squareList.Add(last);
        //    return squareList;
        //}
        #endregion
    }
}
