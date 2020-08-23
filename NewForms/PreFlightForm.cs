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
    }
}
