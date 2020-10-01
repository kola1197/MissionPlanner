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
        private bool testMode = true;
        bool ICERunning = false;
        private int engineoffCounter = 0;
        public ICERun()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabels();
            if (!testMode)
            {
                if (MainV2.comPort.MAV.cs.rpm1 > 3000)
                {
                     ICERunning = true;
                     startButton.Text = "Заглушить";
                     startButton.Enabled = false;
                     label3.Text = "Идет нагрев двигателя";
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

            if (!startButton.Enabled && MainV2.comPort.MAV.cs.rpm2 > 40)   // temp > 40
            {
                startButton.Enabled = true;
                label3.Text = "Температура двигателя ОК»;";
                label3.ForeColor = Color.Green;
            }

            if (engineoffCounter > 1)
            {
                engineoffCounter--;
                System.Diagnostics.Debug.Write("=====================EngineCounter = "+engineoffCounter.ToString());
            }

            if (engineoffCounter == 1)
            {
                engineoffCounter--;
                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)1500);
            }
        }

        private void updateLabels() 
        {
            spedsLabel.Text = MainV2.comPort.MAV.cs.rpm1.ToString();
            tempLabel.Text = MainV2.comPort.MAV.cs.rpm2.ToString();
        }

        private void startButton_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            if (ICERunning)
            {
                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)900);
                if (testMode)
                {
                    startButton.Text = "Запустить";
                    ICERunning = false;
                }
                System.Diagnostics.Debug.Write("DISABLE +++++++++++++++");
            }
            else
            {
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 10, 1900, 0, 0, 0, 0, 0);
                if (testMode)
                {
                    startButton.Text = "Заглушить";
                    ICERunning = true;
                }
                engineoffCounter = 600;
                System.Diagnostics.Debug.Write("ENABLE +++++++++++++++");
            }
        }
    }
}
