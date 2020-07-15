using System;
using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using System.Linq;
using System.Text;
using Painter.Instruments;
using System.Threading.Tasks;

namespace Painter.Figures

{
    public class Rectangle : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;

        public Rectangle(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> Math()
        {
            return new MathRectangle().MathFigure(first, second);
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
            return (minX <= mousePoint.X && minY <= mousePoint.Y && maxX >= mousePoint.X && maxY >= mousePoint.Y);
        }

        public override void Move(Point point)
        {
            first.X += point.X;
            first.Y += point.Y;
            second.X += point.X;
            second.Y += point.Y; 
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
