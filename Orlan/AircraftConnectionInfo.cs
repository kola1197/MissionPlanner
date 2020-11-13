using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;

namespace MissionPlanner
{
    public class AircraftConnectionInfo
    {
        // private string _number;
        private string _name, _serialPort;
        
        private object _sysId;
        
        private static int _aircraftCounter = 0;

        private int _menuNum;

        private bool _notSerialConnection = true;

        private bool _usingAntenna = true;

        private bool _usingSitl = false;
        
        public bool NotSerialConnection => _notSerialConnection;
        public string Speed { get; set; }

        public bool Connected { get; set; }

        public bool UsingSitl
        {
            get => _usingSitl;
            set
            {
                _usingSitl =  value;
                if (value)
                {
                    _usingAntenna = false;
                }
                _notSerialConnection = _usingAntenna || _usingSitl;
            }
        }

        public bool UsingAntenna
        {
            get => _usingAntenna;
            set
            {
                _usingAntenna = value;
                if (value)
                {
                    _usingSitl = false;
                }
                _notSerialConnection = _usingAntenna || _usingSitl;
            }
        }

        public int MenuNum
        {
            get => _menuNum;
        }

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

        private DateTime _startTime = new DateTime(0);

        public bool hasStartTime = false;
        public DateTime StartOfTheFlightTime 
        { 
            get => _startTime;
            set { 
                _startTime = value;
                hasStartTime = true;
            }
        }

        private bool _inAir = false;
        public bool inAir 
        {
            get => _inAir; 
            set => _inAir = value;
        }

        private float _fuelPerTime = 0;

        public float Butt2RealVoltage = 0;

        public float MaxCapacity = 0;

        public float MinCapacity = 0;

        public float FuelPerTime = 0;

        public double Fuel = 0;

        public bool IsParachutePointReached = false;

        public bool ParachuteReleased = false;

        public bool IsEmergencyLandTriggered = false;
        
        public bool FuelSaved { get; set; }
        
        //Only for SITL (Worst code...)
        public SITLInfo SitlInfo = new SITLInfo();

        // public AircraftConnectionInfo(string number, string name, string port)
        // {
        //     this.Number = string.Copy(number);
        //     this.Name = string.Copy(name);
        //     this.SerialPort = string.Copy(port);
        // }

        public AircraftConnectionInfo()
        {
            (Name, SerialPort, Speed, SysId, Connected, UsingSitl, UsingAntenna) =
                ("", "", "115200", null, false, false, true);
            _menuNum = _aircraftCounter;
            _aircraftCounter++;
        }

        public AircraftConnectionInfo(int menuNum)
        {
            (Name, SerialPort, Speed, SysId, Connected, UsingSitl, UsingAntenna) =
                ("", "", "115200", null, false, false, true);
            _menuNum = menuNum;
        }


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
