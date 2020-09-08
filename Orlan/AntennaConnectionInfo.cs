using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.Orlan
{
    public class AntennaConnectionInfo : AircraftConnectionInfo
    {
        public string Mode { get; set; }

        public string satNum { get; set; }

        public string Heading { get; set; }

        public AntennaConnectionInfo() : base() => (Mode, satNum, Heading) = ("Unknown", "0", "0");
    }
}
