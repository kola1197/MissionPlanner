using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class AircraftMenuControl : UserControl
    {
        public class aircraftButtonInfo
        {
            public MyButton Button { get; set; }
            public string DefaultText { get; set; }

            public aircraftButtonInfo(MyButton button, string text) => (Button, DefaultText) = (button, text);
        }

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
        }

        private void butClickAction(int butNum)
        {
            if (MainV2._aircraftInfo.Count == 0)
            {
                MainV2._connectionsForm.Show();
                return;
            }

            if (MainV2._aircraftInfo.Count > butNum)
            {
                MainV2._connectionsForm.switchConnectedAircraft(MainV2._aircraftInfo.ElementAt(butNum).Value);
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
    }
}
