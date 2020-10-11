using Microsoft.CodeAnalysis.CSharp.Syntax;
using MissionPlanner.ArduPilot;
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
    public partial class PreFlightForm : Form
    {
        int selectedIndex = 0;
        int progressIndex = 0;
        public PreFlightForm()
        {
            InitializeComponent();
            this.TopMost = true;
            batt2_voltage.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString();
            //updateARMButton();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > progressIndex && false)      //this check was canceled
            {
                tabControl1.SelectedIndex = selectedIndex;
            }
            else 
            {
                selectedIndex = tabControl1.SelectedIndex;
            }
            iceRun1.focused(false);
            if (selectedIndex == 3) 
            {
                iceRun1.focused(true);
            }
            if (selectedIndex == 4)
            {
                iceCheck1.focused(true);
            }
        }

        private void nextButton1_Click(object sender, EventArgs e)
        {
            if (checkListControl1.allRight()) 
            {
                progressIndex = progressIndex > 1 ? progressIndex : 1;
                selectedIndex = 1;
                tabControl1.SelectedIndex = selectedIndex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AirSpeedLabel.Text = MainV2.comPort.MAV.cs.airspeed.ToString();
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void gotReaction_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex > 2 ? progressIndex : 2;
            selectedIndex = 2;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void backButton2_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                batt2_voltage.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString();
                updateMainV2Data();
            }
        }

        private void maxСapacity_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        

        private void batt2_voltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
            checkBox1.Checked = false;
            //updateMainV2Data();
        }
        //      public int maxCapacity = 0;
        //      public int flyTime = 0;
        //      public int butt2RealVoltage = 0;

        private void updateMainV2Data() 
        {
            int i;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].butt2RealVoltage = int.TryParse(batt2_voltage.Text, out i) ? i : 0;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].maxCapacity = int.TryParse(maxСapacity.Text, out i) ? i : 0;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].fuelPerTime = int.TryParse(flightTimeTBox.Text, out i) ? i : 0;
            int percent = 0;
            //System.Diagnostics.Debug.WriteLine("update void");
            if (MainV2.AircraftInfo[MainV2.CurrentAircraftNum].maxCapacity != 0)
            {
                double d = 100 * MainV2.AircraftInfo[MainV2.CurrentAircraftNum].butt2RealVoltage / MainV2.AircraftInfo[MainV2.CurrentAircraftNum].maxCapacity;
                percent = (int) d;
                System.Diagnostics.Debug.WriteLine(MainV2.AircraftInfo[MainV2.CurrentAircraftNum].butt2RealVoltage.ToString() + "   " + MainV2.AircraftInfo[MainV2.CurrentAircraftNum].maxCapacity.ToString() + "   " + d.ToString() + "   " + percent.ToString());
            }
            valueInPercentsTBox.Text = percent.ToString();
        }

        private void batt2_voltage_TextChanged(object sender, EventArgs e)
        {
            updateMainV2Data();
        }

        private void valueInPercentsTBox_KeyUp(object sender, KeyEventArgs e)
        {
            updateMainV2Data();
        }

        private void nextButton2_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.rpm1 < 3000)
            {
                progressIndex = progressIndex > 3 ? progressIndex : 3;
                selectedIndex = 3;
                tabControl1.SelectedIndex = selectedIndex;
            }
            else 
            {
                progressIndex = progressIndex > 4 ? progressIndex : 4;
                selectedIndex = 4;
                tabControl1.SelectedIndex = selectedIndex;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex >4 ? progressIndex : 4;
            selectedIndex = 4;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            if (iceCheck1.iceChecked)
            {
                progressIndex = progressIndex > 5 ? progressIndex : 5;
                selectedIndex = 5;
                tabControl1.SelectedIndex = selectedIndex;
            }
        }

        private void startCalibrationButton_Click(object sender, EventArgs e)
        {

        }


        private void arm()
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            // arm the MAV
            try
            {
                var isitarmed = MainV2.comPort.MAV.cs.armed;
                var action = MainV2.comPort.MAV.cs.armed ? "Disarm" : "Arm";

                if (isitarmed)
                    if (CustomMessageBox.Show("Are you sure you want to " + action, action,
                            CustomMessageBox.MessageBoxButtons.YesNo) !=
                        CustomMessageBox.DialogResult.Yes)
                        return;
                StringBuilder sb = new StringBuilder();
                var sub = MainV2.comPort.SubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.STATUSTEXT, message =>
                {
                    sb.AppendLine(Encoding.ASCII.GetString(((MAVLink.mavlink_statustext_t)message.data).text)
                        .TrimEnd('\0'));
                    return true;
                });
                bool ans = MainV2.comPort.doARM(!isitarmed);
                MainV2.comPort.UnSubscribeToPacketType(sub);
                /*if (ans == false)
                {
                    if (CustomMessageBox.Show(
                            action + " failed.\n" + sb.ToString() + "\nForce " + action +
                            " can bypass safety checks,\nwhich can lead to the vehicle crashing\nand causing serious injuries.\n\nDo you wish to Force " +
                            action + "?", Strings.ERROR, CustomMessageBox.MessageBoxButtons.YesNo,
                            CustomMessageBox.MessageBoxIcon.Exclamation, "Force " + action, "Cancel") ==
                        CustomMessageBox.DialogResult.Yes)
                    {
                        ans = MainV2.comPort.doARM(!isitarmed, true);
                        if (ans == false)
                        {
                            CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                        }
                    }
                }*/
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        private void updateARMButton() 
        {
            if (MainV2.comPort.MAV.cs.armed)
            {
                armButton.Text = "Disarm";
            }
            else 
            {
                armButton.Text = "Arm";
            }
        }
        private void armButton_Click(object sender, EventArgs e)
        {
            arm();
            //updateARMButton();
        }

        private void myButton3_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Enabled = false;            //set 0 wp as current
            MainV2.setCurrentWP((ushort)0);
            ((Control)sender).Enabled = true;
            Orlan.AircraftConnectionInfo info;
            if (MainV2.AircraftInfo.TryGetValue(MainV2.CurrentAircraftNum, out info))
            {
                info.StartOfTheFlightTime = DateTime.Now;
            }
            MainV2.comPort.setMode("Auto");
        }

        private void startCalibrationButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (
                   CustomMessageBox.Show("Вы уверены, что хотите начать калибровку?", "Action",
                       MessageBoxButtons.YesNo) == (int)DialogResult.Yes)
            {
                int param1 = 0;
                int param3 = 1;

                // request gyro
                if (MainV2.comPort.MAV.cs.firmware == Firmwares.ArduCopter2)
                {
                    param1 = 1; // gyro 
                }
                param3 = 1; // baro / airspeed
                if (!MainV2.comPort.doCommand((MAVLink.MAV_CMD)Enum.Parse(typeof(MAVLink.MAV_CMD), "PREFLIGHT_CALIBRATION"), param1, 0, param3, 0, 0, 0, 0))
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
            }
        }

        private void myButton5_MouseUp(object sender, MouseEventArgs e)
        {
            int i = 0;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].minCapacity = int.TryParse(textBox1.Text, out i) ? i : 0;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].maxCapacity = int.TryParse(maxСapacity.Text, out i) ? i : 0;
            MainV2.AircraftInfo[MainV2.CurrentAircraftNum].fuelPerTime = int.TryParse(flightTimeTBox.Text, out i) ? i : 0;
        }

        private void myButton6_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Text = batt2_voltage.Text;
        }

        private void myButton7_MouseUp(object sender, MouseEventArgs e)
        {
            maxСapacity.Text = batt2_voltage.Text;
        }

        private void PreFlightForm_FormClosing(object sender, FormClosingEventArgs e)       //release the engine
        {
            iceCheck1.focused(false);
            iceRun1.focused(false);
        }
    }
}
