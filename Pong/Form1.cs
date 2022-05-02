using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(30, 100, 10, 60);
        Rectangle player2 = new Rectangle(30, 240, 10, 60);
        Rectangle ball = new Rectangle(295, 195, 10, 10);

        int playerturn = 1;
        
        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;
        int ballXSpeed = 0;
        int ballYSpeed = 0;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        bool hittable = true;
        //bool firstHit = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen highlightPen = new Pen(Color.White, 3);

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(yellowBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            
            if (playerturn == 1)
            {
                e.Graphics.DrawRectangle(highlightPen, player1);
            }
            if (playerturn == 2)
            {
                e.Graphics.DrawRectangle(highlightPen, player2);
            }

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
            //move ball 
            if (ballXSpeed == 0 && playerturn == 1 && player1.IntersectsWith(ball))
            {
                ballXSpeed = 6;
                ballYSpeed = rnd.Next(4,10);
                playerturn = 2;
            }
            else if (ballXSpeed == 0 && playerturn == 2 && player2.IntersectsWith(ball))
            {
                ballXSpeed = 6;
                ballYSpeed = rnd.Next(4, 10);
                playerturn = 1;
            }
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }
            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }
            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }
            if (ball.X > 600 - ball.Width)
            {
                hittable = true;
                ballXSpeed *= -1;
            }

            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 
            if (player1.IntersectsWith(ball) && playerturn == 1 && hittable == true && ballXSpeed != 0)
            {
                ballXSpeed--;
                playerturn = 2;
                ballXSpeed *= -1;
                ballYSpeed = rnd.Next(4, 10);
                ball.X = player1.X + ball.Width;
                hittable = false;
            }
            else if (player2.IntersectsWith(ball) && playerturn == 2 && hittable == true && ballXSpeed != 0)
            {
                ballXSpeed--;
                playerturn = 1;
                ballXSpeed *= -1;
                ballYSpeed = rnd.Next(4, 10);
                ball.X = player2.X + ball.Width;
                hittable = false;
            }

            //check if a player missed the ball and if true add 1 to score of other player  
            if (ball.X < 0 && playerturn == 1)
            {
                player2Score++;
                p2scorelabel.Text = $"{player2Score}";

                ball.X = 295;
                ball.Y = 195;

                ballXSpeed = 0;
                ballYSpeed = 0;

                player1.Y = 100;
                player2.Y = 240;
                player1.X = 30;
                player2.X = 30;
            }
            else if (ball.X < 0)
            {
                player1Score++;
                p1scorelabel.Text = $"{player1Score}";

                ball.X = 295;
                ball.Y = 195;
                
                ballXSpeed = 0;
                ballYSpeed = 0;

                player1.Y = 100;
                player2.Y = 240;
                player1.X = 30;
                player2.X = 30;
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

            Refresh();
        }
    }
}
