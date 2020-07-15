﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Painter.MathFigures;
using Painter.Instruments;
using System.Deployment.Application;

namespace Painter.Figures
{
    public class Square : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;
        List<Point> a;
       public Square(Point first, Color color, int thickness)
       {
            this.first = first;
            this.color = color;
            this.second = first;
            this.thickness = thickness;
       }

       public override List<Point> DoFigureMath()
       {
            a= new MathSquare().MathFigure(first, second);
            return a;
       }

        public override Color SetColor ()
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

        public override bool IsPointInFigure(Point mousePoint) //ищем пренадлежит ли точка квадрату
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

            //if (first.X <= mousePoint.X && first.Y <= mousePoint.Y && second.X >= mousePoint.X && second.Y >= mousePoint.Y)
            //    return true;
            //else return false;

        }

        public override void Move(Point point)
        {
            first.X += point.X;
            first.Y += point.Y;
            second.X += point.X;
            second.Y += point.Y;
        }

        
    }
}
