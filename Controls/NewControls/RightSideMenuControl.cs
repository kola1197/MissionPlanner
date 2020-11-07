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
        // [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        // private static extern IntPtr CreateRoundRectRgn
        // (
        //     int nLeftRect, // x-coordinate of upper-left corner
        //     int nTopRect, // y-coordinate of upper-left corner
        //     int nRightRect, // x-coordinate of lower-right corner
        //     int nBottomRect, // y-coordinate of lower-right corner
        //     int nWidthEllipse, // height of ellipse
        //     int nHeightEllipse // width of ellipse
        // );

        private UserControl activeControl = null;
        private AntennaControl antennaControl;
        private FlightByCompassControl flightByCompassControl;
        private RegionsControl regionsControl;

        private GskControl gskControl;
        // public RightSideMenuControl Instance;
        private Control some_control;
        private Point some_point;
        public RightSideMenuControl()
        {
            InitializeComponent();
            antennaControl = new AntennaControl { Visible = false, Location = new Point(35, 4)}; //локацию по Y не трош!!!!!!!!!!!!!
            flightByCompassControl = new FlightByCompassControl { Visible = false, Location = new Point(35, 4) };
            regionsControl = new RegionsControl { Visible = false, Location = new Point(35, 4) };
            gskControl = new GskControl(){Visible = false, Location = new Point(35, 4) };

            some_control = menuStrip1.Parent;
            some_point = menuStrip1.Location;
            
            this.Controls.Add(antennaControl);
            this.Controls.Add(flightByCompassControl);
            this.Controls.Add(regionsControl);
            this.Controls.Add(gskControl);
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
            /*if (control.Visible)
            {
                //menuStrip1.Parent = control;
                //menuStrip1.Location = new Point(-126, 0);
                //menuStrip1.Visible = true;
                control.Parent = menuStrip1;
            } else
            {
                //menuStrip1.Parent = some_control;
                // menuStrip1.Location = some_point;
                control.Parent = this;
            }*/
            activeControl = control.Visible ? control : null;
            Invalidate();
        }

        private void antennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(antennaControl);
            antennaControl.ShowCurrentBaudInCmb();
        }


        private void ppkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(flightByCompassControl);
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(regionsControl);
            FlightPlanner.regionActive = FlightPlanner.instance.polygongridmode = regionsControl.Visible;
            regionsControl.RedrawPolygonSurvey(regionsControl.GetCurrentPolygon());
        }

        private void gskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchControl(gskControl);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
