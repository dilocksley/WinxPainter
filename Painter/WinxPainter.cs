﻿using Painter.FabricFigure;
using Painter.Figures;
using Painter.MathFigures;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {
        AFigure CurrentFigure;
        StaticBitmap bitmap;
        IFigureFactory factoryFigure;
        Color _currentColor;
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        Point ThirdPoint;
        int n = 1;                  //количество сторон
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
            //switch
            if (toolBox.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали инструмент для рисования");
            }
            else /*if (toolBox.SelectedIndex == 3)*/
            {
                FirstPoint = e.Location;
                CurrentFigure = null;
                n = Convert.ToInt32(textBox1.Text);
    
            }
            //else if(toolBox.SelectedIndex == 6)
            //{
            //    FirstPoint = e.Location;
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

                    //ThirdPoint = e.Location;
                    ////_figure = new Triangle(FirstPoint, SecondPoint, ThirdPoint);
                    //factoryFigure = new TriangleFactory();
                    //count = 0;
                }
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
                else 
                {
                    if(CurrentFigure == null)
                    {
                        CurrentFigure = factoryFigure.Create(FirstPoint,n, _currentColor);
                    }

                    CurrentFigure.Update(e.Location);
                    bitmap.DrawFigure(CurrentFigure); 
                }
               
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


        private void toolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolBox.SelectedIndex)
            {
                case 1:
                    factoryFigure = new LineFactory();
                    break;
                case 2:
                    factoryFigure = new RectangleFactory();
                    break;
                case 3:
                    factoryFigure = new SquareFactory();
                    break;
                case 4:
                    factoryFigure = new NSidedPolygonFactory();
                    break;
                case 5:
                    factoryFigure = new TrapezoidFactory();
                    break;
                //case 6:
                //    factoryFigure = new TriangleFactory();
                //    break;
                case 7:
                    factoryFigure = new RightTriangleFactory();
                    break;
                case 8:
                    factoryFigure = new IsoscelesTriangleFactory();
                    break;
                case 10:
                    factoryFigure = new CircleFactory();
                    break;
                case 11:
                    factoryFigure = new EllipseFactory();
                    break;
            }
                
        }
    }
}
