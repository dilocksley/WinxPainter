using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.MathFigures;

namespace Painter.Figures
{
    public class Line : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public Line(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()
        {
            return new MathLine().MathFigure(first, second);
        }
        public override Color SetColor()
        {
            return color;
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
