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
        public bool[] servos { get; set;}

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

        private void myButton2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "1";
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "5";
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "10";
        }

        private void myButton5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "20";
        }

        private void myButton6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "30";
        }

        private void myButton7_Click(object sender, EventArgs e)
        {
            textBox3.Text = "60";
        }

        private void updateServoButton(int i) 
        {
            
        }
    }
}
