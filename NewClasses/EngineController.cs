using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    public class EngineController
    {
        private int key = -1;
        public int getAccessKeyToEngine() 
        {

            if (key == -1)
            {
                Random r = new Random();
                key = r.Next(100);
                return key;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Engine is busy now");
                return -1;
            }
        }
        private ushort[] overrides = new ushort[] {1500, 1500, 1500, 1500};

        public bool setEngineValueViaOverride(float value, int _key) 
        {
            if (key == _key)
            {
                overrides[3] = (ushort) value;
                //MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)value);
                MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();
                rc.target_component = MainV2.comPort.MAV.compid;
                rc.target_system = MainV2.comPort.MAV.sysid;
                rc.chan1_raw = (ushort) overrides[0];
                rc.chan2_raw = (ushort) overrides[1];
                rc.chan3_raw = (ushort) overrides[2];
                rc.chan4_raw = (ushort) overrides[3];
                
                if (MainV2.comPort.BaseStream.IsOpen)
                {
                    if (MainV2.comPort.BaseStream.BytesToWrite < 50)
                    {
                        MainV2.comPort.sendPacket(rc, rc.target_system, rc.target_component);
                        System.Diagnostics.Debug.WriteLine("rc sent");
                    }
                }
                return true;
            }
            else {
                System.Diagnostics.Debug.WriteLine("Engine is busy now " + key.ToString() +" != " + _key.ToString());
                return false;
            }
        }
        
        public bool setEngineValue(float value, int _key) 
        {
            if (key == _key || true)
            {
                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)value);
                return true;
            }
            else {
                System.Diagnostics.Debug.WriteLine("Engine is busy now " + key.ToString() +" != " + _key.ToString());
                return false;
            }
        }

        public void resetKey() 
        {
            key = -1;
        }
    }
}
