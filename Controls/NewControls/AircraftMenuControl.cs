using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using MissionPlanner.NewForms;
using OpenTK.Input;

namespace MissionPlanner.Controls
{
    public partial class AircraftMenuControl : UserControl
    {
        PreFlightForm preFlightForm;
        MyButton[] buttons = new MyButton[4];
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
            aircraft_BUT2.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            aircraft_BUT3.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            aircraft_BUT4.DoubleClick += new EventHandler(aircraft_BUT_DoubleClick);
            
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT1, aircraft_BUT1.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT2, aircraft_BUT2.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT3, aircraft_BUT3.Text));
            aircraftButtons.Add(new aircraftButtonInfo(aircraft_BUT4, aircraft_BUT4.Text));

            buttons[0] = aircraft_BUT1;
            buttons[1] = aircraft_BUT2;
            buttons[2] = aircraft_BUT3;
            buttons[3] = aircraft_BUT4;
        }

        

        private void butClickAction(int butNum)
        {
            if (!MainV2.connectedAircraftExists() && MainV2.AircraftInfo.Count > 0)
            {
                return;
            }
            
            if (MainV2.AircraftInfo.Count == 0)
            {
                MainV2.ConnectionsForm.Show();
                return;
            }

            if (MainV2.AircraftInfo.Count > butNum && MainV2.AircraftInfo[MainV2.CurrentAircraftNum].MenuNum != butNum)
            {
                MainV2.ConnectionsForm.switchConnectedAircraft(MainV2.instance.getAircraftByButtonNumber(butNum));
            }
            updateCentralButton();
        }

        public void updateCentralButton()
        {
            int butNum = -1;
            if (MainV2.CurrentAircraftNum != null)
            {
                butNum = MainV2.AircraftInfo[MainV2.CurrentAircraftNum].MenuNum;
                aircraftInAir = MainV2.AircraftInfo[MainV2.CurrentAircraftNum].inAir;
                //centerButton.Image = aircraftInAir ? global::MissionPlanner.Properties.Resources.testCenterUL : global::MissionPlanner.Properties.Resources.testCenterULActive;
                centerButton.BackgroundImage = aircraftInAir ? global::MissionPlanner.Properties.Resources.nonefon : global::MissionPlanner.Properties.Resources.icons8_center_button;
                this.BackgroundImage = aircraftInAir ? global::MissionPlanner.Properties.Resources.group_red1 : global::MissionPlanner.Properties.Resources.group_green11;
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
                    this.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
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
            for (int i =0;i<4;i++) 
            {
                
                buttons[i].BGGradBot = activeButton == i ? ColorTranslator.FromHtml("#cde296") : ColorTranslator.FromHtml("#cde296");
                buttons[i].BGGradTop = activeButton == i ? ColorTranslator.FromHtml("#174708") : ColorTranslator.FromHtml("#94c11f");
                
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
            if (!aircraftInAir && MainV2.comPort.MAV.cs.connected)
            {
                if (preFlightForm != null)
                {
                    preFlightForm.Close();
                }
                preFlightForm = new PreFlightForm();
                preFlightForm.Show();
            }
        }
    }
}
