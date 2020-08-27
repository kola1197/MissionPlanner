using GMap.NET.WindowsForms;
using MissionPlanner.Utilities;
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
        public int indexNow = -1;
        public WPConfig(GMapMarkerRect CurentRectMarker)
        {

            InitializeComponent();
            this.TopMost = true;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + CurentRectMarker.Tag.ToString();
            indexNow = int.Parse(CurentRectMarker.Tag.ToString()) -1;
            textBox1.Text = "";
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
        }


    }
}
