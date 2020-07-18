using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using Painter.Instruments;


namespace Painter.Figures
{

    public class Triangle : AFigure
    {
        Point first;
        Point second;
        Point third;
        public Color color;
        List<Point> list;
        public int thickness;
        Color fillColor = Color.Transparent;
        Point e;
        public Triangle(Color color, List<Point> list, Color fillColor, int thickness)
        {
            this.thickness = thickness;
            this.color = color;
            this.list = list;
            this.fillColor = fillColor;
            first = list[0];
            second = list[1];
            third = list[2];
        }
        public override List<Point> DoFigureMath()
        {
            return new MathTriangle(list).MathFigure(first, second);
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
            third.X += point.X;
            third.Y += point.Y;
        }

        public override Color FillSetColor()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        //public override void FillFigure()
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}
