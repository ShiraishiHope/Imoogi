using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Imoogi
{
    public partial class Imoogi : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();


        public Imoogi()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += updateScreen;
            gameTimer.Start();

            StartGame();
        }

        private void updateScreen (object sender, EventArgs e)
        {
            //Timer update screen function
            if(Settings.GameOver == true)
            {
                if (Input.KeyPress(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                movePlayer();
            }
            //refresh picture box
            picCanvas.Invalidate(); 
        }

        private void movePlayer()
        {
            //main loop for snake head and body
            for (int i = Snake.Count-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    //move rest of the body according to the direction of the head
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }
                    //Restrict Snake to picturebox
                    int maxXpos = picCanvas.Size.Width / Settings.Width;
                    int maxYpos = picCanvas.Size.Height / Settings.Height;

                    if (
                        Snake[i].X < 0 || Snake[i].Y < 0 ||
                        Snake[i].X > maxXpos || Snake[i].Y > maxYpos
                        )
                    {
                        die();
                    }

                    //detect collision with any body part
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y )
                        {
                            die();
                        }
                    }

                    //collision between head and food
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood();
                    }
                }
                else
                {
                    Snake[i].X = Snake[i-1].X;
                    Snake[i].Y = Snake[i-1].Y;
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void StartGame()
        {
            label1.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle {  X=10, Y = 5 };
            Snake.Add(head);

            textPoint.Text = Settings.Score.ToString();
            generateFood();
        }

        private void generateFood()
        {
            //create  max x and y half the size of the play area
            int maxXpos = picCanvas.Size.Width / Settings.Width;
            int maxYpos = picCanvas.Size.Height / Settings.Height;

            Random rand = new Random();
            food = new Circle { X = rand.Next(0, maxXpos), Y = rand.Next(0, maxYpos) };
        }


        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {
                Brush snakeColour;
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.Firebrick;
                    }
                    else
                    {
                        snakeColour = Brushes.Green;
                    }

                    canvas.FillRectangle(snakeColour, new Rectangle
                        (
                            Snake[i].X * Settings.Width,
                            Snake[i].Y * Settings.Height,
                            Settings.Width, Settings.Height
                        ));

                canvas.FillEllipse(Brushes.White, new Rectangle
                (
                    food.X * Settings.Width,
                    food.Y * Settings.Height,
                    Settings.Width, Settings.Height
                ));


                }
            }
            else
            {
                string gameOver = "Game Over \n" + "Final Score is " + Settings.Score + "\n Press enter to Restart \n";
                label1.Text = gameOver;
                label1.Visible = true;
            }


        }

        private void EatFood()
        {

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            Settings.Score += Settings.Points;
            textPoint.Text = Settings.Score.ToString();
            generateFood();
        }

        private void die()
        {
            Settings.GameOver = true;
        }
    }
}
