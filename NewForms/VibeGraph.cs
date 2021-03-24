using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class VibeGraph : Form, IFormConnectable
    {
        public VibeGraph()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
        }
        Bitmap myBitmap;
        
        protected override void OnPaint(PaintEventArgs e)
        {
            double sizeMP = 1;
            //myBitmap = new Bitmap(600, 300);
            int w = Width - 16;
            int h = Height - 40;
            myBitmap = new Bitmap(w, h);
            base.OnPaint(e);
            Graphics g;
            g = Graphics.FromImage(myBitmap);
            Pen myPen = new Pen(Color.White);
            myPen.Width = 1;

            g.DrawLine(myPen, 1, h - 50, w, h - 50);
            
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
            int w = Width - 16;
            int h = Height - 40;
            float ff = h - 50;
            //float ww = w / 600;
            Pen p = new Pen(color);
            p.Width = 2;
            for (int i = 0; i < 599; i++)
            {
                g.DrawLine(p, (float)i, (ff - MainV2.vibeData.vibe[index, i]*10f), ((float)i + 1f), (ff - MainV2.vibeData.vibe[index, i + 1]*10f));
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
            //System.Diagnostics.Debug.WriteLine("fuck");
        }

        public void SetFormLocation()
        {
            // Location = new Point(200, MainV2.instance.Height - 150);
            Location = new Point(MainV2.instance.Location.X + 370, MainV2.instance.GetLowerPanelLocation().Y - this.Height + 20);
        }

        public void SetToTop()
        {
            TopMost = true;
        }

        private void VibeGraph_Shown(object sender, EventArgs e)
        {
            SetToTop();
        }

        private void VibeGraph_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(Width - 16, Height - 40);
            label1.Location = new Point(16, Height - 77);
            label2.Location = new Point(72, Height - 77);
            label3.Location = new Point(130, Height - 77);

        }
    }
}
