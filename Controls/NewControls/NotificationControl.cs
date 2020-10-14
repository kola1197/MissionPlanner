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
    public partial class NotificationControl : UserControl
    {
        public NotificationControl()
        {
            InitializeComponent();
            defaultSize = new Size(this.Size.Width, this.Size.Height);       // 265; 41
            //label1.Text = "Время полета: 00:00:00";
            redraw();

        }
        private bool fullSize = false;
        private Size defaultSize;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentFlightTime = "";
            Orlan.AircraftConnectionInfo info;
            if (MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraftNum != null)
            {
                if (MainV2._aircraftInfo.TryGetValue(MainV2.CurrentAircraftNum, out info))
                {
                    DateTime now = DateTime.Now;
                    DateTime diff = new DateTime(0);
                    if (info.hasStartTime)
                    {
                        diff += now - info.StartOfTheFlightTime;
                        currentFlightTime = diff.ToString("HH.mm.ss");
                    }
                    else
                    {
                        currentFlightTime = "00:00:00";
                    }
                }
                else
                {
                    currentFlightTime = "00:00:00";
                }
            }
            else
            {
                currentFlightTime = "00:00:00";
            }
            if (fullSize)
            {
                //label1.Text = "Удаление от дома";
                //label1.Text += "Расстояние до точки";
                //label1.Text += "Длинна маршрута";
                //label1.Text += "Удаление от дома";
                label2.Text =  currentFlightTime;
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
