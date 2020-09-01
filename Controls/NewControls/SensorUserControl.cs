using System;
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
    }
}