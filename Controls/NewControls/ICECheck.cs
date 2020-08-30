using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class ICECheck : UserControl
    {
        public ICECheck()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //typeof(Panel).InvokeMember("DoubleBuffered",   BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,  null, DrawingPanel, new object[] { true });
        }
        int xStart = 8;
        int yStart = 300;
        bool testBool = false;
        int counter = 0;
        bool started = false;
        List<float> ICESpeeds = new List<float>();
        public bool iceChecked = false;
        Bitmap myBitmap;
        protected override void OnPaint(PaintEventArgs e)
        {
            myBitmap = new Bitmap(430,430);
            base.OnPaint(e);
            Graphics g;
            //g = this.CreateGraphics();
            g = Graphics.FromImage(myBitmap);
            Pen myPen = new Pen(Color.Blue);
            myPen.Width = 1;
            //g.DrawLine(myPen, 30, 30, 45, 45);
            //g.DrawLine(myPen, 1, 50, 431, 50);
            g.DrawLine(myPen, 1, 300, 431, 300);
            g.DrawLine(myPen, 1, 300, 431, 300);
            g.DrawLine(myPen, 1, 220, 431, 220);
            g.DrawLine(myPen, 1, 160, 431, 160);

            Pen p = new Pen(Color.Green);
            p.Width = 3;
            Point[] points = new Point[ICESpeeds.Count];
            for (int i = 0; i < ICESpeeds.Count - 1; i++)
            {
                g.DrawLine(p, xStart + i * 2.2f, yStart - ICESpeeds[i] / 50, xStart + (i + 1) * 2.2f, yStart - ICESpeeds[i+1] / 50);
                //points[i] = new Point((int)(xStart + i * 2.2f), (int)(yStart - ICESpeeds[i] / 25));
                //System.Diagnostics.Debug.Write("  " + ICESpeeds[i].ToString() + "  ");
            }
            pictureBox1.Image = myBitmap;
            /*Pen p = new Pen(Color.Green);
            p.Width = 3;
            if (points.Length > 2)
            {
                g.DrawPolygon(p, points);
            }*/
        }

        void drawGraphic() 
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!testBool)
            {
                float i = MainV2.comPort.MAV.cs.rpm1;
                ICESpeeds.Add(i);
            }
            counter++;
            if (counter < 60) 
            {
                MainV2.comPort.MAV.cs.ch10out = 2000;
                if (testBool) 
                {
                    ICESpeeds.Add(13000.0f);
                }
            }
            if (counter > 60 && counter < 120)
            {
                MainV2.comPort.MAV.cs.ch10out = 1400;
                if (testBool)
                {
                    ICESpeeds.Add(4000.0f);
                }
                label1.BackColor = Color.Green;
            }
            if (counter > 120)
            {
                if (testBool)
                {
                    double d = counter;
                    ICESpeeds.Add((((float)Math.Sin(d / 5))) * 4500.0f + 8500.0f);
                    MainV2.comPort.MAV.cs.ch10out = (float)Math.Sin(d / 5) * 300.0f + 1700.0f ;
                }
                label2.BackColor = Color.Green;
            }
            if (counter > 190)
            {
                label3.BackColor = Color.Green;
                startButton.Enabled = true;
                stop();
            }

            if (!testBool)
            {
                float i = MainV2.comPort.MAV.cs.rpm1;
                ICESpeeds.Add(i);
            }
            else 
            {
                //ICESpeeds.Add(6000);
            }
            //this.Refresh();
            Invalidate();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            iceChecked = true;
            stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (started = false)
            {
                started = true;
                ICESpeeds = new List<float>();
                startButton.Text = "Работа стабильна";
                startButton.Enabled = false;
                counter = 0;
                label1.BackColor = Color.DarkSlateGray;
                label2.BackColor = Color.DarkSlateGray;
                label3.BackColor = Color.DarkSlateGray;
                timer1.Start();
            }
            else 
            {
                stop();
                iceChecked = true;
                startButton.Text = "Начать";
            }
        }

        void stop() 
        {
            timer1.Stop();
            started = false;
            counter = 0;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            started = true;
            ICESpeeds = new List<float>();
            //for (int i = 0; i < 18 * 10; i++) 
            //{
            //    ICESpeeds.Add(6000);
            //}
            testBool = true;
            timer1.Start();
        }
    }
}
