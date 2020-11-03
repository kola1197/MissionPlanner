namespace MissionPlanner
{
    public class SITLInfo
    {
        public double Fuel { get; set; }

        public double VerticalSpeed { get; set; }

        public double GroundSpeed { get; set; }

        public double AirSpeed { get; set; }

        public bool SitlLanding { get; set; }

        public double Rpm { get; set; }

        public double RpmLaunch { get; set; }

        public double RpmInAir { get; set; }

        public void SetParameters(double fuel, double vertSpeed, double groundSpeed, double airSpeed, double rpmLaunch,
            double rpmInAir) => (Fuel, VerticalSpeed, GroundSpeed, AirSpeed, RpmLaunch, RpmInAir) =
            (fuel, vertSpeed, groundSpeed, airSpeed, rpmLaunch, rpmInAir);
    }
}