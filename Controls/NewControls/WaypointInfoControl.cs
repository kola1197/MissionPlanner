using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.GCSViews;
using MissionPlanner.NewClasses;
using Xamarin.Forms.Internals;

namespace MissionPlanner.NewForms
{
    public partial class WaypointInfoControl : UserControl
    {
        private UniversalCoordinatsController controller;

        public WaypointInfoControl()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            DoubleBuffered = true;
            ///SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void CreateController(int wpno, string type)
        {
            if (type.ToLower() == "rally" || type == "HOME")
            {
                controller = new UniversalCoordinatsController(new NewClasses.WGSCoordinats(
                    FlightPlanner.instance.pointlist[0].Lat.ToString(),
                    FlightPlanner.instance.pointlist[0].Lng.ToString()));
            }
            else
            {
                controller = new NewClasses.UniversalCoordinatsController(new NewClasses.WGSCoordinats(
                    FlightPlanner.instance.Commands.Rows[wpno - 1].Cells[FlightPlanner.instance.Lat.Index].Value
                        .ToString(),
                    FlightPlanner.instance.Commands.Rows[wpno - 1].Cells[FlightPlanner.instance.Lon.Index].Value
                        .ToString()));
            }
        }

        public void SetInfo(int wpno, int altitude, string type, string homeDist, int typeCode)
        {
            CreateController(wpno, type);

            wpInfo_GB.Text = "Точка " + MainV2.instance.FlightPlanner.getWPSerialNumber(wpno - 1);
            alt_label.Text = altitude + " м";

            if (type == "HOME" || type.ToLower() == "rally")
            {
                type_label.Text = type;
                label14.Text = "";
            }
            else
            {
                label14.Text = "До дома:";
                string typeText = "";
                switch (typeCode) // 0 - takeoff, 1 - wp, 2 - DO_CHANGE_SPEED, 3 - DO_PARACHUTE
                {
                    case 0:
                        typeText = "Точка взлета";
                        break;
                    case 1:
                        typeText = "Маршрутная \n точка";
                        break;
                    case 2:
                        typeText = "Изменение \n скорости";
                        break;
                    case 3:
                        typeText = "Точка посадки";
                        break;
                    default:
                        break;
                }

                type_label.Text = typeText;
            }
            

            lat_label.Text = RegionsControl.instance.FormatCoordinateFromWgs(controller, true);
            lng_label.Text = RegionsControl.instance.FormatCoordinateFromWgs(controller, false);

            homeDist_label.Text = homeDist.ToString(new CultureInfo("en-US"));

            // BackColor = Color.FromArgb(100, Color.Black);
            //BackColor = Color.Transparent;
            //wpInfo_GB.BackColor = Color.FromArgb(155, Color.Black);
            //foreach (Control control in wpInfo_GB.Controls)
            //{
            //    control.BackColor = Color.Transparent;
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // FlightPlanner.instance.timer1_Tick(sender, new EventArgs());
            FlightPlanner.instance.UpdateMapResources();
            FlightPlanner.instance.Refresh();
        }

        private bool _needMainMapRefresh = false;

        public bool NeedMainMapRefresh
        {
            get => _needMainMapRefresh;
            set => _needMainMapRefresh = timer1.Enabled = value;
        }

        private void wpInfo_GB_TextChanged(object sender, EventArgs e)
        {
            wpnoLabel.Text = wpInfo_GB.Text;
        }
    }
}