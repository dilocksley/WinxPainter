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
                StaticBitmap.DrawLineXY((int)x, (int)y, (int)xnew, (int)ynew, _currentColor);

                //Переприсваеваем координаты
                x = xnew;
                y = ynew;

                //Для левой и правой ветки
                DrawTree(x, y, a, angle + ang1);
                DrawTree(x, y, a, angle - ang2);
            }
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
            else if (toolBox.SelectedIndex == 10)
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

        //private void FillArea()
        //{

        //    int q = 0;
        //    int w = 0;
        //    int i = 0;
        //    while(true)
        //    {
        //        StaticBitmap.Bitmap = (Bitmap)pictureBox.Image;
        //        if (StaticBitmap.Bitmap.GetPixel(FirstPoint.X,FirstPoint.Y)== _currentColor)
        //        {
        //            last.X = FirstPoint.X;
        //            last.Y = FirstPoint.Y + i-1;
        //            break;
        //        }
        //        FirstPoint.Y = FirstPoint.Y + 1;
                
        //    }
        //    i = 0;
        //    while (true)
        //    {
        //        if (true)
        //        {
        //            last.Y = last.Y + i;
        //            while (true)
        //            {
        //                if (StaticBitmap.Bitmap.GetPixel(last.X - q, last.Y) != _currentColor)
        //                {
        //                    DrawLine(last.X, last.Y, last.X - q, last.Y, Color.Red);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //                q++;
        //            }

        //            while (true)
        //            {
        //                if (StaticBitmap.Bitmap.GetPixel(last.X + w, last.Y) != _currentColor)
        //                {
        //                    DrawLine(last.X, last.Y, last.X + w, last.Y, Color.Red);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //                w++;
        //            }
        //        }
        //        i++;
        //    }
        //    //DrawLine(x, y, x, y, color);

        //    //if (StaticBitmap.Bitmap.GetPixel(x, y+1) == Color.White )
        //    //{
        //    //    FillArea(x, y + 1, color);
        //    //}
        //    //if (StaticBitmap.Bitmap.GetPixel(x, y - 1) == Color.White)
        //    //{
        //    //    FillArea(x, y - 1, color);
        //    //}
        //    //if (StaticBitmap.Bitmap.GetPixel(x+1, y) == Color.White)
        //    //{
        //    //    FillArea(x + 1, y, color);
        //    //}
        //    //if (StaticBitmap.Bitmap.GetPixel(x-1, y) == Color.White)
        //    //{
        //    //    FillArea(x - 1, y, color);
        //    //}

        //}
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
