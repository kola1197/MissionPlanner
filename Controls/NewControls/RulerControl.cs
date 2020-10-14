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
    public partial class RulerControl : UserControl
    {
        public RulerControl()
        {
            InitializeComponent();
        }
        Bitmap myBitmap;

        public void updateRuler(int a, int b) 
        {
        
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            myBitmap = new Bitmap(width, height);
            base.OnPaint(e);
            Graphics g;
            g = Graphics.FromImage(myBitmap);
            Pen myPen = new Pen(Color.White);
            myPen.Width = 4;
           
            g.DrawLine(myPen, 1, height/2, width - 1, height/2);
            //g.DrawLine(myPen, 1, 300, width - 1, 300);
            

            Pen p = new Pen(Color.Green);
            p.Width = 3;
            
            pictureBox1.Image = myBitmap;
        }
    }
}
