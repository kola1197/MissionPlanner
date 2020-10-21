using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    public class VibeData
    {
        public float[,] vibe = new float[3, 600];
        public VibeData()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 600; j++)
                {
                    vibe[i, j] = 0;
                }
            }
        }

        public void update()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 599; j++)
                {
                    vibe[i, j] = vibe[i, j + 1];
                }
            }
            if (MainV2.comPort.MAV.cs.connected)
            {
                vibe[0, 599] = MainV2.comPort.MAV.cs.vibex;
                vibe[1, 599] = MainV2.comPort.MAV.cs.vibey;
                vibe[2, 599] = MainV2.comPort.MAV.cs.vibez;
            }
            else
            {
                vibe[0, 599] = 0;
                vibe[1, 599] = 0;
                vibe[2, 599] = 0;
            }
        }

    }
}
