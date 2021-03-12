using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class ICECheck : UserControl
    {
        // private static System.Threading.Timer _iceTimer;
        // private static System.Threading.Timer _graphTimer;

        public ICECheck()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //typeof(Panel).InvokeMember("DoubleBuffered",   BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,  null, DrawingPanel, new object[] { true });
            _progressBarsMaxValues.Add(progressBar1.Maximum);
            _progressBarsMaxValues.Add(progressBar2.Maximum);
            _progressBarsMaxValues.Add(progressBar3.Maximum);
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
        }

        int xStart = 8;
        int yStart = 300;
        bool testBool = false;
        int counter = 0;
        private bool _started = false;

        public bool started
        {
            get => _started;
            set => _started = value;
        }

        List<float> ICESpeeds = new List<float>();
        public bool iceChecked = false;
        Bitmap myBitmap;
        private int key = -1;

        private float fMin = 0;
        private float fMax = 0;

        private bool hasOverSevenk = false;
        private bool secondTestStarted = false; // between 4200 and 3600
        private int[] sinusoidTestCounter = new int[] {0, 0}; //0 - 7700, 1- 4200

        private List<int> _progressBarsMaxValues = new List<int>();

        private bool[] tests = new bool[] {true, true, true};
        int multy = 2;

        private void OnDispose(object sender, EventArgs e)
        {
            stop();
            // if (_graphTimer != null)
            // {
                // _graphTimer.Dispose();
            // }
            graphTimer.Stop();
        }

        void DrawGraphic()
        {
            if (Monitor.TryEnter(graphLocker))
            {
                try
                {
                    Invalidate();
                    pictureBox1.Invalidate();
                }
                finally
                {
                    Monitor.Exit(graphLocker);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        static object graphLocker = new object();
        static object iceLocker = new object();

        private void StartTimer()
        {
            // _graphTimer = new System.Threading.Timer(_ => DrawGraphic(), null, 0, 50);
            // _iceTimer = new System.Threading.Timer(_ => RefreshControl(), null, 0, 50);
            iceTimer.Start();
            graphTimer.Start();
        }


        private const int awaitingPeriodForThrotle = 40; // we wait for ICE data from px with min throttle
        private const int counterDivider = 8;
        private bool stopSetServo = false;
        private void RefreshControl()
        {
            if (Monitor.TryEnter(iceLocker))
            {
                try
                {
                    //multy = 100 / timer1.Interval; 
                    if (!testBool)
                     {
                        float i = MainV2.comPort.MAV.cs.rpm1;
                        ICESpeeds.Add(i);
                    }

                    counter++;
                    if (counter < 60 * multy)
                    {
                        if (MainV2.engineController.SetEngineValueAndWait((float) fMax, key))
                        {
                            // System.Diagnostics.Debug.WriteLine("key " + key.ToString() );
                            //CustomMessageBox.Show("Двигатель занят в другом потоке");
                        }

                        //MainV2.comPort.MAV.cs.ch10out = 2000;
                        if (testBool)
                        {
                            ICESpeeds.Add(13000.0f);
                        }

                        if (!hasOverSevenk && MainV2.comPort.MAV.cs.rpm1 > 7600)
                        {
                            hasOverSevenk = true;
                        }

                        if (hasOverSevenk && MainV2.comPort.MAV.cs.rpm1 < 7600)
                        {
                            tests[0] = false;
                        }

                        progressBar1.Value = counter;
                    }

                    if (counter > 60 * multy && counter < 120 * multy)
                    {
                        if (!hasOverSevenk)
                        {
                            tests[0] = false;
                        }

                        if (MainV2.engineController.SetEngineValueAndWait((float) fMin, key))
                        {
                            //CustomMessageBox.Show("Двигатель занят в другом потоке");
                        }

                        //MainV2.comPort.MAV.cs.ch10out = 1400;
                        if (testBool)
                        {
                            ICESpeeds.Add(4000.0f);
                        }

                        progressBar1.ValueColor = tests[0] ? Color.Lime : Color.Red;
                        progressBar2.Value = counter - 60 * multy;

                        if (!secondTestStarted && MainV2.comPort.MAV.cs.rpm1 > 3800 &&
                            MainV2.comPort.MAV.cs.rpm1 < 5100)
                        {
                            secondTestStarted = true;
                        }

                        if (secondTestStarted &&
                            (MainV2.comPort.MAV.cs.rpm1 > 5100 || MainV2.comPort.MAV.cs.rpm1 < 3800))
                        {
                            tests[1] = false;
                        }

                        //label1.BackColor = Color.Green;
                    }

                    if (counter > 120 * multy && counter < 210 * multy + awaitingPeriodForThrotle)
                    {
                        //if (counter == 120 * multy + 1)
                       // {
                            //MainV2.engineController.setEngineValue(fMin, key);
                            //MainV2.comPort.setMode("Manual");
                       //}

                        if (!secondTestStarted)
                        {
                            tests[1] = false;
                        }

                        double d = counter;
                        if (testBool)
                        {
                            ICESpeeds.Add((((float) Math.Sin(d / 5))) * 4500.0f + 8500.0f);
                            //MainV2.comPort.MAV.cs.ch10out = (float)Math.Sin(d / 5) * 300.0f + 1700.0f ;
                        }

                        //if (MainV2.engineController.setEngineValue((float)Math.Sin(d / 5) * (fMax - fMin) / 2f + (fMin + fMax) / 2f, key))
                        float f = (float) Math.Sin(d / 14) * (fMax - fMin) / 2f + (fMin + fMax) / 2f;

                        // MainV2.engineController.setEngineValueViaOverride(
                        // (float) Math.Sin(d / 14) * (fMax - fMin) / 2f + (fMin + fMax) / 2f, key);

                        // System.Diagnostics.Debug.WriteLine("Sinus " +d.ToString()+" -- "+Math.Sin(d / 14).ToString() + " Value - " + f.ToString());
                        if (counter % counterDivider == 0 && counter >= 210 * multy)
                        {
                            if (!stopSetServo)
                            {
                                MainV2.engineController.SetEngineValueAndWait(fMin, key);
                                stopSetServo = true;
                            }
                            else
                            {
                                
                            }
                        }
                        else
                        {
                            if (counter % counterDivider == 0 || counter == 120 * multy + 1 || counter == 210 * multy - 1)
                            {
                                MainV2.engineController.SetEngineValueAndWait(
                                    (float) Math.Sin(d / 14) * (fMax - fMin) / 2f + (fMin + fMax) / 2f, key);
                            }
                        }
                        //CustomMessageBox.Show("Двигатель занят в другом потоке");

                        //MainV2.engineController.setEngineValue((float)Math.Sin(d / 5) * 300.0f + 1700.0f, key);
                        progressBar2.ValueColor = tests[1] ? Color.Lime : Color.Red;
                        if (counter - 120 * multy <= progressBar3.Maximum)
                        {
                            if (counter - 120 * multy >= progressBar3.Minimum)
                            {
                                progressBar3.Value = counter - 120 * multy;
                            }
                            else
                            {
                                progressBar3.Value = progressBar3.Minimum;
                            }
                        }
                        else
                        {
                            progressBar3.Value = progressBar3.Maximum;
                        }


                        if (sinusoidTestCounter[0] == sinusoidTestCounter[1])
                        {
                            if (MainV2.comPort.MAV.cs.rpm1 > 7600)
                            {
                                sinusoidTestCounter[0]++;
                            }
                        }
                        else
                        {
                            if (MainV2.comPort.MAV.cs.rpm1 < 5100)
                            {
                                sinusoidTestCounter[1]++;
                            }
                        }

                        //label2.BackColor = Color.Green;
                    }

                    if (counter > 210 * multy + awaitingPeriodForThrotle)
                    {
                        MainV2.engineController.SetEngineValueAndWait(fMin, key);

                        if (sinusoidTestCounter[0] != 2 || sinusoidTestCounter[1] != 2)
                        {
                            tests[2] = false;
                        }

                        progressBar3.ValueColor = tests[2] ? Color.Lime : Color.Red;
                        //label3.BackColor = Color.Green;
                        startButton.Enabled = true;
                        stop();
                    }
                }
                catch
                {
                }
                finally
                {
                    Monitor.Exit(iceLocker);
                }
            }

            //this.Refresh();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if (myButton1.BackColor ==
                Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32))))))
            {
                myButton1.BackColor = Color.Firebrick;
            }
            else
            {
                myButton1.BackColor = Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))),
                    ((int) (((byte) (32)))));
            }

            iceChecked = true;
            stop();
            MainV2.AircraftMenuControl.preFlightForm.EnableIceCheckNextButton();
            // MainV2.AircraftMenuControl.preFlightForm.SkipIceCheck();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (StatusControlPanel.instance.IsSitlConnected())
            {
                CustomMessageBox.Show("Проверка ДВС недоступна в режиме симуляции.");
                return;
            }

            try
            {
                if (!started)
                {
                    fMin = MainV2.comPort.GetParam("SERVO3_TRIM");
                    fMax = MainV2.comPort.GetParam("SERVO3_MAX");
                    started = true;
                    ICESpeeds = new List<float>();
                    startButton.Text = "Начать перегазовки";
                    startButton.Enabled = false;
                    counter = 0;
                    refreshProgressBars();
                    StartTimer();
                    MainV2.AircraftMenuControl.preFlightForm.EnableIceCheckNextButton();
                }
                else
                {
                    stop();
                    started = false;
                    iceChecked = true;
                    startButton.Text = "Начать перегазовки";
                    MainV2.AircraftMenuControl.preFlightForm.EnableIceCheckNextButton();
                }

                int multy = 2;
                //multy = 100 / timer1.Interval;
                progressBar1.Maximum = progressBar1.Maximum * multy + multy - 1;
                progressBar2.Maximum = progressBar2.Maximum * multy + multy - 1;
                progressBar3.Maximum = progressBar3.Maximum * multy + multy - 1;
            }
            catch
            {
            }
        }

        void refreshProgressBars()
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar1.Maximum = _progressBarsMaxValues[0];
            progressBar2.Maximum = _progressBarsMaxValues[1];
            progressBar3.Maximum = _progressBarsMaxValues[2];
            progressBar1.ValueColor = Color.Cyan;
            progressBar2.ValueColor = Color.Cyan;
            progressBar3.ValueColor = Color.Cyan;
            hasOverSevenk = false;
            tests = new bool[] {true, true, true};
            secondTestStarted = false;
            sinusoidTestCounter = new int[] {0, 0};
        }
        
        
        public void stop()
        {
            // if (_iceTimer != null)
            // {
            //     _iceTimer.Dispose();
            // }
            iceTimer.Stop();
            progressBar3.ValueColor = tests[2] ? Color.Lime : Color.Red;
            //started = false;
            counter = 0;
            started = false;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            started = true;
            ICESpeeds = new List<float>();
            //for (int i = 0; i < 18 * 10; i++) 
            //{
            //    ICESpeeds.Add(6000);
            //}
            testBool = true;
            StartTimer();
        }

        public void focused(bool b) //need to get engine key 
        {
            if (b)
            {
                key = MainV2.engineController.getAccessKeyToEngine();
            }
            else
            {
                MainV2.engineController.resetKey();
                key = -1;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (!testBool)
            //{
            //    float i = MainV2.comPort.MAV.cs.rpm1;
            //    ICESpeeds.Add(i);
            //}
            //myBitmap = new Bitmap(430,430);
            myBitmap = new Bitmap(501, 430);
            base.OnPaint(e);
            Graphics g;
            //g = this.CreateGraphics();
            g = Graphics.FromImage(myBitmap);
            Pen myPen = new Pen(Color.Blue);
            myPen.Width = 1;
            //g.DrawLine(myPen, 30, 30, 45, 45);
            //g.DrawLine(myPen, 1, 50, 431, 50);

            /*g.DrawLine(myPen, 1, 300, 500, 300);
            g.DrawLine(myPen, 1, 300, 500, 300);
            g.DrawLine(myPen, 1, 220, 500, 220);
            g.DrawLine(myPen, 1, 160, 500, 160);
            */

            g.DrawLine(myPen, 1, yStart - 3800 / 50, 500, yStart - 3800 / 50);

            g.DrawLine(myPen, 1, yStart - 7600 / 50, 500, yStart - 7600 / 50);

            Pen myTestPen = new Pen(Color.Gold);
            myPen.Width = 1;
            g.DrawLine(myTestPen, 1, yStart - 5100 / 50, 500, yStart - 5100 / 50);

            // float scale = 587 / ICESpeeds.Count;
            Pen p = new Pen(Color.Lime);
            p.Width = 3;
            Point[] points = new Point[ICESpeeds.Count];
            for (int i = 0; i < ICESpeeds.Count - 1; i++)
            {
                //g.DrawLine(p, xStart + i * 2.2f, (yStart - ICESpeeds[i] / 50), xStart + (i + 1) * 2.2f, yStart - ICESpeeds[i + 1] / 50);

                // g.DrawLine(p, xStart + i * scale / (float) multy, (yStart - ICESpeeds[i] / 50),
                // xStart + (i + 1) * scale / (float) multy, yStart - ICESpeeds[i + 1] / 50);
                g.DrawLine(p, xStart + i * 2.1522f / (float) multy, (yStart - ICESpeeds[i] / 50),
                    xStart + (i + 1) * 2.1522f / (float) multy, yStart - ICESpeeds[i + 1] / 50);
                //points[i] = new Point((int)(xStart + i * 2.2f), (int)(yStart - ICESpeeds[i] / 25));
                //System.Diagnostics.Debug.Write("  " + ICESpeeds[i].ToString() + "  ");
            }

            pictureBox1.Image = myBitmap;
            /*Pen p = new Pen(Color.Green);
            p.Width = 3;
            if (points.Length > 2)
            {
                g.DrawPolygon(p, points);
            }*/
        }

        private void graphTimer_Tick(object sender, EventArgs e)
        {
            DrawGraphic();
        }

        private void iceTimer_Tick(object sender, EventArgs e)
        {
            RefreshControl();
        }
    }
}