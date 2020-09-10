using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class RightSideMenuControl : UserControl
    {
        private AntennaControl antennaControl;
        public RightSideMenuControl()
        {
            InitializeComponent();
            antennaControl = new AntennaControl {Visible = false, Dock = DockStyle.Fill};
        }

        private void antennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            antennaControl.Visible = !antennaControl.Visible;
            Invalidate();
        }
    }
}
