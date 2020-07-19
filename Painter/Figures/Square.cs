using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Painter.MathFigures;
using Painter.Instruments;
using System.Deployment.Application;
using Painter.Instruments;

namespace Painter.Figures
{
    public class Square : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;
        List<Point> a;

        
        Color fillColor = Color.Transparent;
        Point e;
       public Square(Point first, Color color, Color fillColor, int thickness)
       {
            this.first = first;
            this.color = color;
            this.second = first;
            this.thickness = thickness;
            this.fillColor = fillColor;
            this.angle = 0;
       }
        public override List<Point> ReturnPoints()
        {
            List<Point> points = new List<Point>();
            points.Add(first);
            points.Add(second);

            return points;
        }
        public override List<Point> DoFigureMath()
        {
            a = new MathSquare().MathFigure(first, second, angle);
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

        public override bool IsPointInFigure(Point mousePoint) //ищем принадлежит ли точка квадрату
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

        //public void SetAngle(Point point)
        //{
        //    //Point center = first;

        //    //int length = Math.Abs(second.Y - first.Y);

        //    //if (second.X < first.X)
        //    //{
        //    //    second.X = first.X - length;
        //    //}
        //    //else
        //    //{
        //    //    second.X = first.X + length;
        //    //}

        //    //center.X = first.X + (second.X - first.X) / 2;
        //    //center.Y = first.Y + (second.Y - first.Y) / 2;



        //}

        public override Color FillSetColor()
        {
            return fillColor;
        }

        public override Point FindPoint()
        {
            e = new Fill().FindPointFigure(first, second);
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



    }
}
