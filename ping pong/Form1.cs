using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ping_pong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int r;
        int x, y, z, w;
        int dw, dz;
        Random rnd = new Random();




        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //player1
            Point a = new Point(x - 10, 130);
            Point s = new Point(x + 40, 130);
            Point d = new Point(x + 30, 140);
            Point f = new Point(x, 140);
            //player2
            Point l = new Point(y, 463);
            Point h = new Point(y + 30, 463);
            Point j = new Point(y - 10, 473);
            Point k = new Point(y + 40, 473);
            Graphics g = e.Graphics;
            //mantinely
            g.FillRectangle(Brushes.Black, 130, 120, 5, 363);
            g.FillRectangle(Brushes.Black, 430, 120, 5, 363);
            g.FillRectangle(Brushes.Black, 135, 120, 80, 5);
            g.FillRectangle(Brushes.Black, 135, 478, 80, 5);
            g.FillRectangle(Brushes.Black, 350, 478, 80, 5);
            g.FillRectangle(Brushes.Black, 350, 120, 80, 5);

            //odrazatka
            Point[] player1 = { a, s, d, f };
            Point[] player2 = { l, h, k, j };
            g.FillPolygon(Brushes.Blue, player1);
            g.FillPolygon(Brushes.Blue, player2);
            g.FillRectangle(Brushes.Green, y, 463, 30, 10);
            g.FillRectangle(Brushes.Green, x, 130, 30, 10);
            //lopta
            g.FillEllipse(Brushes.Red, w, z, 10, 10);


        }

       
        void check()
        {
            while (true)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                else
                {
                    if ((w >= x - 5 && w <= x + 30 && z < 140 && z > 135 && dz < 0) ||
                         (w >= y - 5 && w <= y + 35 && z > 452 && z < 457 && dz > 0))
                    {

                        dz = -dz;

                       
                    }


                   
                    //boky zhora
                    //3
                    if (Math.Sqrt(Math.Pow(y - w - xx, 2) + Math.Pow(473 - z - xx, 2)) < 10 && dz > 0)
                    {
                        if (dw < 0)
                        {
                            dz = -dz-1;
                            dw = -dw+1;
                        }
                        if (dw > 0)
                        {
                            dz = -dz - 1;
                            dw = -dw - 1;
                        }

                    }
                    //4 problem
                    if (Math.Sqrt(Math.Pow(y + 30 - (w + yy), 2) + Math.Pow(473 - (z + xx), 2)) < 10 && dz > 0)
                    {
                        if (dw < 0)
                        {
                            dz = -dz - 1;
                           //dw = -dw + 1;
                        }
                        if (dw > 0)
                        {
                            dz = -dz - 1;
                           // dw = -dw - 1;
                        }

                    }
                    //2 problem 
                    if (Math.Sqrt(Math.Pow(x + 30 - (w + yy), 2) + Math.Pow(130 - (z + yy), 2)) < 10 && dz < 0)
                    {
                        if (dw < 0)
                        {
                            dz = -dz +1;
                           // dw = -dw - 1;
                        }
                        if (dw > 0)
                        {
                            dz = -dz + 1;
                           // dw = -dw + 1;
                        }

                    }
                    //1
                    if (Math.Sqrt(Math.Pow(x - (w + xx), 2) + Math.Pow(130 - (z + yy / 2), 2)) < 10 && dz < 0)
                    {
                        if (dw < 0)
                        {

                            dz = -dz + 1;
                            dw = -dw + 1;

                        }
                        if (dw > 0)
                        {
                            dz = -dz + 1;
                            dw = -dw - 1;
                        }

                    }
                    if (w >= 423 && dw>0)
                    {
                        dw = -dw;

                    }
                    if (w <= 136 && dw<0)
                    {
                        dw = -dw;

                    }
                    if (z >= 472 && (w < 215 || w > 350) && dz >0)
                    {
                        dz = -dz;

                    }
                    if (z <= 126 && (w < 215 || w > 350)&& dz <0)
                    {
                        dz = -dz;

                    }
                    if (z < 110)
                    {
                        skore2 = skore2 + 1;
                        z = 139;
                        r = 1;
                        w = x + 10;
                        timer2.Enabled = false;
                        backgroundWorker1.CancelAsync();
                      
                    }
                    if (z > 485)
                    {
                        skore1 = skore1 + 1;
                        z = 453;
                        r = 0;
                        w = y + 10;
                        timer2.Enabled = false;
                        backgroundWorker1.CancelAsync();
                        

                    }
                }
            }
        }
        int skore1, skore2;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            check();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Space)
                {
                    dw = 1;
                    dz = 1;
                    timer2.Enabled = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            
            
                if (e.KeyCode == Keys.Right && y + 50 <= 430)
                {
                    y += 10;
                    if (z == 453)
                    {
                        w += 10;
                    }

                }   
            
                if (e.KeyCode == Keys.Left && y -15 >= 135)
                {
                    y += -10;
                    if (z == 453)
                    {
                        w -= 10;
                    }
                }
            
                if (e.KeyCode == Keys.D && x + 50 <= 430)
                {
                    x += 10;
                    if (z == 139)
                    {
                        w += 10;
                    }

                }
                if (e.KeyCode == Keys.A && x-15 >= 135)
                {
                    x += -10;
                    if (z ==139)
                    {
                        w -= 10;
                    }
                }

        }

        

        double xx, yy;
        SoundPlayer player = new SoundPlayer("baseball_hit.wav");
        private void timer2_Tick(object sender, EventArgs e)
        {
            z = z + dz;
            w = w + dw;

            label1.Text = "Player1 : " + Convert.ToString(skore1);
            label2.Text = "Player2 : " + Convert.ToString(skore2);
            Invalidate();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            xx = 5 * (1 + (Math.Sqrt(2) / 2));
            yy = 5 * (1 - (Math.Sqrt(2) / 2));
            timer2.Interval = 1;
            backgroundWorker1.WorkerSupportsCancellation = true;
            timer2.Enabled = false;
            x = 270;
            y = 270;
            w = x + 10;
            r = rnd.Next(2);
            if (r == 0)
            {
                z = 453;
            }
            else
            {
                z = 139;
            }

        }
    }
    
}
