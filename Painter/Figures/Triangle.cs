using System.Collections.Generic;
using System.Drawing;
using Painter.MathFigures;
using Painter.Instruments;


namespace Painter.Figures
{

    public class Triangle : AFigure
    {
        Point first;
        Point second;
        Point third;
        public Color color;
        List<Point> list;
        public int thickness;

        public Triangle(Color color, List<Point> list, int thickness)
        {
            this.thickness = thickness;
            this.color = color;
            this.list = list;
        }
        public override List<Point> DoFigureMath()
        {
            return new MathTriangle(list).MathFigure(first, second);
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
            throw new System.NotImplementedException();
        }

        public override void Move(Point point)
        {
            throw new System.NotImplementedException();
        }

        public override Color FillSetColor()
        {
            throw new System.NotImplementedException();
        }

        public override Point FindPoint()
        {
            throw new System.NotImplementedException();
        }

        public override void FillFigure()
        {
            throw new System.NotImplementedException();
        }

        //public override void FillFigure()
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}
