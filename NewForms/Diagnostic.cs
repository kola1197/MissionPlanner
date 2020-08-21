using Flurl.Util;
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
    public partial class DiagnosticForm : Form
    {
        public DiagnosticForm()
        {
            InitializeComponent();
            var list = MainV2.comPort.MAV.cs.GetItemList(true);
            //System.Diagnostics.Debug.WriteLine(list.ToString());
            foreach (var v in list) 
            {
                System.Diagnostics.Debug.WriteLine(v.ToString());
            }
            updateInfo();
        }

        public void updateInfo()
        {
            label3.Text = MainV2.comPort.MAV.cs.ekfstatus.ToString();
            label5.Text = "( " + MainV2.comPort.MAV.cs.vibex.ToString() + "; " + MainV2.comPort.MAV.cs.vibey.ToString() + "; " + MainV2.comPort.MAV.cs.vibey.ToString() + " )";
            //label7.Text = MainV2.comPort.MAV.cs.i;
            label9.Text = MainV2.comPort.MAV.cs.gpsstatus.ToString();
        }

        private void butClickAction(int butNum)
        {
            if (MainV2._aircraftInfo.Count == 0)
            {
                MainV2._connectionsForm.Show();
                return;
            }

            if (MainV2._aircraftInfo.Count > butNum)
            {
                MainV2._connectionsForm.switchConnectedAircraft(MainV2._aircraftInfo.ElementAt(butNum).Value);
            }
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            butClickAction(0);
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            butClickAction(1);
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            butClickAction(2);
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            butClickAction(3);
        }
    }
}
