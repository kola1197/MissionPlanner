using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class VibeGraph : Form
    {
        public VibeGraph()
        {
            InitializeComponent();
        }
        Bitmap myBitmap;

        public void setPosition() 
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(200, MainV2.instance.Height - 150);
        }

        public void setPosition(Point p)
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = p;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            double sizeMP = 1;
            myBitmap = new Bitmap(600, 300);
            base.OnPaint(e);
            Graphics g;
            g = Graphics.FromImage(myBitmap);
            Pen myPen = new Pen(Color.White);
            myPen.Width = 1;

            g.DrawLine(myPen, 1, 250, 600, 250);
            
            /*Pen p = new Pen(Color.Green);
            p.Width = 3;
            for (int i = 0; i < ICESpeeds.Count - 1; i++)
            {
                g.DrawLine(p, xStart + i * 2.3222f / (float)multy, (yStart - ICESpeeds[i] / 50), xStart + (i + 1) * 2.3222f / (float)multy, yStart - ICESpeeds[i + 1] / 50);

            }*/
            drawVibe(0, Color.Red, g);
            drawVibe(1, Color.Green, g);
            drawVibe(2, Color.Cyan, g);

            pictureBox1.Image = myBitmap;

        }

        private void drawVibe(int index, Color color, Graphics g)
        {
            Pen p = new Pen(color);
            p.Width = 2;
            for (int i = 0; i < 599; i++)
            {
                g.DrawLine(p, (float)i, (250f - MainV2.vibeData.vibe[index, i]*10f), ((float)i + 1f), (250f - MainV2.vibeData.vibe[index, i + 1]*10f));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            if (label1.ForeColor != Color.Red)
            {
                label1.ForeColor = Color.Red;
            }
            if (label2.ForeColor != Color.Lime)
            {
                label2.ForeColor = Color.Lime;
            }
            if (label3.ForeColor != Color.Cyan)
            {
                label3.ForeColor = Color.Cyan;
            }
            Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_ForeColorChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("fuck");
        }
    }
}
