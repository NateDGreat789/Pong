using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Pong
{
    public partial class Form1 : Form
    {
        Rectangle centre = new Rectangle(0, 250, 360, 5);
        Rectangle p1goal = new Rectangle(130, 0, 100, 5);
        Rectangle p2goal = new Rectangle(130, 515, 100, 5);
        Rectangle player1 = new Rectangle(160, 50, 40, 40);
        Rectangle player2 = new Rectangle(160, 430, 40, 40);
        Rectangle ball = new Rectangle(170, 242, 20, 20);
        Rectangle hitbox1 = new Rectangle(0, 0, 1, 1);
        Rectangle hitbox2 = new Rectangle(0, 0, 1, 1);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 5;
        int ballXSpeed = 6;
        int ballYSpeed = 6;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush whiteBrush = new SolidBrush(Color.Purple);
        Pen highlightPen = new Pen(Color.White, 3);

        Random rnd = new Random();

        SoundPlayer hit = new SoundPlayer(Properties.Resources.hit);
        SoundPlayer goal = new SoundPlayer(Properties.Resources.goal);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(redBrush, centre);
            e.Graphics.FillRectangle(redBrush, p1goal);
            e.Graphics.FillRectangle(redBrush, p2goal);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(yellowBrush, player2);
            e.Graphics.FillEllipse(whiteBrush, ball);
            e.Graphics.FillRectangle(redBrush, hitbox1);
            e.Graphics.FillRectangle(redBrush, hitbox2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = ball.X + 10;
            int y = ball.Y + 10;

            hitbox1.X = player1.X + player1.Width;
            hitbox1.Y = player1.Y + player1.Height;

            hitbox2.X = player2.X + player1.Width;
            hitbox2.Y = player2.Y + player1.Height;

            //move ball 
            if (ballXSpeed == 0 && player1.IntersectsWith(ball))
            {
                ballXSpeed = 6;
                ballYSpeed = 6;
            }
            else if (ballXSpeed == 0 && player2.IntersectsWith(ball))
            {
                ballXSpeed = 6;
                ballYSpeed = 6;
            }
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player 1 
            if (player1Score != 3 && player2Score != 3)
            {
                if (wDown == true && player1.Y > 0 && ball.Y > 1)
                {
                    player1.Y -= playerSpeed;
                }
                if (sDown == true && player1.Y < 250 - player1.Height)
                {
                    player1.Y += playerSpeed;
                }
                if (aDown == true && player1.X > 0 && ball.X > 0)
                {
                    player1.X -= playerSpeed;
                }
                if (dDown == true && player1.X < this.Width - player1.Width && ball.X < 360 - ball.Width)
                {
                    player1.X += playerSpeed;
                }
            }

            //move player 2 
            if (player1Score != 3 && player2Score != 3)
            {
                if (upArrowDown == true && player2.Y > 255)
                {
                    player2.Y -= playerSpeed;
                }
                if (downArrowDown == true && player2.Y < this.Height - player2.Height && ball.Y < this.Height - ball.Height)
                {
                    player2.Y += playerSpeed;
                }
                if (leftArrowDown == true && player2.X > 0 && ball.X > 0)
                {
                    player2.X -= playerSpeed;
                }
                if (rightArrowDown == true && player2.X < this.Width - player2.Width && ball.X < 360 - ball.Width)
                {
                    player2.X += playerSpeed;
                }
            }

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;
            }
            if (ball.X > 360 - ball.Width || ball.X < 0)
            {
                ballXSpeed *= -1;
            }

            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 
            if (player1.IntersectsWith(ball) && ballXSpeed != 0 && (y < player1.Y || y > hitbox1.Y))
            {
                ballYSpeed *= -1;
                ball.Y = y;
                hit.Play();
            }
            
            if (player1.IntersectsWith(ball) && ballXSpeed != 0 && (x < player1.X || x > hitbox1.X))
            {
                ballXSpeed *= -1;
                ball.X = x;
                hit.Play();
            }

            if (player2.IntersectsWith(ball) && ballXSpeed != 0 && (y < player2.Y || y > hitbox2.Y))
            {
                ballYSpeed *= -1;
                ball.Y = y;
                hit.Play();
            }

            if (player2.IntersectsWith(ball) && ballXSpeed != 0 && (x < player2.X || x > hitbox2.X))
            {
                ballXSpeed *= -1;
                ball.X = x;
                hit.Play();
            }

            //check if a player missed the ball and if true add 1 to score of other player  
            if (ball.IntersectsWith(p1goal))
            {
                goal.Play();
                
                player2Score++;
                p2scorelabel.Text = $"{player2Score}";

                ball.X = 170;
                ball.Y = 242;

                ballXSpeed = 0;
                ballYSpeed = 0;

                player1.Y = 50;
                player2.Y = 430;
                player1.X = 160;
                player2.X = 160;
            }
            else if (ball.IntersectsWith(p2goal))
            {
                goal.Play();
                
                player1Score++;
                p1scorelabel.Text = $"{player1Score}";

                ball.X = 170;
                ball.Y = 242;

                ballXSpeed = 0;
                ballYSpeed = 0;

                player1.Y = 50;
                player2.Y = 430;
                player1.X = 160;
                player2.X = 160;
            }

            // check score and stop game if either player is at 3 
            if (player1Score == 3)
            {
                gametimer.Enabled = true;
                winlabel.Visible = true;
                winlabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 3)
            {
                gametimer.Enabled = true;
                winlabel.Visible = true;
                winlabel.Text = "Player 2 Wins!!";
            }

            //get ball out of bounds
            

            Refresh();
        }
    }
}
