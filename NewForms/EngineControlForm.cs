using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class EngineControlForm : Form, IFormConnectable
    {
        public EngineControlForm()
        {
            if (!MainV2.comPort.MAV.cs.connected)
            {
                Close();
            }
            else
            {
                InitializeComponent();
                maxDefault = MainV2.comPort.GetParam("THR_MAX");
                minDefault = MainV2.comPort.GetParam("THR_MIN");
            }
        }

        private float maxDefault = 0;
        private float minDefault = 0;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString() + "%";
        }


        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            Button senderButton = (Button)sender;
            string tag = senderButton.Tag.ToString();
            int i = int.Parse(tag);
            MainV2.currentEngineMode = i;
            setEngineMode();
            updateButtons(MainV2.currentEngineMode);
        }

        private void setEngineMode() 
        {
            switch (MainV2.currentEngineMode) 
            {
                case 0:                                             //set thr_max = 30
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MAX", 30);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MIN", minDefault);
                    break;
                case 1:
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MAX", minDefault);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MIN", minDefault);
                    break;
                case 2:
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MAX", maxDefault);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MIN", maxDefault);
                    break;
                case 3:
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MAX", maxDefault);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MIN", minDefault);
                    break;
                case 4:
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MAX", (float)trackBar1.Value * 1.001);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "THR_MIN", (float)trackBar1.Value * 0.999);
                    break;

                default:
                    break;
            }
        }

        private void updateButtons(int i) 
        {
            System.Drawing.Color Botok = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(226)))), ((int)(((byte)(150)))));
            System.Drawing.Color Topok = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(193)))), ((int)(((byte)(31)))));
            System.Drawing.Color BotActive = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            System.Drawing.Color TopActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));

            myButton1.BGGradBot = 0 == i ? BotActive : Botok;
            myButton1.BGGradTop = 0 == i ? TopActive : Topok;

            myButton3.BGGradBot = 1 == i ? BotActive : Botok;
            myButton3.BGGradTop = 1 == i ? TopActive : Topok;

            myButton4.BGGradBot = 2 == i ? BotActive : Botok;
            myButton4.BGGradTop = 2 == i ? TopActive : Topok;

            myButton5.BGGradBot = 3 == i ? BotActive : Botok;
            myButton5.BGGradTop = 3 == i ? TopActive : Topok;

            myButton6.BGGradBot = 4 == i ? BotActive : Botok;
            myButton6.BGGradTop = 4 == i ? TopActive : Topok;
            label1.Text = trackBar1.Value.ToString() + "%";
        }

        private void EngineControlForm_Load(object sender, EventArgs e)
        {
            updateButtons(MainV2.currentEngineMode);
        }

        private void EngineControlForm_Shown(object sender, EventArgs e)
        {
            SetFormLocation();
            SetToTop();
        }

        public void SetToTop()
        {
            this.TopMost = true;
        }

        public void SetFormLocation()
        {
            Point locationLocal = MainV2.StatusMenuPanel.GetLocalEngineFormLocation();
            StatusControlPanel.instance.EngineControlForm.Location = new Point(
                AircraftMenuControl.Instance.Width + this.Location.X + locationLocal.X,
                this.Location.Y + locationLocal.Y);
        }
    }
}
