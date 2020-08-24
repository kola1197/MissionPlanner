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
    public partial class ICERun : UserControl
    {
        bool ICERunning = false;
        public ICERun()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabels();
            if (MainV2.comPort.MAV.cs.rpm1 > 3000) 
            {
                ICERunning = true;
                startButton.Text = "Заглушить";
                MainV2.comPort.MAV.cs.ch1in = 2000;
                MainV2.comPort.MAV.cs.ch1out = 2000;
                MainV2.comPort.MAV.cs.ch10out = 2000;
            }
            if (MainV2.comPort.MAV.cs.rpm1 < 2500)
            {
                ICERunning = false;
                startButton.Text = "Запустить двигатель";
                MainV2.comPort.MAV.cs.ch10in = 900;
            }
        }

        private void updateLabels() 
        {
            spedsLabel.Text = MainV2.comPort.MAV.cs.rpm1.ToString();
            tempLabel.Text = MainV2.comPort.MAV.cs.rpm2.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (ICERunning) 
            {
                
            }
        }
    }
}
