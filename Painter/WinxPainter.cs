using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

         

        public Painter()
        {
            InitializeComponent();

            CurrentColor = Color.Red;
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
           
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
                StaticBitmap.Bitmap.SetPixel((int)startX, (int)startY, CurrentColor);
                startX += incrementX;
                startY += incrementY;
            }
            pictureBox.Image = StaticBitmap.Bitmap;

            //for (int i = PreviousPoint.Y; i < CurrentPoint.Y; i++)
            //{
            //  int x = ((-PreviousPoint.X * i) + (CurrentPoint.X * i) - ((PreviousPoint.X * CurrentPoint.Y) - (PreviousPoint.Y * CurrentPoint.X))) / (PreviousPoint.Y - CurrentPoint.Y);
            //    if (x >= 0 && x < StaticBitmap.Bitmap.Width && i >= 0 && i < StaticBitmap.Bitmap.Height)
            //    {
            //        StaticBitmap.Bitmap.SetPixel(x, i, CurrentColor);
            //    }

            //}
        }

        private void DrawLine(Point PreviousPoint, Point CurrentPoint, Color color)
        {
            Draw(PreviousPoint, CurrentPoint, color);
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
                CurrentPoint = e.Location;
            }
            else if (toolBox.SelectedIndex == 1)
            {                
                FirstPoint = e.Location;
            }            
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (toolBox.SelectedIndex == 0)
                {
                    PreviuosPoint = CurrentPoint;
                    CurrentPoint = e.Location;
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
            if (toolBox.SelectedIndex == 0)
            {
                
            }
            else if (toolBox.SelectedIndex == 1) 
            {               
                SecondPoint = e.Location;               
                DrawLine(FirstPoint, SecondPoint, CurrentColor);
            }

        }

        private void Painter_Load(object sender, EventArgs e)
        {
            
            
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

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
