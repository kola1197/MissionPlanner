using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class SNSInfo : Form, IFormConnectable
    {
        public static SNSInfo Instance;

        public SNSInfo()
        {
            InitializeComponent();
            Instance = this;
            StartPosition = FormStartPosition.Manual;
            updateLabels();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void updateLabels()
        {
            label2.Text = MainV2.comPort.MAV.cs.satcount.ToString();
            label4.Text = MainV2.comPort.MAV.cs.gpsstatus.ToString();
            label6.Text = MainV2.comPort.MAV.cs.gpshdop.ToString();
        }

        public void SetFormLocation()
        {
            // Location = new Point(50, MainV2.instance.Height - 150);
            Location = new Point(MainV2.instance.Location.X + 160, MainV2.instance.GetLowerPanelLocation().Y - this.Height + 20);
        }

        public void SetToTop()
        {
            TopMost = true;
        }

        private void SNSInfo_Shown(object sender, EventArgs e)
        {
            SetToTop();
        }
    }
}