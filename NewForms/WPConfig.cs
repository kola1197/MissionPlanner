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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                label10.Visible = true;
                textBox5.Visible = true;
            }
            else 
            {
                label10.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void myTrackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = myTrackBar1.Value.ToString() + " M";
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
