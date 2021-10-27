namespace MissionPlanner.NewClasses
{
    public class VerticalSpeedArrow
    {
        private readonly char upArrow = '▲';
        private readonly char downArrow = '▼';

        public char GetArrow(double vSpeed) => vSpeed > 0 ? upArrow : downArrow;
    }
}