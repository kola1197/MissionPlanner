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
            //updateLabels();
            //timer1.Start();
        }

        /*private void updateLabels() 
        {
            DateTime start;
            Orlan.AircraftConnectionInfo info;
            if (MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraftNum!= null)
            {
                if (MainV2._aircraftInfo.TryGetValue(MainV2.CurrentAircraftNum, out info))
                {
                    DateTime now = DateTime.Now;
                    DateTime diff = new DateTime(0);
                    if (info.hasStartTime)
                    {
                        diff += now - info.StartOfTheFlightTime;
                        label2.Text = diff.ToString("HH.mm.ss");
                    }
                    else 
                    {
                        label2.Text = "00:00:00";
                    }
                }
                else
                {
                    label2.Text = "00:00:00";
                }
            }
            else
            {
                label2.Text = "00:00:00";
            }
            label3.Text = DateTime.Now.ToString("HH:mm");
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            //updateLabels();   
        }
    }
}
