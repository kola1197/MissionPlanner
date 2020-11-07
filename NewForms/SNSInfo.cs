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
    public partial class SNSInfo : Form
    {
        public SNSInfo()
        {
            InitializeComponent();
            updateLabels();
            timer1.Start();
        }

        public void setPosition() 
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(50, MainV2.instance.Height - 150);
        }

        public void setPosition(Point p)
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = p;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void updateLabels() 
        {
            label2.Text = MainV2.comPort.MAV.cs.satcount.ToString();
            label4.Text = MainV2.comPort.MAV.cs.gpsstatus.ToString();
            label6.Text = MainV2.comPort.MAV.cs.gpshdop.ToString();
        }
    }
}
