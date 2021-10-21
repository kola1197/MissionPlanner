using log4net;
using MissionPlanner.Controls;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigAccelerometerCalibration : MyUserControl, IActivate, IDeactivate
    {
        private const float DisabledOpacity = 0.2F;
        private const float EnabledOpacity = 1.0F;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private byte count;

        bool _incalibrate = false;

        public ConfigAccelerometerCalibration()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            BUT_calib_accell.Enabled = true;
            _incalibrate = false;
        }

        public void Deactivate()
        {
            MainV2.comPort.giveComport = false;
            _incalibrate = false;
        }

        private void BUT_calib_accell_Click(object sender, EventArgs e)
        {
            if (_incalibrate)
            {
                count++;
                try
                {
                    MainV2.comPort.sendPacket(new MAVLink.mavlink_command_ack_t { command = 1, result = count },
                        MainV2.comPort.sysidcurrent, MainV2.comPort.compidcurrent);
                }
                catch
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                    return;
                }

                return;
            }

            try
            {
                count = 0;

                Log.Info("Sending accel command (mavlink 1.0)");

                if (MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.PREFLIGHT_CALIBRATION, 0, 0, 0, 0, 1, 0, 0))
                {
                    _incalibrate = true;

                    MainV2.comPort.SubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.STATUSTEXT, receivedPacket);
                    MainV2.comPort.SubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, receivedPacket);

                    BUT_calib_accell.Text = Strings.Click_when_Done;
                }
                else
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
            }
            catch (Exception ex)
            {
                _incalibrate = false;
                Log.Error("Exception on level", ex);
                CustomMessageBox.Show("Failed to level", Strings.ERROR);
            }
        }

        private bool receivedPacket(MAVLink.MAVLinkMessage arg)
        {
            if (arg.msgid == (uint)MAVLink.MAVLINK_MSG_ID.STATUSTEXT)
            {
                var message = Encoding.ASCII.GetString(arg.ToStructure<MAVLink.mavlink_statustext_t>().text);

                UpdateUserMessage(message);

                if (message.ToLower().Contains("calibration successful") || message.ToLower().Contains("culibration failed"))
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            BUT_calib_accell.Text = "Калибровка успешна";//Strings.Done;
                            BUT_calib_accell.Enabled = false;
                        });

                        _incalibrate = false;
                        MainV2.comPort.UnSubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.STATUSTEXT, receivedPacket);
                        MainV2.comPort.UnSubscribeToPacketType(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, receivedPacket);
                    }
                    catch
                    {
                    }
                }
            }

            if (arg.msgid == (uint)MAVLink.MAVLINK_MSG_ID.COMMAND_LONG)
            {
                var message = arg.ToStructure<MAVLink.mavlink_command_long_t>();
                if (message.command == (ushort)MAVLink.MAV_CMD.ACCELCAL_VEHICLE_POS)
                {
                    MAVLink.ACCELCAL_VEHICLE_POS pos = (MAVLink.ACCELCAL_VEHICLE_POS)message.param1;
                   /* LEVEL – «горизонтально, отсек парашюта внизу»
                    LEFT – «на левый борт»
                    RIGHT – «на правый борт»
                    NOSEUP – «на кок, хвостовой балкой вверх»
                    NOSEDOWN – «на хвостовую балку, коком вверх»
                    BACK – «горизонтально, отсек парашюта вверху»*/

                    String s = "";
                    if (pos.ToString().ToLower().Contains("level"))
                    {
                        s = "горизонтально, отсек парашюта внизу";
                    }
                    if (pos.ToString().ToLower().Contains("left"))
                    {
                        s = "горизонтально, отсек парашюта внизу";
                    }
                    if (pos.ToString().ToLower().Contains("right"))
                    {
                        s = "на правый борт";
                    }
                    if (pos.ToString().ToLower().Contains("noseup"))
                    {
                        s = "на кок, хвостовой балкой вверх";
                    }
                    if (pos.ToString().ToLower().Contains("nosedown"))
                    {
                        s = "на хвостовую балку, коком вверх";
                    }
                    if (pos.ToString().ToLower().Contains("back"))
                    {
                        s = "горизонтально, отсек парашюта вверху";
                    }
                    UpdateUserMessage("Установите БЛА " + s);
                }
            }

            return true;
        }

        public void UpdateUserMessage(string message)
        {
            Invoke((MethodInvoker)delegate
           {
               if (true || message.ToLower().Contains("Please place vehicle") || message.ToLower().Contains("calibration"))
                   lbl_Accel_user.Text = message;
           });
        }

        private void BUT_level_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Info("Sending level command (mavlink 1.0)");
                if (MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    MAVLink.MAV_CMD.PREFLIGHT_CALIBRATION, 0, 0, 0, 0, 2, 0, 0))
                {
                    BUT_level.Text = "Калибровка успешна"; //Strings.Completed;
                }
                else
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception on level", ex);
                CustomMessageBox.Show("Failed to level", Strings.ERROR);
            }
        }
    }
}