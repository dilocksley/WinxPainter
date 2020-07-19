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
        Color fillColor = Color.Transparent;
        Point e;
        List<Point> points;
        public Line(Point first, Color color, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
        }
        public override List<Point> ReturnPoints()
        {
            List<Point> points = new List<Point>();
            points.Add(first);
            points.Add(second);
            return points;
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
            points = new MathLine().MathFigure(first, second);           
            return points.Contains(mousePoint);
        }

        public override void Move(Point point)
        {
            throw new NotImplementedException();
        }

        public override Color FillSetColor()
        {
            return fillColor;
        }

        public override Point FindPoint()
        {
            e = new Fill().FindPointFigure(first, second);
            return e;
        }

        public override void FillFigure()
        {
            
        }

        public override void ChangeFillColor(Color color)
        {
            fillColor = color;
        }
    }
}
