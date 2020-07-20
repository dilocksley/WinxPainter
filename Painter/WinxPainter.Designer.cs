namespace Painter
{
    partial class Painter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Painter));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolBox = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorBox = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.Ylabel = new System.Windows.Forms.Label();
            this.DeletAll = new System.Windows.Forms.Button();
            this.DeleteFigure = new System.Windows.Forms.Button();
            this.thicknessValue = new System.Windows.Forms.NumericUpDown();
            this.Fill = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.undo = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.Change_location = new System.Windows.Forms.Button();
            this.Edit_Figure = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.modeLabel = new System.Windows.Forms.Label();
            this.saveFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.Reversal = new System.Windows.Forms.Button();
            this.showAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1016, 596);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolBox
            // 
            this.toolBox.BackColor = System.Drawing.Color.White;
            this.toolBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolBox.FormattingEnabled = true;
            this.toolBox.Items.AddRange(new object[] {
            "Карандаш",
            "Прямая линия",
            "Прямоугольник",
            "Квадрат",
            "N-угольник",
            "Трапеция",
            "Треугольник (3 точки)",
            "Прямоугольный треугольник",
            "Равнобедренный треугольник ",
            "Дерево",
            "Круг",
            "Эллипс"});
            this.toolBox.Location = new System.Drawing.Point(62, 14);
            this.toolBox.Margin = new System.Windows.Forms.Padding(4);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(164, 21);
            this.toolBox.TabIndex = 1;
            this.toolBox.Text = "Инструмент";
            this.toolBox.SelectedIndexChanged += new System.EventHandler(this.toolBox_SelectedIndexChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ColorBox.BackgroundImage")));
            this.ColorBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ColorBox.Location = new System.Drawing.Point(235, 42);
            this.ColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(43, 30);
            this.ColorBox.TabIndex = 2;
            this.ColorBox.UseVisualStyleBackColor = true;
            this.ColorBox.Click += new System.EventHandler(this.ColorBox_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(12, 45);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 3;
            this.xLabel.Text = "X";
            // 
            // Ylabel
            // 
            this.Ylabel.AutoSize = true;
            this.Ylabel.Location = new System.Drawing.Point(12, 73);
            this.Ylabel.Name = "Ylabel";
            this.Ylabel.Size = new System.Drawing.Size(14, 13);
            this.Ylabel.TabIndex = 4;
            this.Ylabel.Text = "Y";
            // 
            // DeletAll
            // 
            this.DeletAll.Location = new System.Drawing.Point(446, 13);
            this.DeletAll.Margin = new System.Windows.Forms.Padding(4);
            this.DeletAll.Name = "DeletAll";
            this.DeletAll.Size = new System.Drawing.Size(90, 22);
            this.DeletAll.TabIndex = 5;
            this.DeletAll.Text = "Удалить всё!";
            this.DeletAll.UseVisualStyleBackColor = true;
            this.DeletAll.Click += new System.EventHandler(this.DeletAll_Click);
            // 
            // DeleteFigure
            // 
            this.DeleteFigure.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteFigure.BackgroundImage")));
            this.DeleteFigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteFigure.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DeleteFigure.Location = new System.Drawing.Point(327, 42);
            this.DeleteFigure.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteFigure.Name = "DeleteFigure";
            this.DeleteFigure.Size = new System.Drawing.Size(42, 29);
            this.DeleteFigure.TabIndex = 6;
            this.DeleteFigure.UseVisualStyleBackColor = true;
            this.DeleteFigure.Click += new System.EventHandler(this.DeleteFigure_Click);
            // 
            // thicknessValue
            // 
            this.thicknessValue.BackColor = System.Drawing.SystemColors.Window;
            this.thicknessValue.Location = new System.Drawing.Point(13, 15);
            this.thicknessValue.Margin = new System.Windows.Forms.Padding(4);
            this.thicknessValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.thicknessValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessValue.Name = "thicknessValue";
            this.thicknessValue.Size = new System.Drawing.Size(41, 20);
            this.thicknessValue.TabIndex = 8;
            this.thicknessValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessValue.ValueChanged += new System.EventHandler(this.thicknessValue_ValueChanged);
            // 
            // Fill
            // 
            this.Fill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Fill.BackgroundImage")));
            this.Fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Fill.Location = new System.Drawing.Point(286, 42);
            this.Fill.Margin = new System.Windows.Forms.Padding(4);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(33, 31);
            this.Fill.TabIndex = 9;
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 43);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Количество граней";
            // 
            // undo
            // 
            this.undo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("undo.BackgroundImage")));
            this.undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undo.Location = new System.Drawing.Point(446, 42);
            this.undo.Margin = new System.Windows.Forms.Padding(4);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(29, 30);
            this.undo.TabIndex = 12;
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("redo.BackgroundImage")));
            this.redo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.redo.Location = new System.Drawing.Point(508, 42);
            this.redo.Margin = new System.Windows.Forms.Padding(4);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(29, 31);
            this.redo.TabIndex = 13;
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // Change_location
            // 
            this.Change_location.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Change_location.BackgroundImage")));
            this.Change_location.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Change_location.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Change_location.Location = new System.Drawing.Point(375, 42);
            this.Change_location.Margin = new System.Windows.Forms.Padding(2);
            this.Change_location.Name = "Change_location";
            this.Change_location.Size = new System.Drawing.Size(30, 29);
            this.Change_location.TabIndex = 14;
            this.Change_location.UseVisualStyleBackColor = true;
            this.Change_location.Click += new System.EventHandler(this.Change_location_Click);
            // 
            // Edit_Figure
            // 
            this.Edit_Figure.Location = new System.Drawing.Point(235, 13);
            this.Edit_Figure.Name = "Edit_Figure";
            this.Edit_Figure.Size = new System.Drawing.Size(206, 22);
            this.Edit_Figure.TabIndex = 15;
            this.Edit_Figure.Text = "Режим редактирования";
            this.Edit_Figure.UseVisualStyleBackColor = true;
            this.Edit_Figure.Click += new System.EventHandler(this.Edit_Figure_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "winx";
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(12, 97);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(0, 13);
            this.modeLabel.TabIndex = 16;
            // 
            // saveFile
            // 
            this.saveFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveFile.BackgroundImage")));
            this.saveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.saveFile.Location = new System.Drawing.Point(597, 41);
            this.saveFile.Margin = new System.Windows.Forms.Padding(2);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(33, 31);
            this.saveFile.TabIndex = 17;
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // openFile
            // 
            this.openFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("openFile.BackgroundImage")));
            this.openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.openFile.Location = new System.Drawing.Point(543, 41);
            this.openFile.Margin = new System.Windows.Forms.Padding(2);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(33, 31);
            this.openFile.TabIndex = 18;
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // Reversal
            // 
            this.Reversal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Reversal.BackgroundImage")));
            this.Reversal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Reversal.Location = new System.Drawing.Point(409, 42);
            this.Reversal.Margin = new System.Windows.Forms.Padding(2);
            this.Reversal.Name = "Reversal";
            this.Reversal.Size = new System.Drawing.Size(30, 29);
            this.Reversal.TabIndex = 16;
            this.Reversal.UseVisualStyleBackColor = true;
            this.Reversal.Click += new System.EventHandler(this.Reversal_Click);
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(543, 13);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(87, 23);
            this.showAll.TabIndex = 19;
            this.showAll.Text = "Показать всё";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 596);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.saveFile);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.Reversal);
            this.Controls.Add(this.Edit_Figure);
            this.Controls.Add(this.Change_location);
            this.Controls.Add(this.redo);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.thicknessValue);
            this.Controls.Add(this.DeleteFigure);
            this.Controls.Add(this.DeletAll);
            this.Controls.Add(this.Ylabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Painter";
            this.Text = "Painter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox toolBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label Ylabel;
        private System.Windows.Forms.Button DeletAll;
        private System.Windows.Forms.Button DeleteFigure;
        private System.Windows.Forms.NumericUpDown thicknessValue;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Button Change_location;
        private System.Windows.Forms.Button Edit_Figure;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button Reversal;
        private System.Windows.Forms.Button showAll;
    }
}

