using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.ArduPilot;
using MissionPlanner.Comms;
using MissionPlanner.Controls.BackstageView;
using MissionPlanner;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class AntennaControl : UserControl
    {
        private string connectText = "Подключить";
        private string disconnectText = "Отключить";
        private string antennaNumber = "АНТ";
        public static AntennaControl Instance;

        public AntennaControl()
        {
            InitializeComponent();

            ThemeManager.ApplyThemeTo(this);
            this.BackColor = Color.FromArgb(32, 32, 32);

            antennaBindingSource.DataSource = MainV2.AntennaConnectionInfo;
            switchAntenna_CB.DataBindings.Add("Checked", antennaBindingSource, "Active");
            autoMode_BUT.DataBindings.Add("Enabled", antennaBindingSource, "Active");
            stopMode_BUT.DataBindings.Add("Enabled", antennaBindingSource, "Active");
            testAntButton.DataBindings.Add("Enabled", antennaBindingSource, "Active");
            myTrackBar1.DataBindings.Add("Enabled", antennaBindingSource, "Active");
                Instance = this;
            //Tracking.AddPage(this.GetType().ToString(), this.Text);
        }

        private void BackgroundSwitchToAntenna(bool paramLoad)
        {
            try
            {
                // if (!paramLoad)
                // {
                //     await ConnectionsForm.instance.SwitchToAntenna(paramLoad);
                // }
                // else
                // {
                //     ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                //     {
                //         ConnectionsForm.instance.SwitchToAntenna(paramLoad);
                //     }));
                // }

                ConnectionsForm.instance.SwitchToAntenna(paramLoad);
                Thread.Sleep(100);
            }
            catch
            {
            }
        }

        private void ReconnectToAircraft()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                ConnectionsForm.instance.SwitchConnectedAircraft(MainV2.Aircrafts[MainV2.CurrentAircraftNum]);
            }
        }

        private void BackgroundSwitcherTask(string mode)
        {
            try
            {
                if (MainV2.comPort.sysidcurrent != MainV2.AntennaConnectionInfo.SysIdNum)
                {
                    CustomMessageBox.Show("Переключитесь на антенну.");
                    return;
                }

                // BackgroundSwitchToAntenna(false);

                // var temp = (ConnectionControl.port_sysid) MainV2._AntennaConnectionInfo?.SysId;
                MainV2.comPort.setMode((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent, mode);

                // Thread.Sleep(100);

                UpdateControls();
            }
            catch
            {
                // CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        private void ChangeMode(string mode)
        {
            // var queueUserWorkItem = ThreadPool.QueueUserWorkItem((WaitCallback) delegate(object state)
            // {
            //     BackgroundSwitcherTask(mode);
            // });
            BackgroundSwitcherTask(mode);

            // Task.Run(() => { BackgroundSwitcherTask(mode); });
        }

        private void UpdateComPorts()
        {
            CMB_serialport.Items.Clear();
            CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            CMB_serialport.Items.Add("TCP");
            CMB_serialport.Items.Add("UDP");
            CMB_serialport.Items.Add("UDPCl");
            CMB_serialport.Items.Add("WS");
        }

        private void reload_BUT_Click(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        private void FindAntennaOnPort()
        {
        }


        private ConnectionControl.port_sysid GetAntennaSysId()
        {
            var antennaSysIdNum = MainV2.AntennaConnectionInfo.SysIdNum;
            foreach (var item in MainV2._connectionControl.cmb_sysid.Items)
            {
                ConnectionControl.port_sysid portSysId = (ConnectionControl.port_sysid) item;
                if (portSysId.sysid == antennaSysIdNum && portSysId.port.BaseStream != null &&
                    portSysId.port.BaseStream.IsOpen)
                {
                    return portSysId;
                }
            }

            CustomMessageBox.Show("Проверьте SYSID_THISMAV антенны, он должен быть = " + antennaSysIdNum,
                "Некорректное подключение к антенне!");

            return new ConnectionControl.port_sysid();
        }

        private void ConnectAntenna(object sender)
        {
            if (CMB_serialport.SelectedItem == null)
            {
                CustomMessageBox.Show("Задайте порт подключения", "Не выбран порт подключения");
                return;
            }

            var mav = new MAVLinkInterface();
            AntennaConnectionInfo antenna = MainV2.AntennaConnectionInfo;

            antenna.Connected = antenna.Active = true;
            connect_BUT.Text = disconnectText;
            try
            {
                MainV2.instance.doConnect(mav, CMB_serialport.Text, CMB_baudrate.Text, true);

                MainV2.Comports.Add(mav);

                if (MainV2.comPort.BaseStream.IsOpen)
                    MainV2.instance.loadph_serial();

                System.Threading.Thread.Sleep(100);
                antenna.SerialPort = CMB_serialport.SelectedItem.ToString();

                if (CMB_baudrate.SelectedItem != null)
                {
                    antenna.Speed = CMB_baudrate.GetItemText(CMB_baudrate.SelectedItem);
                }

                MainV2._connectionControl.UpdateSysIDS();
                antenna.SysId = GetAntennaSysId();

                timer1.Enabled = true;

                if (((ConnectionControl.port_sysid) antenna.SysId).port == null)
                {
                    // DisconnectAntenna();
                }
                else
                {
                    BackgroundSwitchToAntenna(true);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private bool HasAntennaConnectedAircraft()
        {
            foreach (var aircraft in MainV2.Aircrafts.Values)
            {
                if (aircraft.Connected && aircraft.UsingAntenna)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void DisconnectAntennaAsync()
        {
            if (HasAntennaConnectedAircraft())
            {
                CustomMessageBox.Show("Перед отключением антенны отключите все борты, подключенные к антенне.",
                    "Внимание!");
                return;
            }
            
            AntennaConnectionInfo antenna = MainV2.AntennaConnectionInfo;

            var temp = (ConnectionControl.port_sysid) antenna.SysId;

            try
            {
                MainV2.instance.doDisconnect(temp.port);

                MainV2._connectionControl.UpdateSysIDS();

                if (MainV2.comPort.BaseStream.IsOpen)
                    MainV2.instance.loadph_serial();

                ConnectionsForm.instance.CloseComPort();

                antenna.Connected = antenna.Active = false;
                antenna.SysId = null;
                antenna.UsingSitl = false;
                MainV2.StopUpdates();
                MainV2.AircraftMenuControl.updateAllAircraftButtonTexts();
                connect_BUT.Text = connectText;
                timer1.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void DisconnectAntenna()
        {
            DisconnectAntennaAsync();
        }

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            if (MainV2.AntennaConnectionInfo.Connected)
            {
                DisconnectAntenna();
            }
            else
            {
                ConnectAntenna(sender);
            }
        }

        private void CMB_serialport_DropDown(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        public void ShowCurrentBaudInCmb()
        {
            CMB_baudrate.SelectedIndex = CMB_baudrate.FindString(MainV2.AntennaConnectionInfo.Speed);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainV2.AntennaConnectionInfo.SysId == null)
            {
                // CustomMessageBox.Show("sysid == null");
                return;
            }

            CMB_baudrate.SelectedIndex = CMB_baudrate.FindString(MainV2.AntennaConnectionInfo.Speed);

            UpdateControls();
        }

        private void UpdateControls()
        {
            antennaBindingSource.ResetBindings(false);

            if (!MainV2.AntennaConnectionInfo.Connected)
            {
                return;
            }
            
            var temp = (ConnectionControl.port_sysid) MainV2.AntennaConnectionInfo.SysId;
            foreach (var port in MainV2.Comports)
            {
                // draw the mavs seen on this port
                foreach (var MAV in port.MAVlist)
                {
                    if (MAV.cs.firmware == Firmwares.ArduTracker)
                    {
                        heading_label.Text = Math.Round(MAV.cs.yaw) + "°";
                        satNum_label.Text = MAV.cs.satcount.ToString();
                        mode_label.Text = MAV.cs.mode;
                        lbl_yawpwm.Text = MAV.cs.ch1out.ToString();
                    }
                }
            }
        }

        private void autoMode_BUT_Click(object sender, EventArgs e)
        {
            ChangeMode("AUTO");
        }

        private void stopMode_BUT_Click(object sender, EventArgs e)
        {
            ChangeMode("STOP");
        }

        private void manualMode_BUT_Click(object sender, EventArgs e)
        {
            ChangeMode("SERVO_TEST");
        }

        private void BUT_test_yaw_Click(object sender, EventArgs e)
        {
            double output = 1500;
            MavlinkNumericUpDown mavMinNumUD = new MavlinkNumericUpDown();
            MavlinkNumericUpDown mavMaxNumUD = new MavlinkNumericUpDown();
            mavMinNumUD.setup(900, 2200, 1, 1, "RC1_MIN", MainV2.comPort.MAV.param);
            mavMaxNumUD.setup(900, 2200, 1, 1, "RC1_MAX", MainV2.comPort.MAV.param);
            // if (!mavlinkCheckBox1.Checked)
            {
                output = map(myTrackBar1.Value, myTrackBar1.Maximum, myTrackBar1.Minimum,
                    (double) mavMinNumUD.Value, (double) mavMaxNumUD.Value);
            }
            // else
            // {
            //     output = map(myTrackBar1.Value, myTrackBar1.Minimum, myTrackBar1.Maximum,
            //         (double)mavlinkNumericUpDown1.Value, (double)mavlinkNumericUpDown2.Value);
            // }

            try
            {
                MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 1, (float) output, 0, 0, 0, 0, 0);

                UpdateControls();
            }
            catch
            { 
                // CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

        private double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        private void switchAntenna_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (MainV2.AntennaConnectionInfo.Connected)
            {
                if (MainV2.AntennaConnectionInfo.Active)
                {
                    ReconnectToAircraft();
                }
                else
                {
                    ConnectionsForm.instance.SwitchToAntenna(false);
                }
            }
            else
            {
                SetAntennaState(MainV2.AntennaConnectionInfo.Active);
            }
        }

        public void SetAntennaState(bool active)
        {
            switchAntenna_CB.CheckedChanged -= switchAntenna_CB_CheckedChanged;
            MainV2.AntennaConnectionInfo.Active = active;
            UpdateControls();
            switchAntenna_CB.CheckedChanged += switchAntenna_CB_CheckedChanged;
        }
    }
}