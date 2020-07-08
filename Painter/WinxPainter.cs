using Painter.Figures;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {

        StaticBitmap bitmap;

        Square square;
        Color _currentColor;
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        int n = 1;                 //количество сторон
        int count = 0;
        double angle = Math.PI / 2; //Угол поворота на 90 градусов
        double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов
        Color copyColor;


        public Painter()
        {
            InitializeComponent();
            bitmap = StaticBitmap.GetInstance();
            _currentColor = Color.Black;
            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            bitmap.tmpBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            textBox1.Text = "0";
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
                bitmap.DrawLineXY((int)x, (int)y, (int)xnew, (int)ynew, _currentColor);

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
            else if (toolBox.SelectedIndex < 6 || toolBox.SelectedIndex > 6)
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
                //else if (count == 2)
                //{
                //    _figure = new Triangle(FirstPoint, SecondPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //    count = 0;
                //}
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            bitmap.CopyInNew();

            if (mouseDown)
            {
                if (toolBox.SelectedIndex == 0)
                {
                    SecondPoint = FirstPoint;
                    FirstPoint = e.Location;

                    bitmap.DrawLine(FirstPoint, SecondPoint, _currentColor);
                    bitmap.CopyInOld();
                    pictureBox.Image = bitmap.Bitmap;

                }
                //else if (toolBox.SelectedIndex == 1)
                //{
                //    _figure = new Line(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);

                //}
                //else if (toolBox.SelectedIndex == 2)
                //{
                //    _figure = new RectangleMath(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                else if (toolBox.SelectedIndex == 3)
                {
                    square = new Square(FirstPoint, e.Location, _currentColor); // рисование квадрата

                }
                //else if (toolBox.SelectedIndex == 4)
                //{
                //    n = Convert.ToInt32(textBox1.Text);
                //    if (n <= 1)
                //    {
                //        MessageBox.Show("Введите количество граней");
                //    }
                //    _figure = new NSidedPolygon((double)(360.0 / (double)n), n, FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                //else if (toolBox.SelectedIndex == 5)
                //{
                //    _figure = new Trapezoid( FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                //else if (toolBox.SelectedIndex == 7)
                //{
                //    _figure = new RightTriangle(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                //else if (toolBox.SelectedIndex == 8)
                //{
                //    _figure = new IsoscelesTriangle(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                //else if (toolBox.SelectedIndex == 9)
                //{
                //    DrawTree(FirstPoint.X, FirstPoint.Y, 250, angle);
                //}
                //else if (toolBox.SelectedIndex == 10)
                //{
                //    _figure = new Circle(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}
                //else if (toolBox.SelectedIndex == 11)
                //{
                //    _figure = new Ellipse(FirstPoint, e.Location);
                //    bitmap.DrawFigure(_figure.GetPoints(), _currentColor);
                //}               
            }
            label1.Text = $"X = {e.X}";
            label2.Text = $"Y = {e.Y}";
            GC.Collect();
            pictureBox.Image = bitmap.tmpBitmap;
        }

    
        

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            bitmap.CopyInOld();
            pictureBox.Image = bitmap.Bitmap;

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
            bitmap.Bitmap = null;
            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
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
