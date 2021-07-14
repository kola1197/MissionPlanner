using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltitudeAngelWings.ApiClient.Models;
using MissionPlanner;
using MissionPlanner.NewForms;
using OpenTK.Graphics;
using OpenTK.Input;

namespace MissionPlanner.Controls
{
    public partial class AircraftMenuControl : UserControl
    {
        public PreFlightForm preFlightForm;
        public static AircraftMenuControl Instance;

        public class aircraftButtonInfo
        {
            public MyButton Button { get; set; }
            public string DefaultText { get; set; }

            public aircraftButtonInfo(MyButton button, string text) => (Button, DefaultText) = (button, text);
        }

        bool aircraftInAir = false;

        public List<aircraftButtonInfo> aircraftButtons = new List<aircraftButtonInfo>();

        public AircraftMenuControl()
        {
            InitializeComponent();
            aircraft_BUT1.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            //aircraft_BUT1.MouseMove += new MouseEventHandler(aircraft_BUT1_MouseMove);

            aircraft_BUT2.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            aircraft_BUT3.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            aircraft_BUT4.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);

            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT1, aircraft_BUT1.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT2, aircraft_BUT2.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT3, aircraft_BUT3.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT4, aircraft_BUT4.Text));

            // buttons[0] = aircraft_BUT1;
            // buttons[1] = aircraft_BUT2;
            // buttons[2] = aircraft_BUT3;
            // buttons[3] = aircraft_BUT4;

            Instance = this;
            //aircraft_BUT1.MouseEnter += Aircraft_BUT1_MouseEnter;

            //aircraft_BUT1.MouseLeave += aircraft_BUT1_MouseLeave;
        }


        private void Aircraft_BUT1_MouseEnter(object sender, EventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_MMove;
            //this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            //aircraft_BUT1.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_cloud;
        }

        private void butClickAction(int butNum)
        {
            if (!MainV2.ConnectedAircraftExists() && MainV2.Aircrafts.Count > 0)
            {
                return;
            }

            if (MainV2.Aircrafts.Count == 0)
            {
                MainV2.ConnectionsForm.Show();
                return;
            }

            if (MainV2.Aircrafts.Count > butNum &&
                ((MainV2.CurrentAircraft?.MenuNum ?? 10) != butNum ||
                 MainV2.AntennaConnectionInfo.Active))
            {
                MainV2.ConnectionsForm.SwitchConnectedAircraft(MainV2.instance.getAircraftByButtonNumber(butNum));
            }

            updateCentralButton();
        }

        public void updateCentralButton()
        {
            int butNum = -1;
            if (MainV2.CurrentAircraftNum != null)
            {
                butNum = MainV2.CurrentAircraft.MenuNum;
                aircraftInAir = MainV2.CurrentAircraft.inAir;
                //centerButton.Image = aircraftInAir ? global::MissionPlanner.Properties.Resources.testCenterUL : global::MissionPlanner.Properties.Resources.testCenterULActive;
                centerButton.BackgroundImage = aircraftInAir
                    ? global::MissionPlanner.Properties.Resources.nonefon
                    : global::MissionPlanner.Properties.Resources.icons8_cb2;
                this.BackgroundImage = aircraftInAir
                    ? global::MissionPlanner.Properties.Resources.group_red1
                    : global::MissionPlanner.Properties.Resources.group_green11;
            }
            else
            {
                //centerButton.Image = global::MissionPlanner.Properties.Resources.testCenterUnactive;
                centerButton.BackgroundImage = global::MissionPlanner.Properties.Resources.nonefon;
                this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_6_140;
            }

            switch (butNum)
            {
                case 0:
                    //centerButton.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 1:
                    //centerButton.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    this.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
                case 2:
                    //centerButton.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    break;
                case 3:
                    //centerButton.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    this.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                default:
                    break;
            }

            //centerButton.Text = butNum.ToString();
            paintButtons(butNum);
        }

        public void paintButtons(int activeButton)
        {
            for (int i = 0; i < 4; i++)
            {
                aircraftButtons[i].Button.BGGradBot = activeButton == i
                    ? ColorTranslator.FromHtml("#cde296")
                    : ColorTranslator.FromHtml("#cde296");
                aircraftButtons[i].Button.BGGradTop = activeButton == i
                    ? ColorTranslator.FromHtml("#174708")
                    : ColorTranslator.FromHtml("#94c11f");
            }
        }

        public void setAircraftButtonDefaultText(int butNum, string defaultText)
        {
            if (butNum > 3)
            {
                return;
            }

            aircraftButtons[butNum].DefaultText = defaultText;
        }

        public void updateAircraftButtonText(int butNum)
        {
            if (butNum > 3)
            {
                return;
            }

            aircraftButtons[butNum].Button.Text = aircraftButtons[butNum].DefaultText;
        }

        public void updateAllAircraftButtonTexts()
        {
            foreach (var aircraftButton in aircraftButtons)
            {
                aircraftButton.Button.Text = aircraftButton.DefaultText;
            }
        }

        private void aircraft_BUT1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            butClickAction(0);
        }

        private void aircraft_BUT2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            butClickAction(1);
        }

        private void aircraft_BUT3_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            butClickAction(2);
        }

        private void aircraft_BUT4_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            butClickAction(3);
        }

        private void aircraft_BUT_DoubleClick(object sender, EventArgs e)
        {
            MainV2.ConnectionsForm.Show();
        }

        private void centerButton_Click(object sender, EventArgs e)
        {
            if (!aircraftInAir && MainV2.comPort.MAV.cs.connected && !MainV2.AntennaConnectionInfo.Active &&
                MainV2.CurrentAircraft != null)
            {
                if (preFlightForm != null)
                {
                    preFlightForm.Close();
                }

                preFlightForm = new PreFlightForm();
                preFlightForm.Init();
                preFlightForm.Show();
            }
        }

        public void UpdateConnectionQualityText()
        {
            AircraftConnectionInfo currentAircraft = MainV2.instance.GetCurrentAircraft();
            if (currentAircraft == null)
            {
                return;
            }

            aircraftButtons[currentAircraft.MenuNum].Button.Text =
                aircraftButtons[currentAircraft.MenuNum].DefaultText + " | "
                                                                     + MainV2.comPort.MAV.cs.linkqualitygcs + "%";
        }

        private void aircraft_BUT1_Click(object sender, EventArgs e)
        {
        }

        private void aircraft_BUT1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //aircraft_BUT1.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_cloud;
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_MMove;
            //this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
        }

        private void aircraft_BUT1_MouseLeave(object sender, EventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_6_140;
        }

        private void aircraft_BUT2_Click(object sender, EventArgs e)
        {
        }

        private void aircraft_BUT2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_MMove;
            //this.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        private void aircraft_BUT2_MouseLeave(object sender, EventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_6_140;
        }

        private void aircraft_BUT3_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_MMove;
            //this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        }

        private void aircraft_BUT3_MouseLeave(object sender, EventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_6_140;
        }

        private void aircraft_BUT4_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_MMove;
            //this.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        private void aircraft_BUT4_MouseLeave(object sender, EventArgs e)
        {
            //this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group_6_140;
        }

        public void SwitchOnTimer()
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateConnectionQualityText();
            this.Invalidate();
        }
    }
}