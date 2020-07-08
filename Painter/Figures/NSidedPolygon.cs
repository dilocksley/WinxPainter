using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    //public class NSidedPolygon : AFigures
    //{
    //    List<Point> polygonList = new List<Point>();
    //    int n = 0;
    //    double angle = 0;
    //    public NSidedPolygon(double angle, int n,Point FirstPoint, Point SecondPoint)
    //    {
    //        this.first = FirstPoint;
    //        this.second = SecondPoint;
    //        this.n = n;
    //        this.angle = angle;
    //    }
    //    public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
    //    {
    //        polygonList = FindLineAnglePoints(angle,n, first, second);
    //        return polygonList;
    //    }
    //    private List<Point> FindLineAnglePoints(double angle, int n, Point first, Point second)
    //    {
    //        Point tmp = new Point(-1, -1);
    //        int R = 0;
    //        if (first.X < second.X && first.Y < second.Y) // IV четверть
    //        {
    //            R = second.Y - first.Y;
    //        }
    //        if (first.X > second.X && first.Y > second.Y) // II четверть
    //        {
    //            R = first.Y - second.Y;
    //        }
    //        if (first.X > second.X && first.Y < second.Y) // III четверть
    //        {
    //            R = first.Y - second.Y;
    //        }
    //        if (first.X < second.X && first.Y > second.Y) // I четверть
    //        {
    //            R = second.X - first.X;
    //        }
    //        double z = 0; int i = 0;
    //        while (i < n )
    //        {
    //            tmp.X = first.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
    //            tmp.Y = first.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
    //            polygonList.Add(tmp);
    //            z = z + angle;
    //            i++;
    //        }
    //        return polygonList;
    //    }
    //}
}

