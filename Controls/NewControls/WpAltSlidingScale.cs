using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.GCSViews;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class WpAltSlidingScale : UserControl
    {
        private bool _isMouseDown = false;
        private Point _previousMouseLocation;
        private readonly int _wheelDelta = SystemInformation.MouseWheelScrollDelta;
        private readonly int _altStep = 10;
        private readonly int _mouseMoveScale = 1;
        public WpAltSlidingScale()
        {
            InitializeComponent();
            alt_SlidingScale.MouseWheel += alt_SlidingScaleOnMouseWheel;
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
            alt_SlidingScale.Value = tempAlt;
        }

        private void InsignificantChangeValue()
        {
            var middleValue = (alt_SlidingScale.MaxValue - alt_SlidingScale.MinValue) / 2;
            alt_SlidingScale.Value = alt_SlidingScale.Value + Math.Sign(middleValue - alt_SlidingScale.Value) * 0.01;
        }

    }
}
