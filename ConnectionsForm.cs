using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            MissionPlanner.Utilities.Tracking.AddPage(this.GetType().ToString(), this.Text);
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
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (source, eventArgs) =>
            {
                if (!isMarked && string.IsNullOrEmpty(textBox.Text))
                {
                    isMarked = true;
                    textBox.Text = "номер";
                    textBox.ForeColor = Color.Gray;
                }
            };
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

        private void connectAircraft(object sender)
        {
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

            this.TopMost = false;

            var mav = new MAVLinkInterface();

            try
            {
                MainV2.instance.doConnect(mav, CMB_serialport.Text, CMB_baudrate.Text);

                MainV2.Comports.Add(mav);

                MainV2._connectionControl.UpdateSysIDS();

                AircraftConnectionInfo connectedAircraft = MainV2._aircraftInfo[devices_LB.SelectedItem.ToString()];
                connectedAircraft.SerialPort = CMB_serialport.SelectedItem.ToString();
                connectedAircraft.Speed = CMB_baudrate.SelectedItem;
                connectedAircraft.SysId =
                    MainV2._connectionControl.cmb_sysid.Items[MainV2._connectionControl.cmb_sysid.Items.Count - 1];
                connectedAircraft.Connected = true;

                switchConnectedAircraft(connectedAircraft);

                panel1.Enabled = false;
                connect_BUT.Text = disconnectText;
            }
            catch (Exception)
            {
            }

            this.TopMost = true;
        }

        private void disconnectAircraft()
        {
            KeyValuePair<string, AircraftConnectionInfo> selectedAircraft =
                MainV2._aircraftInfo.ElementAt(devices_LB.SelectedIndex);

            if (selectedAircraft.Value.SysId == null)
            {
                selectedAircraft.Value.Connected = false;
                selectedAircraft.Value.UsingSITL = false;
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
                return;
            }

            var temp = (ConnectionControl.port_sysid)selectedAircraft.Value.SysId;

            try
            {
                MainV2.instance.doDisconnect(temp.port);

                MainV2._connectionControl.UpdateSysIDS();

                if (MainV2.comPort.BaseStream.IsOpen)
                    MainV2.instance.loadph_serial();

                selectedAircraft.Value.Connected = false;
                selectedAircraft.Value.SysId = null;
                selectedAircraft.Value.UsingSITL = false;
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
            }
            catch (Exception)
            {
            }
        }

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            if (MainV2._aircraftInfo.ElementAt(devices_LB.SelectedIndex).Value.Connected)
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

            string aircraftNumber = aircraftNumber_TB.Text;

            MainV2._aircraftInfo.Add(aircraftNumber, new AircraftConnectionInfo());
            devices_LB.Items.Add(aircraftNumber);
            devices_LB.SetSelected(devices_LB.Items.Count - 1, true);
            MainV2._aircraftMenuControl.setAircraftButtonDefaultText(
                MainV2._aircraftInfo[aircraftNumber].MenuNum, aircraftNumber);
            MainV2._aircraftMenuControl.updateAircraftButtonText(MainV2._aircraftInfo[aircraftNumber].MenuNum);
            aircraftNumber_TB.Text = "";
            panel1.Enabled = true;
        }

        public void switchConnectedAircraft(AircraftConnectionInfo selectedAircraft)
        {
            if (selectedAircraft.SysId == null)
                return;

            var temp = (ConnectionControl.port_sysid)selectedAircraft.SysId;

            foreach (var port in MainV2.Comports)
            {
                if (port == temp.port)
                {
                    MainV2.comPort = port;
                    MainV2.comPort.sysidcurrent = temp.sysid;
                    MainV2.comPort.compidcurrent = temp.compid;

                    if (MainV2.comPort.MAV.param.Count == 0 && !(Control.ModifierKeys == Keys.Control))
                        MainV2.comPort.getParamList();

                    MainV2.CurrentAircraftNum = MainV2._aircraftInfo.FirstOrDefault(x => x.Value == selectedAircraft).Key;
                    devices_LB.SelectedItem = MainV2.CurrentAircraftNum;
                    MainV2.View.Reload();
                }
            }
        }

        private void devices_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, AircraftConnectionInfo> selectedAircraft =
                MainV2._aircraftInfo.ElementAt(devices_LB.SelectedIndex);
            connectedAircraftNum_TB.Text = selectedAircraft.Key;
            connectedAircraftName_TB.Text = selectedAircraft.Value.Name;
            useSITL_CheckBox.Checked = selectedAircraft.Value.UsingSITL;

            if (selectedAircraft.Value.Connected)
            {
                CMB_serialport.SelectedIndex = CMB_serialport.Items.IndexOf(selectedAircraft.Value.SerialPort);
                CMB_baudrate.SelectedIndex = CMB_baudrate.Items.IndexOf(selectedAircraft.Value.Speed);
                
                panel1.Enabled = false;
                connect_BUT.Text = disconnectText;

                switchConnectedAircraft(selectedAircraft.Value);
            }
            else
            {
                panel1.Enabled = true;
                connect_BUT.Text = connectText;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paint_TB_waterMark(aircraftNumber_TB, waterMarkAircraftNumActive);
            paint_TB_waterMark(connectedAircraftNum_TB, waterMarkConnectedNumActive);
            Invalidate();
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
    }
}