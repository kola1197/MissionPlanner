using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Topology;

namespace MissionPlanner.Controls.NewControls
{
    public partial class WPMenu : UserControl
    {
        bool fieldActive = false;
        public WPMenu()
        {
            InitializeComponent();
            //updateField();
        }

        private void updateField() 
        {
            this.Size = fieldActive ? new Size(95, 545) : new Size(95, 125);
            System.Drawing.Point now = this.Location;
            int diff = 420;
            this.Location = fieldActive ? new System.Drawing.Point(now.X,now.Y - diff) : new System.Drawing.Point(now.X, now.Y + diff);
            myButton1.Visible = fieldActive;
            myButton2.Visible = fieldActive;
            myButton3.Visible = fieldActive;
            myButton4.Visible = fieldActive;
            myButton5.Visible = fieldActive;
            myButton6.Visible = fieldActive;
        }

        private void myButton5_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, MouseEventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
        }

        private void WPMenu_Load(object sender, EventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
            fieldActive = !fieldActive;
            updateField();
        }
    }
}
