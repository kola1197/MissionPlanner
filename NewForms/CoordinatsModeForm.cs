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

namespace MissionPlanner.NewForms
{
    public partial class CoordinatsModeForm : Form
    {
        public CoordinatsModeForm()
        {
            InitializeComponent();
            updateButtons();
        }

        public void updateButtons() 
        {
            wgs_gButton.BackColor = MainV2.coordinatsShowMode == 0? Color.Green : Color.Gray;
            wgs_gmButton.BackColor = MainV2.coordinatsShowMode == 1 ? Color.Green : Color.Gray;
            wgs_gmsButton.BackColor = MainV2.coordinatsShowMode == 2 ? Color.Green : Color.Gray;
            sk_gButton.BackColor = MainV2.coordinatsShowMode == 3 ? Color.Green : Color.Gray;
            sk_gmButton.BackColor = MainV2.coordinatsShowMode == 4 ? Color.Green : Color.Gray;
            sk_gmsButton.BackColor = MainV2.coordinatsShowMode == 5 ? Color.Green : Color.Gray;
            orthogonalСoordinatesButton.BackColor = MainV2.coordinatsShowMode == 6 ? Color.Green : Color.Gray;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button send = (Button)sender;
            string sTag = (string)send.Tag;
            int tag = int.Parse(sTag);
            MainV2.coordinatsShowMode = tag;
            MainV2.setCoordinatsMode();
            updateButtons();
            RegionsControl.instance.UpdateBindings();
        }

        private void wgs_gButton_BackColorChanged(object sender, EventArgs e)
        {
            int k = 0;
        }
    }
}
