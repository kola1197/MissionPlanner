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

        public void SetInfo(int wpno, int altitude, string type, string homeDist, int typeCode)
        {
            wpInfo_GB.Text = "Точка " + wpno;
            alt_label.Text = altitude + " м";

            if (type == "HOME")
            {
                type_label.Text = type;
            }
            else
            {
                string typeText = "";
                switch (typeCode)              // 0 - takeoff, 1 - wp, 2 - DO_CHANGE_SPEED, 3 - DO_PARACHUTE
                {
                    case 0:
                        typeText = "Точка взлета";
                        break;
                    case 1:
                        typeText = "Маршрутная \n точка";
                        break;
                    case 2:
                        typeText = "Изменение \n скорости";
                        break;
                    case 3:
                        typeText = "Точка посадки";
                        break;
                    default: 
                        break;
                }
                type_label.Text = typeText;
            }
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
