using Flurl.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class DiagnosticForm : Form
    {
        //int debugCounter = 0;
        public DiagnosticForm()
        {
            InitializeComponent();
            this.Text = "Диагностика";
            //var list = MainV2.comPort.MAV.cs.GetItemList(true);
            //System.Diagnostics.Debug.WriteLine(list.ToString());
            //foreach (var v in list) 
            //{
            //    System.Diagnostics.Debug.WriteLine(v.ToString());
            //}
            timer1.Start();
            updateInfo();
        }

        private bool INSGood(out string s) 
        {
            bool result = true;                                                                                                     // IMU??????
            s = "Ok";
            if (!MainV2.comPort.MAV.cs.sensors_health.gps && MainV2.comPort.MAV.cs.sensors_enabled.gps && MainV2.comPort.MAV.cs.sensors_present.gps)     //BadGPSHealth
            {
                s = "BadGPSHealth";
                result = false;
            }
            else if (!MainV2.comPort.MAV.cs.sensors_health.gyro && MainV2.comPort.MAV.cs.sensors_enabled.gyro && MainV2.comPort.MAV.cs.sensors_present.gyro)               //BadGyroHealth
            {
                s = "BadGyroHealth";
                result = false;
            }
            else if (!MainV2.comPort.MAV.cs.sensors_health.barometer && MainV2.comPort.MAV.cs.sensors_enabled.barometer && MainV2.comPort.MAV.cs.sensors_present.barometer)      //BadBaroHealth
            {
                s = "BadBaroHealth";
                result = false;
            }
            else if (!MainV2.comPort.MAV.cs.sensors_health.ahrs && MainV2.comPort.MAV.cs.sensors_enabled.ahrs && MainV2.comPort.MAV.cs.sensors_present.ahrs)  //BadAHRS
            {
                s = "BadAHRS";
                result = false;
            }
            return result;
        }

        public void updateInfo()
        {
            label3.Text = MainV2.comPort.MAV.cs.ekfstatus.ToString();
            label5.Text = "( " + MainV2.comPort.MAV.cs.vibex.ToString("0.00") + "; " + MainV2.comPort.MAV.cs.vibey.ToString("0.00") + "; " + MainV2.comPort.MAV.cs.vibey.ToString("0.00") + " )";
            string s = "";
            label7.ForeColor = INSGood(out s) ? Color.Green : Color.Red;
            label7.Text = s;
            label9.Text = MainV2.comPort.MAV.cs.satcount.ToString();
        }

        private void butClickAction(int butNum)
        {
            if (MainV2.AircraftInfo.Count == 0)
            {
                MainV2.ConnectionsForm.Show();
                return;
            }

            if (MainV2.AircraftInfo.Count > butNum)
            {
                MainV2.ConnectionsForm.switchConnectedAircraft(MainV2.AircraftInfo.ElementAt(butNum).Value);
            }
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            butClickAction(0);
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            butClickAction(1);
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            butClickAction(2);
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            butClickAction(3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateInfo();
            //debugCounter++;
            //this.Text = "Диагностика: " + debugCounter.ToString();
        }
    }
}
