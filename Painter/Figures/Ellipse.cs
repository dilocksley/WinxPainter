using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using System;
using Painter.Instruments;


namespace Painter.Figures
{
    public class Ellipse : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;
        Color fillColor = Color.Transparent;
        Point e;
        public Ellipse(Point first, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
            this.fillColor = fillColor;
        }
        public override List<Point> DoFigureMath()
        {
            return new MathEllipse().MathFigure(first, second);
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

        public override Color FillSetColor()
        {
            return fillColor;
        }

        public override Point FindPoint()
        {
            e = new Fill().FindCenterPointInEllipse(first, second);
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
    }
}
