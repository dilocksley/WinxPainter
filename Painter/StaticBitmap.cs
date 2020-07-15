using Painter.Figures;
using Painter.MathFigures;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class StaticBitmap : StorageFigures
    {
        List<AFigure> tmpFigure = new List<AFigure>();
        private StaticBitmap()
        {

        }
        public static StaticBitmap instance;
        public Bitmap Bitmap { get; set; }

        public Bitmap tmpBitmap { get; set; }

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < tmpBitmap.Width && y >= 0 && y < tmpBitmap.Height)
            {
                tmpBitmap.SetPixel(x, y, color);
            }
        }

        public void DrawLine(Point a, Point b, int radius, Color color)
        {
            Point Delta = new Point(0, 0);

            Delta.X = b.X - a.X;
            Delta.Y = b.Y - a.Y;

            int step;
            if (Math.Abs(Delta.X) > Math.Abs(Delta.Y))
            {
                step = Math.Abs(Delta.X);
            }
            else
            {
                step = Math.Abs(Delta.Y);
            }

            double incrementX = Delta.X / (double)step;
            double incrementY = Delta.Y / (double)step;

            double startX = a.X;
            double startY = a.Y;

            for (int j = 0; j <= step; j++)
            {
                for (int i = -radius; i <= radius; i++)
                {
                    double delta = Math.Sqrt(radius * radius - i  * i);
                    Point tmp = new Point((int)(i + startX), (int)(delta + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(i + startX), (int)(-delta + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(delta + startX), (int)(i + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(-delta + startX), (int)(i + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    delta--;
                    tmp = new Point((int)(i + startX), (int)(delta + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(i + startX), (int)(-delta + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(delta + startX), (int)(i + startY));
                    SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(-delta + startX), (int)(i + startY));
                    SetPixel(tmp.X, tmp.Y, color);

                }
                startX += incrementX;
                startY += incrementY;
            }
        }

        public void DrawFigure(AFigure aFigure)
        {
            List<Point> points = aFigure.Math();
            ConnectPoints(points, aFigure.SetColor(), aFigure.SetThickness());
        }
        public static StaticBitmap GetInstance()
        {
            if (instance == null)
            {
                instance = new StaticBitmap();
            }
            return instance;
        }
        public void CopyInNew()
        {
            if (Bitmap != null)
            {
                tmpBitmap = (Bitmap)Bitmap.Clone();
            }
        }
        public void CopyInOld()
        {
            if (Bitmap != null)
            {
                Bitmap = (Bitmap)tmpBitmap.Clone();
            }
        }
        public void ConnectPoints(List<Point> list, Color color) // для любой фигуры - соединение точек по кол-ву в листе
        {
            Point tmp = new Point(-1, -1);
            foreach (Point point in list)
            {
                if (tmp.X != -1)
                {
                    DrawLine(point, tmp, color);
                }
                tmp = point;
            }
            DrawLine(tmp, list[0], color);       // соедиение последней точки с первой
        }
        public void ConnectPoints(List<Point> list, Color color, int thickness) // для любой фигуры - соединение точек по кол-ву в листе
        {
            Point tmp = new Point(-1, -1);
            foreach (Point point in list)
            {
                if (tmp.X != -1)
                {
                    DrawLine(point, tmp, thickness, color);
                }
                tmp = point;
            }
            DrawLine(tmp, list[0], thickness, color);       // соедиение последней точки с первой
        }
        public void DrawVoluntary(Point first, Point second, Color color)
        {
            Point Delta = new Point(0, 0);

            Delta.X = second.X - first.X;
            Delta.Y = second.Y - first.Y;

            int step;
            if (Math.Abs(Delta.X) > Math.Abs(Delta.Y))
            {
                step = Math.Abs(Delta.X);
            }
            else
            {
                step = Math.Abs(Delta.Y);
            }

            double incrementX = Delta.X / (double)step;
            double incrementY = Delta.Y / (double)step;

            double startX = first.X;
            double startY = first.Y;

            for (int i = 0; i <= step; i++)
            {
                SetPixel((int)startX, (int)startY, color);
                startX += incrementX;
                startY += incrementY;
            }
            //  pictureBox.Image = StaticBitmap.Bitmap; // в самой форме
        } // рисование карандашом (произвольное)

        public void DrawLine(Point first, Point second, Color color)
        {
            DrawVoluntary(first, second, color);
        }
        public void DrawLineXY(int x1, int y1, int x2, int y2, Color color)
        {
            Point firstPoint = new Point(-1, -1);
            Point secondPoint = new Point(-1, -1);
            firstPoint.X = x1;
            firstPoint.Y = y1;
            secondPoint.X = x2;
            secondPoint.Y = y2;

            DrawVoluntary(firstPoint, secondPoint, color);
        }

        public override void AddFigure(AFigure figure)
        {
            aFigures.Add(figure);
        }
        public void ShowOnTheScreen()
        {
            foreach (AFigure figure in aFigures)
            {
                if (figure != null)
                {
                    DrawFigure(figure);
                }
            }
        }


        public void Undo()
        {
            if (aFigures.Count < 1)
            {
                return;
            }
            tmpFigure.Add(aFigures[aFigures.Count - 1]);
            if (tmpFigure != null)
            {
                DrawFigureN(tmpFigure[tmpFigure.Count - 1]);
            }
            aFigures.RemoveAt(aFigures.Count - 1);
            ShowOnTheScreen();
        }

        public void Redo()
        {
            if (tmpFigure.Count < 1)
            {
                return;
            }
            aFigures.Add(tmpFigure[tmpFigure.Count - 1]);

            tmpFigure.RemoveAt(tmpFigure.Count - 1);
            ShowOnTheScreen();
        }

        public void DrawFigureN(AFigure aFigure)
        {
            if (aFigure != null)
            {
                List<Point> points = aFigure.Math();
                ConnectPoints(points, Color.White);
            }

        }

        public void ShowWithOutFigure(AFigure afigure)
        {
            int q = 0;
            for (int i = 0; i < aFigures.Count; i++)
            {
                if (aFigures[i] == afigure)
                {
                    q = i;
                    break;
                }

            }
            DrawFigureN(aFigures[q]);
            aFigures.RemoveAt(q);
            ShowOnTheScreen();

        }

        public void Fill(Point e, Color colorFill)
        {
            Color startColor = tmpBitmap.GetPixel(e.X, e.Y);
            Point left = new Point(e.X, e.Y);
            Point right = new Point(e.X, e.Y);
            //if (Bitmap.Width >= e.X && Bitmap.Height >= e.Y && e.X > 0 && e.Y > 0)
            //{
            while (tmpBitmap.GetPixel(left.X - 1, left.Y) == startColor)
            {
                if (Bitmap.Width >= left.X && Bitmap.Height >= left.Y && left.X > 0 && left.Y > 0)
                {
                    left.X--;
                }
            }

            while (tmpBitmap.GetPixel(right.X + 1, right.Y) == startColor)
            {
                if (Bitmap.Width >= right.X && Bitmap.Height >= right.Y && right.X > 0 && right.Y > 0)
                {
                    right.X++;
                }
            }


            DrawLine(left, right, colorFill);

            for (int i = left.X; i <= right.X; i++)
            {
                if (tmpBitmap.GetPixel(i, e.Y + 1) == startColor)
                {
                    Point up = new Point(i, e.Y + 1);
                    if (Bitmap.Width >= up.X && Bitmap.Height >= up.Y && up.X > 0 && up.Y > 0)
                    {
                        Fill(up, colorFill);
                    }
                }
                if (tmpBitmap.GetPixel(i, e.Y - 1) == startColor)
                {

                    Point down = new Point(i, e.Y - 1);
                    if (Bitmap.Width >= down.X && Bitmap.Height >= down.Y && down.X > 0 && down.Y > 0)
                    {
                        Fill(down, colorFill);
                    }
                }
            }
            //}           
        }
    }
}
