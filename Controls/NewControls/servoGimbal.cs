using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class servoGimbal : UserControl
    {
        int [] timing = new int[11];
        public servoGimbal()
        {
            for (int i = 0; i < 11; i++) 
            {
                timing[i] = 0;
            }
            InitializeComponent();
            myButton1.Tag = 0;
            myButton2.Tag = 9;
            myButton3.Tag = 8;
            myButton4.Tag = 7;
            myButton5.Tag = 6;
            myButton6.Tag = 5;
            myButton7.Tag = 4;
            myButton8.Tag = 3;
            myButton9.Tag = 2;
            myButton10.Tag = 1;
            myButton11.Tag = 10;
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            MyButton b = (MyButton)sender;
            int i = (int)b.Tag;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i<11; i++)
            {
                if (timing[i] > 0) 
                {
                    timing[i]--;
                    MainV2.servoValue servo;
                    if (MainV2.configServo.TryGetValue(i, out servo))
                    {
                        switch (servo.servo)
                        {
                            case 0:
                                break;
                            case 1:
                                MainV2.comPort.MAV.cs.ch1out = 1900;
                                break;
                            case 2:
                                MainV2.comPort.MAV.cs.ch2out = 1900;
                                break;
                            case 3:
                                MainV2.comPort.MAV.cs.ch3out = 1900;
                                break;
                            case 4:
                                MainV2.comPort.MAV.cs.ch4out = 1900;
                                break;
                            case 5:
                                MainV2.comPort.MAV.cs.ch5out = 1900;
                                break;
                            case 6:
                                MainV2.comPort.MAV.cs.ch6out = 1900;
                                break;
                            case 7:
                                MainV2.comPort.MAV.cs.ch7out = 1900;
                                break;
                            case 8:
                                MainV2.comPort.MAV.cs.ch8out = 1900;
                                break;
                            case 9:
                                MainV2.comPort.MAV.cs.ch9out = 1900;
                                break;
                            case 10:
                                MainV2.comPort.MAV.cs.ch10out = 1900;
                                break;
                            case 11:
                                MainV2.comPort.MAV.cs.ch11out = 1900;
                                break;
                            case 12:
                                MainV2.comPort.MAV.cs.ch12out = 1900;
                                break;
                            case 13:
                                MainV2.comPort.MAV.cs.ch13out = 1900;
                                break;
                            case 14:
                                MainV2.comPort.MAV.cs.ch14out = 1900;
                                break;
                            case 15:
                                MainV2.comPort.MAV.cs.ch15out = 1900;
                                break;
                            case 16:
                                MainV2.comPort.MAV.cs.ch16out = 1900;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
