using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using MissionPlanner;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.NewClasses;
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
        private string aircraftText = "Борт: ";

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

        public void Init()
        {
            aircraftsBindingSource.DataSource = MainV2.Aircrafts.ToList();
            devices_LB.DisplayMember = "Key";
            devices_LB.ValueMember = "Key";
            devices_LB.DataSource = aircraftsBindingSource;
            connectionParams_panel.BackColor = antennaPanel.BackColor = connection_GB.BackColor;
            // devices_LB.DisplayMember = "Value";
        }

        public void UpdateComPorts()
        {
            CMB_serialport.Items.Clear();
            CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            if (MainV2.AntennaConnectionInfo != null && MainV2.AntennaConnectionInfo.Connected)
            {
                CMB_serialport.Items.RemoveAt(CMB_serialport.FindString(MainV2.AntennaConnectionInfo.SerialPort));
            }

            CMB_serialport.Items.Add("TCP");
            CMB_serialport.Items.Add("UDP");
            CMB_serialport.Items.Add("UDPCl");
            CMB_serialport.Items.Add("WS");
        }

        private void ConnectionsForm_Paint(object sender, PaintEventArgs e)
        {
        }

        public void SelectAircraftInListBox(AircraftConnectionInfo aircraft)
        {
            devices_LB.SelectedIndex = aircraft.MenuNum;
        }
        
        private void paint_TB_waterMark(TextBox textBox, bool isMarked)
        {
            textBox.GotFocus += (source, eventArgs) =>
            {
                if (isMarked)
                {
                    isMarked = false;
                    if (MainV2.Aircrafts.Count == 0 || textBox == aircraftNumber_TB)
                    {
                        textBox.Text = "";
                    }
                    else
                    {
                        textBox.Text = GetSelectedAircraftNum();
                    }

                    textBox.ForeColor = connection_GB.ForeColor;
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
            // paint_TB_waterMark(connectedAircraftNum_TB, waterMarkConnectedNumActive);
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

        private bool IsSitlAllowed()
        {
            if (MainV2.AntennaConnectionInfo != null && MainV2.AntennaConnectionInfo.Connected)
            {
                return false;
            }

            foreach (var aircraft in MainV2.Aircrafts.Values)
            {
                if (aircraft.Connected)
                {
                    return false;
                }
            }

            return true;
        }

        private void ConnectAircraft(object sender)
        {
            MAVLinkInterface.paramsLoading = true;
            AircraftConnectionInfo connectedAircraft = MainV2.Aircrafts[GetSelectedAircraftNum()];
            if (useAntenna_CheckBox.Checked)
            {
                if (sysid_cmb.SelectedItem == null)
                {
                    MAVLinkInterface.paramsLoading = false;
                    return;
                }
                connectedAircraft.SerialPort = MainV2.AntennaConnectionInfo.SerialPort;
                connectedAircraft.Speed = MainV2.AntennaConnectionInfo.Speed;
                connectedAircraft.SysId = sysid_cmb.SelectedItem;
                connectedAircraft.UsingAntenna = true;
                SwitchConnectedAircraft(connectedAircraft);
                connectedAircraft.Connected = true;
                connect_BUT.Text = disconnectText;
                MainV2.comPort.MavChanged += OnMavChanged;
                // connect_BUT.Enabled = false;
                return;
            }

            if (useSITL_CheckBox.Checked)
            {
                if (!IsSitlAllowed())
                {
                    MAVLinkInterface.paramsLoading = false;
                    CustomMessageBox.Show("Отключите антенну и все подключенные борты.",
                        "Невозможно создать симуляцию.");
                    return;
                }

                MainV2.instance.MenuSimulation_Click(sender, EventArgs.Empty);
                sitlForm.aircraftSITLInfo = MainV2.Aircrafts[GetSelectedAircraftNum()];
                sitlForm.aircraftSITLInfo.UsingSitl = true;
                sitlForm.aircraftSITLInfo.Connected = true;

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
                Thread.Sleep(1000); // i do not know why, but it helps with crash on params loading

                MainV2.Comports.Add(mav);

                MainV2._connectionControl.UpdateSysIDS();
                UpdateAircraftSysIdCmb();

                connectedAircraft.SerialPort = CMB_serialport.SelectedItem.ToString();

                if (CMB_baudrate.SelectedItem != null)
                {
                    connectedAircraft.Speed = CMB_baudrate.GetItemText(CMB_baudrate.SelectedItem);
                }

                connectedAircraft.SysId =
                    MainV2._connectionControl.cmb_sysid.Items[MainV2._connectionControl.cmb_sysid.Items.Count - 1];
                connectedAircraft.Connected = true;
                connect_BUT.Text = disconnectText;

                SwitchConnectedAircraft(connectedAircraft);
            }
            catch (Exception)
            {
            }

            this.TopMost = true;
        }

        public void CloseComPort()
        {
            if (MainV2.comPort.BaseStream.IsOpen)
            {
                try
                {
                    MainV2._connectionControl.IsConnected(false);
                    MainV2.comPort.Close();
                }
                catch
                {
                }
            }
        }
        
        public void DisconnectAircraft()
        {
            AircraftConnectionInfo selectedAircraft = MainV2.Aircrafts[GetSelectedAircraftNum()];
            
            if (MAVLinkInterface.paramsLoading && MainV2.comPort.frmProgressReporter.Running)
            {
                MainV2.comPort.frmProgressReporter.doWorkArgs.CancelRequested = true;
                int ticksPassed = 0;
                while (!MainV2.comPort.frmProgressReporter.doWorkArgs.CancelAcknowledged)
                {
                    Task.Delay(25);
                    ticksPassed += 25;
                }
            }

            MAVLinkInterface.paramsLoading = false;
            MainV2.comPort.frmProgressReporter.doWorkArgs.CancelRequested = false;
            MainV2.comPort.frmProgressReporter.doWorkArgs.CancelAcknowledged = false;

            if (selectedAircraft.SysId == null)
            {
                selectedAircraft.Connected = false;
                selectedAircraft.UsingSitl = false;
                selectedAircraft.UsingAntenna = false;
                connect_BUT.Text = connectText;
                MainV2.CurrentAircraftNum = null;
                return;
            }

            if (selectedAircraft.UsingAntenna)
            {
                MainV2.comPort.MAV.param.Clear();
                Thread.Sleep(100);
                SwitchToAntenna(false);
                selectedAircraft.Connected = false;
                selectedAircraft.SysId = null;
                connect_BUT.Text = connectText;
                sysid_cmb.Items.Clear();
                sysid_cmb.SelectedIndex = -1;
                sysid_cmb.Text = "";
                MainV2.CurrentAircraftNum = null;
                return;
            }

            var temp = (ConnectionControl.port_sysid) selectedAircraft.SysId;

            try
            {
                MainV2.instance.doDisconnect(temp.port);

                MainV2._connectionControl.UpdateSysIDS();

                if (MainV2.comPort.BaseStream.IsOpen)
                    MainV2.instance.loadph_serial();
                
                CloseComPort();

                selectedAircraft.Connected = false;
                selectedAircraft.SysId = null;
                MainV2.CurrentAircraftNum = null;
                MainV2.StopUpdates();
                MainV2.AircraftMenuControl.updateAllAircraftButtonTexts();

                connect_BUT.Text = connectText;
            }
            catch (Exception)
            {
            }
        }

        private void connect_BUT_Click(object sender, EventArgs e)
        {
            if (MainV2.Aircrafts[GetSelectedAircraftNum()].Connected)
            {
                DisconnectAircraft();
            }
            else
            {
                ConnectAircraft(sender);
            }

            UpdateControlsBindings();
        }

        private void addAircraft_BT_Click(object sender, EventArgs e)
        {
            if (MainV2.Aircrafts.Count > 3 || MainV2.Aircrafts.Keys.Contains(aircraftNumber_TB.Text) ||
                aircraftNumber_TB.Text.Equals("") || !regex.IsMatch(aircraftNumber_TB.Text))
                return;

            AddAircraft(aircraftNumber_TB.Text);
        }

        private List<Task> uiUpdateTasks = new List<Task>();

        public async Task AddAircraft(string aircraftNumber)
        {
            MainV2.Aircrafts.Add(aircraftNumber, new AircraftConnectionInfo());
            MainV2.AircraftMenuControl.setAircraftButtonDefaultText(
                MainV2.Aircrafts[aircraftNumber].MenuNum, aircraftNumber);
            MainV2.AircraftMenuControl.updateAircraftButtonText(MainV2.Aircrafts[aircraftNumber].MenuNum);

            aircraftNumber_TB.Text = "";
            connection_GB.Enabled = true;
            uiUpdateTasks.Clear();
            await UpdateControlsBindings();
            await Task.WhenAll(uiUpdateTasks.ToArray());
            devices_LB.SelectedIndex = devices_LB.Items.Count - 1;
        }


        public Binding CreateInversedBoolBinding(string propertyName, object dataSource, string dataMember)
        {
            Binding binding = new Binding(propertyName, dataSource, dataMember);

            binding.Format += SwitchBool;
            binding.Parse += SwitchBool;
            return binding;
        }

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            e.Value = !((bool) e.Value);
        }

        private void FormatAircraftNumBindingString(object sender, ConvertEventArgs e)
        {
            e.Value = aircraftText + e.Value.ToString();
        }

        private Binding CreateAircraftNumBinding(string propertyName, object dataSource, string dataMember)
        {
            Binding binding = new Binding(propertyName, dataSource, dataMember);

            binding.Format += FormatAircraftNumBindingString;
            binding.Parse += FormatAircraftNumBindingString;
            return binding;
        }

        private void ClearControlsBindings()
        {
            connection_GB.DataBindings.Clear();
            connectionParams_panel.DataBindings.Clear();
            connectedAircraftName_TB.DataBindings.Clear();
            useSITL_CheckBox.DataBindings.Clear();
            useAntenna_CheckBox.DataBindings.Clear();
            CMB_serialport.DataBindings.Clear();
            CMB_baudrate.DataBindings.Clear();
            antennaPanel.DataBindings.Clear();
        }

        private readonly object uiLock = new object();

        public async Task UpdateControlsBindings()
        {
            // Invoke((MethodInvoker) UpdateControlsBindingsAsync);
            await UpdateControlsBindingsAsync();
            // uiUpdateTasks.Add(Task.Run(UpdateControlsBindingsAsync));
        }

        private async Task UpdateControlsBindingsAsync()
        {
            //lock (uiLock)
            //{
            ClearControlsBindings();
            if (!HasResetSourcesBindings())
                return;
            BindControls();
            //}
        }

        private void SetControlsProperties()
        {
            connectedAircraftNum_TB.Text = GetSelectedAircraftNum();
            AircraftConnectionInfo selectedAircraft = MainV2.Aircrafts[GetSelectedAircraftNum()];
            CMB_serialport.SelectedIndex = CMB_serialport.FindString(selectedAircraft.SerialPort);
            CMB_baudrate.SelectedIndex = CMB_baudrate.FindString(selectedAircraft.Speed);
            UpdateAircraftSysIdCmb();
        }

        private void BindControls()
        {
            try
            {
                connection_GB.DataBindings.Add(CreateAircraftNumBinding("Text", aircraftsBindingSource.Current, "Key"));
                connectionParams_panel.DataBindings.Add(CreateInversedBoolBinding("Enabled", airInfoBindingSource,
                    "Connected"));

                connectedAircraftName_TB.DataBindings.Add(new Binding("Text", airInfoBindingSource, "Name"));
                useSITL_CheckBox.DataBindings.Add(new Binding("Checked", airInfoBindingSource, "UsingSitl"));
                useAntenna_CheckBox.DataBindings.Add(new Binding("Checked", airInfoBindingSource, "UsingAntenna"));
                // useSITL_CheckBox.DataBindings.Add(
                //     CreateInversedBoolBinding("Enabled", airInfoBindingSource, "UsingAntenna"));
                // useAntenna_CheckBox.DataBindings.Add(
                //     CreateInversedBoolBinding("Enabled", airInfoBindingSource, "UsingSitl"));

                CMB_serialport.DataBindings.Add(CreateInversedBoolBinding("Enabled", airInfoBindingSource,
                    "NotSerialConnection"));
                CMB_baudrate.DataBindings.Add(
                    CreateInversedBoolBinding("Enabled", airInfoBindingSource, "NotSerialConnection"));
                // CMB_serialport.DataBindings.Add(new Binding("SelectedValue", airInfoBindingSource, "SerialPort"));
                // CMB_baudrate.DataBindings.Add(new Binding("SelectedValue", airInfoBindingSource, "Speed"));

                antennaPanel.DataBindings.Add(new Binding("Enabled", airInfoBindingSource, "UsingAntenna"));

                SetControlsProperties();
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message + "\n" + e.Source + "\n" + e.StackTrace);
            }

            // useSITL_CheckBox.Checked = selectedAircraft.UsingSITL;
            // useAntenna_CheckBox.Checked = selectedAircraft.UsingAntenna;
        }

        private string GetSelectedAircraftNum()
        {
            return devices_LB.GetItemText(devices_LB.SelectedItem);
        }

        private bool HasResetSourcesBindings()
        {
            aircraftsBindingSource.DataSource = MainV2.Aircrafts.ToList();
            aircraftsBindingSource.ResetBindings(false);
            if (aircraftsBindingSource.Count == 0 || aircraftsBindingSource.Current == null)
                return false;

            airInfoBindingSource.DataSource = ((dynamic) aircraftsBindingSource.Current).Value;
            aircraftsBindingSource.ResetBindings(false);
            return true;
        }

        public void SwitchToAntenna(bool loadParams)
        {
            if (MainV2.AntennaConnectionInfo.SysId == null)
                return;
            
            MainV2.comPort.MavChanged -= OnMavChanged;
            
            var temp = (ConnectionControl.port_sysid) MainV2.AntennaConnectionInfo.SysId;

            foreach (var port in MainV2.Comports)
            {
                if (port == temp.port)
                {
                    MainV2.comPort = port;
                    MainV2.comPort.sysidcurrent = temp.sysid;
                    MainV2.comPort.compidcurrent = temp.compid;

                    if (loadParams)
                    {
                        // int toProcess = 1;
                        // using (ManualResetEvent resetEvent = new ManualResetEvent(false))
                        // {
                        //     var list = new List<int>();
                        //
                        //     ThreadPool.QueueUserWorkItem(
                        //         new WaitCallback(x =>
                        //         {
                        //             MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                        //                 (byte) MainV2.comPort.compidcurrent);
                        //             // Safely decrement the counter
                        //             if (Interlocked.Decrement(ref toProcess) == 0)
                        //                 resetEvent.Set();
                        //         }));
                        //     resetEvent.WaitOne(new TimeSpan(24, 0, 0));
                        // }

                        // MainV2.comPort.getParamList();
                        
                        Task.Run(() =>
                        {
                        MainV2.comPort.getParamList(MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid);
                        });
                    }
                    AntennaControl.Instance.SetAntennaState(true);
                    // MainV2.View.Reload();
                }
            }
            MainV2.comPort.MavChanged += OnMavChanged;
        }

        public void OnMavChanged(object sender, EventArgs e)
        {
            if (MainV2._currentAircraftNum == null || MainV2.Aircrafts[MainV2._currentAircraftNum].SysId == null ||
                !MainV2.Aircrafts[MainV2._currentAircraftNum].Connected)
            {
                return;
            }

            var currentSysId = (ConnectionControl.port_sysid) MainV2.Aircrafts[MainV2._currentAircraftNum].SysId;

            if (currentSysId.sysid != MainV2.comPort.sysidcurrent)
            {
                // CustomMessageBox.Show("Проведите правильное подключение.", "ОБНАРУЖЕН НЕ ВНЕСЕННЫЙ В СПИСОК БОРТ!");
            }
        }

        public void SwitchConnectedAircraft(AircraftConnectionInfo selectedAircraft)
        {
            if (selectedAircraft.SysId == null)
                return;
            
            MainV2.comPort.MavChanged -= OnMavChanged;

            bool loadParams = !MainV2.Aircrafts[GetSelectedAircraftNum()].Connected;
            var temp = (ConnectionControl.port_sysid) selectedAircraft.SysId;
            
            foreach (var port in MainV2.Comports) 
            {
                if (port == temp.port)
                {
                    MainV2.comPort = port;
                    MainV2.comPort.sysidcurrent = temp.sysid;
                    MainV2.comPort.compidcurrent = temp.compid;

                    if (loadParams || MainV2.comPort.MAV.param.Count == 0)
                    {
                        /*
                         new System.Threading.Thread(delegate()
                                                {
                                                    MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                                                        (byte) MainV2.comPort.compidcurrent);
                                                }).Start();*/
                        /*Task.Run(() =>
                        {
                            MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                                (byte) MainV2.comPort.compidcurrent);
                        });*/
                        // ThreadPool.QueueUserWorkItem((WaitCallback) delegate(object state)
                        // {
                        //     MainV2.comPort.getParamList((byte) MainV2.comPort.sysidcurrent,
                        //         (byte) MainV2.comPort.compidcurrent);
                        // });
                        //
                        
                        // MainV2.comPort.getParamList();

                        //
                        Task.Run(() =>
                        {
                            MainV2.comPort.getParamList(MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid);
                        });
                    }

                    MainV2.CurrentAircraftNum =
                        MainV2.Aircrafts.FirstOrDefault(x => x.Value == selectedAircraft).Key;
                    devices_LB.SelectedIndex = MainV2.Aircrafts[MainV2.CurrentAircraftNum].MenuNum;
                    AntennaControl.Instance.SetAntennaState(false);
                    // MainV2.View.Reload();
                }
            }
            MainV2.comPort.MavChanged += OnMavChanged;
        }

        private void devices_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsBindings();
            UpdateComPorts();
            AircraftConnectionInfo selectedAircraft = MainV2.Aircrafts[GetSelectedAircraftNum()];
            if (selectedAircraft.Connected)
            {
                UpdateAircraftSysIdCmb();
                connect_BUT.Text = disconnectText;
                if (!GetSelectedAircraftNum().Equals(MainV2.CurrentAircraftNum))
                {
                    SwitchConnectedAircraft(selectedAircraft);
                }
            }
            else
            {
                connect_BUT.Text = connectText;
            }
        }


        private void reload_BUT_Click(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        private void useSITL_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainV2.Aircrafts[GetSelectedAircraftNum()].UsingSitl = useSITL_CheckBox.Checked;
            UpdateControlsBindings();
        }

        private void aircraftNumber_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void connectedAircraftNum_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void connectedAircraftNum_TB_TextChanged(object sender, EventArgs e)
        {
            if (MainV2.Aircrafts == null || MainV2.Aircrafts.Keys.Contains(connectedAircraftNum_TB.Text) ||
                connectedAircraftNum_TB.Text.Equals("") || !regex.IsMatch(connectedAircraftNum_TB.Text))
                return;

            var oldAircraftNumber = GetSelectedAircraftNum();
            var newAircraftNumber = connectedAircraftNum_TB.Text;
            RenameAircraftNum(oldAircraftNumber, newAircraftNumber);
            UpdateControlsBindings();
        }

        public static void RenameAircraftNum(string fromKey, string toKey)
        {
            var dic = MainV2.Aircrafts;
            AircraftConnectionInfo value = dic[fromKey];
            dic.Remove(fromKey);
            dic.Add(toKey, value);
        }

        private void useAntenna_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainV2.Aircrafts[GetSelectedAircraftNum()].UsingAntenna = useAntenna_CheckBox.Checked;
            UpdateAircraftSysIdCmb();
            UpdateControlsBindings();
        }

        private void UpdateAircraftSysIdCmb()
        {
            sysid_cmb.Items.Clear();
            var oldidx = sysid_cmb.SelectedIndex;
            int selectidx = -1;
            var sysId = MainV2.Aircrafts[GetSelectedAircraftNum()].SysId;
            ConnectionControl.port_sysid selectedAircraftSysId;

            if (sysId != null)
            {
                selectedAircraftSysId = (ConnectionControl.port_sysid) sysId;
            }
            else
            {
                selectedAircraftSysId = new ConnectionControl.port_sysid();
            }

            foreach (var port in MainV2.Comports.ToArray())
            {
                var list = port.MAVlist.GetRawIDS();

                foreach (int item in list)
                {
                    var temp = new ConnectionControl.port_sysid()
                        {compid = (item % 256), sysid = (item / 256), port = port};
                    
                    if (temp.sysid != MainV2.AntennaConnectionInfo.SysIdNum)
                    {
                        var idx = sysid_cmb.Items.Add(temp);

                        if (temp.port == selectedAircraftSysId.port && temp.sysid == selectedAircraftSysId.sysid &&
                            temp.compid == selectedAircraftSysId.compid)
                        {
                            selectidx = idx;
                        }
                    }
                }
            }

            if (selectidx == -1)
            {
                sysid_cmb.ResetText();
            }

            sysid_cmb.SelectedIndex = selectidx;
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
            UpdateAircraftSysIdCmb();
        }

        private void sysid_cmb_DropDown(object sender, EventArgs e)
        {
            UpdateAircraftSysIdCmb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainV2.Aircrafts.First().Value.Connected = true;
            UpdateControlsBindings();
        }

        private void connectedAircraftName_TB_TextChanged(object sender, EventArgs e)
        {
        }

        private void aircraftNumber_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addAircraft_BT_Click(sender, EventArgs.Empty);
            }
        }

        private void ConnectionsForm_Shown(object sender, EventArgs e)
        {
            UpdateComPorts();
            UpdateControlsBindings();
        }
    }
}