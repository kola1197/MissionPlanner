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
using MissionPlanner.GCSViews;
using Color = System.Drawing.Color;
using Region = KMLib.Region;
using System.Runtime.InteropServices;

namespace MissionPlanner.Controls.NewControls
{
    public partial class RightSideMenuControl : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private UserControl activeControl = null;
        private AntennaControl antennaControl;
        private FlightByCompassControl flightByCompassControl;
        private RegionsControl regionsControl;
        // public RightSideMenuControl Instance;
        public RightSideMenuControl()
        {
            InitializeComponent();
            antennaControl = new AntennaControl {Visible = false, Location = new Point(35, 0)};
            flightByCompassControl = new FlightByCompassControl { Visible = false, Location = new Point(35, 0) };
            regionsControl = new RegionsControl { Visible = false, Location = new Point(35, 0) };
            
            this.Controls.Add(antennaControl);
            this.Controls.Add(flightByCompassControl);
            this.Controls.Add(regionsControl);
            this.BackColor = Color.FromArgb(200, Color.Black);
            // Instance = this;
        }

        public void Init()
        {
            // foreach (Control control in Controls)
            // {
            //     control.Parent = this.Parent;
            //     control.BackColor = Color.FromArgb(200, Color.Black);
            // }
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

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(regionsControl);
            FlightPlanner.regionActive = FlightPlanner.instance.polygongridmode = regionsControl.Visible;
        }
    }
}
