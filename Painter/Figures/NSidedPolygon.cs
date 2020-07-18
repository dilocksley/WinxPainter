using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Instruments;
using Painter.MathFigures;

namespace Painter.Figures
{
    public class NSidedPolygon : AFigure
    {
        Point first;
        Point second;
        public Color color;
        int n;
        public int thickness;
        Color fillColor = Color.Transparent;
        Point e;
        public NSidedPolygon(Point first,int n, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.n = n;
            this.thickness = thickness;
            this.fillColor = fillColor;
        }
        public override List<Point> DoFigureMath()
        {                     
            return new MathNSidedPolygon(n).MathFigure(first, second);
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
            throw new NotImplementedException();
        }

        //public override void FillFigure()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

