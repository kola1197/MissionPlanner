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
using MissionPlanner.NewClasses;
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

        Delegate test;
        private bool active = false;
        private int X = 0;

        public MainMenuWidget()
        {
            InitializeComponent();
            Region = ControlDrawingTools.CreateRoundRectRgn(-20, -20, Width, Height, 20);
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            updateSize();
            Instance = this;
            MapChoiseButton.MouseEnter += Button_MouseEnter;
            MapChoiseButton.MouseLeave += Button_MouseLeave;

            EKFButton.MouseEnter += Button_MouseEnter;
            EKFButton.MouseLeave += Button_MouseLeave;

            ParamsButton.MouseEnter += Button_MouseEnter;
            ParamsButton.MouseLeave += Button_MouseLeave;


            RulerButton.MouseEnter += Button_MouseEnter;
            RulerButton.MouseLeave += Button_MouseLeave;

            centeringButton.MouseEnter += Button_MouseEnter;
            centeringButton.MouseLeave += Button_MouseLeave;

            homeButton.MouseEnter += Button_MouseEnter;
            homeButton.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                MyButton b = (MyButton)sender;
                toolTip1.InitialDelay = 2000;
                toolTip1.Show(b.Tag.ToString(), b);
            }
            catch { }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                MyButton b = (MyButton)sender;
                toolTip1.Hide(b);
            }
            catch { }
        }

        private void MapChoiseButton_MouseEnter(object sender, EventArgs e)
        {
                //MyButton b = (MyButton)sender;
                toolTip1.InitialDelay = 10;
                toolTip1.Show(MapChoiseButton.Tag.ToString(), MapChoiseButton);   
        }

        public void InitRuler()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            RulerRoute = new GMapRoute(points, "Distance measure")
                {Stroke = new Pen(Color.FromArgb(200, Color.Red), 2)};
            // RulerRoute.Stroke.Width = 2;
            // RulerRoute.Stroke.Color = Color.Red;
            FlightPlanner.RulerOverlay.Routes.Add(RulerRoute);
            RedrawRulerSurvey(RulerRoute);

            FlightPlanner.instance.OutlineTotalDistanceColor = Color.FromArgb(255, Color.Black);
            FlightPlanner.instance.OutlineDistanceBetweenPointsColor = Color.FromArgb(255, Color.Black);
            FlightPlanner.instance.OutlineWidth = 2;
        }

        public MainMenuWidget(Delegate t)
        {
            InitializeComponent();
            test = t;
            MapChoiseButton.MouseEnter += MapChoiseButton_MouseEnter;

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
                this.Size = new Size(70, 70);
                Region = ControlDrawingTools.CreateRoundRectRgn(-20, -20, Width, Height, 20);
            }
            else
            {
                this.Size = new Size(420, 70);
                Region = ControlDrawingTools.CreateRoundRectRgn(-20, -20, Width, Height, 20);
            }
        }

        public void setState(bool _active)
        {
            active = _active;
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
            try
            {
                MyButton b = (MyButton)sender;
                toolTip1.Hide(b);
            }
            catch { }
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

        public bool onMainMap = true;
        private void RulerButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (onMainMap)
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