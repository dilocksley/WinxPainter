﻿using System.Collections.Generic;
using System.Drawing;


namespace Painter.Figures
{
    public class RightTriangle : AFigures
    {
        List<Point> triangleList = new List<Point>();
        public RightTriangle(Point FirstPoint, Point SecondPoint)
        {
            this.first = FirstPoint;
            this.second = SecondPoint;
        }
        public override List<Point> GetPoints()                      // реализация метода абстр класса для получения точек фигуры
        {
            triangleList = FindRightTrianglePoints(first, second);
            return triangleList;
        }

        public List<Point> FindRightTrianglePoints(Point First, Point Second)
        {

            Point first = First;
            Point second = Second;
            Point next = Second;
            next.X = first.X;
            next.Y = second.Y;

            triangleList.Add(first);
            triangleList.Add(next);
            triangleList.Add(second);

            return triangleList;
        }
    }
}
