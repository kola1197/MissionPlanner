using GMap.NET.WindowsForms;
using MissionPlanner.NewClasses;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;

namespace MissionPlanner.NewForms
{
    public partial class WPConfig : Form
    {
        public bool closedByButton = false;
        public bool[] servos = new bool[9];
        public UniversalCoordinatsController controller;
        private int originalLoiterRad = -1;
        public WPConfig()
        {
            InitializeComponent();

            this.TopMost = true;
        }

        /*public WPConfig(string s)
        {
            InitializeComponent();
            this.TopMost = true;
            Text = s;
            if (s == "Home")
            {
                
            }
        }*/

        public int indexNow = -1;
        public string SerialNum = "-2";

        public WPConfig(string serNum)
        {
            InitializeComponent();

            Init(serNum);
            // this.TopMost = true;
            // //SerialNum = _serNum;
            // SerialNum = serNum;
            // Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + serNum.ToString();
            // latTB1.Text = "";
            // if (MainV2.loiterRad == -1)
            // {
            //     MainV2.loiterRad = (int)MainV2.comPort.GetParam("WP_LOITER_RAD");
            // }
            // loiterRadTextBox.Text = MainV2.loiterRad.ToString();
        }

        public WPConfig(GMapMarkerRect currentRectMarker, string serNum)
        {
            InitializeComponent();

            Init(serNum, currentRectMarker);
        }

        private void Init(string serNum, GMapMarkerRect currentRectMarker = null)
        {
            TopMost = true;
            
            SerialNum = serNum;
            string aircraftNum = "0";
            if (MainV2.CurrentAircraftNum != null)
            {
                aircraftNum = MainV2.CurrentAircraftNum;
            }
            
            Text = "Борт " + aircraftNum + " Точка " + serNum.ToString();
            
            if (currentRectMarker!=null && currentRectMarker.Tag.ToString() != "H" && serNum.ToLower() != "rally")
            {
                indexNow = int.Parse(currentRectMarker.Tag.ToString()) - 1;
            }
            
            if (MainV2.loiterRad == -1 && MainV2.comPort.MAV.cs.connected && MainV2.CurrentAircraft != null) 
            {
                MainV2.loiterRad = (int) MainV2.comPort.GetParam("WP_LOITER_RAD");
            }

            loiterRadTextBox.Text = MainV2.loiterRad.ToString();
            originalLoiterRad = MainV2.loiterRad;
            latTB1.Text = "";
        }


        private void SelectCurrentWpTypeInCombobox()
        {
            
        }

        /*public WPConfig(GMapMarkerRect currentRectMarker, int _serNum)
        {

            InitializeComponent();
            this.TopMost = true;
            SerialNum = _serNum;
            Text = "Борт " + MainV2.CurrentAircraftNum + " Точка " + SerialNum.ToString();
            indexNow = int.Parse(currentRectMarker.Tag.ToString()) -1;
            textBox1.Text = "";
        }*/


        private void myButton1_Click(object sender, EventArgs e)
        {
            if (latNotification.Visible || lonNotification.Visible)
            {
                CustomMessageBox.Show(
                    "Введите корректные значения координат, или отмените введенные изменения закрытием окна.",
                    "Введены некорректные данные координат точки!");
                return;
            }

            closedByButton = true;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                label10.Visible = true;
                label11.Visible = true;
                textBox5.Visible = true;
                textBox5.Text = "20";
            }
            else
            {
                label10.Visible = false;
                label11.Visible = false;
                textBox5.Visible = false;
            }

            if (comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 0)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "1";
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "5";
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "10";
        }

        private void myButton5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "20";
        }

        private void myButton6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "30";
        }

        private void myButton7_Click(object sender, EventArgs e)
        {
            textBox3.Text = "60";
        }

        public void updateServoButtons()
        {
            myButton8.BGGradTop = servos[0] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton9.BGGradTop = servos[1] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton10.BGGradTop =
                servos[2] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton13.BGGradTop =
                servos[3] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton12.BGGradTop =
                servos[4] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton11.BGGradTop =
                servos[5] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton16.BGGradTop =
                servos[6] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton15.BGGradTop =
                servos[7] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            myButton14.BGGradTop =
                servos[8] ? ColorTranslator.FromHtml("#05FF07") : ColorTranslator.FromHtml("#C4C4C4");

            Invalidate();
        }

        private void updateServoButton(int i)
        {
            servos[i] = !servos[i];
            updateServoButtons();
        }

        private void myButton8_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(0);
        }

        private void myButton9_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(1);
        }

        private void myButton10_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(2);
        }

        private void myButton13_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(3);
        }

        private void myButton12_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(4);
        }

        private void myButton11_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(5);
        }

        private void myButton16_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(6);
        }

        private void myButton15_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(7);
        }

        private void myButton14_MouseUp(object sender, MouseEventArgs e)
        {
            updateServoButton(8);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = !checkBox1.Checked;
        }

        private void editTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            var _editTextBox = sender as TextBox;
            if (e.KeyCode == Keys.Back)
            {
                string text = _editTextBox.Text;
                int selectionStart = _editTextBox.SelectionStart;
                if (selectionStart > 0 && !Char.IsDigit(text[selectionStart - 1]) && text[selectionStart - 1] != '-' &&
                    text[selectionStart - 1] != '.')
                {
                    _editTextBox.SelectionStart--;
                    _editTextBox.SelectionLength = 0;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            if (e.KeyCode == Keys.Delete || Control.IsKeyLocked(Keys.Insert))
            {
                string text = _editTextBox.Text;
                int selectionStart = _editTextBox.SelectionStart;

                if (selectionStart != text.Length && !Char.IsDigit(text[selectionStart]) &&
                    text[selectionStart] != '-' && text[selectionStart] != '.')
                {
                    _editTextBox.SelectionStart++;
                    _editTextBox.SelectionLength = 0;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            // if (e.KeyCode == Keys.Enter)
            // {
            //     latLong_DGV.EndEdit();
            //     e.Handled = true;
            //     e.SuppressKeyPress = true;
            // }

            if (_editTextBox.SelectionLength > 0)
            {
                _editTextBox.SelectionStart = _editTextBox.Text.Length;
                e.Handled = true;
            }
        }


        private void EditTextBoxOnKeyPress(object sender, KeyPressEventArgs e)
        {
            // if (e.KeyChar == (char) 13)
            // {
            //     latLong_DGV.EndEdit();
            //     e.Handled = true;
            // }

            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private bool locked = false;

        public void setCoordsMode()
        {
            latTB1.TextChanged -= latTB1_TextChanged;
            lonTB1.TextChanged -= lonTB1_TextChanged;
            locked = true;
            switch (MainV2.CoordinatsShowMode) 
            {
                case 0:
                    WGSCoordinats rr = controller.wgs;
                    System.Diagnostics.Debug.WriteLine("WGS----- " + rr.Lat.ToString() + ", " + rr.Lng.ToString());
                    latTB1.Text = controller.wgs.Lat.ToString("F6", new CultureInfo("en-US"));
                    locked = false;
                    lonTB1.Text = controller.wgs.Lng.ToString("F6", new CultureInfo("en-US"));
                    break;
                case 1:
                    latTB1.Text = controller.wgs.to_GM_View_lat();
                    locked = false;
                    lonTB1.Text = controller.wgs.to_GM_View_lon();
                    break;
                case 2:
                    latTB1.Text = controller.wgs.to_GMS_View_lat();
                    locked = false;
                    lonTB1.Text = controller.wgs.to_GMS_View_lon();
                    break;
                case 3:
                    latTB1.Text = controller.wgs.toSK42().Lat.ToString("F6", new CultureInfo("en-US"));
                    locked = false;
                    lonTB1.Text = controller.wgs.toSK42().Lng.ToString("F6", new CultureInfo("en-US"));
                    break;
                case 4:
                    latTB1.Text = controller.wgs.ToSk42_GM().Item1;
                    locked = false;
                    lonTB1.Text = controller.wgs.ToSk42_GM().Item2;
                    break;
                case 5:
                    latTB1.Text = controller.wgs.ToSk42_GMS().Item1;
                    locked = false;
                    lonTB1.Text = controller.wgs.ToSk42_GMS().Item2;
                    break;
                case 6:
                    RectCoordinats r = controller.wgs.toRect();
                    System.Diagnostics.Debug.WriteLine("Rect----- " + r.x.ToString() + ", " + r.y.ToString());
                    latTB1.Text = controller.wgs.toRect().x.ToString("F2", new CultureInfo("en-US"));
                    locked = false;
                    lonTB1.Text = controller.wgs.toRect().y.ToString("F2", new CultureInfo("en-US"));
                    break;
            }

            latTB1.Text = latTB1.Text.Replace(',', '.');
            lonTB1.Text = lonTB1.Text.Replace(',', '.');
            latTB1.TextChanged += latTB1_TextChanged;
            lonTB1.TextChanged += lonTB1_TextChanged;
        }

        private void latTB1_TextChanged(object sender, EventArgs e)
        {
            if (!locked)
            {
                var lat = latTB1.Text.Replace(".", ",");
                var lng = lonTB1.Text.Replace(".", ",");
                try
                {
                    latNotification.Visible = false;
                    switch (MainV2.CoordinatsShowMode)
                    {
                        case 0:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 1:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 2:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 3:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 4:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 5:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 6:
                            controller = new UniversalCoordinatsController(new RectCoordinats(lat, lng));
                            break;
                    }
                }
                catch (Exception ee)
                {
                    System.Diagnostics.Debug.WriteLine(ee.ToString());
                    latNotification.Visible = true;
                }
            }
        }

        private void lonTB1_TextChanged(object sender, EventArgs e)
        {
            if (!locked)
            {
                var lat = latTB1.Text.Replace(".", ",");
                var lng = lonTB1.Text.Replace(".", ",");
                try
                {
                    latNotification.Visible = false;
                    switch (MainV2.CoordinatsShowMode)
                    {
                        case 0:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 1:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 2:
                            controller = new UniversalCoordinatsController(new WGSCoordinats(lat, lng));
                            break;
                        case 3:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 4:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 5:
                            controller = new UniversalCoordinatsController(new SK42Coordinats(lat, lng));
                            break;
                        case 6:
                            controller = new UniversalCoordinatsController(new RectCoordinats(lat, lng));
                            break;
                    }
                }
                catch
                {
                    lonNotification.Visible = true;
                }
            }
        }

        public void tryToSetLoiterRad()
        {
            try
            {
                int newrad = int.Parse(loiterRadTextBox.Text);
                if (newrad != originalLoiterRad)
                {
                    MainV2.loiterRad = newrad;
                    MainV2.comPort.setParam(new[] {"LOITER_RAD", "WP_LOITER_RAD"},
                        newrad / CurrentState.multiplierdist);
                    MainV2.instance.FlightPlanner.TXT_loiterrad.Text = MainV2.loiterRad.ToString();
                }
            }
            catch

            {
                CustomMessageBox.Show("Не удалось установить праметр", "Ошибка");
            }

        }

        private void myButton17_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
   
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        public void tryToSetServosDist()
        {
            if (checkBox2.Checked)
            {
                double delta = double.Parse(textBox4.Text);
                PointLatLng current = new PointLatLng(controller.wgs.Lat,controller.wgs.Lng);
                double[] prevCooords = MainV2.instance.FlightPlanner.getWPCoords( int.Parse(SerialNum)-1);
                double dist = MainV2.instance.FlightPlanner.MainMap.MapProvider.Projection.GetDistance(new PointLatLng(prevCooords[0],prevCooords[1]),current );
                dist *= 1000;
                double newLat = (prevCooords[0] * delta + controller.wgs.Lat * (dist - delta)) / dist;
                double newLng = (prevCooords[1] * delta + controller.wgs.Lng * (dist - delta)) / dist;
                controller = new UniversalCoordinatsController(new WGSCoordinats(newLat, newLng));
            }
        }
    }
}
