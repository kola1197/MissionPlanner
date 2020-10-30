using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner
{
    public class AntennaConnectionInfo : AircraftConnectionInfo
    {
        public string Mode { get; set; }

        public string SatNum { get; set; }

        public string Heading { get; set; }

        private const byte _sysIdNum = 2;

        private bool _active = false;
        public bool Active
        {
            get => _active;
            set => _active = value;
        }
        
        public byte SysIdNum => _sysIdNum;

        public AntennaConnectionInfo() : base(-1) => (Mode, SatNum, Heading) = ("Unknown", "0", "0");
    }
}
