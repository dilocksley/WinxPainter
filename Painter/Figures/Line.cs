using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.MathFigures;
using Painter.Instruments;

namespace Painter.Figures
{
    public class Line : AFigure
    {
        Point first;
        Point second;
        public Color color;
        public int thickness;

        public Line(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> DoFigureMath()
        {
            return new MathLine().MathFigure(first, second);
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
            throw new NotImplementedException();
        }

        public override Point FindPoint()
        {
            throw new NotImplementedException();
        }

        public override void FillFigure()
        {
            throw new NotImplementedException();
        }

        //public override void FillFigure()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
