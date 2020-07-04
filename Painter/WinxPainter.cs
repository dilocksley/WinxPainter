using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class Painter : Form
    {
        
        Color CurrentColor;
        Point CurrentPoint;
        Point PreviuosPoint;
        bool mouseDown;
        Point FirstPoint;
        Point SecondPoint;
        Point next;
        Point middle;
        Point last;
        int n = 1;//количество сторон
        int R;//расстояние от центра до стороны       
        Point[] p;
        int count = 0;


        public Painter()
        {
            InitializeComponent();
          
            CurrentColor = Color.Black;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            textBox1.Text = "0";
        }

        private void Trapezoid(Point first, Point second, Color color)
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
        private void PointTriangle(Point FirstPoint, Point SecondPoint, Point ThirdPoint, Color color)
        {
            DrawLine(FirstPoint, SecondPoint, color);
            DrawLine(SecondPoint, ThirdPoint, color);
            DrawLine(ThirdPoint, FirstPoint, color);
        }

        private void PointRightTriangle(Point first, Point second, Color color)
        {
            next.X = first.X;
            next.Y = second.Y;
            DrawLine(first, next, color);
            DrawLine(next, second, color);
            DrawLine(second, first, color);
        }

        private void IsoscelesTriangle(Point first, Point second, Color color)
        {
            next.X = first.X - (second.X - first.X);
            next.Y = second.Y;
            DrawLine(first, second, color);
            DrawLine(second, next, color);
            DrawLine(next, first, color);
        }


        private void NSidedPolygon(int n)
        {

            p = new Point[n + 1];
            lineAngle((double)(360.0 / (double)n));
            int i = n;
            
            while (i > 0)
            {
                DrawLine( p[i], p[i - 1],CurrentColor);
                i = i - 1;
            }
        }

        private void lineAngle(double angle)
        {
            
            if (FirstPoint.X < SecondPoint.X && FirstPoint.Y < SecondPoint.Y) // 4 четверть
            {
                R = SecondPoint.Y - FirstPoint.Y;
            }
            if (FirstPoint.X > SecondPoint.X && FirstPoint.Y > SecondPoint.Y) // II chetvert
            {
                R =  FirstPoint.Y - SecondPoint.Y;
            }
            if (FirstPoint.X > SecondPoint.X && FirstPoint.Y < SecondPoint.Y) // III chetvert
            {
                R = FirstPoint.Y - SecondPoint.Y;
            }
            if (FirstPoint.X < SecondPoint.X && FirstPoint.Y > SecondPoint.Y) // I chetvert
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
        private void Square(Point first, Point second, Color color)
        {
            int length = 0;
            if (first.X< second.X && first.Y<second.Y) // 4 четверть
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
            if (first.X > second.X && first.Y > second.Y) // II chetvert
            {
                length = first.X - second.X;


                next.X = first.X - length;
                next.Y = first.Y;
                DrawLine(first, next, color);

                middle.X = next.X;
                middle.Y = next.Y - length;
                DrawLine(next, middle, color);

                last.X = middle.X+ length;
                last.Y = middle.Y;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
            if (first.X > second.X && first.Y < second.Y) // III chetvert
            {
                length = first.X - second.X;

                next.X = first.X ;
                next.Y = first.Y+ length;
                DrawLine(first, next, color);

                middle.X = next.X- length;
                middle.Y = next.Y;
                DrawLine(next, middle, color);

                last.X = middle.X ;
                last.Y = middle.Y - length;
                DrawLine(middle, last, color);

                DrawLine(last, first, color);
            }
            if (first.X < second.X && first.Y > second.Y) // I chetvert
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
        private void Rectangle(Point first, Point second, Color color)
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
        private void Draw(Point PreviousPoint, Point CurrentPoint, Color color )
        {
            Point Delta = new Point(0, 0);

            Delta.X = CurrentPoint.X - PreviousPoint.X;
            Delta.Y = CurrentPoint.Y - PreviousPoint.Y;

            int step;
            if(Math.Abs(Delta.X) > Math.Abs(Delta.Y))
            {
                step = Math.Abs(Delta.X);
            }
            else
            {
                step = Math.Abs(Delta.Y);
            }

            double incrementX = Delta.X / (double)step;
            double incrementY = Delta.Y / (double)step;

            double startX = PreviousPoint.X;
            double startY = PreviousPoint.Y;

            for (int i = 0; i <= step; i++)
            {
                StaticBitmap.SetPixel((int)startX, (int)startY, CurrentColor);
                startX += incrementX;
                startY += incrementY;
            }
            pictureBox.Image = StaticBitmap.Bitmap;           
        }

        private void DrawLine(Point PreviousPoint, Point CurrentPoint, Color color)
        {
            Draw(PreviousPoint, CurrentPoint, color);
        }
        private void DrawLine(int x1, int y1, int x2, int y2, Color color)
        {
            PreviuosPoint.X = x1;
            PreviuosPoint.Y = y1;
            CurrentPoint.X = x2;
            CurrentPoint.Y = y2;

            Draw(PreviuosPoint, CurrentPoint, color);
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

                    PointTriangle(FirstPoint, SecondPoint, e.Location, CurrentColor);
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
                    Draw(PreviuosPoint, CurrentPoint, CurrentColor);
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
                    Rectangle(FirstPoint, SecondPoint, CurrentColor);
                }
                else if (toolBox.SelectedIndex == 3)
                {                   
                    Square(FirstPoint, SecondPoint, CurrentColor);
                }
                else if (toolBox.SelectedIndex == 4)
                {
                    n = Convert.ToInt32(textBox1.Text);
                    if (n <= 0)
                    {
                       MessageBox.Show("Введите количество граней");
                    }
               
                    NSidedPolygon(n);
                }
                else if (toolBox.SelectedIndex == 5)
                {                   
                   Trapezoid(FirstPoint, SecondPoint, CurrentColor);
                }
                else if (toolBox.SelectedIndex == 7)
                {                    
                    PointRightTriangle(FirstPoint, SecondPoint, CurrentColor);
                }
                else if (toolBox.SelectedIndex == 8)
                {                    
                     IsoscelesTriangle(FirstPoint, SecondPoint, CurrentColor);
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
            
            if (StaticBitmap.Bitmap.GetPixel(x, y+1) == Color.White )
            {
                FillArea(x, y + 1, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x, y - 1) == Color.White)
            {
                FillArea(x, y - 1, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x+1, y) == Color.White)
            {
                FillArea(x + 1, y, color);
            }
            if (StaticBitmap.Bitmap.GetPixel(x-1, y) == Color.White)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
