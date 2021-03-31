using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easy_And_Fun_Game
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpspeed = 11;
        int force = 10;
        int score = 0;
        int castusSpeed = 10;
        Random r = new Random();
        int postion;
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            GameReset();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            
            lblScore.Text = "Score: " + score;

            if (jumping == true && force < 0)
            {
                jumping = false;    
            }

            if (jumping == true)
            {
                force -= 1;
                jumpspeed = -11;
            }
            else
            {
                jumpspeed = 11;
            }


            if (trex.Top > 356 && jumping == false)
            {
                force = 10;
                trex.Top = 357;
                jumpspeed = 0;
            }
            trex.Top += jumpspeed;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "castus")
                {
                    x.Left -= 10;
                    if (x.Left < -45)
                    {
                        x.Left = this.ClientSize.Width + r.Next(600, 800) + (x.Width * 15);
                        //x.Left = postion;
                        score++;
                    }

                    
                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        isGameOver = true;
                        gameTimer.Stop();
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
                
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                isGameOver = false;
                GameReset();

            }
        }

        private void GameReset()
        {
            force = 11;
            jumpspeed = 0;
            score = 0;
            castusSpeed = 10;
            lblScore.Text = "Score: " + score;
            isGameOver = false;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "castus")
                {
                    postion = this.ClientSize.Width + r.Next(500,800) + (x.Width * 10) ;
                    x.Left = postion;
                }
            }
            gameTimer.Start();
        }
    }
}
