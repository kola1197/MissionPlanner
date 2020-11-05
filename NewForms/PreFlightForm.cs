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
using MissionPlanner.Controls;
using System.IO;

namespace MissionPlanner.NewForms
{
    public partial class PreFlightForm : Form
    {
        Tabs selectedIndex = Tabs.Refuel;
        Tabs progressIndex = Tabs.Refuel;

        private enum Tabs
        {
            Refuel = 0,
            Calibration = 1,
            Checklist = 2,
            IceStart = 3,
            IceCheck = 4,
            Launch = 5
        }

        public PreFlightForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public void Init()
        {
            batt2_voltage.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString();
            LoadFuelText();
            iceRun1.Init();
            //updateARMButton();
        }

        private void LoadFuelText()
        {
            minCapacity.Text = MainV2.CurrentAircraft.MinCapacity.ToString();
            maxСapacity.Text = MainV2.CurrentAircraft.MaxCapacity.ToString();
            flightTimeTBox.Text = MainV2.CurrentAircraft.FuelPerTime.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedIndex == 0) // previos item was "preflight checkboxes"
            {
                if (checkListControl1.allRight())
                {
                    MainV2.logger.write("Все чекбоксы успешно пройдены");
                }
                else
                {
                    MainV2.logger.write("Следующие проблемы возникли при прохождении проверки:");
                    string[] text = new string[]
                    {
                        "Количество видимых спутников < 6",
                        "Задание не загружено на борт",
                        "Самолет не в Arm",
                        "Машинки не под напряжением или нейтрали не в норме",
                        "Нет реакции на СВЕТ/ЗВУК",
                        "Напряжение в бортовой цепи менее 11.5 вольт"
                    };
                    List<bool> b = checkListControl1.getCheckboxesState();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (!b[i])
                        {
                            MainV2.logger.write("Ошибка: " + text[i]);
                        }
                    }
                }
            }

            if (tabControl1.SelectedIndex > (int) progressIndex && false) //this check was canceled
            {
                tabControl1.SelectedIndex = (int) selectedIndex;
            }
            else
            {
                selectedIndex = (Tabs) tabControl1.SelectedIndex;
            }

            iceRun1.focused(false);
            if (selectedIndex == Tabs.IceStart)
            {
                iceRun1.focused(true);
            }

            if (selectedIndex == Tabs.IceCheck)
            {
                iceCheck1.focused(true);
            }
        }

        private void checkListNextBUT_Click(object sender, EventArgs e)
        {
            if (checkListControl1.allRight())
            {
                if (MainV2.comPort.MAV.cs.rpm1 < 3000)
                {
                    progressIndex = progressIndex > Tabs.IceStart ? progressIndex : Tabs.IceStart;
                    selectedIndex = Tabs.IceStart;
                    tabControl1.SelectedIndex = (int) selectedIndex;
                }
                else
                {
                    progressIndex = progressIndex > Tabs.IceCheck ? progressIndex : Tabs.IceCheck;
                    selectedIndex = Tabs.IceCheck;
                    tabControl1.SelectedIndex = (int) selectedIndex;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AirSpeedLabel.Text = MainV2.comPort.MAV.cs.airspeed.ToString() + " м/с";
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void gotReaction_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex > Tabs.Checklist ? progressIndex : Tabs.Checklist;
            selectedIndex = Tabs.Checklist;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void backButton2_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = (int) selectedIndex;
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

        public void SkipIceCheck()
        {
            iceCheckNextBUT_Click(this, new EventArgs());
        }


        private void batt2_voltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
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
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            AircraftConnectionInfo currentAircraft = MainV2.CurrentAircraft;

            float.TryParse(batt2_voltage.Text, out currentAircraft.Butt2RealVoltage);
            if (!currentAircraft.FuelSaved)
            {
                float.TryParse(maxСapacity.Text, out currentAircraft.MaxCapacity);
                float.TryParse(flightTimeTBox.Text, out currentAircraft.FuelPerTime);
                float.TryParse(minCapacity.Text, out currentAircraft.MinCapacity);
            }

            int percent = 0;
            //System.Diagnostics.Debug.WriteLine("update void");
            if (currentAircraft.MaxCapacity != 0)
            {
                double d = 100 * currentAircraft.Butt2RealVoltage / currentAircraft.MaxCapacity;
                percent = (int) d;
                System.Diagnostics.Debug.WriteLine(
                    currentAircraft.Butt2RealVoltage.ToString() + "   " +
                    currentAircraft.MaxCapacity.ToString() + "   " + d.ToString() + "   " +
                    percent.ToString());
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

        private void refuelNextButton_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex > Tabs.Calibration ? progressIndex : Tabs.Calibration;
            selectedIndex = Tabs.Calibration;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void iceStartNextBUT_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex > Tabs.IceCheck ? progressIndex : Tabs.IceCheck;
            selectedIndex = Tabs.IceCheck;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = (int) selectedIndex;
        }

        private void iceCheckNextBUT_Click(object sender, EventArgs e)
        {
            if (iceCheck1.iceChecked)
            {
                progressIndex = progressIndex > Tabs.Launch ? progressIndex : Tabs.Launch;
                selectedIndex = Tabs.Launch;
                tabControl1.SelectedIndex = (int) selectedIndex;
            }
        }

        public void EnableIceCheckNextButton()
        {
            iceCheckNextBut.Enabled = true;
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
                    sb.AppendLine(Encoding.ASCII.GetString(((MAVLink.mavlink_statustext_t) message.data).text)
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
            ((Control) sender).Enabled = false; //set 0 wp as current
            MainV2.setCurrentWP((ushort) 0);
            ((Control) sender).Enabled = true;
            MissionPlanner.AircraftConnectionInfo info;
            if (MainV2.Aircrafts.TryGetValue(MainV2.CurrentAircraftNum, out info))
            {
                info.StartOfTheFlightTime = DateTime.Now;
            }

            MainV2.comPort.setMode("Auto");
            MainV2.StatusMenuPanel.SitlEmulation.SetTargetState(SitlState.SitlStateName.Takeoff);
        }

        private void startCalibrationButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (
                CustomMessageBox.Show("Вы уверены, что хотите начать калибровку?", "Калибровка",
                    MessageBoxButtons.YesNo) == (int) DialogResult.Yes)
            {
                int param1 = 0;
                int param3 = 1;

                // request gyro
                if (MainV2.comPort.MAV.cs.firmware == Firmwares.ArduCopter2)
                {
                    param1 = 1; // gyro 
                }

                param3 = 1; // baro / airspeed
                if (!MainV2.comPort.doCommand(
                    (MAVLink.MAV_CMD) Enum.Parse(typeof(MAVLink.MAV_CMD), "PREFLIGHT_CALIBRATION"), param1, 0, param3,
                    0, 0, 0, 0))
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
            }
        }

        private void myButton5_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            AircraftConnectionInfo currentAircraft = MainV2.CurrentAircraft;

            float.TryParse(minCapacity.Text, out currentAircraft.MinCapacity);
            float.TryParse(maxСapacity.Text, out currentAircraft.MaxCapacity);
            float.TryParse(flightTimeTBox.Text, out currentAircraft.FuelPerTime);
            AircraftConnectionInfo info;
            if (MainV2.Aircrafts.TryGetValue(MainV2.CurrentAircraftNum, out info))
            {
                MissionPlanner.Controls.ConnectionControl.port_sysid port_Sysid =
                    (MissionPlanner.Controls.ConnectionControl.port_sysid) info.SysId;
                int id = port_Sysid.sysid;
                tryToSave(id);
            }

            currentAircraft.FuelSaved = true;

            //Todo: make bindings
            StatusControlPanel.instance.SetFuelPbMinMax();
        }

        private void tryToLoad(int id)
        {
            float[] values = new float[] {0, 0, 0};
            if (File.Exists(MainV2.defaultFuelSavePath + "_" + id.ToString() + ".txt"))
            {
                try
                {
                    StreamReader stream = new StreamReader(MainV2.defaultFuelSavePath + "_" + id.ToString() + ".txt");
                    for (int i = 0; i < 3; i++)
                    {
                        values[i] = float.Parse(stream.ReadLine());
                    }

                    minCapacity.Text = values[0].ToString();
                    maxСapacity.Text = values[1].ToString();
                    flightTimeTBox.Text = values[2].ToString();
                    MainV2.CurrentAircraft.MinCapacity =
                        float.Parse(minCapacity.Text); //double.TryParse(minCapacity.Text, out i) ? i : 0;
                    MainV2.CurrentAircraft.MaxCapacity =
                        float.Parse(maxСapacity.Text); //double.TryParse(maxСapacity.Text, out i) ? i : 0;
                    MainV2.CurrentAircraft.FuelPerTime =
                        float.Parse(flightTimeTBox.Text); //double.TryParse(flightTimeTBox.Text, out i) ? i : 0;
                }
                catch
                {
                }
            }
        }


        private void tryToSave(int id)
        {
            float[] values = new float[]
            {
                MainV2.CurrentAircraft.MinCapacity,
                MainV2.CurrentAircraft.MaxCapacity,
                MainV2.CurrentAircraft.FuelPerTime
            };
            StreamWriter stream = new StreamWriter(MainV2.defaultFuelSavePath + "_" + id.ToString() + ".txt", false);
            for (int i = 0; i < values.Length; i++)
            {
                stream.WriteLine(values[i]);
            }

            stream.Close();
        }

        private void myButton6_MouseUp(object sender, MouseEventArgs e)
        {
            minCapacity.Text = batt2_voltage.Text;
        }

        private void myButton7_MouseUp(object sender, MouseEventArgs e)
        {
            maxСapacity.Text = batt2_voltage.Text;
        }

        private void PreFlightForm_FormClosing(object sender, FormClosingEventArgs e) //release the engine
        {
            iceCheck1.focused(false);
            iceRun1.focused(false);
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}