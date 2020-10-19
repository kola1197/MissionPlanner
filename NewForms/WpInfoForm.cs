using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class WpInfoForm : Form
    {
        public WpInfoForm(int wpno, int altitude, string type, string homeDist)
        {
            InitializeComponent();
            wpInfoControl.wpInfo_GB.Text = "Точка " + wpno;
            wpInfoControl.alt_label.Text = altitude + " м";
            wpInfoControl.type_label.Text = type;
            wpInfoControl.homeDist_label.Text = homeDist;

            if (type == "HOME")
            {
                wpInfoControl.label14.Text = "";
            }
        }
    }
}
