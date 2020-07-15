using System;
using System.Collections.Generic;
using Painter.MathFigures;
using System.Drawing;
using Painter.Instruments;

namespace Painter.Figures
{
    public class Trapezoid : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;
        public Trapezoid(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> DoFigureMath()
        {
            return new MathTrapezoid().MathFigure(first, second);
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
    }
}
