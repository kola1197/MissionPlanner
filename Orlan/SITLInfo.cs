using System.Collections.Generic;

namespace MissionPlanner
{
    public class SITLInfo
    {
        public double VerticalSpeed = 0;

        public double GroundSpeed = 0;

        public double AirSpeed = 0;

        public bool SitlLanding = false;

        public double Rpm = 0;
        
        public Dictionary<string, double> Parameters = new Dictionary<string, double>()
        {
            {"Fuel", 0}
        };
        
        public void SetParameters(double vertSpeed, double groundSpeed, double airSpeed) => (VerticalSpeed, GroundSpeed, AirSpeed) =
            (vertSpeed, groundSpeed, airSpeed);
    }
}