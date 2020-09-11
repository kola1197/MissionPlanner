using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Comms;
using MissionPlanner.Controls.BackstageView;
using MissionPlanner.Orlan;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class AntennaControl : UserControl
    {
        private string connectText = "Подключить";
        private string disconnectText = "Отключить";
        private string antennaNumber = "АНТ";
        public AntennaControl()
        {
            InitializeComponent();

            ThemeManager.ApplyThemeTo(this);

            //Tracking.AddPage(this.GetType().ToString(), this.Text);
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
        
        private void addAntenna()
        {
            MainV2._aircraftInfo.Add(antennaNumber, new AircraftConnectionInfo());
        }

        private void connectAircraft(object sender)
        {
            if (!MainV2._aircraftInfo.Keys.Contains(antennaNumber))
            {
                // addAntenna();
            }

            if (CMB_serialport.SelectedItem == null)
            {
                CustomMessageBox.Show("Задайте порт подключения", "Не выбран порт подключения");
                return;
            }

            var mav = new MAVLinkInterface();

            try
            {
                MainV2.instance.doConnect(mav, CMB_serialport.Text, CMB_baudrate.Text);

                MainV2.Comports.Add(mav);

                MainV2._connectionControl.UpdateSysIDS();

                AntennaConnectionInfo antenna = MainV2._AntennaConnectionInfo;
                antenna.SerialPort = CMB_serialport.SelectedItem.ToString();

                if (CMB_baudrate.SelectedItem != null)
                {
                    antenna.Speed = CMB_baudrate.SelectedItem;
                }

                antenna.SysId = MainV2._connectionControl.cmb_sysid.Items[0];
                antenna.Connected = true;
                connect_BUT.Text = disconnectText;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void disconnectAircraft()
        {
            AircraftConnectionInfo selectedAircraft = MainV2._AntennaConnectionInfo;

            var temp = (ConnectionControl.port_sysid)selectedAircraft.SysId;

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
                connect_BUT.Text = connectText;
            }
            catch (Exception)
            {
            }
        }

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            if (MainV2._AntennaConnectionInfo.Connected)
            {
                disconnectAircraft();
            }
            else
            {
                connectAircraft(sender);
            }
        }

        private void CMB_serialport_DropDown(object sender, EventArgs e)
        {
            UpdateComPorts();
        }
    }
}
