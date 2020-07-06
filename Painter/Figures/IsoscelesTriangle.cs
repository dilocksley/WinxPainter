using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public class IsoscelesTriangle : AFigures
    {
        List<Point> triangleList = new List<Point>();
        public IsoscelesTriangle(Point FirstPoint, Point SecondPoint)
        {
            this.first = FirstPoint;
            this.second = SecondPoint;
        }
        public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        {
            triangleList = FindIsoscelesTrianglePoints(first, second);
            return triangleList;
        }

        public List<Point> FindIsoscelesTrianglePoints(Point First, Point Second)
        {

            Point first = First;
            Point second = Second;
            Point next = Second;
            next.X = first.X - (second.X - first.X);
            next.Y = second.Y;

            triangleList.Add(first);
            triangleList.Add(next);
            triangleList.Add(second);

            return triangleList;
        }
    }
}
