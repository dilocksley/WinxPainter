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
        Color fillColor = Color.Transparent;
        Point e;
        public Ellipse(Point first, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.thickness = thickness;
            this.fillColor = fillColor;
            this.angle = 0;
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
            return new MathEllipse().MathFigure(first, second, angle);
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
            List<Point> focusPoints = new MathEllipse().FindFocusPoints(first, second);
            Point center = focusPoints[0];
            Point right = focusPoints[1];
            Point left = focusPoints[2];
            Point top = focusPoints[3];
            Point bottom = focusPoints[4];
            if (mousePoint == center || mousePoint == right || mousePoint == left || mousePoint == top || mousePoint == bottom)
            {
                return true;
            }
            else if (mousePoint.X <= right.X && mousePoint.X >= top.X && mousePoint.Y <= right.Y && mousePoint.Y >= top.Y) // top right quarter
            {
                return true;
            }
            else if (mousePoint.X <= right.X && mousePoint.X >= bottom.X && mousePoint.Y >= right.Y && mousePoint.Y <= bottom.Y) //bottom right quarter
            {
                return true;
            }
            else if (mousePoint.X <= bottom.X && mousePoint.X >= left.X && mousePoint.Y <= bottom.Y && mousePoint.Y >= left.Y) //bottom left quarter
            {
                return true;
            }
            else if (mousePoint.X >= left.X & mousePoint.X <= top.X && mousePoint.Y <= left.Y && mousePoint.Y >= top.Y) // top left quarter
            {
                return true;
            }
            return false;
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
            e = new Fill().FindCenterPointInEllipse(first, second);
            return e;
        }

        public override void FillFigure()
        {
            new Fill().FillFigure(e, fillColor);
        }

        public override void ChangeFillColor(Color color)
        {
            fillColor = color;
        }

        //public override void FillFigure()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
