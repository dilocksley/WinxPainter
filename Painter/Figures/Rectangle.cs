using System;
using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures

{
    public class Rectangle : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public Rectangle(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()
        {
            return new MathRectangle().MathFigure(first, second);
        }
        public override Color SetColor()
        {
            return color;
        }
        public override void Update(Point e)
        {
            second = e;
        }

        public override bool IsPointInFigure(Point mousePoint)
        {
            throw new NotImplementedException();
        }

        public override void Move(Point point)
        {
            throw new NotImplementedException();
        }


        #region RectangleMathCode
        //public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        //{
        //    rectangleList = FindRectanglePoints(first, second);
        //    return rectangleList;
        //}
        //public List<Point> FindRectanglePoints(Point First, Point Second)
        //{
        //    Point next = First;
        //    Point last = Second;
        //    next.X = First.X;
        //    next.Y = Second.Y;

        //    last.X = Second.X;
        //    last.Y = First.Y;

        //    rectangleList.Add(First);
        //    rectangleList.Add(next);
        //    rectangleList.Add(Second);
        //    rectangleList.Add(last);

        //    return rectangleList;
        //}
        #endregion
    }
}
