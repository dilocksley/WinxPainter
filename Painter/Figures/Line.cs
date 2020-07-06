using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public class Line : AFigures
    {
        List<Point> squareList = new List<Point>();
        
       
        public Line(Point FirstPoint, Point SecondPoint)
        {
            this.first = FirstPoint;
            this.second = SecondPoint;
            
        }
        public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        {
            squareList = FindLinePoints(first, second);
            return squareList;
        }

        public List<Point> FindLinePoints(Point first,Point second)
        {
            squareList.Add(first);
            squareList.Add(second);

            return squareList;
        }
    }
}
