namespace MissionPlanner
{
    public class SitlParam
    {
        public string Name;

        public double Value;

        public SitlParam(string name, double value) =>
            (Name, Value) = (name, value);
    }
}