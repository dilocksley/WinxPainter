using System;
using System.Collections.Generic;
using Painter.MathFigures;
using System.Drawing;

namespace Painter.Figures
{
    public class Trapezoid : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public Trapezoid(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()
        {
            return new MathTrapezoid().MathFigure(first, second);
        }
        public override Color SetColor()
        {
            return color;
        }
        public override void Update(Point e)
        {
            second = e;
        }
    }
}
