using System;
using System.Xml.Serialization;

namespace MissionPlanner
{
    [Serializable]
    public class AircraftConnectionInfo
    {
        private static int _aircraftCounter;

        private float _fuelPerTime = 0;

        private bool _inAir;

        // private string _number;
        private string _name, _serialPort, _tcpIp, _tcpPort, _udpPort;

        private DateTime _startTime = new DateTime(0);

        private object _sysId;

        private bool _usingAntenna;

        private bool _usingSitl;

        [XmlIgnore] public float Butt2RealVoltage = 0;

        [XmlIgnore] public double Fuel = 0;

        [XmlIgnore] public float FuelPerTime = 0;

        [XmlIgnore] public bool HasStartTime;

        [XmlIgnore] public bool IsEmergencyLandTriggered = false;

        [XmlIgnore] public bool IsParachutePointReached = false;

        [XmlIgnore] public float MaxCapacity = 0;

        [XmlIgnore] public float MinCapacity = 0;

        [XmlIgnore] public bool ParachuteReleased = false;

        //Only for SITL (Worst code...)
        [XmlIgnore] public SITLInfo SitlInfo = new SITLInfo();

        // public AircraftConnectionInfo(string number, string name, string port)
        // {
        //     this.Number = string.Copy(number);
        //     this.Name = string.Copy(name);
        //     this.SerialPort = string.Copy(port);
        // }

        public AircraftConnectionInfo()
        {
            (Name, SerialPort, Speed, SysId, Connected, UsingSitl, UsingAntenna) =
                ("", "", "115200", null, false, false, false);
            MenuNum = _aircraftCounter;
            _aircraftCounter++;
            _tcpIp = "127.0.0.1";
            _tcpPort = "5760";
            _udpPort = "14550";
        }

        public AircraftConnectionInfo(int menuNum)
        {
            (Name, SerialPort, Speed, SysId, Connected, UsingSitl, UsingAntenna) =
                ("", "", "115200", null, false, false, false);
            MenuNum = menuNum;
            _tcpIp = "127.0.0.1";
            _tcpPort = "5760";
            _udpPort = "14550";
        }

        [XmlIgnore] public bool NotSerialConnection { get; private set; } = true;

        public string Speed { get; set; }

        [XmlIgnore] public bool Connected { get; set; }

        [XmlIgnore]
        public bool UsingSitl
        {
            get => _usingSitl;
            set
            {
                _usingSitl = value;
                if (value) _usingAntenna = false;
                NotSerialConnection = _usingAntenna || _usingSitl;
            }
        }

        [XmlIgnore]
        public bool UsingAntenna
        {
            get => _usingAntenna;
            set
            {
                _usingAntenna = value;
                if (value) _usingSitl = false;
                NotSerialConnection = _usingAntenna || _usingSitl;
            }
        }

        public string UdpPort
        {
            get => string.Copy(_udpPort);
            set => _udpPort = string.Copy(value);
        }
        
        public string TcpIp
        {
            get => string.Copy(_tcpIp);
            set => _tcpIp = string.Copy(value);
        }

        public string TcpPort
        {
            get => string.Copy(_tcpPort);
            set => _tcpPort = string.Copy(value);
        }

        public int MenuNum { get; }

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
        
        [XmlIgnore]
        public object SysId
        {
            get => _sysId;
            set => _sysId = value;
        }

        [XmlIgnore]
        public DateTime StartOfTheFlightTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                HasStartTime = true;
            }
        }

        [XmlIgnore]
        public bool InAir
        {
            get => _inAir;
            set => _inAir = value;
        }


        [XmlIgnore] public bool FuelSaved { get; set; }


        // public AircraftConnectionInfo(string name, string serialPort, object speed, string sysId, bool connected,
        //     bool usingSITL)
        // {
        //     (Name, SerialPort, Speed, SysId, Connected, UsingSITL) =
        //         (name, serialPort, speed, sysId, connected, usingSITL);
        //     _menuNum = _aircraftCounter;
        //     _aircraftCounter++;
        // }
    }
}