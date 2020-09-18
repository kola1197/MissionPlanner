using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.ArduPilot;
using MissionPlanner.Comms;
using MissionPlanner.Controls;
using MissionPlanner.GCSViews;
using MissionPlanner.Orlan;
using MissionPlanner.Utilities;

namespace MissionPlanner
{
    public partial class ConnectionsForm : Form
    {
        // [DllImport("user32.dll", CharSet = CharSet.Auto)]
        // private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        // const int EM_SETCUEBANNER = 0x1501;

        public SITL sitlForm { get; set; }

        private bool waterMarkAircraftNumActive = true;
        private bool waterMarkConnectedNumActive = true;

        public static ConnectionsForm instance;

        private static Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);

        private string connectText = "Подключить";
        private string disconnectText = "Отключить";

        public ConnectionsForm()
        {
            InitializeComponent();

            // SendMessage(aircraftNumber_TB.Handle, EM_SETCUEBANNER, 1, "Number");

            UpdateComPorts();

            ThemeManager.ApplyThemeTo(this);

            connectedAircraftNum_TB.ForeColor = Color.Gray;
            connectedAircraftNum_TB.Text = "введите номер";

            aircraftNumber_TB.ForeColor = Color.Gray;
            aircraftNumber_TB.Text = "номер";

            Tracking.AddPage(this.GetType().ToString(), this.Text);

            instance = this;
        }

        public void UpdateComPorts()
        {
            CMB_serialport.Items.Clear();
            CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            CMB_serialport.Items.Add("TCP");
            CMB_serialport.Items.Add("UDP");
            CMB_serialport.Items.Add("UDPCl");
            CMB_serialport.Items.Add("WS");
        }

        private void ConnectionsForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void paint_TB_waterMark(TextBox textBox, bool isMarked)
        {
            textBox.GotFocus += (source, eventArgs) =>
            {
                if (isMarked)
                {
                    isMarked = false;
                    if (MainV2._aircraftInfo.Count == 0 || textBox == aircraftNumber_TB)
                    {
                        textBox.Text = "";
                    }
                    else
                    {
                        textBox.Text = devices_LB.SelectedItem.ToString();
                    }

                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (source, eventArgs) =>
            {
                if (!isMarked && String.IsNullOrEmpty(textBox.Text))
                {
                    isMarked = true;
                    textBox.Text = "номер";
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paint_TB_waterMark(aircraftNumber_TB, waterMarkAircraftNumActive);
            paint_TB_waterMark(connectedAircraftNum_TB, waterMarkConnectedNumActive);
            Invalidate();
        }

        private void ConnectionsForm_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void ConnectionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void SetToDefault()
        {
            panel1.Enabled = true;
            connect_BUT.Text = connectText;
            connect_BUT.Enabled = true;
        }

        private void connectAircraft(object sender)
        {
            AircraftConnectionInfo connectedAircraft = MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()];
            if (useAntenna_CheckBox.Checked)
            {
                if (sysid_cmb.SelectedItem == null)
                    return;
                connectedAircraft.SerialPort = MainV2._AntennaConnectionInfo.SerialPort;
                connectedAircraft.Speed = MainV2._AntennaConnectionInfo.Speed;
                connectedAircraft.Connected = true;
                connectedAircraft.SysId = sysid_cmb.SelectedItem;
                connectedAircraft.UsingAntenna = true;
                switchConnectedAircraft(connectedAircraft);
                panel1.Enabled = false;
                connect_BUT.Text = disconnectText;
                // connect_BUT.Enabled = false;
                return;
            }

            if (useSITL_CheckBox.Checked)
            {
                MainV2.instance.MenuSimulation_Click(sender, EventArgs.Empty);
                sitlForm.aircraftSITLInfo = MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()];
                sitlForm.aircraftSITLInfo.UsingSITL = true;
                sitlForm.aircraftSITLInfo.Connected = true;

                panel1.Enabled = false;
                connect_BUT.Text = disconnectText;

                this.Hide();
                return;
            }

            if (CMB_serialport.SelectedItem == null)
            {
                CustomMessageBox.Show("Задайте порт подключения", "Не выбран порт подключения");
                return;
            }

            this.TopMost = false;

            var mav = new MAVLinkInterface();

            try
            {
                MainV2.instance.doConnect(mav, CMB_serialport.Text, CMB_baudrate.Text);
                Thread.Sleep(1000);                              // i do not know why, but it helps with crash on params loading

                MainV2.Comports.Add(mav);

                MainV2._connectionControl.UpdateSysIDS();


                connectedAircraft.SerialPort = CMB_serialport.SelectedItem.ToString();

                if (CMB_baudrate.SelectedItem != null)
                {
                    connectedAircraft.Speed = CMB_baudrate.SelectedItem;
                }

                connectedAircraft.SysId =
                    MainV2._connectionControl.cmb_sysid.Items[MainV2._connectionControl.cmb_sysid.Items.Count - 1];
                connectedAircraft.Connected = true;
                panel1.Enabled = false;
                connect_BUT.Text = disconnectText;

                switchConnectedAircraft(connectedAircraft);
            }
            catch (Exception)
            {
            }

            this.TopMost = true;
        }

        private void disconnectAircraft()
        {
            AircraftConnectionInfo selectedAircraft = MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()];

            if (selectedAircraft.UsingAntenna)
            {
                switchToAntenna();
                selectedAircraft.Connected = false;
                selectedAircraft.SysId = null;
                selectedAircraft.UsingSITL = false;
                selectedAircraft.UsingAntenna = false;
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
                return;
            }

            if (selectedAircraft.SysId == null)
            {
                selectedAircraft.Connected = false;
                selectedAircraft.UsingSITL = false;
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
                return;
            }

            var temp = (ConnectionControl.port_sysid) selectedAircraft.SysId;

            try
            {
                MainV2.instance.doDisconnect(temp.port);

                MainV2._connectionControl.UpdateSysIDS();

                if (MainV2.comPort.BaseStream.IsOpen)
                    MainV2.instance.loadph_serial();

                selectedAircraft.Connected = false;
                selectedAircraft.SysId = null;
                selectedAircraft.UsingSITL = false;
                MainV2.StopUpdates();
                MainV2._aircraftMenuControl.updateAllAircraftButtonTexts();

                panel1.Enabled = true;
                connect_BUT.Text = connectText;
            }
            catch (Exception)
            {
            }
        }

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            if (MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()].Connected)
            {
                disconnectAircraft();
            }
            else
            {
                connectAircraft(sender);
            }
        }

        private void addAircraft_BT_Click(object sender, EventArgs e)
        {
            if (MainV2._aircraftInfo.Count > 4 || MainV2._aircraftInfo.Keys.Contains(aircraftNumber_TB.Text) ||
                aircraftNumber_TB.Text.Equals("") || !regex.IsMatch(aircraftNumber_TB.Text))
                return;

            addAircraft(aircraftNumber_TB.Text);
        }

        public void addAircraft(string aircraftNumber)
        {
            MainV2._aircraftInfo.Add(aircraftNumber, new AircraftConnectionInfo());
            devices_LB.Items.Add(aircraftNumber);
            devices_LB.SetSelected(devices_LB.Items.Count - 1, true);
            MainV2._aircraftMenuControl.setAircraftButtonDefaultText(
                MainV2._aircraftInfo[aircraftNumber].MenuNum, aircraftNumber);
            MainV2._aircraftMenuControl.updateAircraftButtonText(MainV2._aircraftInfo[aircraftNumber].MenuNum);
            panel1.Enabled = true;
            aircraftNumber_TB.Text = "";
        }

        public void switchToAntenna()
        {
            if (MainV2._AntennaConnectionInfo.SysId == null)
                return;

            var temp = (ConnectionControl.port_sysid) MainV2._AntennaConnectionInfo.SysId;

            foreach (var port in MainV2.Comports)
            {
                if (port == temp.port)
                {
                    MainV2.comPort = port;
                    MainV2.comPort.sysidcurrent = temp.sysid;
                    MainV2.comPort.compidcurrent = temp.compid;

                    if (MainV2.comPort.MAV.param.Count == 0 && Control.ModifierKeys != Keys.Control)
                        MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                            (byte) MainV2.comPort.compidcurrent);

                    MainV2.View.Reload();
                }
            }
        }

        public void switchConnectedAircraft(AircraftConnectionInfo selectedAircraft)
        {
            if (selectedAircraft.SysId == null)
                return;

            var temp = (ConnectionControl.port_sysid) selectedAircraft.SysId;

            foreach (var port in MainV2.Comports)
            {
                if (port == temp.port)
                {
                    MainV2.comPort = port;
                    MainV2.comPort.sysidcurrent = temp.sysid;
                    MainV2.comPort.compidcurrent = temp.compid;

                    if (MainV2.comPort.MAV.param.Count == 0 && Control.ModifierKeys != Keys.Control)
                        MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                            (byte) MainV2.comPort.compidcurrent);

                    MainV2.CurrentAircraftNum =
                        MainV2._aircraftInfo.FirstOrDefault(x => x.Value == selectedAircraft).Key;
                    devices_LB.SelectedItem = MainV2.CurrentAircraftNum;
                    MainV2.View.Reload();
                }
            }
        }

        private void devices_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AircraftConnectionInfo selectedAircraft = MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()];
            connectedAircraftNum_TB.Text = devices_LB.SelectedItem.ToString();
            connectedAircraftName_TB.Text = selectedAircraft.Name;
            useSITL_CheckBox.Checked = selectedAircraft.UsingSITL;
            useAntenna_CheckBox.Checked = selectedAircraft.UsingAntenna;

            if (selectedAircraft.Connected)
            {
                CMB_serialport.SelectedIndex = CMB_serialport.Items.IndexOf(selectedAircraft.SerialPort);
                CMB_baudrate.SelectedIndex = CMB_baudrate.Items.IndexOf(selectedAircraft.Speed);

                panel1.Enabled = false;
                if (selectedAircraft.UsingAntenna)
                {
                    connect_BUT.Enabled = false;
                }

                connect_BUT.Text = disconnectText;
                if (!devices_LB.SelectedItem.ToString().Equals(MainV2.CurrentAircraftNum))
                {
                    switchConnectedAircraft(selectedAircraft);
                }
            }
            else
            {
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
            }
        }


        private void reload_BUT_Click(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        private void useSITL_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useSITL_CheckBox.Checked)
            {
                CMB_serialport.Enabled = false;
                CMB_baudrate.Enabled = false;
            }
            else
            {
                CMB_serialport.Enabled = true;
                CMB_baudrate.Enabled = true;
            }
        }

        private void aircraftNumber_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void connectedAircraftNum_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void connectedAircraftNum_TB_TextChanged(object sender, EventArgs e)
        {
            if (MainV2._aircraftInfo == null || MainV2._aircraftInfo.Keys.Contains(aircraftNumber_TB.Text) ||
                aircraftNumber_TB.Text.Equals("") || !regex.IsMatch(aircraftNumber_TB.Text))
                return;

            var oldAircraftNumber = devices_LB.SelectedItem.ToString();
            var newAircraftNumber = connectedAircraftNum_TB.Text;
            renameAircraftNum(MainV2._aircraftInfo, oldAircraftNumber, newAircraftNumber);
        }

        public static void renameAircraftNum(Dictionary<string, AircraftConnectionInfo> dic, string fromKey,
            string toKey)
        {
            AircraftConnectionInfo value = dic[fromKey];
            dic.Remove(fromKey);
            dic.Add(toKey, value);
        }

        private void useAntenna_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            antennaPanel.Enabled = !antennaPanel.Enabled;
            CMB_baudrate.Enabled = !CMB_baudrate.Enabled;
            CMB_serialport.Enabled = !CMB_serialport.Enabled;
            useSITL_CheckBox.Enabled = !useSITL_CheckBox.Enabled;
            UpdateSysId();
        }

        private void UpdateSysId()
        {
            sysid_cmb.Items.Clear();

            int selectidx = -1;

            foreach (var port in MainV2.Comports.ToArray())
            {
                var list = port.MAVlist.GetRawIDS();

                foreach (int item in list)
                {
                    var temp = new ConnectionControl.port_sysid()
                        {compid = (item % 256), sysid = (item / 256), port = port};

                    var idx = sysid_cmb.Items.Add(temp);

                    if (temp.port == MainV2.comPort && temp.sysid == MainV2.comPort.sysidcurrent &&
                        temp.compid == MainV2.comPort.compidcurrent)
                    {
                        selectidx = idx;
                    }
                }
            }
        }

        private void sysid_cmb_Format(object sender, ListControlConvertEventArgs e)
        {
            var temp = (ConnectionControl.port_sysid) e.Value;
            MAVLink.MAV_COMPONENT compid = (MAVLink.MAV_COMPONENT) temp.compid;
            string mavComponentHeader = "MAV_COMP_ID_";
            string mavComponentString = null;

            foreach (var port in MainV2.Comports)
            {
                if (port == temp.port)
                {
                    if (compid == (MAVLink.MAV_COMPONENT) 1)
                    {
                        //use Autopilot type as displaystring instead of "FCS1"
                        mavComponentString = port.MAVlist[temp.sysid, temp.compid].aptype.ToString();
                    }
                    else
                    {
                        //use name from enum if it exists, use the component ID otherwise
                        mavComponentString = compid.ToString();
                        if (mavComponentString.Length > mavComponentHeader.Length)
                        {
                            //remove "MAV_COMP_ID_" header
                            mavComponentString = mavComponentString.Remove(0, mavComponentHeader.Length);
                        }

                        if (temp.port.MAVlist[temp.sysid, temp.compid].CANNode)
                            mavComponentString =
                                temp.compid + " " + temp.port.MAVlist[temp.sysid, temp.compid].VersionString;
                    }

                    e.Value = temp.port.BaseStream.PortName + "-" + ((int) temp.sysid) + "-" +
                              mavComponentString.Replace("_", " ");
                }
            }
        }

        private void updateSysId_BUT_Click(object sender, EventArgs e)
        {
            UpdateSysId();
        }
    }
}