using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Symbology.Forms;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.NewForms;
using MissionPlanner.Utilities;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.WinForms;

namespace MissionPlanner.Controls
{
    public partial class StatusControlPanel : UserControl
    {
        private readonly Point slidingScaleIndent;
        private readonly Point engineIndent;

        private Dictionary<ToolStripItem, SensorUserControl> sensors =
            new Dictionary<ToolStripItem, SensorUserControl>();

        private List<SensorUserControl> currentSensors = new List<SensorUserControl>();

        private Stopwatch stopwatch = new Stopwatch();

        private Queue<double> rpmQueue = new Queue<double>();

        public static StatusControlPanel instance;

        private ToolStripControlHost clickedSensorControl;

        public EngineControlForm EngineControlForm;

        public EmulateSitlParameters SitlEmulation = new EmulateSitlParameters();

        public StatusControlPanel()
        {
            InitializeComponent();

            InitSensors();

            // ThemeManager.ApplyThemeTo(this);
            instance = this;

            AddClickToSpeedPanelControls();
            AddClickToEnginePanelControls();

            slidingScaleIndent = new Point(speedPanel.Width / 4, 30);
            engineIndent = new Point(0, 30);
        }

        public void SetFuelPbMinMax()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                splittedBar_fuel.Minimum = MainV2.CurrentAircraft.MinCapacity;
                splittedBar_fuel.Maximum = MainV2.CurrentAircraft.MaxCapacity;
                splittedBar_fuel.Step = (splittedBar_fuel.Maximum - splittedBar_fuel.Minimum) / 10;
            }
        }

        public Point GetLocalRouteFormLocation()
        {
            return new Point(speedPanel.Location.X + slidingScaleIndent.X,
                speedPanel.Location.Y + this.Height + slidingScaleIndent.Y);
        }

        public Point GetLocalEngineFormLocation()
        {
            return new Point(enginePanel.Location.X + engineIndent.X,
                enginePanel.Location.Y + this.Height + engineIndent.Y);
        }

        private void AddClickToSpeedPanelControls()
        {
            foreach (Control control in speedPanel.Controls)
            {
                control.Click += speedPanel_Click;
            }
        }

        private void AddClickToEnginePanelControls()
        {
            foreach (Control control in enginePanel.Controls)
            {
                control.Click += enginePanel_Click;
            }
        }

        private void InitSensors()
        {
            foreach (ToolStripItem toolStripItem in sensorsContextMenuStrip.Items)
            {
                // if (toolStripItem.Text == "Магнитный курс")
                // {
                //     GaugeHeading gaugeHeading = new GaugeHeading();
                //     gaugeHeading.CustomOnClick += sensorsStrip_Click;
                //     sensors.Add(toolStripItem, gaugeHeading);
                // }
                // else
                // {
                AdditionalSensorControl sensorControl = new AdditionalSensorControl(bindingSourceCurrentState)
                {
                    sensorName = toolStripItem.Text
                };
                sensorControl.CustomOnClick += sensorsStrip_Click;
                sensors.Add(toolStripItem, sensorControl);
                // }
            }

            ToolStripControlHost defaultSensorControlHost =
                new ToolStripControlHost(GetDesiredSensor(sensorsContextMenuStrip.Items[1]));
            sensorsMenuStrip.Items.Add(defaultSensorControlHost);

            // ThemeManager.ApplyThemeTo(this);
            instance = this;
        }

        private SensorUserControl GetDesiredSensor(ToolStripItem keyItem)
        {
            SensorUserControl desiredSensor = sensors[keyItem];

            // Creating a copy of sensor to replace it in dictionary
            // if (keyItem.Text == "Магнитный курс")
            // {
            //     GaugeHeading gaugeHeading = new GaugeHeading();
            //     gaugeHeading.CustomOnClick += sensorsStrip_Click;
            //     sensors[keyItem] = gaugeHeading;
            // }
            // else
            // {
            AdditionalSensorControl sensorControl = new AdditionalSensorControl(bindingSourceCurrentState)
            {
                sensorName = keyItem.Text
            };
            sensorControl.CustomOnClick += sensorsStrip_Click;
            sensors[keyItem] = sensorControl;
            // }

            return desiredSensor;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }

            base.OnInvalidated(e);
            UpdateBindingSourceWork();
        }

        public void SubscribeWpNoValueChangedEvent()
        {
            if (IsSitlConnected())
            {
                MainV2.comPort.MAV.cs.WpNoValueChanged += SitlOnWpNoValueChanged;
            }
        }

        private void SitlOnWpNoValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (IsSitlConnected() && (int) MainV2.comPort.MAV.cs.wpno == 2)
            {
                SitlEmulation.SetTargetState(SitlState.SitlStateName.Flight);
            }
        }

        private double CalculateAverageRpm()
        {
            return rpmQueue.Sum() / rpmQueue.Count;
        }

        private void UpdateBindingSourceWork()
        {
            float rpm1;
            if (IsSitlConnected() && MainV2.CurrentAircraft != null)
            {
                rpm1 = (float) MainV2.CurrentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName.Rpm);
            }
            else
            {
                rpm1 = MainV2.comPort.MAV.cs.rpm1;
            }

            rpmQueue.Enqueue(rpm1);
            if (stopwatch.ElapsedMilliseconds > 2000)
            {
                rpmQueue.Dequeue();
                stopwatch.Stop();
            }

            try
            {
                if (this.Visible)
                {
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(
                        bindingSourceCurrentState.UpdateDataSource(MainV2.comPort.MAV.cs));
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(
                        bindingSourceHud.UpdateDataSource(MainV2.comPort.MAV.cs));
                }
                else
                {
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(
                        bindingSourceHud.UpdateDataSource(MainV2.comPort.MAV.cs));
                }
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }
        }


        // There are some missing params in SITL, so we need to update them by hand
        public void DisableControlBindings()
        {
            splittedBar_fuel.DataBindings.Clear();
        }

        // Enable when switching from SITL
        public void EnableControlBindings()
        {
            if (splittedBar_fuel.DataBindings.Count == 0)
            {
                splittedBar_fuel.DataBindings.Add(new Binding("Value", bindingSourceCurrentState, "battery_voltage2",
                    true));
            }
        }

        public bool IsSitlConnected()
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return false;
            }

            var aircraft = MainV2.CurrentAircraft;
            if (aircraft.Connected && aircraft.UsingSitl && !MainV2.AntennaConnectionInfo.Active)
            {
                return true;
            }

            return false;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // fuel_label.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString("F2");
            UpdateStatusLabels();

            this.Invalidate();
            if (IsSitlConnected())
            {
                UpdateFuelProgressBar();
            }
        }

        private void UpdateFuelProgressBar()
        {
            splittedBar_fuel.Value = Math.Round(MainV2.CurrentAircraft.Fuel);
        }

        private void UpdateStatusLabels()
        {
            double rpm1, engineTemp, airspeed, groundSpeed, verticalSpeed, alt, targetAlt;
            if (IsSitlConnected() && MainV2.CurrentAircraft != null)
            {
                var sitlParamList = MainV2.CurrentAircraft.SitlInfo.ParamList;

                rpm1 = sitlParamList.GetParamValue(SitlParam.ParameterName.Rpm);
                engineTemp = sitlParamList.GetParamValue(SitlParam.ParameterName.Temperature);
                airspeed = sitlParamList.GetParamValue(SitlParam.ParameterName.AirSpeed);
                groundSpeed = sitlParamList.GetParamValue(SitlParam.ParameterName.GroundSpeed);
                verticalSpeed = sitlParamList.GetParamValue(SitlParam.ParameterName.VerticalSpeed);
                alt = sitlParamList.GetParamValue(SitlParam.ParameterName.Alt);
                targetAlt = sitlParamList.GetParamValue(SitlParam.ParameterName.TargetAlt);
            }
            else
            {
                rpm1 = MainV2.comPort.MAV.cs.rpm1;
                engineTemp = MainV2.comPort.MAV.cs.rpm2;
                airspeed = MainV2.comPort.MAV.cs.airspeed;
                groundSpeed = MainV2.comPort.MAV.cs.groundspeed;
                verticalSpeed = MainV2.comPort.MAV.cs.verticalspeed;
                alt = MainV2.comPort.MAV.cs.alt;
                targetAlt = MainV2.comPort.MAV.cs.targetalt;
            }

            rpmICE_label.Text = rpm1.ToString("F2", new CultureInfo("en-US")) + " об/м";

            engineTemp_label.Text = engineTemp.ToString("F1", new CultureInfo("en-US")) + "°";

            airspeed_label.Text = (airspeed * 3.6).ToString("F1", new CultureInfo("en-US")) + " км/ч";

            groundSpeed_label.Text = (groundSpeed * 3.6).ToString("F1", new CultureInfo("en-US")) + " км/ч";

            verticalSpeed_label.Text = verticalSpeed.ToString("F1", new CultureInfo("en-US")) + " м/с";

            altitude_label.Text = alt.ToString("F2", new CultureInfo("en-US"));

            targetAlt_label.Text = targetAlt.ToString("F2", new CultureInfo("en-US"));

            fuel_label.Text = CalcFuelPercentage().ToString(new CultureInfo("en-US")) + "%";

            voltage_label.Text = MainV2.comPort.MAV.cs.battery_voltage.ToString("F2", new CultureInfo("en-US"));

            environmentTemp_label.Text =
                MainV2.comPort.MAV.cs.press_temp2.ToString("F1", new CultureInfo("en-US")) + "°";

            string flightMode = MainV2.comPort.MAV.cs.mode;
            flightMode_label.Text = flightMode == "Unknown" ? "Не подключен" : MainV2.comPort.MAV.cs.mode;

            averageRpmICE_label.Text = CalculateAverageRpm().ToString("F2", new CultureInfo("en-US"));
        }

        private void AdditionalSensorToolStripMenuItemClick(object sender, EventArgs e)
        {
            int clickedSensorIndex = sensorsMenuStrip.Items.IndexOf(clickedSensorControl);
            changeSensorMenuStripItem(clickedSensorIndex,
                new ToolStripControlHost(GetDesiredSensor((ToolStripItem) sender)));

            // sensor_panel.Size = new System.Drawing.Size(sensor_panel.Size.Width + 130, sensor_panel.Height);
            Invalidate();
        }

        public void sensorsStrip_Click(object sender, EventArgs e)
        {
            sensorsContextMenuStrip.Show(Cursor.Position);
            try
            {
                foreach (ToolStripControlHost controlHost in sensorsMenuStrip.Items)
                {
                    if (controlHost.Control == sender)
                    {
                        clickedSensorControl = controlHost;
                    }
                    else
                    {
                        foreach (Control control in controlHost.Control.Controls)
                        {
                            if (control == sender)
                            {
                                clickedSensorControl = controlHost;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                clickedSensorControl = (ToolStripControlHost) sensorsMenuStrip.Items[0];
            }
        }

        private void changeSensorMenuStripItem(int oldSensorIndex, ToolStripControlHost newSensor)
        {
            ToolStripItem[] copy = new ToolStripItem[sensorsMenuStrip.Items.Count];
            sensorsMenuStrip.Items.CopyTo(copy, 0);
            sensorsMenuStrip.Items.Clear();
            copy[oldSensorIndex] = null;

            foreach (var item in copy)
            {
                sensorsMenuStrip.Items.Add(item ?? newSensor);
            }
        }

        private void showSensor_BUT_Click(object sender, EventArgs e)
        {
            if (sensorsMenuStrip.Items.Count >= 6)
                return;
            SensorUserControl sensorToShow = GetDesiredSensor(sensorsContextMenuStrip.Items[1]);
            this.Size = new Size(this.Size.Width + sensorToShow.ControlSize.Width, this.Size.Height);
            sensorsMenuStrip.Items.Add(new ToolStripControlHost(sensorToShow));
        }

        private void hideSensor_BUT_Click(object sender, EventArgs e)
        {
            if (sensorsMenuStrip.Items.Count < 2)
                return;
            int indexOfSensorToHide = sensorsMenuStrip.Items.Count - 1;
            SensorUserControl sensorToHide =
                (SensorUserControl) ((ToolStripControlHost) sensorsMenuStrip.Items[indexOfSensorToHide]).Control;
            sensorsMenuStrip.Items.RemoveAt(indexOfSensorToHide);
            this.Size = new Size(this.Size.Width - sensorToHide.ControlSize.Width, this.Size.Height);
        }

        private void enginePanel_Click(object sender, EventArgs e)
        {
            if (EngineControlForm != null && EngineControlForm.Visible)
            {
                MainV2.FormConnector.DisconnectForm(EngineControlForm);
                EngineControlForm.Close();
                return;
            }

            EngineControlForm = new EngineControlForm()
                {Visible = false, StartPosition = FormStartPosition.Manual};
            if (!EngineControlForm.IsDisposed)
            {
                //EngineControlForm.Location = new Point (enginePanel.Location.X+enginePanel.Size.Width/2, enginePanel.Location.Y + enginePanel.Size.Height);
                MainV2.FormConnector.ConnectForm(EngineControlForm);
                EngineControlForm.SetFormLocation();
                EngineControlForm.Show();
            }
        }

        public int CalcFuelPercentage()
        {
            int percent;
            if (IsSitlConnected())
            {
                percent = (int) Math.Round(MainV2.CurrentAircraft.Fuel /
                    (splittedBar_fuel.Maximum - splittedBar_fuel.Minimum) * 100);
            }
            else
            {
                percent = (int) Math.Round(MainV2.comPort.MAV.cs.battery_voltage2 / splittedBar_fuel.Maximum * 100);
            }

            return percent;
        }


        private void speedPanel_Click(object sender, EventArgs e)
        {
            if (MainV2.RouteAltForm.Visible)
            {
                MainV2.RouteAltForm.Hide();
                return;
            }

            MainV2.RouteAltForm.SetSlidingScaleFormattedValue();
            MainV2.FormConnector.ConnectForm(MainV2.RouteAltForm);
            MainV2.RouteAltForm.Show();
            MainV2.RouteAltForm.TopLevel = true;
        }
    }
}