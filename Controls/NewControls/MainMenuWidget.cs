using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using static MissionPlanner.Log.LogOutput;
using System.Runtime.InteropServices;
using AltitudeAngelWings.Models;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MissionPlanner.GCSViews;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls
{
    public partial class MainMenuWidget : MyUserControl
    {
        private bool _rulerClicked = false;
        public static MainMenuWidget Instance;

        public GMapRoute RulerRoute;

        private bool RulerClicked
        {
            get => _rulerClicked;
            set
            {
                if (value)
                {
                    RulerButton.BackColor = Color.Chartreuse;
                }
                else
                {
                    RulerButton.BackColor = Color.Transparent;
                }

                RulerButton.Invalidate();
                _rulerClicked = value;
            }
        }

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

        Delegate test;
        private bool active = false;
        private int X = 0;

        public MainMenuWidget()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            updateSize();
            Instance = this;
        }

        public void InitRuler()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            RulerRoute = new GMapRoute(points, "Distance measure")
                {Stroke = new Pen(Color.FromArgb(144, Color.Red), 2)};
            // RulerRoute.Stroke.Width = 2;
            // RulerRoute.Stroke.Color = Color.Red;
            FlightPlanner.RulerOverlay.Routes.Add(RulerRoute);
            RedrawRulerSurvey(RulerRoute);

            FlightPlanner.instance.OutlineForeColor = Color.FromArgb(255, Color.White);
            FlightPlanner.instance.OutlineWidth = 2;
        }

        public MainMenuWidget(Delegate t)
        {
            InitializeComponent();
            test = t;
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            //active = !active;
            //Console.WriteLine("MainButton pressed, now: "+active);
            //updateSize();
        }

        private void updateSize()
        {
            if (!active)
            {
                this.Size = new Size(60, 70);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            }
            else
            {
                this.Size = new Size(420, 70);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(-20, -20, Width, Height, 20, 20));
            }
        }

        public void setState(bool _active)
        {
            //active = _active;
            updateSize();
        }

        private void MainMenuWidget_MouseEnter(object sender, EventArgs e)
        {
            active = true;
            updateSize();
            //System.Diagnostics.Debug.WriteLine("active - true");
        }

        private void MainMenuWidget_MouseLeave(object sender, EventArgs e)
        {
            if (this.GetChildAtPoint(this.PointToClient(MousePosition)) == null)
            {
                active = false;
                updateSize();
                //System.Diagnostics.Debug.WriteLine("active - false");
            }
        }

        private void MapChoiseButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWW");
        }

        private void ParamsButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWW");
        }

        // public void ForceUpdateOverlays()
        // {
        //     if (FlightPlanner.instance.MainMap.Core.IsStarted)
        //     {
        //         FlightPlanner.instance.MainMap.ForceUpdateOverlays();
        //     }
        // }

        private void RulerButton_MouseDown(object sender, MouseEventArgs e)
        {
            RulerClicked = FlightPlanner.rulerActive = !RulerClicked;
            RulerRoute = FlightPlanner.instance.GetRulerRoute();
            if (!FlightPlanner.rulerActive)
            {
                RulerRoute.Points.Clear();
                RedrawRulerSurvey(RulerRoute);
                FlightPlanner.RulerOverlay.ForceUpdate();
            }
            else
            {
                RulerRoute.Stroke.Color = Color.FromArgb(144, Color.Red);
                RedrawRulerSurvey(RulerRoute);
            }

            // FlightPlanner.instance.MeasureDistance();
        }

        public void RedrawRulerSurvey(GMapRoute route) //here wp markers lived
        {
            if (route.Points.Count == 0)
            {
                FlightPlanner.RulerOverlay.Markers.Clear();
                FlightPlanner.instance.MainMap.Invalidate();
                return;
            }

            PointLatLng[] pointCopyList = new PointLatLng[route.Points.Count];
            route.Points.CopyTo(pointCopyList);
            route.Points.Clear();
            FlightPlanner.RulerOverlay.Markers.Clear();

            int tag = 0;
            pointCopyList.ForEach(x =>
            {
                tag++;
                route.Points.Add(x);
                addRouteMarkerGrid(tag.ToString(), x.Lng, x.Lat, 0);
            });

            FlightPlanner.instance.MainMap.UpdateRouteLocalPosition(route);

            FlightPlanner.instance.MainMap.Invalidate();
        }

        private void addRouteMarkerGrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Never;
                m.ToolTipText = "grid" + tag;
                m.Tag = "grid" + tag;

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                FlightPlanner.RulerOverlay.Markers.Add(m);
                FlightPlanner.RulerOverlay.Markers.Add(mBorders);
            }
            catch (Exception ex)
            {
                MainV2.log.Info(ex.ToString());
            }
        }
    }
}