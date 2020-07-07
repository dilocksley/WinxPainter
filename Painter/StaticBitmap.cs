using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public static class StaticBitmap
    {
        public static Bitmap Bitmap { get; set; }
        public static Bitmap tmpBitmap { get; set; }
        public static void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < tmpBitmap.Width && y >= 0 && y < tmpBitmap.Height)
            {
                tmpBitmap.SetPixel(x, y, color);
            }
        }

        public static void CopyInNew()
        {
            if(Bitmap!=null)
            {
                tmpBitmap = (Bitmap)Bitmap.Clone();
            }
        }

        public static void CopyInOld()
        {
            if (Bitmap != null)
            {
               Bitmap = (Bitmap)tmpBitmap.Clone();
            }
        }
        public static void DrawFigure(List<Point> list, Color color) // для любой фигуры - соединение точек по кол-ву в листе
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
        public static void DrawRoundShapedFigure(List<Point> list, Color color)
        {
            Point tmp = new Point(-1, -1);
            foreach (Point point in list)
            {
                if (tmp.X != -1)
                {
                    SetPixel(tmp.X, tmp.Y, color);
                }
                tmp = point;
            }
            //StaticBitmap.SetPixel(tmp.X, tmp.Y, color);
        }
        private static void DrawVoluntary(Point first, Point second, Color color)
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

       public static void DrawLine(Point first, Point second, Color color)
        {
            DrawVoluntary(first, second, color);
        }
        public static void DrawLineXY(int x1, int y1, int x2, int y2, Color color)
        {
            Point firstPoint = new Point (-1, -1);
            Point secondPoint = new Point(-1, -1);
            firstPoint.X = x1;
            firstPoint.Y = y1;
            secondPoint.X = x2;
            secondPoint.Y = y2;

            DrawVoluntary(firstPoint, secondPoint, color);
        }
    }



}
