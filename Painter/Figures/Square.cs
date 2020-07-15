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
       public Square(Point first, Color color, int thickness)
        Color fillColor = Color.Transparent;
        Point e;
       public Square(Point first, Color color, Color fillColor)
       {
            this.first = first;
            this.color = color;
            this.second = first;
            this.thickness = thickness;
            this.fillColor = fillColor;
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
            e = new Fill().FindPointFigure(first, second);
            return e;
        }
        
        public override void FillFigure()
        {
            new Fill().FillFigure(e, fillColor);
        }

      
    }
}
