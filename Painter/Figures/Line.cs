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
            int error = 5;
            if (mousePoint.X >= first.X - error && mousePoint.X <= first.X + error) return true;
            else if (mousePoint.X >= second.X - error && mousePoint.X <= second.X + error) return true;
            else if (mousePoint.Y >= first.Y - error && mousePoint.Y <= first.Y + error) return true;
            else if (mousePoint.Y >= second.Y - error && mousePoint.Y <= second.Y + error) return true;
            else return false;
        }

        public override void Move(Point point)
        {
            first.X += point.X;
            first.Y += point.Y;
            second.X += point.X;
            second.Y += point.Y;
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
