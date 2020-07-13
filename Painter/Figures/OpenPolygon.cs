using System;
using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public class OpenPolygon : AFigure
    {
        Point first;
        Point second;
        public Color color;

        public OpenPolygon(Point first, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
        }
        public override List<Point> Math()
        {
            return new MathOpenPolygon().MathFigure(first, second);
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
