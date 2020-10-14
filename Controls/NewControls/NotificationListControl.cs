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

namespace MissionPlanner.Controls.NewControls
{
    public partial class NotificationListControl : UserControl
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
        public bool fullList = false;
        public NotificationListControl()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, -20, Width, Height, 20, 20));
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
                this.Size = new Size(this.Width, 50 * MainV2.notifications.Count);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, -20, Width, Height, 20, 20));
                this.BackColor = Color.FromArgb(200, 32, 32, 32);
                this.Visible = true;
            }
            else 
            {

                this.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int i = 0; i < MainV2.notifications.Count; i++)
            {
                label1.Text += "\n";
                label1.Text += MainV2.notifications[i];
                label1.Text += "\n";
            }
        }
    }
}
