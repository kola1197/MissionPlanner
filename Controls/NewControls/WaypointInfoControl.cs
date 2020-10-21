using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class WaypointInfoControl : UserControl
    {
        public WaypointInfoControl()
        {
            InitializeComponent();
        }

        public void SetInfo(int wpno, int altitude, string type, string homeDist)
        {
            wpInfo_GB.Text = "Точка " + wpno;
            alt_label.Text = altitude + " м";
            type_label.Text = type;
            homeDist_label.Text = homeDist;
            
            // BackColor = Color.FromArgb(100, Color.Black);
            BackColor = Color.Transparent;
            wpInfo_GB.BackColor = Color.FromArgb(155, Color.Black);
            foreach (Control control in wpInfo_GB.Controls)
            {
                control.BackColor = Color.Transparent;
            }
            if (type == "HOME")
            {
                label14.Text = "";
            }
            else
            {
                label14.Text = "До дома:";
            }
        }
    }
}
