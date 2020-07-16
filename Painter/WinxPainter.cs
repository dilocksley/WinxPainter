using Painter.FactoryOfFigures;
using Painter.Figures;
using Painter.MathFigures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {
        AFigure CurrentFigure;
        AFigure ActiveFigure;
        StaticBitmap bitmap;
        IFigureFactory factoryFigure;
        Color _fillColor;
        Color _currentColor;
        int _currentThickness;      // текущая толщина
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        int n = 1;                  //количество сторон
        int count = 0;
        double angle = Math.PI / 2; //Угол поворота на 90 градусов
        double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов
        Color copyColor;
        List<Point> list = new List<Point>();
        bool _editFigure;
        bool _changeLocation;
        bool _deletingFigure;
        bool fill;
        public Painter()
        {

            InitializeComponent();
            bitmap = StaticBitmap.GetInstance();
            _currentColor = Color.Black;
            _currentThickness = 1;
            _fillColor = Color.White;
            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            bitmap.tmpBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Change_location.Hide();
            DeleteFigure.Hide();
            textBox1.Hide();
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

            if (toolBox.SelectedIndex != 6)
            {
                CurrentFigure = null;

                if (toolBox.SelectedIndex == 4)
                {
                    try
                    {
                        n = Convert.ToInt32(textBox1.Text);
                        if (n < 5)
                        {
                            mouseDown = false;
                            MessageBox.Show("Минимальное количество граней = 5.");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите число 5 или больше.");
                        mouseDown = false;
                    }
                }
                FirstPoint = e.Location;
            }
        }
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            //if (fill)
            //{

            //    bitmap.Fill(e.Location, _fillColor);
            //    bitmap.CopyInOld();
            //    pictureBox.Image = bitmap.Bitmap;
            //}
            if (_editFigure)
            {
                //ActiveFigure = bitmap.SelectFigureByPoint(e.Location);
                //bitmap.DrawSelectedFigure(ActiveFigure);
                //Change_location.Show();
                //DeleteFigure.Show();
            }
            if (toolBox.SelectedIndex == 6)
            {
                if (count == 0)
                {
                    list.Add(e.Location);
                    count++;
                }
                else if (count == 1)
                {
                    list.Add(e.Location);
                    count++;
                }
                else if (count == 2)
                {
                    list.Add(e.Location);
                    factoryFigure = new TriangleFactory(list);

                    count = 0;
                    list = new List<Point>();

                    CurrentFigure = factoryFigure.Create(FirstPoint, n, _currentColor, _fillColor, _currentThickness);
                    bitmap.DrawFigure(CurrentFigure);
                    pictureBox.Image = bitmap.tmpBitmap;
                }
            }
        }


        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            bitmap.CopyInNew();
            if (mouseDown)
            {
                if (_changeLocation)
                {
                    Point delta = new Point();

                    delta.X = e.X - FirstPoint.X;
                    delta.Y = e.Y - FirstPoint.Y;
                    FirstPoint = e.Location;

                    if (CurrentFigure == null)
                    {
                        CurrentFigure = bitmap.SelectFigureByPoint(e.Location);
                        if (CurrentFigure != null)
                        {
                            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                            bitmap.DeleteFigure(CurrentFigure);
                        }
                    }
                    if (CurrentFigure != null)
                    {
                        bitmap.ShowOnTheScreen();
                        CurrentFigure.Move(delta);
                        bitmap.DrawFigure(CurrentFigure);
                        bitmap.DrawSelectedFigure(CurrentFigure);
                    }
                }
                if (_deletingFigure)
                {
                    if (CurrentFigure == null)
                    {
                        CurrentFigure = bitmap.SelectFigureByPoint(e.Location);
                        if (CurrentFigure != null)
                        {
                            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                            bitmap.DeleteFigure(CurrentFigure);
                        }
                    }
                }
                else if (toolBox.SelectedIndex == 0)
                {
                    SecondPoint = FirstPoint;
                    FirstPoint = e.Location;

                    bitmap.DrawLine(FirstPoint, SecondPoint, _currentThickness, _currentColor);
                    bitmap.CopyInOld();
                    pictureBox.Image = bitmap.Bitmap;

                }
                else if (toolBox.SelectedIndex != 6 && toolBox.SelectedIndex != -1)
                {
                    if (CurrentFigure == null && factoryFigure != null)
                    {

                        CurrentFigure = factoryFigure.Create(FirstPoint, n, _currentColor, _fillColor, _currentThickness);
                    }

                    if (CurrentFigure != null)
                    {

                        CurrentFigure.Update(e.Location);
                        bitmap.DrawFigure(CurrentFigure);

                    }
                }
            }

            if (toolBox.SelectedIndex != -1)
            {
                _changeLocation = false;
                _deletingFigure = false;
                _editFigure = false;
            }
            label1.Text = $"X = {e.X}";
            label2.Text = $"Y = {e.Y}";
            GC.Collect();
            pictureBox.Image = bitmap.tmpBitmap;
        }




        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            fill = false;
            //if (_fillColor != Color.White)
            //{
            //    CurrentFigure.FindPoint();

            //    CurrentFigure.FillFigure();

            //}

            if (CurrentFigure != null)
            {

                if (_fillColor != Color.White)
                {
                    CurrentFigure.FindPoint();

                    CurrentFigure.FillFigure();

                }
                bitmap.AddFigure(CurrentFigure);
                //if (ActiveFigure != null)
                //{
                //    bitmap.AddFigure(ActiveFigure);
                //}
            }
            //if (_editFigure)
            //{
            //    //DeleteFigure.Show();
            //    bitmap.DrawSelectedFigure(ActiveFigure);
            //}
            //DeleteFigure.Hide();
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
        private void DeleteFigure_Click(object sender, EventArgs e)
        {
            _deletingFigure = true;
            CurrentFigure = null;
            toolBox.SelectedIndex = -1;
            //bitmap.DeleteFigure(ActiveFigure);
            //if (_editFigure)
            //{
            //    bitmap.Undo();
            //    bitmap.CopyInOld();
            //    pictureBox.Image = bitmap.Bitmap;
            //}
        }

        private void toolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change_location.Hide();
            DeleteFigure.Hide();
            switch (toolBox.SelectedIndex)
            {
                case 1:
                    textBox1.Hide();
                    factoryFigure = new LineFactory();
                    break;
                case 2:
                    textBox1.Hide();
                    factoryFigure = new RectangleFactory();
                    break;
                case 3:
                    textBox1.Hide();
                    factoryFigure = new SquareFactory();
                    break;
                case 4:
                    textBox1.Show();
                    if (textBox1.Text == "Количество граней")
                    {
                        MessageBox.Show("Введите количество граней 5 или больше.");
                    }
                    textBox1.Text = "";
                    factoryFigure = new NSidedPolygonFactory();
                    break;
                case 5:
                    textBox1.Hide();
                    factoryFigure = new TrapezoidFactory();
                    break;
                case 6:
                    textBox1.Hide();
                    factoryFigure = null;
                    break;
                case 7:
                    textBox1.Hide();
                    factoryFigure = new RightTriangleFactory();
                    break;
                case 8:
                    textBox1.Hide();
                    factoryFigure = new IsoscelesTriangleFactory();
                    break;
                case 10:
                    textBox1.Hide();
                    factoryFigure = new CircleFactory();
                    break;
                case 11:
                    textBox1.Hide();
                    factoryFigure = new EllipseFactory();
                    break;
            }
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            bitmap.ShowOnTheScreen();
            bitmap.CopyInOld();
            pictureBox.Image = bitmap.Bitmap;
        }

        private void undo_Click(object sender, EventArgs e)
        {
            bitmap.Undo();
            bitmap.CopyInOld();
            pictureBox.Image = bitmap.Bitmap;
        }

        private void redo_Click(object sender, EventArgs e)
        {
            bitmap.Redo();
            bitmap.CopyInOld();
            pictureBox.Image = bitmap.Bitmap;
        }

        private void Change_location_Click(object sender, EventArgs e)
        {
            _changeLocation = true;
            //_editFigure = true;
            CurrentFigure = null;
            toolBox.SelectedIndex = -1;
        }


        private void Fill_Click(object sender, EventArgs e)
        {
            fill = true;

            DialogResult D = colorDialog1.ShowDialog();
            if (D == DialogResult.OK)
            {
                _fillColor = colorDialog1.Color;
            }
        }

        private void thicknessValue_ValueChanged(object sender, EventArgs e)
        {
            _currentThickness = (int)thicknessValue.Value;
        }

        private void Edit_Figure_Click(object sender, EventArgs e)
        {
            _editFigure = true;
            //if (CurrentFigure != null)
            //{
            //    ActiveFigure = CurrentFigure;

            //    bitmap.DrawSelectedFigure(ActiveFigure);

            //}
            //CurrentFigure = null;
            toolBox.SelectedIndex = -1;
            Change_location.Show();
            DeleteFigure.Show();
        }
    }
}
