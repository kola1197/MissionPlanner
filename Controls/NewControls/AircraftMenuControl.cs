﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Orlan;
using MissionPlanner.NewForms;

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
            if (!MainV2.connectedAircraftExists() && MainV2._aircraftInfo.Count > 0)
            {
                return;
            }
            
            if (MainV2._aircraftInfo.Count == 0)
            {
                MainV2._connectionsForm.Show();
                return;
            }

            if (MainV2._aircraftInfo.Count > butNum && MainV2._aircraftInfo[MainV2.CurrentAircraftNum].MenuNum != butNum)
            {
                MainV2._connectionsForm.switchConnectedAircraft(MainV2.instance.getAircraftByButtonNumber(butNum));
            }
            updateCentralButton();
        }

        public void updateCentralButton()
        {
            int butNum = -1;
            if (MainV2.CurrentAircraftNum != null)
            {
                butNum = MainV2._aircraftInfo[MainV2.CurrentAircraftNum].MenuNum;
                aircraftInAir = MainV2._aircraftInfo[MainV2.CurrentAircraftNum].inAir;
                centerButton.Image = aircraftInAir ? global::MissionPlanner.Properties.Resources.testCenterUL : global::MissionPlanner.Properties.Resources.testCenterULActive;
            }
            else 
            {
                centerButton.Image = global::MissionPlanner.Properties.Resources.testCenterUnactive;
            }
            switch (butNum) 
            {
                case 0:
                    centerButton.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 1:
                    centerButton.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 2:
                    centerButton.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 3:
                    centerButton.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                default: 
                    break;
            }
            centerButton.Text = butNum.ToString();
            paintButtons(butNum ); 
            
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

        private void aircraft_BUT1_MouseClick(object sender, MouseEventArgs e)
        {
            butClickAction(0);
        }

        private void aircraft_BUT2_MouseClick(object sender, MouseEventArgs e)
        {
            butClickAction(1);
        }
        private void aircraft_BUT3_MouseClick(object sender, MouseEventArgs e)
        {
            butClickAction(2);
        }
        private void aircraft_BUT4_MouseClick(object sender, MouseEventArgs e)
        {
            butClickAction(3);
        }

        private void aircraft_BUT_DoubleClick(object sender, EventArgs e)
        {
            MainV2._connectionsForm.Show();
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
