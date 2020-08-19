using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.Orlan
{
    public class AircraftConnectionInfo
    {
        // private string _number;
        private string _name, _serialPort;

        private object _sysId;

        public object Speed { get; set; }

        public bool Connected { get; set; }

        public bool UsingSITL { get; set; }

        public string Name
        {
            get => string.Copy(_name);
            set => _name = string.Copy(value);
        }

        public string SerialPort
        {
            get => string.Copy(_serialPort);
            set => _serialPort = string.Copy(value);
        }

        public object SysId
        {
            get => _sysId;
            set => _sysId = value;
        }

        // public AircraftConnectionInfo(string number, string name, string port)
        // {
        //     this.Number = string.Copy(number);
        //     this.Name = string.Copy(name);
        //     this.SerialPort = string.Copy(port);
        // }

        public AircraftConnectionInfo() => (Name, SerialPort, Speed, SysId, Connected, UsingSITL) =
            ("", "", 115200, null, false, false);

        public AircraftConnectionInfo(string name, string serialPort, object speed, string sysId, bool connected,
            bool usingSITL) =>
            (Name, SerialPort, Speed, SysId, Connected, UsingSITL) =
            (name, serialPort, speed, sysId, connected, usingSITL);
    }
}
