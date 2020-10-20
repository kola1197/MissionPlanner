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
    public partial class CoordinatsControl : UserControl
    {
        CoordinatsModeForm coordinatsModeForm;
        public CoordinatsControl()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (coordinatsModeForm != null)
            {
                coordinatsModeForm.Close();
            }
            coordinatsModeForm = new CoordinatsModeForm();
            coordinatsModeForm.TopMost = true;
            coordinatsModeForm.updateButtons();
            coordinatsModeForm.Show();
            coordinatsModeForm.updateButtons();

        }
    }
}
