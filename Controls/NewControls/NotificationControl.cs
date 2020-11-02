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
            defaultSize = new Size(this.Size.Width, this.Size.Height);       // 265; 41
            Region = ControlDrawingTools.CreateRoundRectRgn(0, -20, Width, Height, 20);
            
            //label1.Text = "Время полета: 00:00:00";
            redraw();

        }
        private bool fullSize = false;
        private Size defaultSize;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentFlightTime = "";
            string startFlightTime = "";
            AircraftConnectionInfo info;
            if (MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraftNum != null)
            {
                if (MainV2.Aircrafts.TryGetValue(MainV2.CurrentAircraftNum, out info))
                {
                    DateTime now = DateTime.Now;
                    DateTime diff = new DateTime(0);
                    if (info.hasStartTime)
                    {
                        diff += now - info.StartOfTheFlightTime;
                        startFlightTime = info.StartOfTheFlightTime.ToString("HH.mm.ss");
                        currentFlightTime = diff.ToString("HH.mm.ss");
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
                label2.Text =  currentFlightTime;
                label9.Text = startFlightTime;
            }
            else {
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
