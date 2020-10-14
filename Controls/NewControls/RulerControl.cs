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

            this.DoubleBuffered = true;
            recalculate(0);
        }
        double lastLenght = 0;
        Bitmap myBitmap;
        int[] roundValues = new int[] { 50,100,250,500,1000};

        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        

        public void recalculate(double a) 
        {
            //a *= 100;
            if (a != lastLenght)
            {
                lastLenght = a;
                label1.Text = MainV2.FormatDistance(a, true);

                int width = this.Size.Width;
                int height = this.Size.Height;
                myBitmap = new Bitmap(width, height);

                //base.OnPaint(e);
                Graphics g;
                g = Graphics.FromImage(myBitmap);
                Pen myPen = new Pen(Color.White);
                myPen.Width = 4;


                g.DrawLine(myPen, 1, height / 2, width - 1, height / 2);
                g.DrawLine(myPen, 1, 0, 1, height);
                g.DrawLine(myPen, width - 1, height / 2, width - 1, height);

                                                            //now let's draw round value  
                int k = (int)a;
                if (k == 0)
                {
                    k = (int)(a*1000);
                    int num = 0;
                    for (int i = 0; i < roundValues.Length - 1; i++)
                    {
                        if (roundValues[i] < k && k < roundValues[i + 1])
                        {
                            num = i;
                        }
                    }

                    k = roundValues[num];
                    int newWidth = (int)((double)width * (k / (a*1000)));
                    g.DrawLine(myPen, newWidth - 1, 0, newWidth - 1, height / 2);
                    double d = k;
                    label2.Text = MainV2.FormatDistance(d/1000, true);
                }
                else
                {
                    int newWidth = (int)((double)width * (k / a));
                    g.DrawLine(myPen, newWidth - 1, 0, newWidth - 1, height / 2);
                    label2.Text = MainV2.FormatDistance(k, false);
                }
                Pen p = new Pen(Color.Green);
                p.Width = 3;

                pictureBox1.Image = myBitmap;
            }
        }
    }
}
