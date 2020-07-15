using System;
using System.Collections.Generic;
using Painter.MathFigures;
using System.Drawing;
using Painter.Instruments;


namespace Painter.Figures
{
    public class IsoscelesTriangle : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;

        public IsoscelesTriangle(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> Math()                      // реализация метода абстр класса для получения точек фигуры
        {
            return new MathIsoscelesTriangle().MathFigure(first, second);
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
            throw new NotImplementedException();
        }

        public override void Move(Point point)
        {
            throw new NotImplementedException();
        }

        //public class IsoscelesTriangle : AFigure
        //{
        //    //List<Point> triangleList = new List<Point>();

        //    //public IsoscelesTriangle(Point FirstPoint, Point SecondPoint)
        //    //{
        //    //    this.first = FirstPoint;
        //    //    this.second = SecondPoint;
        //    //}
        //    //public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        //    //{
        //    //    triangleList = FindIsoscelesTrianglePoints(first, second);
        //    //    return triangleList;
        //    //}

        //    //public List<Point> FindIsoscelesTrianglePoints(Point First, Point Second)
        //    //{
        //    //    Point next = Second;
        //    //    next.X = First.X - (Second.X - First.X);
        //    //    next.Y = Second.Y;

        //    //    triangleList.Add(First);
        //    //    triangleList.Add(next);
        //    //    triangleList.Add(Second);

        //    //    return triangleList;
        //    //}
        //}
    }
}