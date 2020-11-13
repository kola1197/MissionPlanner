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
using System.Threading;
using MissionPlanner.NewClasses;

namespace MissionPlanner.Controls.NewControls
{
    public partial class NotificationListControl : UserControl
    {
       //  [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
       //  private static extern IntPtr CreateRoundRectRgn
       // (
       //    int nLeftRect, // x-coordinate of upper-left corner
       //    int nTopRect, // y-coordinate of upper-left corner
       //    int nRightRect, // x-coordinate of lower-right corner
       //    int nBottomRect, // y-coordinate of lower-right corner
       //    int nWidthEllipse, // height of ellipse
       //    int nHeightEllipse // width of ellipse
       // );
        public bool fullList = false;
        public NotificationListControl()
        {
            InitializeComponent();
            Region = ControlDrawingTools.CreateRoundRectRgn(0, -20, Width, Height, 20);
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fullList = false;
            redraw();
        }

        public void redraw() 
        {
            if (fullList)
            {
                this.Size = new Size(this.Width, 50 * (MainV2.warnings.Count + MainV2.notifications.Count));
                label1.Size = new Size(this.Width, 50 * (MainV2.warnings.Count + MainV2.notifications.Count));
                Region = ControlDrawingTools.CreateRoundRectRgn(0, -20, Width, Height, 20);
                this.BackColor = Color.FromArgb(200, 32, 32, 32);
                this.Visible = true;
            }
            else 
            {

                this.Visible = false;
            }
        }

        private static System.Threading.Timer _timer;

        private static object locker;
        
        public bool IsTimerEnabled
        {
            get => _timer == null;
            set
            {
                if (value && _timer != null)
                {
                    return;
                }

                if (value)
                {
                    _timer = new System.Threading.Timer(_ => RefreshControl(), null, 0, 300);
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

        private void RefreshControl()
        {
            if (Monitor.TryEnter(locker))
            {

                try
                {
                    //label1.BackColor = Color.White;
                    string notifications = "";
                    notifications += "________";
                    for (int i = 0; i < MainV2.warnings.Count; i++)
                    {
                        notifications += "\n";
                        notifications += MainV2.warnings[i];
                        //label1.Text += "\n";
                    }

                    for (int i = 0; i < MainV2.notifications.Count; i++)
                    {
                        notifications += "\n";
                        notifications += MainV2.notifications[i];

                    }

                    label1.Text = notifications;
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
        }
    }
}
