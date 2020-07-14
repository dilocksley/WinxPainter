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
        Color _currentColor;
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
        bool changeFigure = false;

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
                return;
            }
            else if (!changeFigure) //если выбрана фигура
            {
                CurrentFigure = null;
                n = Convert.ToInt32(textBox1.Text);
                
            }
            FirstPoint = e.Location;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //if (changeFigure && CurrentFigure == null)
            //{
            //    //FirstPoint = e.Location;
                
            //}
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

                    CurrentFigure = factoryFigure.Create(FirstPoint, n, _currentColor);
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
                if (changeFigure)
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
                            
                            bitmap.ShowWithOutFigure(CurrentFigure);
                            
                            // bitmap.ShowOnTheScreen();
                            // pictureBox.Image = bitmap.tmpBitmap;
                        }
                    }
                    if (CurrentFigure != null)
                    {
                        //bitmap.ShowWithOutFigure(CurrentFigure); 
                        bitmap.ShowOnTheScreen();
                        CurrentFigure.Move(delta);
                        bitmap.DrawFigure(CurrentFigure);

                    }
                }
                else if (toolBox.SelectedIndex == 0)
                {
                    SecondPoint = FirstPoint;
                    FirstPoint = e.Location;

                    bitmap.DrawLine(FirstPoint, SecondPoint, _currentColor);
                    bitmap.CopyInOld();
                    pictureBox.Image = bitmap.Bitmap;

                }               
                else if (toolBox.SelectedIndex != 6)
                {
                    if(CurrentFigure == null && factoryFigure!= null)
                    {
                        CurrentFigure = factoryFigure.Create(FirstPoint,n, _currentColor);
                    }

                    if (CurrentFigure != null)
                    {
                        CurrentFigure.Update(e.Location);
                        bitmap.DrawFigure(CurrentFigure);
                    }
                }
                //if (changeFigure)
                //{
                //    Point delta = new Point();

                //    delta.X = e.X - FirstPoint.X;
                //    delta.Y = e.Y - FirstPoint.Y;

                //    CurrentFigure.Move(delta);
                //    bitmap.ShowOnTheScreen();
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
            if (CurrentFigure != null)
            {
                bitmap.AddFigure(CurrentFigure);
            }
            bitmap.CopyInOld();
            pictureBox.Image = bitmap.Bitmap;

            if (changeFigure)
            {
                CurrentFigure = null;
                changeFigure = false;
                toolBox.SelectedIndex = 3;

                //FirstPoint = e.Location;
               

            }
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
                case 6:
                    factoryFigure = null;
                    break;
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

        private void Change_figure_Click(object sender, EventArgs e)
        {
            changeFigure = true;
            CurrentFigure = null;
            toolBox.SelectedIndex = -1;
        }
    }
}
