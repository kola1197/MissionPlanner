using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Symbology.Forms;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.Utilities;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.WinForms;

namespace MissionPlanner.Controls
{
    public partial class StatusControlPanel : UserControl
    {
        private Dictionary<ToolStripItem, SensorUserControl> sensors = new Dictionary<ToolStripItem, SensorUserControl>();

        private List<SensorUserControl> currentSensors = new List<SensorUserControl>();

        private Stopwatch stopwatch = new Stopwatch();

        private Queue<double> rpmQueue = new Queue<double>();

        public static StatusControlPanel instance;

        private ToolStripControlHost clickedSensorControl;

        public StatusControlPanel()
        {
            InitializeComponent();

            foreach (ToolStripItem toolStripItem in sensorsContextMenuStrip.Items)
            {
                if (toolStripItem.Text == "Магнитный курс")
                {
                    GaugeHeading gaugeHeading = new GaugeHeading();
                    gaugeHeading.SensorOnClick += sensorsStrip_Click;
                    sensors.Add(toolStripItem, gaugeHeading);
                }
                else
                {
                    AdditionalSensorControl sensorControl = new AdditionalSensorControl(bindingSourceCurrentState);
                    sensorControl.sensorName = toolStripItem.Text;
                    sensorControl.SensorOnClick += sensorsStrip_Click;
                    sensors.Add(toolStripItem, sensorControl);
                }
            }

            ToolStripControlHost defaultSensorControlHost =
                new ToolStripControlHost(sensors[sensorsContextMenuStrip.Items[1]]);
            sensorsMenuStrip.Items.Add(defaultSensorControlHost);
            
            instance = this;
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
            changeSensorMenuStripItem(clickedSensorIndex, new ToolStripControlHost(sensors[(ToolStripItem) sender]));

            // sensor_panel.Size = new System.Drawing.Size(sensor_panel.Size.Width + 130, sensor_panel.Height);
            Invalidate();
        }

        public void sensorsStrip_Click(object sender, EventArgs e)
        {
            sensorsContextMenuStrip.Show(Cursor.Position);
            object clickedHost;
            try
            {
                clickedHost = (UserControl) sender;
            }
            catch (Exception exception)
            {
                try
                {
                    clickedHost = (UserControl) ((Control) sender).Parent;
                }
                catch (Exception e1)
                {
                    clickedHost = (UserControl) ((UserControl) sender).Parent;
                }
                
            }

            try
            {
                foreach (ToolStripControlHost controlHost in sensorsMenuStrip.Items)
                {
                    if (controlHost.Control == clickedHost)
                    {
                        clickedSensorControl = controlHost;
                    }
                }

                // clickedSensorControl = sensors.Values.((AdditionalSensorControl) sender);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Pizdec");
                // clickedSensorControl = (ToolStripControlHost)((Control) sender).Parent;
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
    }
}