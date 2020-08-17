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
        private string _name, _port;

        /*public string Number
        {
            get => string.Copy(_number);
            set => _number = string.Copy(value);
        }*/

        public string Name
        {
            get => string.Copy(_name);
            set => _name = string.Copy(value);
        }

        public string Port
        {
            get => string.Copy(_port);
            set => _port = string.Copy(value);
        }

        // public AircraftConnectionInfo(string number, string name, string port)
        // {
        //     this.Number = string.Copy(number);
        //     this.Name = string.Copy(name);
        //     this.Port = string.Copy(port);
        // }

        public AircraftConnectionInfo() => (Name, Port) = ("", "");
        public AircraftConnectionInfo(string name, string port) => (Name, Port) = (name, port);
    }
}
