using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures

{
    public class RectangleMath : AFigures
    {
        List<Point> squareList = new List<Point>();
        public RectangleMath(Point FirstPoint, Point SecondPoint)
        {
            this.first = FirstPoint;
            this.second = SecondPoint;
        }
        public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        {          
            squareList = FindRectanglePoints(first, second);
            return squareList;
        }

        public List<Point> FindRectanglePoints(Point First,Point Second)
        {         

            Point next = First;
            Point last = Second;
            next.X = First.X;
            next.Y = Second.Y;

            last.X = Second.X;
            last.Y = First.Y;

            squareList.Add(First);
            squareList.Add(next);
            squareList.Add(Second);
            squareList.Add(last);

            return squareList;
        }
    }
}
