using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner
{
    public class ValueChangedEventArgs
    {
        public readonly double LastValue;
        public readonly double NewValue;

        public ValueChangedEventArgs(double lastValue, double newValue)
        {
            this.LastValue = lastValue;
            this.NewValue = newValue;
        }
    }
}
