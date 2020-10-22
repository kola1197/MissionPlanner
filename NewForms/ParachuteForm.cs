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
    public partial class ParachuteForm : Form
    {
        public ParachuteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.connected)
            {
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 12, 1900, 0, 0, 0, 0, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.mode.ToLower() != "manual")        
            {
                MainV2.comPort.setMode("Manual");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.connected)
            {
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 9, 1900, 0, 0, 0, 0, 0);
            }
        }
    }
}
