using System;
using System.Globalization;

namespace MissionPlanner
{
    public class SitlParam : IEquatable<SitlParam>
    {
        public enum ParameterName
        {
            VerticalSpeed,
            GroundSpeed,
            AirSpeed,
            Rpm,
            Temperature,
            Alt,
            TargetAlt
        }

        public ParameterName Name;

        public double Value;

        public bool NeedUpdateFromRealSitl;

        public SitlParam(ParameterName name, double value, bool needUpdateFromRealSitl = false) =>
            (Name, Value, NeedUpdateFromRealSitl) = (name, value, needUpdateFromRealSitl);

        public bool Equals(SitlParam other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SitlParam) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Name;
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ NeedUpdateFromRealSitl.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            switch (Name)
            {
                case ParameterName.VerticalSpeed:
                    return Value.ToString("F1", new CultureInfo("en-US")) + " м/с";
                    break;
                case ParameterName.GroundSpeed:
                    return (Value * 3.6).ToString("F1", new CultureInfo("en-US")) + " км/ч";
                    break;
                case ParameterName.AirSpeed:
                    return (Value * 3.6).ToString("F1", new CultureInfo("en-US")) + " км/ч";
                    break;
                case ParameterName.Rpm:
                    return Value.ToString("F2", new CultureInfo("en-US")) + " об/м";
                    break;
                case ParameterName.Temperature:
                    return Value.ToString("F1", new CultureInfo("en-US")) + "°";
                    break;
                case ParameterName.Alt:
                    return Value.ToString("F2", new CultureInfo("en-US"));
                    break;
                case ParameterName.TargetAlt:
                    return Value.ToString("F2", new CultureInfo("en-US"));
                    break;
                default:
                    return base.ToString();
                    break;
            }
        }
    }
}