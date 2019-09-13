using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rocket_chaichana
{
    public partial class Form1 : Form
    {
        int cnt = 1;
        int y1;
        int y2;
        int y3;

        int h;
        Random r;

        int score;
        bool start;

        int status ;
        public Form1()
        {
            InitializeComponent();
            y1 = pictureBox1.Top;
            y2 = pictureBox2.Top;

            h = Height;
            r = new Random();

            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            start = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left = pictureBox1.Left + 10;
            if (pictureBox1.Left > Width)
            {
                pictureBox1.Left = -pictureBox1.Width;
                pictureBox1.Top = r.Next(h - pictureBox1.Height * 2);
                y1 = pictureBox1.Top;

                scoreCal(true, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer3.Enabled = true;
            timer5.Enabled = true;

            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            score = 100;
            label1.Text = score.ToString();
            progressBar1.Value = 100;
            start = true;

            pictureBox1.Load(@"images\rocket.jpg");
            pictureBox1.Left = -pictureBox1.Width;
            pictureBox2.Load(@"images\rocket1.jpg");
            pictureBox2.Left = +pictureBox1.Width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox1.Load(@"images\BOMB.jpg");
            int w2 = pictureBox1.Height;
            pictureBox1.Top = y1 - w2 / 2;
            timer2.Enabled = true;

            scoreCal(true, 2);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cnt % 2 == 1)
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
            }
            cnt++;
            if (cnt == 10)
            {
                pictureBox1.Load(@"images\rocket.jpg");

                pictureBox1.Left = -pictureBox1.Width;
                pictureBox1.Top = r.Next(h - pictureBox1.Height * 2);
                y1 = pictureBox1.Top;

                pictureBox1.Visible = true;

                timer2.Enabled = false;
                timer1.Enabled = true;
                cnt = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();     
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            status = 0;
            scoreCal(start,status);
        }

        void scoreCal(bool startbool,int status)
        {
            if (startbool)
            {
                if (status == 0)
                {
                    score = score - 5;
                    label1.Text = score.ToString();
                    if (score <= 0)
                    {
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        progressBar1.Value = score;
                    }
                    if (score <= 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                        timer4.Enabled = false;
                        timer5.Enabled = false;
                        timer6.Enabled = false;
                        MessageBox.Show("Game Orver!!!");
                    }
                }
                else if (status == 1)
                {
                    score = score - 15;
                    label1.Text = score.ToString();
                    if (score <= 0)
                    {
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        progressBar1.Value = score;
                    }
                    if (score <= 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                        timer4.Enabled = false;
                        timer5.Enabled = false;
                        timer6.Enabled = false;
                        MessageBox.Show("Game Orver!!!");
                    }
                }
                else
                {
                    score = score + 10;
                    if (score <= 200)
                    {
                        progressBar1.Value = score;
                    }
                    else
                    {
                        progressBar1.Value = 200;
                    }
                    label1.Text = score.ToString();
                    if (score >= 200)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                        timer4.Enabled = false;
                        timer5.Enabled = false;
                        timer6.Enabled = false;
                        MessageBox.Show("Win");
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
             pictureBox2.Left = pictureBox2.Left - 5;
            if (pictureBox2.Left <= -pictureBox3.Width  )
            {
                pictureBox2.Left = Width ;
                pictureBox2.Top = r.Next(h - pictureBox2.Height * 2);
                y2 = pictureBox2.Top;

                scoreCal(true, 1);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            pictureBox2.Load(@"images\BOMB.jpg");
            int w2 = pictureBox2.Height;
            pictureBox2.Top = y2 - w2 / 2;
            timer4.Enabled = true;

            scoreCal(true, 2);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (cnt % 2 == 1)
            {
                pictureBox2.Visible = false;
            }
            else
            {
                pictureBox2.Visible = true;
            }
            cnt++;
            if (cnt == 10)
            {
                pictureBox2.Load(@"images\rocket1.jpg");

                pictureBox2.Left = +Width;
                pictureBox2.Top = r.Next(h - pictureBox2.Height * 2);
                y2 = pictureBox2.Top;

                pictureBox2.Visible = true;

                timer4.Enabled = false;
                timer3.Enabled = true;
                cnt = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            pictureBox3.Left = pictureBox3.Left + 10;
            pictureBox3.Top = pictureBox3.Top - 5;
            if (pictureBox3.Top < -pictureBox3.Height || pictureBox3.Left > Width)
            {
                pictureBox3.Top = Height;
                pictureBox3.Left = r.Next(Width - pictureBox3.Width * 2);

                scoreCal(true, 1);
            }

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (cnt % 2 == 1)
            {
                pictureBox3.Visible = false;
            }
            else
            {
                pictureBox3.Visible = true;
            }
            cnt++;
            if (cnt == 10)
            {
                pictureBox3.Load(@"images\rocket2.jpg");

                pictureBox3.Left = -pictureBox2.Width;
                pictureBox3.Top = r.Next(h - pictureBox3.Height * 2);
                y3 = pictureBox2.Top;

                pictureBox3.Visible = true;

                timer6.Enabled = false;
                timer5.Enabled = true;
                cnt = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer5.Enabled = false;
            pictureBox2.Load(@"images\BOMB.jpg");
            int w2 = pictureBox2.Height;
            pictureBox3.Top = Height;
            timer6.Enabled = true;

            scoreCal(true, 2);
        }

    }
}
