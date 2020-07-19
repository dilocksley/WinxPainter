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
        Point third;
        public Color color;
        public int thickness;
        Color fillColor = Color.Transparent;
        Point e;
        List<Point> points;
        public IsoscelesTriangle(Point first, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
            this.fillColor = fillColor;
        }
        public override List<Point> ReturnPoints()
        {
            List<Point> points = new List<Point>();
            points.Add(first);
            points.Add(second);

            return points;
        }
        public override List<Point> DoFigureMath()                      // реализация метода абстр класса для получения точек фигуры
        {
            points = new MathIsoscelesTriangle().MathFigure(first, second);
            third = points[1];
            return points;
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

            int a = (first.X - mousePoint.X) * (second.Y - first.Y) - (second.X - first.X) * (first.Y - mousePoint.Y);
            int b = (second.X - mousePoint.X) * (third.Y - second.Y) - (third.X - second.X) * (second.Y - mousePoint.Y);
            int c = (third.X - mousePoint.X) * (first.Y - third.Y) - (first.X - third.X) * (third.Y - mousePoint.Y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            return false;
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
            e = new Fill().FindPointFigure(first, second,third);
            return e;
        }

        public override void FillFigure()
        {
            new Fill().FillFigure(e, fillColor);
        }

        public override void ChangeFillColor(Color color)
        {
            fillColor = color;
        }

        //public override void FillFigure()
        //{
        //    throw new NotImplementedException();
        //}

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