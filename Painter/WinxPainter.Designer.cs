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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeletAll = new System.Windows.Forms.Button();
            this.Rubber = new System.Windows.Forms.Button();
            this.thicknessValue = new System.Windows.Forms.NumericUpDown();
            this.Fill = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.showAll = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.Change_figure = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.pictureBox.Size = new System.Drawing.Size(1354, 733);
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
            this.toolBox.Location = new System.Drawing.Point(147, 14);
            this.toolBox.Margin = new System.Windows.Forms.Padding(4);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(110, 21);
            this.toolBox.TabIndex = 1;
            this.toolBox.Text = "Инструмент";
            this.toolBox.SelectedIndexChanged += new System.EventHandler(this.toolBox_SelectedIndexChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ColorBox.BackgroundImage")));
            this.ColorBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ColorBox.Location = new System.Drawing.Point(342, 11);
            this.ColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(43, 30);
            this.ColorBox.TabIndex = 2;
            this.ColorBox.UseVisualStyleBackColor = true;
            this.ColorBox.Click += new System.EventHandler(this.ColorBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // DeletAll
            // 
            this.DeletAll.Location = new System.Drawing.Point(434, 11);
            this.DeletAll.Margin = new System.Windows.Forms.Padding(4);
            this.DeletAll.Name = "DeletAll";
            this.DeletAll.Size = new System.Drawing.Size(100, 22);
            this.DeletAll.TabIndex = 5;
            this.DeletAll.Text = "Удалить всё!";
            this.DeletAll.UseVisualStyleBackColor = true;
            this.DeletAll.Click += new System.EventHandler(this.DeletAll_Click);
            // 
            // Rubber
            // 
            this.Rubber.Location = new System.Drawing.Point(887, 15);
            this.Rubber.Margin = new System.Windows.Forms.Padding(4);
            this.Rubber.Name = "Rubber";
            this.Rubber.Size = new System.Drawing.Size(75, 23);
            this.Rubber.TabIndex = 6;
            this.Rubber.Text = "Стерка";
            this.Rubber.UseVisualStyleBackColor = true;
            this.Rubber.Click += new System.EventHandler(this.Rubber_Click);
            // 
            // thicknessValue
            // 
            this.thicknessValue.BackColor = System.Drawing.SystemColors.Window;
            this.thicknessValue.Location = new System.Drawing.Point(265, 14);
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
            this.thicknessValue.Size = new System.Drawing.Size(58, 20);
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
            this.Fill.Location = new System.Drawing.Point(393, 11);
            this.Fill.Margin = new System.Windows.Forms.Padding(4);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(33, 31);
            this.Fill.TabIndex = 9;
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Количество граней";
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(542, 12);
            this.showAll.Margin = new System.Windows.Forms.Padding(4);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(96, 22);
            this.showAll.TabIndex = 11;
            this.showAll.Text = "Показать всё";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // undo
            // 
            this.undo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("undo.BackgroundImage")));
            this.undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undo.Location = new System.Drawing.Point(20, 90);
            this.undo.Margin = new System.Windows.Forms.Padding(4);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(29, 29);
            this.undo.TabIndex = 12;
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("redo.BackgroundImage")));
            this.redo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.redo.Location = new System.Drawing.Point(19, 133);
            this.redo.Margin = new System.Windows.Forms.Padding(4);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(29, 29);
            this.redo.TabIndex = 13;
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // Change_figure
            // 
            this.Change_figure.Location = new System.Drawing.Point(644, 12);
            this.Change_figure.Margin = new System.Windows.Forms.Padding(2);
            this.Change_figure.Name = "Change_figure";
            this.Change_figure.Size = new System.Drawing.Size(83, 22);
            this.Change_figure.TabIndex = 14;
            this.Change_figure.Text = "Переместить";
            this.Change_figure.UseVisualStyleBackColor = true;
            this.Change_figure.Click += new System.EventHandler(this.Change_figure_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(732, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 24);
            this.button1.TabIndex = 15;
            this.button1.Text = "Режим редактирования";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Change_figure);
            this.Controls.Add(this.redo);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.thicknessValue);
            this.Controls.Add(this.Rubber);
            this.Controls.Add(this.DeletAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DeletAll;
        private System.Windows.Forms.Button Rubber;
        private System.Windows.Forms.NumericUpDown thicknessValue;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Button Change_figure;
        private System.Windows.Forms.Button button1;
    }
}

