using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class CoordinatsModeForm : Form, IFormConnectable
    {
        public CoordinatsModeForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            updateButtons();
        }

        public void updateButtons() 
        {
            wgs_gButton.BackColor = MainV2.CoordinatsShowMode == 0? Color.Green : Color.Gray;
            wgs_gmButton.BackColor = MainV2.CoordinatsShowMode == 1 ? Color.Green : Color.Gray;
            wgs_gmsButton.BackColor = MainV2.CoordinatsShowMode == 2 ? Color.Green : Color.Gray;
            sk_gButton.BackColor = MainV2.CoordinatsShowMode == 3 ? Color.Green : Color.Gray;
            sk_gmButton.BackColor = MainV2.CoordinatsShowMode == 4 ? Color.Green : Color.Gray;
            sk_gmsButton.BackColor = MainV2.CoordinatsShowMode == 5 ? Color.Green : Color.Gray;
            orthogonalСoordinatesButton.BackColor = MainV2.CoordinatsShowMode == 6 ? Color.Green : Color.Gray;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button send = (Button)sender;
            string sTag = (string)send.Tag;
            int tag = int.Parse(sTag);
            MainV2.CoordinatsShowMode = tag;
            MainV2.setCoordinatsMode();
            updateButtons();
            RegionsControl.instance.UpdateBindings();
        }

        private void wgs_gButton_BackColorChanged(object sender, EventArgs e)
        {
            int k = 0;
        }

        public void SetFormLocation()
        {
            Location = new Point(MainV2.instance.Location.X + 0, MainV2.instance.GetLowerPanelLocation().Y - this.Height + 20);
        }

        public void SetToTop()
        {
            TopMost = true;
        }

        private void CoordinatsModeForm_Shown(object sender, EventArgs e)
        {
            SetToTop();
        }

        private void CoordinatsModeForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
