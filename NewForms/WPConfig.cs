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
        public bool closedByButton = false;
        public bool[] servos = new bool[9];

        public WPConfig()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        /*public WPConfig(string s)
        {
            InitializeComponent();
            this.TopMost = true;
            Text = s;
            if (s == "Home")
            {
                
            }
        }*/

        public int indexNow = -1;
        public int SerialNum = -1;

        public WPConfig(string _serNum)
        {
            InitializeComponent();
            this.TopMost = true;
            //SerialNum = _serNum;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + _serNum.ToString();
            textBox1.Text = "";
        }

        public WPConfig(GMapMarkerRect currentRectMarker, string _serNum)
        {

            InitializeComponent();
            this.TopMost = true;
            //SerialNum = _serNum;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + _serNum.ToString();
            
            if (currentRectMarker.Tag.ToString() != "H" && _serNum.ToLower() != "rally")
            {
                indexNow = int.Parse(currentRectMarker.Tag.ToString()) - 1;
            }
            

            textBox1.Text = "";
        }
        
        /*public WPConfig(GMapMarkerRect currentRectMarker, int _serNum)
        {

            InitializeComponent();
            this.TopMost = true;
            SerialNum = _serNum;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + SerialNum.ToString();
            indexNow = int.Parse(currentRectMarker.Tag.ToString()) -1;
            textBox1.Text = "";
        }*/

       
        private void myButton1_Click(object sender, EventArgs e)
        {
            closedByButton = true;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                label10.Visible = true;
                label11.Visible = true;
                textBox5.Visible = true;
                textBox5.Text = "20";
            }
            else 
            {
                label10.Visible = false;
                label11.Visible = false;
                textBox5.Visible = false;
            }
            if (comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 0)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else 
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
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

        public void updateServoButtons() 
        {
            myButton8.BGGradTop = servos[0] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton9.BGGradTop = servos[1] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton10.BGGradTop = servos[2] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton13.BGGradTop = servos[3] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton12.BGGradTop = servos[4] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton11.BGGradTop = servos[5] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton16.BGGradTop = servos[6] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton15.BGGradTop = servos[7] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            myButton14.BGGradTop = servos[8] ? ColorTranslator.FromHtml("#80FF80") : ColorTranslator.FromHtml("#FFFFCC");
            Invalidate();
        }

        private void updateServoButton(int i) 
        {
            servos[i] = !servos[i];
            updateServoButtons();
        }

        private void myButton8_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(0);
        }

        private void myButton9_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(1);
        }

        private void myButton10_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(2);
        }

        private void myButton13_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(3);
        }

        private void myButton12_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(4);
        }
        private void myButton11_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(5);
        }

        private void myButton16_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(6);
        }

        private void myButton15_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(7);
        }

        private void myButton14_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(8);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = !checkBox1.Checked;
        }
    }
}
