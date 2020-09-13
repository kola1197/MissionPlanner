using System;
using System.Drawing;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SensorUserControl : UserControl
    {
        public SensorUserControl()
        {
            InitializeComponent();
        }

        public virtual event EventHandler SensorOnClick;

        public virtual System.Drawing.Size ControlSize { get; }
    }
}