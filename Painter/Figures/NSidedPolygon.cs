using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Instruments;
using Painter.MathFigures;

namespace Painter.Figures
{
    public class NSidedPolygon : AFigure
    {
        Point first;
        Point second;
        public Color color;
        int n;
        public int thickness;
        Color fillColor = Color.Transparent;
        Point e;
        List<Point> points;
        public NSidedPolygon(Point first,int n, Color color, Color fillColor, int thickness)
        {
            this.first = first;
            this.second = first;
            this.color = color;
            this.n = n;
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
            points = new MathNSidedPolygon(n).MathFigure(first, second, angle);
            return points;
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
            for (int i = 0; i < points.Count-1; i++)
            {
                if(i==0)
                {
                    int q = (first.X - mousePoint.X) * (points[i].Y - first.Y) - (points[i].X - first.X) * (first.Y - mousePoint.Y);
                    int w = (points[i].X - mousePoint.X) * (points[points.Count - 1].Y - points[i].Y) - (points[points.Count - 1].X - points[i].X) * (points[i].Y - mousePoint.Y);
                    int e = (points[points.Count - 1].X - mousePoint.X) * (first.Y - points[points.Count - 1].Y) - (first.X - points[points.Count - 1].X) * (points[points.Count - 1].Y - mousePoint.Y);

                    if ((q >= 0 && w >= 0 && e >= 0) || (q <= 0 && w <= 0 && e <= 0))
                    {
                        return true;
                    }
                }
                int a = (first.X - mousePoint.X) * (points[i].Y - first.Y) - (points[i].X - first.X) * (first.Y - mousePoint.Y);
                int b = (points[i].X - mousePoint.X) * (points[i+1].Y - points[i].Y) - (points[i + 1].X - points[i].X) * (points[i].Y - mousePoint.Y);
                int c = (points[i + 1].X - mousePoint.X) * (first.Y - points[i + 1].Y) - (first.X - points[i + 1].X) * (points[i + 1].Y - mousePoint.Y);
                               

                if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                {
                    return true;
                }
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
            e = new Fill().FindPointFigure(first, second);
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
    }
}

