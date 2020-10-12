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
        }
        private bool fullSize = false;
        private Size defaultSize;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainV2.notifications.Count > 0)
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
            }
        }

        private void redraw() 
        {
            this.Size = fullSize? new Size(defaultSize.Width, (int)Math.Min(defaultSize.Height + 80 * (MainV2.notifications.Count - 1), defaultSize.Height * 15)) : defaultSize;

            label1.Size = fullSize ? new Size(defaultSize.Width, (int)Math.Min(defaultSize.Height + 80 * (MainV2.notifications.Count - 1), defaultSize.Height * 15)) : defaultSize;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MainV2.notifications.Count > 1 || fullSize)
            {
                fullSize = !fullSize;
                redraw();
            }
        }

        private void dataListView1_Click(object sender, EventArgs e)
        {
            if (MainV2.notifications.Count > 1 || fullSize)
            {
                fullSize = !fullSize;
                redraw();
            }
        }
    }
}
