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
        private bool _isTrackBarClicked = false;
        
        public EngineControlForm()
        {
            InitializeComponent();
        }

        // private void Init()
        // {
        //     if (MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraft != null)
        //     {
        //         try
        //         {
        //             MaxDefault = MainV2.comPort.GetParam("THR_MAX");
        //             MinDefault = MainV2.comPort.GetParam("THR_MIN");
        //         }
        //         catch
        //         {
        //             Close();
        //         }
        //     }
        //     else
        //     {
        //         Close();
        //     }
        // }

        private const float MaxDefault = 100.0f;
        private const float MinDefault = 4.0f;
        private const float MaxSmall = 8.0f;
        private const float MaxTime = 30.0f;
        private const float EngineChannelOutMin = 1100;
        private const float EngineChannelOutMax = 1900;

        public enum EngineMode
        {
            LongestTime = 0,
            Small = 1,
            Full = 2,
            Auto = 3,
            Manual = 4
        }

        private void throttle_TrackBar_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = throttle_TrackBar.Value.ToString() + "%";

        }


        private void ThrottleMode_But_MouseUp(object sender, MouseEventArgs e)
        {
            Button senderButton = (Button) sender;
            string tag = senderButton.Tag.ToString();
            int i = int.Parse(tag);
            MainV2.currentEngineMode = i;
            setEngineMode();
            updateButtons(MainV2.currentEngineMode);
        }


        public void setEngineMode()
        {
            byte sysid = (byte) MainV2.comPort.sysidcurrent;
            byte compid = (byte) MainV2.comPort.compidcurrent;
            switch (MainV2.currentEngineMode)
            {
                case (int) EngineMode.LongestTime: //set thr_max = 30
                    MainV2.comPort.setParam(sysid, compid, "THR_MAX", MaxTime);
                    MainV2.comPort.setParam(sysid, compid, "THR_MIN", MinDefault);
                    // MainV2.instance.EngineChannelOverride = (ushort) Math.Round(CalcEngineChannel(MaxTime));
                    // MainV2.EngineOverrideTestFlag = true;
                    break;
                case (int) EngineMode.Small:
                    MainV2.comPort.setParam(sysid, compid, "THR_MAX", MaxSmall);
                    MainV2.comPort.setParam(sysid, compid, "THR_MIN", MinDefault);
                    // MainV2.instance.EngineChannelOverride = (ushort) Math.Round(CalcEngineChannel(MaxSmall));
                    // MainV2.EngineOverrideTestFlag = true;
                    break;
                case (int) EngineMode.Full:
                    MainV2.comPort.setParam(sysid, compid, "THR_MAX", MaxDefault);
                    MainV2.comPort.setParam(sysid, compid, "THR_MIN", MaxDefault * 0.999);
                    // MainV2.instance.EngineChannelOverride = (ushort) Math.Round(CalcEngineChannel(MaxDefault));
                    // MainV2.EngineOverrideTestFlag = true;
                    break;
                case (int) EngineMode.Auto:
                    MainV2.comPort.setParam(sysid, compid, "THR_MAX", MaxDefault);
                    MainV2.comPort.setParam(sysid, compid, "THR_MIN", MinDefault);
                    // MainV2.instance.EngineChannelOverride = (ushort) Math.Round(CalcEngineChannel(MaxDefault));
                    // MainV2.EngineOverrideTestFlag = true;
                    break;
                case (int) EngineMode.Manual:
                    MainV2.comPort.setParam(sysid, compid, "THR_MAX", (float) throttle_TrackBar.Value * 1.001);
                    MainV2.comPort.setParam(sysid, compid, "THR_MIN", (float) throttle_TrackBar.Value * 0.999);
                    // MainV2.instance.EngineChannelOverride = (ushort) Math.Round(CalcEngineChannel((float) throttle_TrackBar.Value));
                    // MainV2.EngineOverrideTestFlag = true;
                    break;
                default:
                    break;
            }
            // MainV2._lastEngineOverrideTime = DateTime.Now;
        }

        public void updateButtons(int i)
        {
            System.Drawing.Color Botok = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))),
                ((int) (((byte) (32)))));
            System.Drawing.Color Topok = System.Drawing.Color.FromArgb(((int) (((byte) (196)))),
                ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            System.Drawing.Color BotActive = System.Drawing.Color.FromArgb(((int) (((byte) (128)))),
                ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            System.Drawing.Color TopActive = System.Drawing.Color.FromArgb(((int) (((byte) (0)))),
                ((int) (((byte) (192)))), ((int) (((byte) (192)))));

            longestTimeThr_But.BGGradBot = (int) EngineMode.LongestTime == i ? BotActive : Botok;
            longestTimeThr_But.BGGradTop = (int) EngineMode.LongestTime == i ? TopActive : Topok;
            longestTimeThr_But.TextColor = (int) EngineMode.LongestTime == i ? Color.Black : Color.White;

            smallThr_but.BGGradBot = (int) EngineMode.Small == i ? BotActive : Botok;
            smallThr_but.BGGradTop = (int) EngineMode.Small == i ? TopActive : Topok;
            smallThr_but.TextColor = (int) EngineMode.Small == i ? Color.Black : Color.White;

            fullThr_But.BGGradBot = (int) EngineMode.Full == i ? BotActive : Botok;
            fullThr_But.BGGradTop = (int) EngineMode.Full == i ? TopActive : Topok;
            fullThr_But.TextColor = (int) EngineMode.Full == i ? Color.Black : Color.White;

            autoThr_But.BGGradBot = (int) EngineMode.Auto == i ? BotActive : Botok;
            autoThr_But.BGGradTop = (int) EngineMode.Auto == i ? TopActive : Topok;
            autoThr_But.TextColor = (int) EngineMode.Auto == i ? Color.Black : Color.White;

            manualThr_But.BGGradBot = (int) EngineMode.Manual == i ? BotActive : Botok;
            manualThr_But.BGGradTop = (int) EngineMode.Manual == i ? TopActive : Topok;
            manualThr_But.TextColor = (int) EngineMode.Manual == i ? Color.Black : Color.White;
            label1.Text = throttle_TrackBar.Value.ToString() + "%";
        }

        private float CalcEngineChannel(float percent)
        {
            float channelOut = (EngineChannelOutMax - EngineChannelOutMin) * percent / 100 + EngineChannelOutMin;
            return channelOut;
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
            Point locationLocal = MainV2.StatusControlPanel.GetLocalEngineFormLocation();
            StatusControlPanel.instance.EngineControlForm.Location = new Point(
                AircraftMenuControl.Instance.Width + this.Location.X + locationLocal.X,
                this.Location.Y + locationLocal.Y);
        }

        private void throttle_TrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            _isTrackBarClicked = true;
        }

        private void throttle_TrackBar_Scroll(object sender, EventArgs e)
        {
            if (_isTrackBarClicked)
            {
                return;
            }
        }

        private void throttle_TrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isTrackBarClicked)
            {
                return;
            }

            _isTrackBarClicked = false;
            if (MainV2.currentEngineMode == (int) EngineMode.Manual)
            {
                setEngineMode();
                updateButtons(MainV2.currentEngineMode);
            }
        }
    }
}