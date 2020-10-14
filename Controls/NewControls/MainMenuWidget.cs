using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using static MissionPlanner.Log.LogOutput;
using System.Runtime.InteropServices;

namespace MissionPlanner.Controls
{
    public partial class MainMenuWidget : MyUserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect, // x-coordinate of upper-left corner
           int nTopRect, // y-coordinate of upper-left corner
           int nRightRect, // x-coordinate of lower-right corner
           int nBottomRect, // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );
        Delegate test;
        private bool active = false;
        private int X = 0;
        public MainMenuWidget()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            updateSize();
        }

        public MainMenuWidget(Delegate t)
        {
            InitializeComponent();
            test = t;
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            //active = !active;
            //Console.WriteLine("MainButton pressed, now: "+active);
            //updateSize();
        }

        private void updateSize() 
        {
            if (!active)
            {
                this.Size = new Size(60, 60);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            }
            else 
            {
                this.Size = new Size(417, 60);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            }
        }

        public void setState(bool _active) 
        {
            //active = _active;
            updateSize();
        }
        
        private void MainMenuWidget_MouseEnter(object sender, EventArgs e)
        {
            active = true;
            updateSize();
            //System.Diagnostics.Debug.WriteLine("active - true");
        }

        private void MainMenuWidget_MouseLeave(object sender, EventArgs e)
        {
            if (this.GetChildAtPoint(this.PointToClient(MousePosition)) == null)
            {
                active = false;
                updateSize();
                //System.Diagnostics.Debug.WriteLine("active - false");
            }
        }

        private void MapChoiseButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWW");
        }

        private void ParamsButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWW");
        }

        private void myButton2_Click(object sender, EventArgs e)
        {

        }

        private void centeringButton_Click(object sender, EventArgs e)
        {

        }

        private void RulerButton_Click(object sender, EventArgs e)
        {

        }

        private void EKFButton_Click(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {

        }
    }
    
}
