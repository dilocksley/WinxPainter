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

        public Ellipse(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> Math()
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
    }
}
