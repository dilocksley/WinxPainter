using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.MathFigures;

namespace Painter.Figures
{
    public class NSidedPolygon : AFigure
    {
        Point first;
        Point second;
        public Color color;
        int n;
        public NSidedPolygon(Point first,int n, Color color)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.n = n;
        }
        public override List<Point> Math()
        {                     
            return new MathNSidedPolygon(n).MathFigure(first, second);
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

