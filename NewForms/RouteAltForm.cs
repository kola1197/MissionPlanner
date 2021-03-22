using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.GCSViews;
using MissionPlanner;
using MissionPlanner.Controls;
using MissionPlanner.NewClasses;
using MissionPlanner.Utilities;

namespace MissionPlanner.NewForms
{
    public partial class RouteAltForm : Form, IFormConnectable
    {
        private bool _isMouseDown = false;
        private Point _previousMouseLocation;
        private readonly int _wheelDelta = SystemInformation.MouseWheelScrollDelta;
        private readonly int _altStep = 20;
        private readonly int _mouseMoveScale = 5;
        private RouteAltitude _routeAltitude = new RouteAltitude();

        public RouteAltForm()
        {
            InitializeComponent();
            alt_SlidingScale.MouseWheel += alt_SlidingScaleOnMouseWheel;
        }

        private void CsOnWpNoValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_routeAltitude.HoldAlt)
            {
                SetNewWPAlt(_routeAltitude.Value);
            }
        }

        private void alt_SlidingScaleOnMouseWheel(object sender, MouseEventArgs e)
        {
            int altChange = (e.Delta / _wheelDelta) * _altStep;
            alt_SlidingScale.Value += altChange;
        }

        private void alt_SlidingScale_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _previousMouseLocation = e.Location;
            alt_SlidingScale.ValueChanged -= alt_SlidingScale_ValueChanged;
        }

        private void alt_SlidingScale_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseDelta = (e.Location.Y - _previousMouseLocation.Y);
            if (_isMouseDown && Math.Abs(mouseDelta) > _mouseMoveScale)
            {
                alt_SlidingScale.Value += Math.Sign(mouseDelta) * _altStep;
                _previousMouseLocation = e.Location;
            }
        }

        private void alt_SlidingScale_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            var tempAlt = alt_SlidingScale.Value;
            InsignificantChangeValue();
            alt_SlidingScale.ValueChanged += alt_SlidingScale_ValueChanged;
            alt_SlidingScale.Value = tempAlt;
        }

        private void InsignificantChangeValue()
        {
            var middleValue = (alt_SlidingScale.MaxValue - alt_SlidingScale.MinValue) / 2;
            alt_SlidingScale.Value = alt_SlidingScale.Value + Math.Sign(middleValue - alt_SlidingScale.Value) * 0.01;
        }

        private void RouteAltForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetSlidingScaleFormattedValue()
        {
            alt_SlidingScale.ValueChanged -= alt_SlidingScale_ValueChanged;
            alt_SlidingScale.Value = GetFormattedAlt();
            alt_SlidingScale.ValueChanged += alt_SlidingScale_ValueChanged;
        }

        private int GetFormattedAlt()
        {
            return ((int) Math.Round(MainV2.comPort.MAV.cs.targetalt / 20)) * 20;
        }

        private void alt_SlidingScale_ValueChanged(object sender, MissionPlanner.ValueChangedEventArgs e)
        {
            if (!MainV2.comPort.MAV.cs.connected)
                return;

            int newAlt = (int) alt_SlidingScale.Value;
            int currentAlt = (int) MainV2.comPort.MAV.cs.targetalt;

            if (newAlt == currentAlt)
                return;

            if (SetNewWPAlt(newAlt))
            {
                _routeAltitude.Value = newAlt;
                MainV2.comPort.MAV.cs.WpNoValueChanged += CsOnWpNoValueChanged;
            }
        }

        private void route_BUT_Click(object sender, EventArgs e)
        {
            ReturnToRouteAltitude();
        }

        public void ReturnToRouteAltitude()
        {
            var altIndex = FlightPlanner.instance.GetAltIndex();
            var wpno = (int) MainV2.comPort.MAV.cs.wpno;
            int newAlt = (int) alt_SlidingScale.Value;
            try
            {
                newAlt = Convert.ToInt32(FlightPlanner.instance.Commands.Rows[wpno - 1].Cells[altIndex].Value);
            }
            catch (Exception exception)
            {
                CustomMessageBox.Show("Выставите маршрутные точки на карте или считайте их с подключенного борта.",
                    "Не удалось найти текущую точку или высоту текущей точки!");
                return;
            }

            SetNewWPAlt(newAlt);

            _routeAltitude.StopHoldingAlt();
        }

        private static bool SetNewWPAlt(int newAlt)
        {
            try
            {
                MainV2.comPort.setNewWPAlt(new Locationwp {alt = newAlt / CurrentState.multiplieralt});
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorCommunicating, Strings.ERROR);
                return false;
            }

            return true;
        }

        private void RouteAltForm_Shown(object sender, EventArgs e)
        {
            SetFormLocation();
            SetToTop();
        }

        public void SetToTop()
        {
            this.TopMost = true;
        }

        public void SetFormLocation()
        {
            Point locationLocal = StatusControlPanel.instance.GetLocalRouteFormLocation();
            MainV2.RouteAltForm.Location = new Point(MainV2.instance.Location.X +
                AircraftMenuControl.Instance.Width + locationLocal.X,MainV2.instance.Location.Y + locationLocal.Y);
        }
    }
}