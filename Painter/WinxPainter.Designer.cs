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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolBox = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeletAll = new System.Windows.Forms.Button();
            this.Rubber = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Fill = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1210, 644);
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
            this.toolBox.Location = new System.Drawing.Point(130, 10);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(110, 21);
            this.toolBox.TabIndex = 1;
            this.toolBox.Text = "Инструмент";
            this.toolBox.SelectedIndexChanged += new System.EventHandler(this.toolBox_SelectedIndexChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(678, 12);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(127, 23);
            this.ColorBox.TabIndex = 2;
            this.ColorBox.Text = "Выбор цвета";
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
            this.DeletAll.Location = new System.Drawing.Point(491, 12);
            this.DeletAll.Name = "DeletAll";
            this.DeletAll.Size = new System.Drawing.Size(100, 23);
            this.DeletAll.TabIndex = 5;
            this.DeletAll.Text = "Удалить все!";
            this.DeletAll.UseVisualStyleBackColor = true;
            this.DeletAll.Click += new System.EventHandler(this.DeletAll_Click);
            // 
            // Rubber
            // 
            this.Rubber.Location = new System.Drawing.Point(597, 12);
            this.Rubber.Name = "Rubber";
            this.Rubber.Size = new System.Drawing.Size(75, 23);
            this.Rubber.TabIndex = 6;
            this.Rubber.Text = "Стерка";
            this.Rubber.UseVisualStyleBackColor = true;
            this.Rubber.Click += new System.EventHandler(this.Rubber_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(246, 10);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // Fill
            // 
            this.Fill.Location = new System.Drawing.Point(410, 12);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(75, 23);
            this.Fill.TabIndex = 9;
            this.Fill.Text = "Заливка";
            this.Fill.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 10;
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 644);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Rubber);
            this.Controls.Add(this.DeletAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Painter";
            this.Text = "Painter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.TextBox textBox1;
    }
}

