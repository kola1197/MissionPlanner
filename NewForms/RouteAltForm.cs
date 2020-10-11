using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class RouteAltForm : Form
    {
        private bool _isMouseDown = false;
        private Point _previousMouseLocation;
        private readonly int _wheelDelta = SystemInformation.MouseWheelScrollDelta;
        private readonly int _maxAlt = 5100;
        private readonly int _minAlt = 80;
        private readonly int _altStep = 20;
        private readonly int _mouseMoveScale = 5;

        public RouteAltForm()
        {
            InitializeComponent();
            alt_SlidingScale.MouseWheel += alt_SlidingScaleOnMouseWheel;
        }

        private void alt_SlidingScaleOnMouseWheel(object sender, MouseEventArgs e)
        {
            int altChange = (e.Delta / _wheelDelta) * _altStep;
            if (IsAltInRange(altChange))
            {
                alt_SlidingScale.Value += altChange;
            }
        }

        private void alt_SlidingScale_ValueChanged(object sender, Orlan.ValueChangedEventArgs e)
        {

        }

        private void alt_SlidingScale_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _previousMouseLocation = e.Location;
        }

        private void alt_SlidingScale_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseDelta = (e.Location.Y - _previousMouseLocation.Y);
            if (_isMouseDown && Math.Abs(mouseDelta) > _mouseMoveScale && IsAltInRange(mouseDelta))
            {
                alt_SlidingScale.Value += Math.Sign(mouseDelta) * _altStep;
                _previousMouseLocation = e.Location;
            }
        }

        private void alt_SlidingScale_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }
        private bool IsAltInRange(int mouseDelta)
        {
            if (Math.Sign(mouseDelta) > 0 && alt_SlidingScale.Value < _maxAlt ||
                Math.Sign(mouseDelta) < 0 && alt_SlidingScale.Value > _minAlt)
            {
                return true;
            }

            return false;
        }

        private void RouteAltForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void route_BUT_Click(object sender, EventArgs e)
        {

        }
    }
}
