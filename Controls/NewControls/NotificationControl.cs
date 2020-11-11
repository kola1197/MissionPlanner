using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GMap.NET;
using MissionPlanner.GCSViews;
using MissionPlanner.NewClasses;

namespace MissionPlanner.Controls.NewControls
{
    public partial class NotificationControl : UserControl
    {
        // [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        // private static extern IntPtr CreateRoundRectRgn
        // (
        //    int nLeftRect, // x-coordinate of upper-left corner
        //    int nTopRect, // y-coordinate of upper-left corner
        //    int nRightRect, // x-coordinate of lower-right corner
        //    int nBottomRect, // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        // );
        public NotificationControl()
        {
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            InitializeComponent();
            defaultSize = new Size(this.Size.Width, this.Size.Height); // 265; 41
            Region = ControlDrawingTools.CreateRoundRectRgn(0, -20, Width, Height, 20);

            //label1.Text = "Время полета: 00:00:00";
            redraw();
        }

        private bool fullSize = false;
        private Size defaultSize;

        private System.Threading.Timer _timer;

        private bool _isTimerEnabled = false;

        public bool IsTimerEnabled
        {
            get => _isTimerEnabled;
            set
            {
                if (value == _isTimerEnabled)
                {
                    return;
                }

                _isTimerEnabled = value;
                if (value)
                {
                    _timer = new System.Threading.Timer(_ => RefreshControl(), null, 0, 100);
                }
                else
                {
                    if (_timer != null)
                    {
                        _timer.Dispose();
                    }
                }
            }
        }

        private bool _isTimerBusy = false;
        private string currentFlightTime = "";
        private string startFlightTime = "";

        private void RefreshControl()
        {
            if (_isTimerBusy)
            {
                return;
            }

            try
            {
                _isTimerBusy = true;
                FlightPlanner flightPlanner = FlightPlanner.instance;
                MAVLinkInterface comPort = MainV2.comPort;
                if (comPort.MAV.cs.connected)
                {
                    double homedistfromplane = 0;
                    int azimuth = 0;
                    if (flightPlanner.pointlist.Count > 0)
                    {
                        homedistfromplane = flightPlanner.MainMap.MapProvider.Projection.GetDistance(
                            new PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng), flightPlanner.pointlist[0]);
                        azimuth = (int) Math.Truncate(flightPlanner.GetAzimuthAngle(flightPlanner.pointlist[0],
                            new PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng)));
                    }

                    string homedistfromplaneString = flightPlanner.FormatDistance(homedistfromplane);
                    label3.Text = homedistfromplaneString;


                    azimuthUav_label.Text = azimuth + "°";
                }
                else
                {
                    label3.Text = "0 м";
                }

                label5.Text =
                    flightPlanner.FormatDistance(comPort.MAV.cs.wp_dist / 1000.0);
                double lengthCountr = 0;
                for (int i = 0; i < flightPlanner.Commands.Rows.Count; i++)
                {
                    string s = flightPlanner.Commands.Rows[i].Cells[flightPlanner.Dist.Index].Value.ToString();
                    lengthCountr += double.Parse(flightPlanner.Commands.Rows[i].Cells[flightPlanner.Dist.Index].Value
                        .ToString());
                }

                label7.Text = flightPlanner.FormatDistance(lengthCountr / 1000.0);

                
                AircraftConnectionInfo info;
                if (MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraftNum != null)
                {
                    if (MainV2.Aircrafts.TryGetValue(MainV2.CurrentAircraftNum, out info))
                    {
                        DateTime now = DateTime.Now;
                        DateTime diff = new DateTime(0);
                        if (info.hasStartTime)
                        {
                            startFlightTime = info.StartOfTheFlightTime.ToString("HH.mm.ss");
                            if (!info.ParachuteReleased && !MainV2.IsSitlLanding)
                            {
                                diff += now - info.StartOfTheFlightTime;
                                currentFlightTime = diff.ToString("HH.mm.ss");
                            }
                        }
                        else
                        {
                            currentFlightTime = "00:00:00";
                            startFlightTime = "00:00:00";
                        }
                    }
                    else
                    {
                        currentFlightTime = "00:00:00";
                        startFlightTime = "00:00:00";
                    }
                }
                else
                {
                    currentFlightTime = "00:00:00";
                    startFlightTime = "00:00:00";
                }

                if (fullSize)
                {
                    //label1.Text = "Удаление от дома";
                    //label1.Text += "Расстояние до точки";
                    //label1.Text += "Длинна маршрута";
                    //label1.Text += "Удаление от дома";
                    label2.Text = currentFlightTime;
                    label9.Text = startFlightTime;
                }
                else
                {
                    label2.Text = currentFlightTime;
                }

                /*if (MainV2.notifications.Count > 0)
                {
                    if (fullSize) 
                    {
                        label1.Text = "";
                        for (int i = 0; i < MainV2.notifications.Count;i++) {
                            label1.Text += "\n";
                            label1.Text += MainV2.notifications[i];
                            label1.Text += "\n";
                        }
                    }
                    else
                    {
                        label1.Text = MainV2.notifications[0];
                    }
                }
                else {
                    label1.Text = "";
                }*/
            }
            catch
            {
                _isTimerBusy = false;
            }
            finally
            {
                _isTimerBusy = false;
            }
        }

        private void redraw()
        {
            this.Size = fullSize ? new Size(330, 180) : new Size(330, 40);
            Region = ControlDrawingTools.CreateRoundRectRgn(0, -20, Width, Height, 20);
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            label10.Visible = fullSize;
            label9.Visible = fullSize;
            label8.Visible = fullSize;
            label7.Visible = fullSize;
            label6.Visible = fullSize;
            label5.Visible = fullSize;
            label4.Visible = fullSize;
            label3.Visible = fullSize;
            //label1.Size = fullSize ? new Size(defaultSize.Width, defaultSize.Height * 5) : defaultSize;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fullSize = !fullSize;
            redraw();
        }

        private void NotificationControl_Click(object sender, EventArgs e)
        {
            fullSize = !fullSize;
            redraw();
        }
    }
}