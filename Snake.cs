using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SpielParadies
{
    public partial class Snake : Form
    {

        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int Score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        SpielAuswahl parent;
        public Snake(SpielAuswahl parent)
        {
            InitializeComponent();
            this.parent = parent;

            new Settings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }


            if (e.KeyCode == Keys.Down && Settings.directions != "down")
            {
                goDown = true;
            }







        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }




        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // setting the direction

            if (goLeft)
            {
                Settings.directions = "left";
            }
            else if  (goRight)
            {
                Settings.directions = "right";
            }
           else if (goDown)
            {
                Settings.directions = "down";
            }
            else if (goUp)
            {
                Settings.directions = "up";
            }



            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            snake[i].X--;
                            break;
                        case "right":
                            snake[i].X++;
                            break;
                        case "down":
                            snake[i].Y++;
                            break;
                        case "up":
                            snake[i].Y--;
                            break;

                    }
                    if (snake[i].X < 0)
                    {
                        snake[i].X = maxWidth;
                    }
                    if (snake[i].X > maxWidth)
                    {
                        snake[i].X = 0;
                    }
                    if (snake[i].Y < 0)
                    {
                        snake[i].Y = maxHeight;
                    }
                    if (snake[i].Y > maxHeight)
                    {
                        snake[i].Y = 0;
                    }



                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }

            picCanvas.Invalidate();
        }

        private void UpdatePicturBoxGraphics(object sender, PaintEventArgs e)
        {

            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                (
                snake[i].X * Settings.Width,
                snake[i].Y * Settings.Height,
                Settings.Width, Settings.Height
                ));


            }
            canvas.FillEllipse(Brushes.Red, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));


        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;

            Score = 0;
            txtScore.Text = "Score: " + Score;

            Circle head = new Circle { X = 10, Y = 5 };
            snake.Add(head); // adding the head part of the Snake to the List

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
