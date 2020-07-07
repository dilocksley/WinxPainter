using Painter.Figures;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {
        AFigures _figure;

        Color _currentColor;
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        Point next;
        Point middle;
        Point last;
        Point center;
        int n = 1;                 //количество сторон
        int count = 0;
        double angle = Math.PI / 2; //Угол поворота на 90 градусов
        double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов
        Color copyColor;
       


        public Painter()
        {
            InitializeComponent();

            _currentColor = Color.Black;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            StaticBitmap.tmpBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            textBox1.Text = "0";
           // pictureBox.Image = StaticBitmap.Bitmap;
        }

        private void DrawTree(double x, double y, double a, double angle)
        {
            if (a > 2)
            {
                a *= 0.7;                                                                //Меняем параметр a - это колличество веток

                                                                                          //Считаем координаты для ветки
                double xnew = Math.Round(x + a * Math.Cos(angle)),
                       ynew = Math.Round(y - a * Math.Sin(angle));

                //соединяем вершинами
                DrawLine((int)x, (int)y, (int)xnew, (int)ynew, _currentColor);

                //Переприсваеваем координаты
                x = xnew;
                y = ynew;

                //Для левой и правой ветки
                DrawTree(x, y, a, angle + ang1);
                DrawTree(x, y, a, angle - ang2);
            }
        }

        private void DrawPointTriangle(Point FirstPoint, Point SecondPoint, Point ThirdPoint, Color color)
        {
            DrawLine(FirstPoint, SecondPoint, color);
            DrawLine(SecondPoint, ThirdPoint, color);
            DrawLine(ThirdPoint, FirstPoint, color);

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
                                               
                  StaticBitmap.SetPixel((int)startX, (int)startY, color);
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
                
            if (toolBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Вы не выбрали инструмент для рисования");
                }
            else if (toolBox.SelectedIndex == 0)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 1)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 2)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 3)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 4)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 5) 
            { 
                FirstPoint = e.Location; 
            } 
            else if (toolBox.SelectedIndex == 7)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 8)
            {
                FirstPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 9)
            {
                FirstPoint = e.Location;
            }        
            else if (toolBox.SelectedIndex == 11)
            {
                FirstPoint = e.Location;
            }
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
                    _figure = new Triangle(FirstPoint, SecondPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                    count = 0;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            StaticBitmap.CopyInNew();

            if (mouseDown)
            {
                if (toolBox.SelectedIndex == 0)
                {                    
                    SecondPoint = FirstPoint;
                    FirstPoint = e.Location;

                    StaticBitmap.DrawLine(FirstPoint, SecondPoint, _currentColor);
                    StaticBitmap.CopyInOld();
                    pictureBox.Image = StaticBitmap.Bitmap;

                }
                else if (toolBox.SelectedIndex == 1)
                {
                    _figure = new Line(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);

                }
                else if (toolBox.SelectedIndex == 2)
                {
                    _figure = new RectangleMath(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 3)
                {
                    _figure = new Square(FirstPoint, e.Location);               // вызов фигуры квадрата
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor); // рисование квадрата

                }
                else if (toolBox.SelectedIndex == 4)
                {
                    n = Convert.ToInt32(textBox1.Text);
                    if (n <= 0)
                    {
                        MessageBox.Show("Введите количество граней");
                    }
                    _figure = new NSidedPolygon((double)(360.0 / (double)n), n, FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 5)
                {
                    _figure = new Trapezoid( FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 7)
                {
                    _figure = new RightTriangle(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 8)
                {
                    _figure = new IsoscelesTriangle(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 9)
                {
                    DrawTree(FirstPoint.X, FirstPoint.Y, 250, angle);
                }
                else if (toolBox.SelectedIndex == 10)
                {
                    _figure = new Circle(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }
                else if (toolBox.SelectedIndex == 11)
                {
                    _figure = new Ellipse(FirstPoint, e.Location);
                    StaticBitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                }               
            }
            label1.Text = $"X = {e.X}";
            label2.Text = $"Y = {e.Y}";
            GC.Collect();
            pictureBox.Image = StaticBitmap.tmpBitmap;
        }

       
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;           
            
            StaticBitmap.CopyInOld();
            pictureBox.Image = StaticBitmap.Bitmap;

        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == DialogResult.OK)
            {
                _currentColor = colorDialog1.Color;
            }
        }

        private void DeletAll_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            StaticBitmap.Bitmap = null;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

        private void FillArea()
        {

            int q = 0;
            int w = 0;
            int i = 0;
            while(true)
            {
                StaticBitmap.Bitmap = (Bitmap)pictureBox.Image;
                if (StaticBitmap.Bitmap.GetPixel(FirstPoint.X,FirstPoint.Y)== _currentColor)
                {
                    last.X = FirstPoint.X;
                    last.Y = FirstPoint.Y + i-1;
                    break;
                }
                FirstPoint.Y = FirstPoint.Y + 1;
                
            }
            i = 0;
            while (true)
            {
                if (true)
                {
                    last.Y = last.Y + i;
                    while (true)
                    {
                        if (StaticBitmap.Bitmap.GetPixel(last.X - q, last.Y) != _currentColor)
                        {
                            DrawLine(last.X, last.Y, last.X - q, last.Y, Color.Red);
                        }
                        else
                        {
                            break;
                        }
                        q++;
                    }

                    while (true)
                    {
                        if (StaticBitmap.Bitmap.GetPixel(last.X + w, last.Y) != _currentColor)
                        {
                            DrawLine(last.X, last.Y, last.X + w, last.Y, Color.Red);
                        }
                        else
                        {
                            break;
                        }
                        w++;
                    }
                }
                i++;
            }
            //DrawLine(x, y, x, y, color);

            //if (StaticBitmap.Bitmap.GetPixel(x, y+1) == Color.White )
            //{
            //    FillArea(x, y + 1, color);
            //}
            //if (StaticBitmap.Bitmap.GetPixel(x, y - 1) == Color.White)
            //{
            //    FillArea(x, y - 1, color);
            //}
            //if (StaticBitmap.Bitmap.GetPixel(x+1, y) == Color.White)
            //{
            //    FillArea(x + 1, y, color);
            //}
            //if (StaticBitmap.Bitmap.GetPixel(x-1, y) == Color.White)
            //{
            //    FillArea(x - 1, y, color);
            //}

        }
        private void Fill_Click(object sender, EventArgs e)
        {
            // fill = true;
        }

        private void Rubber_Click(object sender, EventArgs e)
        {            
            if (_currentColor != Color.White)
            {
                copyColor = _currentColor;
                _currentColor = Color.White;
                return;
            }
            _currentColor = copyColor;
        }

       
    }
}
