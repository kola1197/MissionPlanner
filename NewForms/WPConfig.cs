using GMap.NET.WindowsForms;
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
    public partial class WPConfig : Form
    {
        public WPConfig()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public WPConfig(GMapMarkerRect CurentRectMarker)
        {
            InitializeComponent();
            this.TopMost = true;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + CurentRectMarker.Tag.ToString();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
