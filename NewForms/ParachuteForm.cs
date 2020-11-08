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

        private bool closeParachuteRelease = false;

        public void setPosition() 
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(275, MainV2.instance.Height - 250);
        }

        public void setPosition(Point p)
        {
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.connected)
            {
                if (MainV2.CurrentAircraft.UsingSitl && !MainV2.IsSitlLanding) 
                {
                    if (!MainV2.instance.SitlReachedParachutePoint)
                    {
                        MainV2.instance.FlightPlanner.landPoint = new GMap.NET.PointLatLng(MainV2.comPort.MAV.cs.lat, MainV2.comPort.MAV.cs.lng);
                    }
                    MainV2.IsSitlLanding = true;
                    MainV2.instance.setLandWpInSitl();
                }
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
                if (!closeParachuteRelease)
                {
                    closeParachuteRelease = !closeParachuteRelease;
                    MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                        MAVLink.MAV_CMD.DO_SET_SERVO, 9, 900, 0, 0, 0, 0, 0);
                    button3.Text = "Отцеп закрыть";
                }
                else
                {
                    closeParachuteRelease = !closeParachuteRelease;
                    MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 9, 1500, 0, 0, 0, 0, 0);
                    button3.Text = "Отцеп открыть";
                }
            }
        }
    }
}
