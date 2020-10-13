using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private EngineControlForm engineControlForm;
        private Dictionary<ToolStripItem, SensorUserControl> sensors =
            new Dictionary<ToolStripItem, SensorUserControl>();

        private List<SensorUserControl> currentSensors = new List<SensorUserControl>();

        private Stopwatch stopwatch = new Stopwatch();

        private Queue<double> rpmQueue = new Queue<double>();

        public static StatusControlPanel instance;

        private ToolStripControlHost clickedSensorControl;

        public StatusControlPanel()
        {
            InitializeComponent();

            InitSensors();

            ToolStripControlHost defaultSensorControlHost =
                new ToolStripControlHost(getDesiredSensor(sensorsContextMenuStrip.Items[1]));
            sensorsMenuStrip.Items.Add(defaultSensorControlHost);

            // ThemeManager.ApplyThemeTo(this);
            instance = this;

            AddClickToSpeedPanelControls();
            AddClickToEnginePanelControls();

            slidingScaleIndent = new Point(speedPanel.Width / 4, 30);
        }

        public Point GetLocalRouteFormLocation()
        {
            return new Point(speedPanel.Location.X + slidingScaleIndent.X,
                speedPanel.Location.Y + this.Height + slidingScaleIndent.Y);
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
                if (toolStripItem.Text == "Магнитный курс")
                {
                    GaugeHeading gaugeHeading = new GaugeHeading();
                    gaugeHeading.CustomOnClick += sensorsStrip_Click;
                    sensors.Add(toolStripItem, gaugeHeading);
                }
                else
                {
                    AdditionalSensorControl sensorControl = new AdditionalSensorControl(bindingSourceCurrentState)
                    {
                        sensorName = toolStripItem.Text
                    };
                    sensorControl.CustomOnClick += sensorsStrip_Click;
                    sensors.Add(toolStripItem, sensorControl);
                }
            }

            ToolStripControlHost defaultSensorControlHost =
                new ToolStripControlHost(getDesiredSensor(sensorsContextMenuStrip.Items[1]));
            sensorsMenuStrip.Items.Add(defaultSensorControlHost);

            // ThemeManager.ApplyThemeTo(this);
            instance = this;
        }

        private SensorUserControl getDesiredSensor(ToolStripItem keyItem)
        {
            SensorUserControl desiredSensor = sensors[keyItem];

            // Creating a copy of sensor to replace it in dictionary
            if (keyItem.Text == "Магнитный курс")
            {
                GaugeHeading gaugeHeading = new GaugeHeading();
                gaugeHeading.CustomOnClick += sensorsStrip_Click;
                sensors[keyItem] = gaugeHeading;
            }
            else
            {
                AdditionalSensorControl sensorControl = new AdditionalSensorControl(bindingSourceCurrentState)
                {
                    sensorName = keyItem.Text
                };
                sensorControl.CustomOnClick += sensorsStrip_Click;
                sensors[keyItem] = sensorControl;
            }

            return desiredSensor;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }

            base.OnInvalidated(e);
            updateBindingSourceWork();
        }

        private double calculateAverageRpm()
        {
            return rpmQueue.Sum() / rpmQueue.Count;
        }

        private void updateBindingSourceWork()
        {
            rpmQueue.Enqueue(MainV2.comPort.MAV.cs.rpm1);
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

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            fuel_label.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString("F2");

            voltage_label.Text = MainV2.comPort.MAV.cs.battery_voltage.ToString("F2");

            rpmICE_label.Text = MainV2.comPort.MAV.cs.rpm1.ToString("F2") + " об/м";

            airspeed_label.Text = (MainV2.comPort.MAV.cs.airspeed * 3.6).ToString("F1") + " км/ч";

            groundSpeed_label.Text = (MainV2.comPort.MAV.cs.groundspeed * 3.6).ToString("F1") + " км/ч";

            verticalSpeed_label.Text = MainV2.comPort.MAV.cs.verticalspeed.ToString("F1") + " м/с";

            altitude_label.Text = MainV2.comPort.MAV.cs.alt.ToString("F2");

            targetAlt_label.Text = MainV2.comPort.MAV.cs.targetalt.ToString("F2");

            environmentTemp_label.Text = MainV2.comPort.MAV.cs.press_temp2.ToString("F1") + "°";

            engineTemp_label.Text = MainV2.comPort.MAV.cs.rpm2.ToString("F1") + "°";

            string flightMode = MainV2.comPort.MAV.cs.mode;
            flightMode_label.Text = flightMode == "Unknown" ? "Не подключен" : MainV2.comPort.MAV.cs.mode;

            averageRpmICE_label.Text = calculateAverageRpm().ToString("F2");

            this.Invalidate();
        }

        private void AdditionalSensorToolStripMenuItemClick(object sender, EventArgs e)
        {
            int clickedSensorIndex = sensorsMenuStrip.Items.IndexOf(clickedSensorControl);
            changeSensorMenuStripItem(clickedSensorIndex,
                new ToolStripControlHost(getDesiredSensor((ToolStripItem) sender)));

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
            SensorUserControl sensorToShow = getDesiredSensor(sensorsContextMenuStrip.Items[1]);
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
            if (engineControlForm != null) 
            {
                engineControlForm.Close();
            }
            engineControlForm = new EngineControlForm();
            engineControlForm.TopMost = true;
            engineControlForm.Show();
        }

        private void speedPanel_Click(object sender, EventArgs e)
        {
            MainV2.instance.SetRouteFormLocation();
            MainV2.RouteAltForm.SetSlidingScaleFormattedValue();
            MainV2.RouteAltForm.Show();
            MainV2.RouteAltForm.TopLevel = true;
        }
    }
}