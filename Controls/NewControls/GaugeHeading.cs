using System;
using System.Windows.Forms;
using DotSpatial.Topology;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls
{
    public partial class GaugeHeading : SensorUserControl
    {
        public GaugeHeading()
        {
            //MainV2.comPort.MAV.cs.UpdateCurrentSettings(
            //    bindingSourceGaugeHeading.UpdateDataSource(MainV2.comPort.MAV.cs));
            InitializeComponent();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            updateBindingSourceWork();
        }

        private void updateBindingSourceWork()
        {
            try
            {
                if (this.Visible)
                {
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(
                            bindingSourceGaugeHeading.UpdateDataSource(MainV2.comPort.MAV.cs));
                }
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            headingDegrees_Label.Text = Math.Round(MainV2.comPort.MAV.cs.yaw) + "°";
            headingDegrees_Label.Location = new System.Drawing.Point(48, 35);
        }
        
        public override event EventHandler SensorOnClick {
            add {
                base.Click += value;
                foreach (Control control in Controls) {
                    control.Click += value;
                }
            }
            remove {
                base.Click -= value;
                foreach (Control control in Controls) {
                    control.Click -= value;
                }
            }
        }
    }
}