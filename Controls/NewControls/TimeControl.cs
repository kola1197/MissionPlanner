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
    public partial class TimeControl : UserControl
    {
        bool stopWatchActive = false;
        public TimeControl()
        {
            InitializeComponent();
            updateLabels();
            timer1.Start();
        }

        private void updateLabels() 
        {
            label3.Text = DateTime.Now.ToString("HH:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabels();   
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
