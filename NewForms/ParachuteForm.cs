using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class ParachuteForm : Form, IFormConnectable
    {
        public ParachuteForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
        }

        private bool closeParachuteRelease = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.connected)
            {
                if (MainV2.CurrentAircraft.UsingSitl && !MainV2.IsSitlLanding) 
                {
                    if (!MainV2.CurrentAircraft.IsParachutePointReached)
                    {
                        MainV2.instance.FlightPlanner.landPoint = new GMap.NET.PointLatLng(MainV2.comPort.MAV.cs.lat, MainV2.comPort.MAV.cs.lng);
                    }
                    MainV2.IsSitlLanding = true;
                    MainV2.instance.setLandWpInSitl();
                    MainV2.CurrentAircraft.IsEmergencyLandTriggered = true;
                }
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 12, 1900, 0, 0, 0, 0, 0);
                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 10, 1000, 0, 0, 0, 0, 0);
                
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
            try
            {
                if (MainV2.comPort.MAV.cs.connected)
                {
                    if (!closeParachuteRelease)
                    {
                        closeParachuteRelease = !closeParachuteRelease;
                        MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent,
                            (byte) MainV2.comPort.compidcurrent,
                            MAVLink.MAV_CMD.DO_SET_SERVO, 9, 900, 0, 0, 0, 0, 0);
                        button3.Text = "Отцеп закрыть";
                    }
                    else
                    {
                        closeParachuteRelease = !closeParachuteRelease;
                        MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent,
                            (byte) MainV2.comPort.compidcurrent,
                            MAVLink.MAV_CMD.DO_SET_SERVO, 9, 1800, 0, 0, 0, 0, 0);
                        button3.Text = "Отцеп открыть";
                    }
                }
            }
            catch
            {
            }
        }

        public void SetFormLocation()
        {
            // Location = new Point(275, MainV2.instance.Height - 250);
            Location = new Point(MainV2.instance.Location.X + 10, MainV2.instance.GetLowerPanelLocation().Y - this.Height - 340 + 20);
        }

        public void SetToTop()
        {
            TopMost = true;
        }

        private void ParachuteForm_Shown(object sender, EventArgs e)
        {
            SetToTop();
        }
    }
}
