using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    class EngineController
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
            return -1;
        }
    }
}
