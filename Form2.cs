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
    public partial class Form2 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle ();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        SpielAuswahl parent;
        public Form2(SpielAuswahl parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.KeyPreview = true;
            
            this.KeyPreview = true; // Wichtig für Tasteneingabe
            this.KeyDown += KeyIsDown; // Das VERBINDET die Tasten mit dem Code


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            

            // Zusätzlich: WASD-Steuerung
            if (e.KeyCode == Keys.A && Settings.directions != "right")
            {
                Settings.directions = "left";
            }
            else if (e.KeyCode == Keys.D && Settings.directions != "left")
            {
                Settings.directions = "right";
            }
            else if (e.KeyCode == Keys.W && Settings.directions != "down")
            {
                Settings.directions = "up";
            }
            else if (e.KeyCode == Keys.S && Settings.directions != "up")
            {
                Settings.directions = "down";
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
            this.Focus(); // Das sorgt dafür, dass Tasten funktionieren
            gameTimer.Enabled = true;
            Settings.directions = "right"; // Startrichtu

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Kopf: {Snake[0].X},{Snake[0].Y} | Apfel: {food.X},{food.Y}");

            // end of directions
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;

                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;

                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)

                    {
                        Snake[i].Y = 0;
                    }
                    

                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood();
                        
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Red;
                }
                else
                {
                    snakeColour = Brushes.Pink;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
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
            Snake.Clear();
            startButton.Enabled = false;
            gameTimer.Interval = 120;

            score = 0;
            txtScore.Text = "Score: " + score;
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // adding the head part of the snake to the list

            for (int i = 0; i < 5; i++) // z. B. 2 Körperteile
            {
                Snake.Add(new Circle
                {
                    X = Snake[0].X,
                    Y = Snake[0].Y
                });
            }
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            gameTimer.Start();

        }

        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;

            // Neuen Schlangenteil hinten anhängen
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);

            // Neues Futter setzen – aber NICHT auf der Schlange
            bool validFood = false;
            while (!validFood)
            {
                food = new Circle
                {
                    X = rand.Next(2, maxWidth),
                    Y = rand.Next(2, maxHeight)
                };

                validFood = true;

                foreach (var part in Snake)
                {
                    if (part.X == food.X && part.Y == food.Y)
                    {
                        validFood = false;
                        break;
                    }
                }
            }

        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }


        public static class Settings
        {
            public static int Width { get; set; } = 25;
            public static int Height { get; set; } = 25;
            public static string directions { get; set; } = "left";
        }

    }
}
