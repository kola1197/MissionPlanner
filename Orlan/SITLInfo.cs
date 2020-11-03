namespace MissionPlanner
{
    public class SITLInfo
    {
        public double Fuel = 0;

        public double VerticalSpeed = 0;

        public double GroundSpeed = 0;

        public double AirSpeed = 0;

        public bool SitlLanding = false;

        public double Rpm = 0;

        public double RpmLaunch = 0;

        public double RpmInAir = 0;
        
        public void SetParameters(double fuel, double vertSpeed, double groundSpeed, double airSpeed, double rpmLaunch,
            double rpmInAir) => (Fuel, VerticalSpeed, GroundSpeed, AirSpeed, RpmLaunch, RpmInAir) =
            (fuel, vertSpeed, groundSpeed, airSpeed, rpmLaunch, rpmInAir);
    }
}