namespace MissionPlanner
{
    public class RouteAltitude
    {
        private bool _holdAlt = false;

        public bool HoldAlt => _holdAlt;

        private int _value = 100;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                _holdAlt = true;
            }
        }

        public void StopHoldingAlt()
        {
            _holdAlt = false;
        }
        
    }
}