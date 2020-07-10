using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using System;


namespace Painter.Figures
{
    public class Ellipse : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public Ellipse(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()
        {
            return new MathEllipse().MathFigure(first, second);
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
