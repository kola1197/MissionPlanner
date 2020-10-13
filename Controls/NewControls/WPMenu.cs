﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Topology;

namespace MissionPlanner.Controls.NewControls
{
    public partial class WPMenu : UserControl
    {
        public bool fieldActive = false;
        public WPMenu()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200,64,64,64);
            //updateField();
        }

        public bool progressBarVisible = false;

        private void updateField()
        {
            this.BackColor = Color.FromArgb(200, 64, 64, 64);
            //MainV2.wpLoadMenuAcrive = 
            this.Size = fieldActive ? new Size(95, 652) : new Size(95, 125);
            System.Drawing.Point now = this.Location;
            int diff = 420;
            //this.Location = fieldActive ? new System.Drawing.Point(now.X,now.Y - diff) : new System.Drawing.Point(now.X, now.Y + diff);

            //panel1.Visible = fieldActive;
            //panel2.Visible = fieldActive;
            //panel3.Visible = fieldActive;
            //panel4.Visible = fieldActive;
            //panel5.Visible = fieldActive;
            //panel6.Visible = fieldActive;
            loadButton.Visible = fieldActive;
            saveButton.Visible = fieldActive;
            altButton.Visible = fieldActive;
            writeButton.Visible = fieldActive;
            getButton.Visible = fieldActive;
            deleteButton.Visible = fieldActive;
            label10.Visible = fieldActive;
            label9.Visible = fieldActive;
            label8.Visible = fieldActive;
            label7.Visible = fieldActive;
            label6.Visible = fieldActive;
            label5.Visible = fieldActive;

        }

        private void myButton5_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, MouseEventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
        }

        private void WPMenu_Load(object sender, EventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
            fieldActive = !fieldActive;
            updateField();
        }

        private void updateValues() 
        {
            
            if (progressBar1.Visible != progressBarVisible)
            {
                progressBar1.Value = 0;
                progressBar1.Visible = progressBarVisible; 
            }
            //label1.Text = MainV2.comPort.MAV.cs.wpno.ToString();
            mainButton.Text = MainV2.comPort.MAV.cs.wpno.ToString();
            label2.Text = MainV2.instance.FlightPlanner.Commands.Rows.Count.ToString();
            label3.Text = MainV2.comPort.MAV.cs.wp_dist.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateValues();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
