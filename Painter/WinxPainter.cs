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
        Color СurrentColor = Color.Black;
        Point CurrentPoint;
        bool mouseDown;

        public Painter()
        {
            InitializeComponent();
            StaticBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
        }
        private void PaintPixel(Point point)
        {
            StaticBitmap.Bitmap.SetPixel(point.X, point.Y, СurrentColor);
            pictureBox.Image = StaticBitmap.Bitmap;
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

            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {


            if (mouseDown)
            {
                if (toolBox.SelectedIndex == 0)
                {
                    PaintPixel(e.Location);
                }
                else if (toolBox.SelectedIndex == 1)
                {

                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (toolBox.SelectedIndex == 0)
            {
                
            }
            else if (toolBox.SelectedIndex == 1) { }

        }
    }
}
