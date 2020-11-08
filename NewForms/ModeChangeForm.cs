using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Controls;

namespace MissionPlanner.NewForms
{
    public partial class ModeChangeForm : Form
    {
        public ModeChangeForm()
        {
            InitializeComponent();
            string[] whiteList = new string[] {"Auto", "Manual", "Land", "STABILIZE" };
            List<KeyValuePair<int, string>> modelList = ArduPilot.Common.getModesList(MainV2.comPort.MAV.cs.firmware);
            List<KeyValuePair<int, string>> fixedModelList = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < modelList.Count; i++) 
            {
                for (int j = 0; j < whiteList.Length; j++)
                {
                    if (whiteList[j].ToLower() == modelList[i].Value.ToLower())
                    {
                        fixedModelList.Add(modelList[i]);
                    }
                }
            }
            // CMB_modes.DataSource = fixedModelList;
            // CMB_modes.ValueMember = "Key";
            // CMB_modes.DisplayMember = "Value";

            //default to auto
            // CMB_modes.Text = "Auto";
        }

        public void setPosition() 
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(125, MainV2.instance.Height - 150);
        }

        public void setPosition(Point p)
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = p;
        }

        private void SetMode_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as MyButton;
            if (MainV2.comPort.MAV.cs.connected)
            {
                if (MainV2.comPort.MAV.cs.failsafe)
                {
                    if (CustomMessageBox.Show("You are in failsafe, are you sure?", "Failsafe", MessageBoxButtons.YesNo) !=
                        (int)DialogResult.Yes)
                    {
                        return;
                    }
                }
                if (MainV2.comPort.MAV.cs.mode == "Auto")
                {
                    MainV2.logger.write("Смена режима с AUTO на " + button.Text);
                }
            
                MainV2.comPort.setMode(button.Text);
            }
        }
        
        // private void BUTsetmode_MouseUp(object sender, MouseEventArgs e)
        // {
        //     if (MainV2.comPort.MAV.cs.connected)
        //     {
        //         if (MainV2.comPort.MAV.cs.failsafe)
        //         {
        //             if (CustomMessageBox.Show("You are in failsafe, are you sure?", "Failsafe", MessageBoxButtons.YesNo) !=
        //                 (int)DialogResult.Yes)
        //             {
        //                 return;
        //             }
        //         }
        //         if (MainV2.comPort.MAV.cs.mode == "Auto")
        //         {
        //             MainV2.logger.write("Смена режима с AUTO на " + CMB_modes.Text);
        //         }
        //
        //         MainV2.comPort.setMode(CMB_modes.Text);
        //     }
        // }
        //
        // private void BUT_setmode_Click(object sender, EventArgs e)
        // {
        //     if (MainV2.comPort.MAV.cs.failsafe)
        //     {
        //         if (CustomMessageBox.Show("You are in failsafe, are you sure?", "Failsafe", MessageBoxButtons.YesNo) !=
        //             (int) DialogResult.Yes)
        //         {
        //             return;
        //         }
        //     }
        //
        //     MainV2.comPort.setMode(CMB_modes.Text);
        // }

        private void ModeChangeForm_Load_1(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void CMB_modes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}