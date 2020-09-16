using System;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class ModeChangeForm : Form
    {
        public ModeChangeForm()
        {
            InitializeComponent();
            CMB_modes.DataSource = ArduPilot.Common.getModesList(MainV2.comPort.MAV.cs.firmware);
            CMB_modes.ValueMember = "Key";
            CMB_modes.DisplayMember = "Value";

            //default to auto
            CMB_modes.Text = "Auto";
        }

        private void BUTsetmode_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainV2.comPort.MAV.cs.failsafe)
            {
                if (CustomMessageBox.Show("You are in failsafe, are you sure?", "Failsafe", MessageBoxButtons.YesNo) !=
                    (int) DialogResult.Yes)
                {
                    return;
                }
            }

            MainV2.comPort.setMode(CMB_modes.Text);
        }

        private void BUT_setmode_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.failsafe)
            {
                if (CustomMessageBox.Show("You are in failsafe, are you sure?", "Failsafe", MessageBoxButtons.YesNo) !=
                    (int) DialogResult.Yes)
                {
                    return;
                }
            }

            MainV2.comPort.setMode(CMB_modes.Text);
        }

        private void ModeChangeForm_Load_1(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
    }

}