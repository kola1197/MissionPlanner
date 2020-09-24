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
    public partial class FlightByCompassControl : UserControl
    {
        private bool enabled = false;
        private float Kp = 4f;
        private float Ki = 0.2f;
        private float Kd = 1f;
        private float directValue = 0;
        private float integral = 0;
        private float preError = 0;
        public FlightByCompassControl()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            directionNowLabel.Text = MainV2.comPort.MAV.cs.connected ? MainV2.comPort.MAV.cs.nav_bearing.ToString() : "null";
            if (enabled)
            {
                computePID();
            }
        }

        private void FlightByCompassControl_VisibleChanged(object sender, EventArgs e)
        {
            timer1.Enabled = this.Visible;
        }

        private void computePID() 
        {
            float dt = timer1.Interval;
            dt /= 1000;
            float error = MainV2.comPort.MAV.cs.nav_bearing - directValue;
            while (error > 180)
            {
                error -= 360;
            }
            while (error < -180)
            {
                error += 360;
            }
            float outputDiff = 0;


            float Pout = Kp * error;

            integral += error * dt;                               //we have the same time with timer
            float Iout = Ki * integral;

            float derevative = (error - preError) / dt;           //we have the same time with timer
            float Dout = Kd * derevative;

            float output = Pout + Iout + Dout;
            output /= 100;
            
            System.Diagnostics.Debug.WriteLine("PID answer: " + output.ToString());
            /*MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                        MAVLink.MAV_CMD.DO_SET_SERVO, 2, output, 0, 0,
                        0, 0, 0);
            */

            preError = error;
        }

        private void turnOnButton_MouseUp(object sender, MouseEventArgs e)
        {
            enabled = !enabled;
            if (enabled)
            {
                turnOnButton.Text = "Выключить";
                float.TryParse(directionNowLabel.Text, out directValue);
            }
            else 
            {
                turnOnButton.Text = "Включить";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
