using System;
using System.Collections.Generic;
using System.Drawing;

namespace Painter.Figures
{
    //public class Trapezoid : AFigures
    //{
    //    List<Point> trapezoidList = new List<Point>();
    //    public Trapezoid(Point FirstPoint, Point SecondPoint)
    //    {
    //        first = FirstPoint;
    //        second = SecondPoint;
    //    }
    //    public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
    //    {
    //        trapezoidList = FindTrapezoidPoints(first, second);
    //        return trapezoidList;
    //    }

    //    private List<Point> FindTrapezoidPoints(Point first, Point second)
    //    {
    //            Point next = new Point(-1,-1);
    //            Point last = new Point(-1, -1);

    //        if (second.X > first.X)
    //        {
    //            next.X = first.X + Math.Abs(second.X - first.X) / 4;
    //            next.Y = second.Y;

    //            last.X = next.X + ((second.X - first.X) / 2);
    //            last.Y = next.Y;

    //            second.Y = first.Y;

    //            trapezoidList.Add(first);
    //            trapezoidList.Add(next);
    //            trapezoidList.Add(last);
    //            trapezoidList.Add(second);
               
    //        }
    //        else
    //        {
    //            next.X = first.X - Math.Abs(second.X - first.X) / 4;
    //            next.Y = second.Y;

    //            last.X = next.X + ((second.X - first.X) / 2);
    //            last.Y = next.Y;

    //            second.Y = first.Y;

    //            trapezoidList.Add(first);
    //            trapezoidList.Add(next);
    //            trapezoidList.Add(last);
    //            trapezoidList.Add(second);
    //        }

    //        return trapezoidList;
    //    }
    //}
}
