using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Modules;

namespace MissionPlanner.Controls.NewControls
{
    public partial class servoGimbal : UserControl
    {
        private bool[] buttonPressed = new bool[11]; 
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
            timer1.Start();
        }

        private void defaultButton(object sender)
        {
            MyButton b = (MyButton)sender;
            if (b.BGGradTop != Color.DarkRed && b.BGGradTop != Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196))))))
            {
                b.BGGradBot = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));    //it is default MP shit
                b.BGGradTop = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                b.TextColor = Color.Black;
                b.Outline = Color.Transparent;
            }
        }
        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            // if (!timer1.Enabled)
            // {
            //     timer1.Start();
            // }
            //timing[i] = 10;
            //System.Diagnostics.Debug.WriteLine("button click " + i.ToString());
            
            MyButton b = (MyButton)sender;
            int i = (int)b.Tag;
            buttonPressed[i] = !buttonPressed[i];
            b.BGGradBot = buttonPressed[i]? Color.Brown : Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));    //it is default MP shit
            b.BGGradTop = buttonPressed[i]? Color.DarkRed : Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            servoSet(i,buttonPressed[i]);
        }

        private void myButton1_mouseDown(object sender, MouseEventArgs e)
        {
            // MyButton b = (MyButton)sender;
            // int i = (int)b.Tag;
            // System.Diagnostics.Debug.WriteLine("button click " + i.ToString());
            // b.BGGradBot = Color.Brown;
            // b.BGGradTop= Color.DarkRed;
            // servoSet(i,true);
        }

        private void servoSet(int i, bool downPress)
        {
            if (MainV2.comPort.MAV.cs.connected)
            {
                MainV2.servoValue servo;
                if (MainV2.configServo.TryGetValue(i, out servo))
                {
                    MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                        MAVLink.MAV_CMD.DO_SET_SERVO, servo.servo, downPress ? servo.value : servo.defaultValue, 0, 0,
                        0, 0, 0);
                }
            }
        }
        //b.BGGradBot = buttonPressed[i]? Color.Brown : Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));    //it is default MP shit
        //b.BGGradTop = buttonPressed[i]? Color.DarkRed : Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
        private void fixButtons() {
            defaultButton(myButton1);
            defaultButton(myButton2);
            defaultButton(myButton3);
            defaultButton(myButton4);
            defaultButton(myButton5);
            defaultButton(myButton6);
            defaultButton(myButton7);
            defaultButton(myButton8);
            defaultButton(myButton9);
            defaultButton(myButton10);
            defaultButton(myButton11);
        }

        private void timerVoid()
        {
            for (int i = 0; i<11; i++)
            {
                if (timing[i] > 0) 
                {
                    timing[i]--;
                    MainV2.servoValue servo;
                    if (MainV2.configServo.TryGetValue(i, out servo))
                    {
                        System.Diagnostics.Debug.WriteLine("Servo click!!! Servo: " + servo.servo.ToString() + " Value: " + servo.value.ToString());
                       MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, servo.servo, servo.value, 0, 0, 0, 0, 0);

                        switch (servo.servo)
                        {
                            case 0:
                                break;
                            case 1:
                                //MainV2.comPort.MAV.cs.ch1in = servo.value;
                                //MainV2.comPort.MAV.cs.ch1out = servo.value;
                                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 2, 1800, 0, 0, 0, 0, 0);
                                MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 3, 1800, 0, 0, 0, 0, 0);
                                break;
                            case 2:
                                MainV2.comPort.MAV.cs.ch2out = servo.value;
                                break;
                            case 3:
                                break;
                            case 4:
                                MainV2.comPort.MAV.cs.ch4out = servo.value;
                                break;
                            case 5:
                                MainV2.comPort.MAV.cs.ch5out = servo.value;
                                break;
                            case 6:
                                MainV2.comPort.MAV.cs.ch6out = servo.value;
                                break;
                            case 7:
                                MainV2.comPort.MAV.cs.ch7out = servo.value;
                                break;
                            case 8:
                                MainV2.comPort.MAV.cs.ch8out = servo.value;
                                break;
                            case 9:
                                MainV2.comPort.MAV.cs.ch9out = servo.value;
                                break;
                            case 10:
                                MainV2.comPort.MAV.cs.ch10out = servo.value;
                                break;
                            case 11:
                                MainV2.comPort.MAV.cs.ch11out = servo.value;
                                break;
                            case 12:
                                MainV2.comPort.MAV.cs.ch12out = servo.value;
                                break;
                            case 13:
                                MainV2.comPort.MAV.cs.ch13out = servo.value;
                                break;
                            case 14:
                                MainV2.comPort.MAV.cs.ch14out = servo.value;
                                break;
                            case 15:
                                MainV2.comPort.MAV.cs.ch15out = servo.value;
                                break;
                            case 16:
                                MainV2.comPort.MAV.cs.ch16out = servo.value;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timerVoid();
            fixButtons();
        }

        private void myButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
