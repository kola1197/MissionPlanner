using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace MissionPlanner.Controls.NewControls
{
    public partial class ICERun : UserControl
    {
        private bool testMode = false;
        private bool _iceRunning = false;
        public static ICERun Instance;
        public bool ICERunning
        {
            get => _iceRunning;
            set
            {
                _iceRunning = value;
                StatusControlPanel.instance.SitlEmulation.EngineRunning = value;
            }
        }

        private int engineoffCounter = 0;
        public int key = -1;
        float trim3 = 900;

        public ICERun()
        {
            InitializeComponent();
            Instance = this;
        }
        
        // private static System.Threading.Timer _timer;

        private static object locker = new object();
        
        public bool IsTimerEnabled
        {
            get => timer1.Enabled;
            set
            {
                if (value == timer1.Enabled)
                {
                    return;
                }

                if (value)
                {
                    timer1.Start();
                    // _timer = new System.Threading.Timer(_ => RefreshControl(), null, 0, 300);
                }
                else
                {
                    // if (_timer != null)
                    // {
                    //     _timer.Dispose();
                    // }
                    timer1.Stop();
                }
            }
        }


        public void Init()
        {
            trim3 = MainV2.comPort.GetParam("SERVO3_TRIM");
        }

        private void RefreshControl()
        {
            if (Monitor.TryEnter(locker))
            {
                try
                {
                    updateLabels();
                    float rpm1, rpm2;
                    if (StatusControlPanel.instance.IsSitlConnected())
                    {
                        rpm1 = (float) MainV2.CurrentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName
                            .Rpm);
                        rpm2 = (float) MainV2.CurrentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName
                            .Temperature);
                    }
                    else
                    {
                        rpm1 = MainV2.comPort.MAV.cs.rpm1;
                        rpm2 = MainV2.comPort.MAV.cs.rpm2;
                    }

                    if (!testMode)
                    {
                        if (rpm1 > 3000)
                        {
                            //ICERunning = true;
                            //startButton.Text = "Заглушить";
                            //startButton.Enabled = false;
                            label3.Text = "Двигатель достиг 3000 оборотов";
                            if (StatusControlPanel.instance.SitlEmulation.GetCurrentStateName() ==
                                SitlState.SitlStateName.EngineStart)
                            {
                                StatusControlPanel.instance.SitlEmulation.SetTargetState(SitlState.SitlStateName
                                    .EngineWarmUp);
                            }
                        }

                        if (rpm1 < 2500)
                        {
                            label3.Text = "Обороты двигателя < 2500";

                            //ICERunning = false;
                            //startButton.Text = "Запустить двигатель";
                            //MainV2.comPort.MAV.cs.ch10in = 900;
                            //MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 10, 900, 0, 0, 0, 0, 0);
                        }
                    }

                    if (rpm2 > 40) // temp > 40
                    {
                        startButton.Enabled = true;
                        label3.Text += "\n Температура двигателя ОК»;";
                        label3.ForeColor = Color.Green;
                    }

                    if (engineoffCounter > 1)
                    {
                        engineoffCounter--;
                        System.Diagnostics.Debug.Write(
                            "=====================EngineCounter = " + engineoffCounter.ToString());
                    }

                    if (engineoffCounter == 1)
                    {
                        engineoffCounter--;
                        //MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)1500);
                        if (!MainV2.engineController.setEngineValue(trim3, key))
                        {
                            CustomMessageBox.Show("Двигатель занят в другом потоке");
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
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

        private void updateLabels()
        {
            if (StatusControlPanel.instance.IsSitlConnected())
            {
                spedsLabel.Text =
                    MainV2.CurrentAircraft.SitlInfo.ParamList.GetParamToString(SitlParam.ParameterName.Rpm);
                tempLabel.Text =
                    MainV2.CurrentAircraft.SitlInfo.ParamList.GetParamToString(SitlParam.ParameterName.Temperature);
            }
            else
            {
                spedsLabel.Text = MainV2.comPort.MAV.cs.rpm1.ToString();
                tempLabel.Text = MainV2.comPort.MAV.cs.rpm2.ToString();
            }
        }

        public void StopEngine()
        {
            if (!MainV2.engineController.setEngineValue(900f, key))
            {
                CustomMessageBox.Show("Двигатель занят в другом потоке");
            }

            MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                MAVLink.MAV_CMD.DO_SET_SERVO, 10, 900, 0, 0, 0, 0, 0);
            if (testMode)
            {
                startButton.Text = "Запустить";
                ICERunning = false;
            }

            startButton.Text = "Запустить";
            ICERunning = false;
            System.Diagnostics.Debug.Write("DISABLE +++++++++++++++");
            engineoffCounter = 30;
        }
        
        private void startButton_MouseUp(object sender, MouseEventArgs e)
        {
            IsTimerEnabled = true;
            if (ICERunning)
            {
                StopEngine();
            }
            else
            {
                var result = MainV2.comPort.doCommandAsync((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.DO_SET_SERVO, 10, 1900, 0, 0, 0, 0, 0).Result;
                if (!MainV2.engineController.SetEngineValueAndWait(trim3, key))
                {
                    CustomMessageBox.Show("Двигатель занят в другом потоке");
                }


                startButton.Text = "Заглушить";
                ICERunning = true;

                System.Diagnostics.Debug.Write("ENABLE +++++++++++++++");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshControl();
        }
    }
}