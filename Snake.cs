using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
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

            // Standard Richtung setzen
            Settings.directions = "right";

            this.Shown += (s, e) =>
            {
                maxWidth = picCanvas.Width / Settings.Width - 1;
                maxHeight = picCanvas.Height / Settings.Height - 1;
                RestartGame(); // Spielstart sicherstellen
            };
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
                Settings.directions = "left";
            }
            else if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                Settings.directions = "right";
            }
            else if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                Settings.directions = "up";
            }
            else if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                Settings.directions = "down";
            }
        }
       

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Diese Methode ist unnötig, wenn die Richtung in KeyIsDown gesteuert wird
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();


            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            // Debug-Tipp: Zeigt an, ob die Werte korrekt sind
            Console.WriteLine("maxWidth: " + maxWidth + ", maxHeight: " + maxHeight);
            MessageBox.Show("maxWidth: " + maxWidth + ", maxHeight: " + maxHeight);


            snake.Clear();
            startButton.Enabled = false;
            snapButton.Enabled = false;

            Score = 0;
            txtScore.Text = "Score: " + Score;

            Circle head = new Circle { X = 10, Y = 5 };
            snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored: " + Score + " and my Highscore is " + highScore + " on the Snake Game from MOO ICT";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Purple;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot MOO ICT";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft) Settings.directions = "left";
            else if (goRight) Settings.directions = "right";
            else if (goDown) Settings.directions = "down";
            else if (goUp) Settings.directions = "up";

            // Bewege die Schlange
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left": snake[i].X--; break;
                        case "right": snake[i].X++; break;
                        case "down": snake[i].Y++; break;
                        case "up": snake[i].Y--; break;
                    }

                    // Randüberlauf verhindern
                    if (snake[i].X < 0) snake[i].X = maxWidth;
                    if (snake[i].X > maxWidth) snake[i].X = 0;
                    if (snake[i].Y < 0) snake[i].Y = maxHeight;
                    if (snake[i].Y > maxHeight) snake[i].Y = 0;

                    // Kollision mit Essen
                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    // Kollision mit sich selbst
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }

            // Canvas aktualisieren
            picCanvas.Refresh();
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
                    snakeColour = Brushes.DarkBlue;
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
            Score += 1;
            txtScore.Text = "Score: " + Score;
            Circle body = new Circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(body);
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;
            if (Score > highScore)
            {
                highScore = Score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}



