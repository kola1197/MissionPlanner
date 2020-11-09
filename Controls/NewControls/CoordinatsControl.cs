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
        private static CoordinatsModeForm _coordinatsModeForm = new CoordinatsModeForm() {Visible = false};

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
            if (_coordinatsModeForm.IsDisposed || !_coordinatsModeForm.Visible)
            {
                _coordinatsModeForm = new CoordinatsModeForm() {Visible = false};
                _coordinatsModeForm.SetToTop();
                _coordinatsModeForm.SetFormLocation();
                MainV2.FormConnector.ConnectForm(_coordinatsModeForm);
                _coordinatsModeForm.updateButtons();
                _coordinatsModeForm.Show();
                _coordinatsModeForm.updateButtons();
            }
            else
            {
                _coordinatsModeForm.Close();
            }
        }
    }
}