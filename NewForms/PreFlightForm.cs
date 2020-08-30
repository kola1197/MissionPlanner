using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    public partial class PreFlightForm : Form
    {
        int selectedIndex = 0;
        int progressIndex = 0;
        public PreFlightForm()
        {
            InitializeComponent();
            this.TopMost = true;
            batt2_voltage.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > progressIndex)
            {
                tabControl1.SelectedIndex = selectedIndex;
            }
            else 
            {
                selectedIndex = tabControl1.SelectedIndex;
            }
        }

        private void nextButton1_Click(object sender, EventArgs e)
        {
            if (checkListControl1.allRight() || true) 
            {
                progressIndex = progressIndex > 1 ? progressIndex : 1;
                selectedIndex = 1;
                tabControl1.SelectedIndex = selectedIndex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AirSpeedLabel.Text = MainV2.comPort.MAV.cs.airspeed.ToString();
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void gotReaction_Click(object sender, EventArgs e)
        {
            progressIndex = progressIndex > 2 ? progressIndex : 2;
            selectedIndex = 2;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void backButton2_Click(object sender, EventArgs e)
        {
            selectedIndex--;
            tabControl1.SelectedIndex = selectedIndex;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                batt2_voltage.Text = MainV2.comPort.MAV.cs.battery_voltage2.ToString();
            }
        }

        private void maxСapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
            //updateMainV2Data();
        }

        private void batt2_voltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
            checkBox1.Checked = false;
            //updateMainV2Data();
        }
        //      public int maxCapacity = 0;
        //      public int flyTime = 0;
        //      public int butt2RealVoltage = 0;

        private void updateMainV2Data() 
        {
            MainV2.butt2RealVoltage = int.Parse(batt2_voltage.Text);
            MainV2.maxCapacity = int.Parse(maxСapacity.Text);
            MainV2.flyTime = int.Parse(flightTimeTBox.Text);
            int percent = 0;
            if (MainV2.maxCapacity != 0)
            {
                percent = MainV2.butt2RealVoltage / MainV2.maxCapacity;
            }
            valueInPercentsTBox.Text = percent.ToString();
        }

        private void batt2_voltage_TextChanged(object sender, EventArgs e)
        {
            updateMainV2Data();
        }
    }
}
