using Painter.FactoryOfFigures;
using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        bool q;
        AFigure Current;
        //string file;
        bool _reversal;
        int angle = 0;

        double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов

        List<Point> list = new List<Point>();
        bool _editFigure;
        bool _changeLocation;
        bool _deletingFigure;
        bool fill;
        string mode;
        public Painter()
        {

            InitializeComponent();
            bitmap = StaticBitmap.GetInstance();
            _currentColor = Color.Black;
            _currentThickness = 1;
            _fillColor = Color.Transparent;
            bitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            bitmap.tmpBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Change_location.Hide();
            DeleteFigure.Hide();
            Reversal.Hide();
            textBox1.Hide();
            mode = "Рисуем";
            //saveFile.Click += saveFile_Click;
            //openFile.Click += openFile_Click;
            openFileDialog1.Filter = "Winx files(*.winx)|*.winx|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Winx files(*.winx)|*.winx|All files(*.*)|*.*";
            //ActiveFigure = null;
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
            if (mode == "Навел"  )
            {
                if (ActiveFigure == null)
                {
                    ActiveFigure = CurrentFigure;
                    CurrentFigure = null;
                    // bitmap.HighlightSelectedFigure(ActiveFigure); 
                    mode = "Выбрал";
                }
                else
                {
                    bitmap.HighlightSelectedFigureW(ActiveFigure);
                    bitmap.DrawFigure(ActiveFigure);
                    ActiveFigure = null;
                    mode = "Рисуем";
                }
            }

            if (mode == "Выбрал")
            {
                if (q)
                {
                    Current = ActiveFigure;
                    mode = "Изменить";
                }
              
            }


            if (toolBox.SelectedIndex != 6)
            {

                CurrentFigure = null;

                if (toolBox.SelectedIndex == 4)
                {
                    try
                    {
                        n = Convert.ToInt32(textBox1.Text);
                        if (n < 3)
                        {
                            mouseDown = false;
                            MessageBox.Show("Минимальное количество граней = 3.");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите число 3 или больше.");
                        mouseDown = false;
                    }
                }

                FirstPoint = e.Location;
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
                mode = "Рисуем";
            }
            // bitmap.ShowOnTheScreen();
        }
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {



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

                }
            }
        }


        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            bitmap.CopyInNew();

            if (mouseDown)
            {
                if (_reversal && ActiveFigure != null)
                {
                    int rev = e.Y - FirstPoint.Y;
                    ActiveFigure.SetAngle(rev);
                    bitmap.DeleteFigure(ActiveFigure);
                    bitmap.DrawFigure(ActiveFigure);


                }
                if (_changeLocation)
                {
                    fill = false;
                    _deletingFigure = false;

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
                else if (toolBox.SelectedIndex != 6 && toolBox.SelectedIndex != -1 && mode == "Рисуем")
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
            if (mode == "Изменить" && mouseDown)  //mode == "Изменить"
            {

                ActiveFigure.Update(e.Location);
                bitmap.DrawFigure(ActiveFigure);

            }

            if (bitmap.SelectFigureByPointq(e.Location) && mode != "Выбрал" && mode != "Изменить")
            {
                CurrentFigure = bitmap.GetAFigure();
                bitmap.HighlightSelectedFigure(CurrentFigure);
                mode = "Навел";
            }
            else if (mode != "Выбрал" && mode != "Изменить")
            {
                mode = "Рисуем";
            }

            if (mode == "Выбрал")
            {

                q = bitmap.PointInPoint(ActiveFigure, e.Location);

            }

            if (toolBox.SelectedIndex != -1 && mode != "Изменить")
            {
                _changeLocation = false;
                _deletingFigure = false;
                _editFigure = false;
                _reversal = false;

            }
            xLabel.Text = $"X = {e.X}";
            Ylabel.Text = $"Y = {e.Y}";
            modeLabel.Text = mode;
            GC.Collect();

            pictureBox.Image = bitmap.tmpBitmap;


        }




        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            fill = false;
            if (mode == "Изменить")
            {
                mode = "Рисуем";
                bitmap.AddFigure(ActiveFigure);
                bitmap.DeleteFigure(Current);
                ActiveFigure = null;
                q = false;
            }

            if (CurrentFigure != null)
            {
                if (_fillColor != Color.Transparent)
                {
                    CurrentFigure.FindPoint();
                    CurrentFigure.FillFigure();
                }
                bitmap.AddFigure(CurrentFigure);
            }

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
            bitmap.ClearStorage();
        }
        private void DeleteFigure_Click(object sender, EventArgs e)
        {
            _deletingFigure = true;
            //CurrentFigure = null;
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
            Reversal.Hide();

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
                        MessageBox.Show("Введите количество граней 3 или больше.");
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
            CurrentFigure = null;
            toolBox.SelectedIndex = -1;
        }


        private void Fill_Click(object sender, EventArgs e)
        {
            if (_editFigure)
            {
                fill = true;
            }
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
            if (CurrentFigure != null)
            {
                bitmap.HighlightSelectedFigure(CurrentFigure);
            }
            //CurrentFigure = null;
            mode = "Рисуем";
            toolBox.SelectedIndex = -1;
            Change_location.Show();
            DeleteFigure.Show();
            Reversal.Show();

        }

        private void Reversal_Click(object sender, EventArgs e)
        {

            if (ActiveFigure == null)
            {
                MessageBox.Show("Вы не выбрали фигуру!");
                return;
            }
            _reversal = true;



        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Winx files(*.winx)|*.winx";

            switch (dialog.ShowDialog())
            {
                case DialogResult.OK: 
                    string file = JsonSerializer.Serialize(bitmap.GetListSt());
                    File.WriteAllText(dialog.FileName, file);
                    Console.WriteLine("Проект сохранён.");
                    break;
                default:
                    return;

            }
           

            //if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            //    return;

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = dialog.FileName;
            //    //Get the extension
            //    string strFilExtn =
            //        fileName.Remove(0, fileName.Length - 4);
            //    //Save file
            //    file = JsonSerializer.Serialize(bitmap.GetListSt());
            //    File.WriteAllText("Painter.winx", file);
            //    Console.WriteLine("Проект сохранён.");
            //    using (FileStream fs = new FileStream("Painter.winx", FileMode.OpenOrCreate))
            //    {
            //    }
            //    switch (strFilExtn)
            //    {
            //        case "winx":
            //            winx.Save(fileName, System.Drawing.Imaging.ImageFormat.Winx);
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Winx files(*.winx)|*.winx";

            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    string file = File.ReadAllText(dialog.FileName);
                    bitmap.SetListSt(JsonSerializer.Deserialize<List<AFigure>>(file));
                    break;
                default:
                    return;

            }

            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Winx files (*.WINX)|*.winx";
            //if (dialog.ShowDialog() == DialogResult.Cancel)
            //    return;
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    Image image = Image.FromFile(dialog.FileName);

            //}
            //using (FileStream fs = new FileStream("Painter.winx", FileMode.OpenOrCreate))
            //{
            //    string file = File.ReadAllText("Painter.winx");
            //    bitmap.SetListSt( JsonSerializer.Deserialize<List<AFigure>>(file));
            //}
        }
    }
}
