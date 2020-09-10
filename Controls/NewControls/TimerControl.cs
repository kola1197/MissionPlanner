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
    public partial class TimerControl : UserControl
    {
        bool active = false;
        DateTime last;
        DateTime stopWatchTime = new DateTime(0);

        public TimerControl()
        {
            InitializeComponent();
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            stopWatchTime = new DateTime(0);
            label1.Text = stopWatchTime.ToString("HH:mm:ss.f");
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!active)
            {
                active = true;
                timer1.Start();
                last = DateTime.Now;
            }
            else 
            {
                timer1.Stop();
                active = false;
            }
        }

        void updateLabels() 
        {
            label1.Text = stopWatchTime.ToString("HH:mm:ss.f");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (active) 
            {
                DateTime now = DateTime.Now;
                stopWatchTime += now - last;
                last = now;
                updateLabels();
            }
        }
    }
}
