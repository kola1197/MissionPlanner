using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDAL;

namespace MissionPlanner.Controls.NewControls
{
    public partial class RightSideMenuControl : UserControl
    {
        private UserControl activeControl = null;
        private AntennaControl antennaControl;
        private FlightByCompassControl flightByCompassControl;
        public RightSideMenuControl()
        {
            InitializeComponent();
            antennaControl = new AntennaControl { Visible = false };
            antennaControl.Location = new Point(35, 0);
            this.Controls.Add(antennaControl);
            flightByCompassControl = new FlightByCompassControl { Visible = false, Location = new Point(35, 0) };
            this.Controls.Add(flightByCompassControl);
        }

        private void switchControl(UserControl control) 
        {
            if (activeControl != null)
            {
                activeControl.Visible = (control == activeControl); 
            }
            control.Visible = !control.Visible;
            activeControl = control.Visible ? control : null;
            Invalidate();
        }

        private void antennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(antennaControl);
        }


        private void ppkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(flightByCompassControl);
        }
    }
}
