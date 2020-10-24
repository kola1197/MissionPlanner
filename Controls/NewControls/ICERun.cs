﻿using System;
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
        private bool testMode = false;
        bool ICERunning = false;
        private int engineoffCounter = 0;
        private int key = -1;
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
                }

                if (MainV2.comPort.MAV.cs.rpm1 < 2500)
                {
                     ICERunning = false;
                     startButton.Text = "Запустить двигатель";
                     //MainV2.comPort.MAV.cs.ch10in = 900;
                     MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 10, 900, 0, 0, 0, 0, 0);
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
                //MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)1500);
                float f = MainV2.comPort.GetParam("SERVO3_TRIM");
                if (!MainV2.engineController.setEngineValue(f, key))
                {
                    CustomMessageBox.Show("Двигатель занят в другом потоке");
                }
            }
        }

        public void focused(bool b)  //need to get engine key 
        {
            if (b)
            {
                key = MainV2.engineController.getAccessKeyToEngine();
            }
            else 
            {
                MainV2.engineController.resetKey();
                key = -1;
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
                if (!MainV2.engineController.setEngineValue(900f, key))
                {
                    CustomMessageBox.Show("Двигатель занят в другом потоке");
                }
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 10, 900, 0, 0, 0, 0, 0);
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
                engineoffCounter = 300;
                System.Diagnostics.Debug.Write("ENABLE +++++++++++++++");
            }
        }
    }
}
