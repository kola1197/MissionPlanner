﻿using System;
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
using MissionPlanner.Orlan;
using MissionPlanner.Utilities;

namespace MissionPlanner
{
    public partial class ConnectionsForm : Form
    {
        // [DllImport("user32.dll", CharSet = CharSet.Auto)]
        // private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        // const int EM_SETCUEBANNER = 0x1501;

        private bool waterMarkAircraftNumActive = true;
        private bool waterMarkConnectedNumActive = true;
        
        private static Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);

        public ConnectionsForm()
        {
            InitializeComponent();


            // SendMessage(aircraftNumber_TB.Handle, EM_SETCUEBANNER, 1, "Number");

            CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            CMB_serialport.Items.Add("TCP");
            CMB_serialport.Items.Add("UDP");
            CMB_serialport.Items.Add("UDPCl");
            CMB_serialport.Items.Add("WS");

            ThemeManager.ApplyThemeTo(this);

            connectedAircraftNum_TB.ForeColor = Color.Gray;
            connectedAircraftNum_TB.Text = "введите номер";

            aircraftNumber_TB.ForeColor = Color.Gray;
            aircraftNumber_TB.Text = "номер";

            MissionPlanner.Utilities.Tracking.AddPage(this.GetType().ToString(), this.Text);
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

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            var mav = new MAVLinkInterface();

            try
            {
                MainV2.instance.doConnect(mav, CMB_serialport.Text, CMB_baudrate.Text);

                MainV2.Comports.Add(mav);

                MainV2._connectionControl.UpdateSysIDS();
            }
            catch (Exception)
            {
            }
        }

        private void addAircraft_BT_Click(object sender, EventArgs e)
        {
            if (MainV2._aircraftInfo.Count > 4 || MainV2._aircraftInfo.Keys.Contains(aircraftNumber_TB.Text) ||
                aircraftNumber_TB.Text.Equals("") || !regex.IsMatch(aircraftNumber_TB.Text))
                return;

            MainV2._aircraftInfo.Add(aircraftNumber_TB.Text, new AircraftConnectionInfo());
            devices_LB.Items.Add(aircraftNumber_TB.Text);
            devices_LB.SetSelected(devices_LB.Items.Count - 1, true);
            
            aircraftNumber_TB.Text = "";
            panel1.Enabled = true;
        }

        private void devices_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, AircraftConnectionInfo> selectedAircraft =
                MainV2._aircraftInfo.ElementAt(devices_LB.SelectedIndex);
            connectedAircraftNum_TB.Text = selectedAircraft.Key;
            connectedAircraftName_TB.Text = selectedAircraft.Value.Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paint_TB_waterMark(aircraftNumber_TB, waterMarkAircraftNumActive);
            paint_TB_waterMark(connectedAircraftNum_TB, waterMarkConnectedNumActive);

            Invalidate();
        }

        private void sitl_BUT_Click(object sender, EventArgs e)
        {
            //((MainV2)Form.ActiveForm).MenuSimulation_Click(sender, EventArgs.Empty);
        }
    }
}