using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.NewForms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SNSControl : UserControl
    {
        private ModeChangeForm modeChangeForm;
        private SNSInfo snsInfo;
        private Vibration frm;
        public SNSControl()
        {
            InitializeComponent();
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (snsInfo != null) 
            {
                snsInfo.Close();
            }
            snsInfo = new SNSInfo();
            snsInfo.Show();
        }

        private void myButton2_MouseUp(object sender, EventArgs e)
        {
            modeChangeForm = new ModeChangeForm();
            modeChangeForm.Show();
        }

        

        private void myButton3_MouseUp(object sender, MouseEventArgs e)
        {
            if (frm != null) {
                frm.Close();
            }
            frm = new Vibration();
            frm.TopMost = true;
            frm.Show();
        }
    }
}
