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
    public partial class NotificationListControl : UserControl
    {
        public bool fullList = false;
        public NotificationListControl()
        {
            InitializeComponent();
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
                this.Size = new Size(this.Width, 50 * MainV2.notifications.Count + 50);
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
