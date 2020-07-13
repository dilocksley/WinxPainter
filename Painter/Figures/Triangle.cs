using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;


namespace Painter.Figures
{

    public class Triangle : AFigure
    {
        Point first;
        Point second;
        Point third;
        public Color color;
        List<Point> list;

        public Triangle(Color color, List<Point> list)
        {

            this.color = color;
            this.list = list;

        }
        public override List<Point> Math()
        {

            return new MathTriangle(list).MathFigure(first, second);
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
            throw new System.NotImplementedException();
        }

        public override void Move(Point point)
        {
            throw new System.NotImplementedException();
        }
    }

}
