using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;


namespace Painter.Figures

{

    public class RightTriangle : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public RightTriangle(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()                      // реализация метода абстр класса для получения точек фигуры
        {
            return new MathRightTriangle().MathFigure(first, second);
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
            throw new System.NotImplementedException();
        }

        public override void Move(Point point)
        {
            throw new System.NotImplementedException();
        }

        //public List<Point> FindRightTrianglePoints(Point First, Point Second)
        //{

        //    Point first = First;
        //    Point second = Second;
        //    Point next = Second;
        //    next.X = first.X;
        //    next.Y = second.Y;

        //    triangleList.Add(first);
        //    triangleList.Add(next);
        //    triangleList.Add(second);

        //    return triangleList;
        //}
    }
}
