using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {

        Color CurrentColor;
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        Point next;
        Point middle;
        Point last;
        Point center;
        int n = 1;                  //количество сторон
        int R;                      //расстояние от центра до стороны       
        Point[] p;
        int count = 0;
        double angle = Math.PI / 2; //Угол поворота на 90 градусов
        double angle1 = Math.PI / 4;  //Угол поворота на 45 градусов
        double angle2 = Math.PI / 6;  //Угол поворота на 30 градусов

        public Painter()
        {
            InitializeComponent();

            CurrentColor = Color.Black;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            textBox1.Text = "0";
        }

        private void DrawTree(double x, double y, double a, double angle)
        {
            if (a > 2)
            {
                a *= 0.7; //Меняем параметр a - это колличество веток

                //Считаем координаты для ветки
                double xnew = Math.Round(x + a * Math.Cos(angle)),
                       ynew = Math.Round(y - a * Math.Sin(angle));

                //соединяем вершинами
                DrawLine((int)x, (int)y, (int)xnew, (int)ynew, CurrentColor);

                //Переприсваеваем координаты
                x = xnew;
                y = ynew;

                //Для левой и правой ветки
                DrawTree(x, y, a, angle + angle1);
                DrawTree(x, y, a, angle - angle2);
            }
        }
        private void DrawTrapezoid(Point first, Point second, Color color)
        {
            if (second.X > first.X)
            {
                next.X = first.X + Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                second.Y = first.Y;

                DrawLine(first, next, color);

                DrawLine(next, last, color);

                DrawLine(last, second, color);

                DrawLine(second, first, color);
            }
            else
            {
                next.X = first.X - Math.Abs(second.X - first.X) / 4;
                next.Y = second.Y;

                last.X = next.X + ((second.X - first.X) / 2);
                last.Y = next.Y;

                second.Y = first.Y;

                DrawLine(first, next, color);

                DrawLine(next, last, color);

                DrawLine(last, second, color);

                DrawLine(second, first, color);
            }
        }

        private void DrawPointTriangle(Point FirstPoint, Point SecondPoint, Point ThirdPoint, Color color)
        {
            DrawLine(FirstPoint, SecondPoint, color);
            DrawLine(SecondPoint, ThirdPoint, color);
            DrawLine(ThirdPoint, FirstPoint, color);
        }

        private void DrawPointRightTriangle(Point first, Point second, Color color)
        {
            next.X = first.X;
            next.Y = second.Y;
            DrawLine(first, next, color);
            DrawLine(next, second, color);
            DrawLine(second, first, color);
        }

        private void DrawIsoscelesTriangle(Point first, Point second, Color color)
        {
            next.X = first.X - (second.X - first.X);
            next.Y = second.Y;
            DrawLine(first, second, color);
            DrawLine(second, next, color);
            DrawLine(next, first, color);
        }


        private void DrawNSidedPolygon(int n)
        {

            p = new Point[n + 1];
            LineAngle((double)(360.0 / (double)n));
            int i = n;

            while (i > 0)
            {
                DrawLine(p[i], p[i - 1], CurrentColor);
                i = i - 1;
            }
        }

        private void LineAngle(double angle)
        {

            if (FirstPoint.X < SecondPoint.X && FirstPoint.Y < SecondPoint.Y) // IV четверть
            {
                R = SecondPoint.Y - FirstPoint.Y;
            }
            if (FirstPoint.X > SecondPoint.X && FirstPoint.Y > SecondPoint.Y) // II четверть
            {
                R = FirstPoint.Y - SecondPoint.Y;
            }
            if (FirstPoint.X > SecondPoint.X && FirstPoint.Y < SecondPoint.Y) // III четверть
            {
                R = FirstPoint.Y - SecondPoint.Y;
            }
            if (FirstPoint.X < SecondPoint.X && FirstPoint.Y > SecondPoint.Y) // I четверть
            {
                R = SecondPoint.X - FirstPoint.X;
            }
            double z = 0; int i = 0;
            while (i < n + 1)
            {
                p[i].X = FirstPoint.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
                p[i].Y = FirstPoint.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
                z = z + angle;
                i++;
            }
        }
        private void DrawSquare(Point first, Point second, Color color)
        {
            int length = 0;
            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                length = second.Y - first.Y;

                next.X = first.X + length;
                next.Y = first.Y;
                DrawLine(first, next, color);

                middle.X = next.X;
                middle.Y = next.Y + length;
                DrawLine(next, middle, color);

                last.X = middle.X - length;
                last.Y = middle.Y;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                length = first.X - second.X;


                next.X = first.X - length;
                next.Y = first.Y;
                DrawLine(first, next, color);

                middle.X = next.X;
                middle.Y = next.Y - length;
                DrawLine(next, middle, color);

                last.X = middle.X + length;
                last.Y = middle.Y;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                length = first.X - second.X;

                next.X = first.X;
                next.Y = first.Y + length;
                DrawLine(first, next, color);

                middle.X = next.X - length;
                middle.Y = next.Y;
                DrawLine(next, middle, color);

                last.X = middle.X;
                last.Y = middle.Y - length;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                length = second.X - first.X;

                next.X = first.X;
                next.Y = first.Y - length;
                DrawLine(first, next, color);

                middle.X = next.X + length;
                middle.Y = next.Y;
                DrawLine(next, middle, color);

                last.X = middle.X;
                last.Y = middle.Y + length;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
        }
        private void DrawCircle(Point first, Point second, Color color) // на основе алгоритма Брезенхема
        {
            int length = 0;
            if (first.X < second.X && first.Y < second.Y) // IV четверть
            {
                length = second.Y - first.Y;
                next.X = first.X + length;
                next.Y = first.Y;
                middle.X = next.X - length / 2;
                middle.Y = next.Y;
                center.X = middle.X;
                center.Y = middle.Y + length / 2;
            }
            if (first.X > second.X && first.Y > second.Y) // II четверть
            {
                length = first.X - second.X;
                next.X = first.X - length;
                next.Y = first.Y;
                middle.X = first.X - length / 2;
                middle.Y = first.Y;
                center.X = middle.X;
                center.Y = middle.Y - length / 2;
            }
            if (first.X > second.X && first.Y < second.Y) // III четверть
            {
                length = first.X - second.X;
                next.X = first.X;
                next.Y = first.Y + length;
                middle.X = next.X;
                middle.Y = next.Y + length / 2;
                center.X = middle.X - length / 2;
                center.Y = middle.Y;
            }
            if (first.X < second.X && first.Y > second.Y) // I четверть
            {
                length = second.X - first.X;
                next.X = first.X;
                next.Y = first.Y - length;
                middle.X = first.X;
                middle.Y = first.Y - length / 2;
                center.X = middle.X + length / 2;
                center.Y = middle.Y;
            }

            int radius = length / 2;
            int x = 0;
            int y = radius;
            int delta = 1 - 2 * radius;
            int error = 0;
            while (y >= 0)
            {
                StaticBitmap.SetPixel(center.X + x, center.Y + y, color);
                StaticBitmap.SetPixel(center.X + x, center.Y - y, color);
                StaticBitmap.SetPixel(center.X - x, center.Y + y, color);
                StaticBitmap.SetPixel(center.X - x, center.Y - y, color);
                error = 2 * (delta + y) - 1;
                if (delta < 0 && error <= 0)
                {
                    delta += 2 * x++ + 1;
                    continue;
                }
                if (delta > 0 && error > 0)
                {
                    delta -= 2 * y-- + 1;
                    continue;
                }
                delta += 2 * (x++ - y--);
            }
            pictureBox.Image = StaticBitmap.Bitmap;
        }
        private void DrawEllipse(Point first, Point second, Color color)
        {
            //ищем диаметр
            int diameterY = Math.Abs(second.Y - first.Y); 
            int diameterX = Math.Abs(second.X - first.X);
            //ищем радиус
            int radiusY = diameterY / 2;
            int radiusX = diameterX / 2;
            //ищем центр эллипса, определяем старт рисования
            int centerY = radiusY + first.Y;            
            if (first.Y > second.Y)
            {
                centerY = radiusY + second.Y;
            }

            int centerX = radiusX + first.X;
            int startX = first.X;
            if (first.X > second.X)
            {
                centerX = radiusX + second.X;
                startX = second.X;
            }
            
            int previousX = startX;
            int previousY = DrawEllipseGetY(previousX, centerX, centerY, radiusX, radiusY);
            int previousYMirror = previousY;

            for (int X = startX+1; X <= startX + diameterX; X++)
            {
                int Y = DrawEllipseGetY(X, centerX, centerY, radiusX, radiusY);
                int YMirror = Y - (Y - centerY) * 2;

                DrawLine(new Point(previousX, previousY), new Point(X, Y), color);
                DrawLine(new Point(previousX, previousYMirror), new Point(X, YMirror), color);

                previousX = X;
                previousY = Y;
                previousYMirror = YMirror;
            }

            pictureBox.Image = StaticBitmap.Bitmap;
        }

        private int DrawEllipseGetY(int X, int centerX, int centerY, int radiusX, int radiusY)
        {
            double ch = ((X - centerX) * (X - centerX));
            double zn = (radiusX * radiusX);
            double p = ch / zn;

            if (p > 1)
            {
                p = 1;
            }

            double YD = Math.Sqrt((1 - p) * radiusY * radiusY) + centerY;
            return Convert.ToInt32(YD);
        }


        //private void DrawEllipse(Point first, Point second, Color color)
        //{
        //    int differenceY = second.Y - first.Y;
        //    int differenceX = second.X - first.X;
        //    int anotherDifferenceY = first.Y - second.Y;
        //    int anotherDifferenceX = first.X - second.X;
        //    int shortLength = 0;
        //    int longLength = 0;
        //    // если разница у меньше разницы х - горизонатльный
        //    // если разница y > разницы х - вертикальный
        //    if (differenceY < differenceX || anotherDifferenceY < anotherDifferenceX) // горизонтальный
        //    {
        //        if (first.X < second.X && first.Y < second.Y) // IV четверть
        //        {
        //            shortLength = second.Y - first.Y;
        //            longLength = second.X - first.X;
        //            center.X = first.X + longLength / 2;
        //            center.Y = first.Y + shortLength / 2;
        //        }
        //        if (first.X > second.X && first.Y > second.Y) // II четверть
        //        {
        //            shortLength = first.Y - second.Y;
        //            longLength = first.X - second.X;
        //            center.X = first.X - longLength / 2;
        //            center.Y = first.Y - shortLength / 2;
        //        }
        //        if (first.X > second.X && first.Y < second.Y) // III четверть
        //        {
        //            shortLength = second.Y - first.Y;
        //            longLength = first.X - second.X;
        //            center.X = first.X - longLength / 2;
        //            center.Y = first.Y + shortLength / 2;
        //        }
        //        if (first.X < second.X && first.Y > second.Y) // I четверть
        //        {
        //            shortLength = first.Y - second.Y;
        //            longLength = second.X - first.X;
        //            center.X = first.X + longLength / 2;
        //            center.Y = first.Y - shortLength / 2;
        //        }
        //    }
        //    else if (differenceY > differenceX || anotherDifferenceY > anotherDifferenceX) // вертикальный
        //    {
        //        if (first.X < second.X && first.Y < second.Y) // IV четверть
        //        {
        //            shortLength = second.X - first.X;
        //            longLength = second.Y - first.Y;
        //            center.X = first.X + shortLength / 2;
        //            center.Y = first.Y + longLength / 2;
        //        }
        //        if (first.X > second.X && first.Y > second.Y) // II четверть
        //        {
        //            shortLength = first.X - second.X;
        //            longLength = first.Y - second.Y;
        //            center.X = first.X - shortLength / 2;
        //            center.Y = first.Y - longLength / 2;
        //        }
        //        if (first.X > second.X && first.Y < second.Y) // III четверть
        //        {
        //            shortLength = first.X - second.X;
        //            longLength = second.Y - first.Y;
        //            center.X = first.X - shortLength / 2;
        //            center.Y = first.Y + longLength / 2;
        //        }
        //        if (first.X < second.X && first.Y > second.Y) // I четверть
        //        {
        //            shortLength = second.X - first.X;
        //            longLength = first.Y - second.Y;
        //            center.X = first.X + shortLength / 2;
        //            center.Y = first.Y - longLength / 2;
        //        }
        //    }
        //    //else            // если разница равна, то это окружность, а не эллипс
        //    //{
        //    //    DrawCircle(first, second, color);
        //    //}
        //    int longRadius = longLength / 2;
        //    int shortRadius = shortLength / 2;
        //    int _x = 0;
        //    int _y = shortRadius;
        //    // Параметры в первой части
        //    float delta = (shortRadius * shortRadius) - (longRadius * longRadius * shortRadius) +
        //                    (0.25f * longRadius * longRadius);
        //    float dx = 2 * shortRadius * shortRadius * _x;
        //    float dy = 2 * longRadius * longRadius * _y;
        //    float error = 0;
        //    while (dx < dy)
        //    {

        //        // симметричные точки
        //        StaticBitmap.SetPixel(center.X + _x, center.Y + _y, color);
        //        StaticBitmap.SetPixel(center.X + _x, center.Y - _y, color);
        //        StaticBitmap.SetPixel(center.X - _x, center.Y + _y, color);
        //        StaticBitmap.SetPixel(center.X - _x, center.Y - _y, color);
        //        error = 2 * (delta + _y) - 1;
        //        if (delta < 0)
        //        {
        //            _x++;
        //            dx = dx + (2 * shortRadius * shortRadius);
        //            delta = delta + dx + (shortRadius * shortRadius);
        //        }
        //        else
        //        {
        //            _x++;
        //            _y--;
        //            dx = dx + (2 * shortRadius * shortRadius);
        //            dy = dy - (2 * longRadius * longRadius);
        //            delta = delta + dx - dy + (shortRadius * shortRadius);
        //        }

        //    }

        //    // Параметры второй части
        //    float d2 = ((shortRadius * shortRadius) * ((_x + 0.5f) * (_x + 0.5f)))
        //        + ((longRadius * longRadius) * ((_y - 1) * (_y - 1)))
        //        - (longRadius * longRadius * shortRadius * shortRadius);

        //    while (_y >= 0)
        //    {

        //        StaticBitmap.SetPixel(center.X + _x, center.Y + _y, color);
        //        StaticBitmap.SetPixel(center.X + _x, center.Y - _y, color);
        //        StaticBitmap.SetPixel(center.X - _x, center.Y + _y, color);
        //        StaticBitmap.SetPixel(center.X - _x, center.Y - _y, color);
        //        error = 2 * (delta + _y) - 1;
        //        if (d2 > 0)
        //        {
        //            _y--;
        //            dy = dy - (2 * longRadius * longRadius);
        //            d2 = d2 + (longRadius * longRadius) - dy;
        //        }
        //        else
        //        {
        //            _y--;
        //            _x++;
        //            dx = dx + (2 * shortRadius * shortRadius);
        //            dy = dy - (2 * longRadius * longRadius);
        //            d2 = d2 + dx - dy + (longRadius * longRadius);
        //        }
        //    }


        //    pictureBox.Image = StaticBitmap.Bitmap;
        //}

        private void DrawRectangle(Point first, Point second, Color color)
        {
            next.X = first.X;
            next.Y = second.Y;
            DrawLine(first, next, color);
            DrawLine(next, second, color);

            next.X = second.X;
            next.Y = first.Y;
            DrawLine(second, next, color);
            DrawLine(next, first, color);
        }
        private void Draw(Point first, Point second, Color color)
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
                StaticBitmap.SetPixel((int)startX, (int)startY, CurrentColor);
                startX += incrementX;
                startY += incrementY;
            }
            pictureBox.Image = StaticBitmap.Bitmap;
        }

        private void DrawLine(Point first, Point second, Color color)
        {
            Draw(first, second, color);
        }
        private void DrawLine(int x1, int y1, int x2, int y2, Color color)
        {
            FirstPoint.X = x1;
            FirstPoint.Y = y1;
            SecondPoint.X = x2;
            SecondPoint.Y = y2;

            Draw(FirstPoint, SecondPoint, color);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            FirstPoint = e.Location;
            if (toolBox.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали инструмент для рисования");
            }

            //else if (toolBox.SelectedIndex == 5)
            //{
            //    FillArea(e.X, e.Y, CurrentColor);
            //}
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            if (toolBox.SelectedIndex == 6)
            {
                if (count == 0)
                {
                    FirstPoint = e.Location;
                    count++;
                }
                else if (count == 1)
                {
                    SecondPoint = e.Location;
                    count++;
                }
                else if (count == 2)
                {

                    DrawPointTriangle(FirstPoint, SecondPoint, e.Location, CurrentColor);
                    count = 0;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (toolBox.SelectedIndex == 0)
                {
                    SecondPoint = FirstPoint;
                    FirstPoint = e.Location;
                    Draw(FirstPoint, SecondPoint, CurrentColor);
                }
                else if (toolBox.SelectedIndex == 1)
                {

                }
            }

            label1.Text = $"X = {e.X}";
            label2.Text = $"Y = {e.Y}";

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            mouseDown = false;
            SecondPoint = e.Location;
            if (toolBox.SelectedIndex == 0)
            {

            }
            else if (toolBox.SelectedIndex == 1)
            {
                DrawLine(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 2)
            {
                DrawRectangle(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 3)
            {
                DrawSquare(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 4)
            {
                n = Convert.ToInt32(textBox1.Text);
                if (n <= 0)
                {
                    MessageBox.Show("Введите количество граней");
                }
                DrawNSidedPolygon(n);
            }
            else if (toolBox.SelectedIndex == 5)
            {
                DrawTrapezoid(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 7)
            {
                DrawPointRightTriangle(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 8)
            {
                DrawIsoscelesTriangle(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 9)
            {
                DrawTree(FirstPoint.X, FirstPoint.Y, 250, angle);
            }
            else if (toolBox.SelectedIndex == 10)
            {
                DrawCircle(FirstPoint, SecondPoint, CurrentColor);
            }
            else if (toolBox.SelectedIndex == 11)
            {
                DrawEllipse(FirstPoint, SecondPoint, CurrentColor);
            }
        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }
        }

        private void DeletAll_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            StaticBitmap.Bitmap = null;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

        private void FillArea(int x, int y, Color color)
        {
            DrawLine(x, y, x, y, color);

            if (StaticBitmap.Bitmap.GetPixel(x, y + 1) == Color.White)
            {
                FillArea(x, y + 1, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x, y - 1) == Color.White)
            {
                FillArea(x, y - 1, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x + 1, y) == Color.White)
            {
                FillArea(x + 1, y, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x - 1, y) == Color.White)
            {
                FillArea(x - 1, y, color);
            }

        }
        private void Fill_Click(object sender, EventArgs e)
        {


        }

        private void Rubber_Click(object sender, EventArgs e)
        {

        }
    }
}
