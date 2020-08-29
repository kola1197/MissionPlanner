using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MissionPlanner.Utilities;
using Xamarin.Forms.Platform.WinForms;

namespace MissionPlanner.Controls
{
    public partial class StatusControlPanel : UserControl
    {
        private DateTime starttime = DateTime.MinValue;
        private Queue<double> rpmQueue = new Queue<double>();
        public StatusControlPanel()
        {
            starttime = DateTime.Now;
            InitializeComponent();
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
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
            if ((DateTime.Now - starttime).Milliseconds > 2000)
            {
                rpmQueue.Dequeue();
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

            airspeed_label.Text = (MainV2.comPort.MAV.cs.airspeed * 3.6).ToString("F2") + " км/ч";

            groundSpeed_label.Text = (MainV2.comPort.MAV.cs.groundspeed * 3.6).ToString("F2") + " км/ч";

            verticalSpeed_label.Text = MainV2.comPort.MAV.cs.verticalspeed.ToString("F2") + " м/с";

            altitude_label.Text = MainV2.comPort.MAV.cs.alt.ToString("F2");

            targetAlt_label.Text = MainV2.comPort.MAV.cs.targetalt.ToString("F2");

            environmentTemp_label.Text = MainV2.comPort.MAV.cs.press_temp2.ToString("F1");

            engineTemp_label.Text = MainV2.comPort.MAV.cs.rpm2.ToString("F1");

            string flightMode = MainV2.comPort.MAV.cs.mode;
            if (flightMode == "Unknown")
            {
                flightMode_label.Text = "Не подключен";

            }
            else
            {
                flightMode_label.Text = MainV2.comPort.MAV.cs.mode;
            }

            averageRpmICE_label.Text = calculateAverageRpm().ToString("F2");

            this.Invalidate();
        }
    }
}