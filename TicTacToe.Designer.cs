namespace SpielParadies
{
    partial class TicTacToe
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
            button1 = new Button();
            A00 = new Button();
            A01 = new Button();
            A02 = new Button();
            A10 = new Button();
            A11 = new Button();
            A12 = new Button();
            A20 = new Button();
            A21 = new Button();
            A22 = new Button();
            label1 = new Label();
            button11 = new Button();
            button2 = new Button();
            lbl_x = new Label();
            lbl_O = new Label();
            lbl_draw = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(750, 491);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // A00
            // 
            A00.Location = new Point(118, 67);
            A00.Name = "A00";
            A00.Size = new Size(150, 150);
            A00.TabIndex = 1;
            A00.UseVisualStyleBackColor = true;
            A00.Click += buttonsClick;
            // 
            // A01
            // 
            A01.Location = new Point(274, 67);
            A01.Name = "A01";
            A01.Size = new Size(150, 150);
            A01.TabIndex = 2;
            A01.UseVisualStyleBackColor = true;
            A01.Click += buttonsClick;
            // 
            // A02
            // 
            A02.Location = new Point(430, 67);
            A02.Name = "A02";
            A02.Size = new Size(150, 150);
            A02.TabIndex = 3;
            A02.UseVisualStyleBackColor = true;
            A02.Click += buttonsClick;
            // 
            // A10
            // 
            A10.Location = new Point(118, 223);
            A10.Name = "A10";
            A10.Size = new Size(150, 150);
            A10.TabIndex = 4;
            A10.UseVisualStyleBackColor = true;
            A10.Click += buttonsClick;
            // 
            // A11
            // 
            A11.Location = new Point(274, 223);
            A11.Name = "A11";
            A11.Size = new Size(150, 150);
            A11.TabIndex = 5;
            A11.UseVisualStyleBackColor = true;
            A11.Click += buttonsClick;
            // 
            // A12
            // 
            A12.Location = new Point(430, 223);
            A12.Name = "A12";
            A12.Size = new Size(150, 150);
            A12.TabIndex = 6;
            A12.UseVisualStyleBackColor = true;
            A12.Click += buttonsClick;
            // 
            // A20
            // 
            A20.Location = new Point(118, 379);
            A20.Name = "A20";
            A20.Size = new Size(150, 150);
            A20.TabIndex = 7;
            A20.UseVisualStyleBackColor = true;
            A20.Click += buttonsClick;
            // 
            // A21
            // 
            A21.Location = new Point(274, 379);
            A21.Name = "A21";
            A21.Size = new Size(150, 150);
            A21.TabIndex = 8;
            A21.UseVisualStyleBackColor = true;
            A21.Click += buttonsClick;
            // 
            // A22
            // 
            A22.Location = new Point(430, 379);
            A22.Name = "A22";
            A22.Size = new Size(150, 150);
            A22.TabIndex = 9;
            A22.UseVisualStyleBackColor = true;
            A22.Click += buttonsClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(274, 26);
            label1.Name = "label1";
            label1.Size = new Size(157, 33);
            label1.TabIndex = 10;
            label1.Text = "TicTacToe";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.Location = new Point(750, 431);
            button11.Name = "button11";
            button11.Size = new Size(150, 46);
            button11.TabIndex = 11;
            button11.Text = "Reset";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(750, 20);
            button2.Name = "button2";
            button2.Size = new Size(150, 49);
            button2.TabIndex = 12;
            button2.Text = "New Game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lbl_x
            // 
            lbl_x.AutoSize = true;
            lbl_x.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_x.ForeColor = Color.Red;
            lbl_x.Location = new Point(750, 223);
            lbl_x.Name = "lbl_x";
            lbl_x.Size = new Size(39, 32);
            lbl_x.TabIndex = 13;
            lbl_x.Text = "X:";
            // 
            // lbl_O
            // 
            lbl_O.AutoSize = true;
            lbl_O.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_O.ForeColor = Color.Blue;
            lbl_O.Location = new Point(749, 268);
            lbl_O.Name = "lbl_O";
            lbl_O.Size = new Size(40, 32);
            lbl_O.TabIndex = 14;
            lbl_O.Text = "O:";
            // 
            // lbl_draw
            // 
            lbl_draw.AutoSize = true;
            lbl_draw.BackColor = Color.Silver;
            lbl_draw.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_draw.Location = new Point(749, 317);
            lbl_draw.Name = "lbl_draw";
            lbl_draw.Size = new Size(96, 37);
            lbl_draw.TabIndex = 15;
            lbl_draw.Text = "Draw:";
            lbl_draw.Click += lbl_draw_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Silver;
            pictureBox1.Location = new Point(697, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 581);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // TicTacToe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(912, 566);
            Controls.Add(lbl_draw);
            Controls.Add(lbl_O);
            Controls.Add(lbl_x);
            Controls.Add(button2);
            Controls.Add(button11);
            Controls.Add(label1);
            Controls.Add(A22);
            Controls.Add(A21);
            Controls.Add(A20);
            Controls.Add(A12);
            Controls.Add(A11);
            Controls.Add(A10);
            Controls.Add(A02);
            Controls.Add(A01);
            Controls.Add(A00);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "TicTacToe";
            Text = "TicTacToe";
            Load += TicTacToe_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button A00;
        private Button A01;
        private Button A02;
        private Button A10;
        private Button A11;
        private Button A12;
        private Button A20;
        private Button A21;
        private Button A22;
        private Label label1;
        private Button button11;
        private Button button2;
        private Label lbl_x;
        private Label lbl_O;
        private Label lbl_draw;
        private PictureBox pictureBox1;
    }
}