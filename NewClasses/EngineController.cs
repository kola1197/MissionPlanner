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

        public bool setEngineValue(float value, int _key) 
        {
            if (key == _key)
            {
                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "SERVO3_MIN", (float)value);
                return true;
            }
            else {
                System.Diagnostics.Debug.WriteLine("Engine is busy now");
                return false;
            }
        }

        public void resetKey() 
        {
            key = -1;
        }
    }
}
