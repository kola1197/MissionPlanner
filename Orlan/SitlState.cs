using System;

namespace MissionPlanner
{
    public class SitlState
    {
        public SITLInfo TargetInfo;
        public SITLInfo StepInfo;
        public SitlStateName Name;

        public enum SitlStateName
        {
            PrepareFlight,
            EngineStart,
            EngineWarmUp,
            Takeoff,
            Flight,
            LandingStart,
            LandingEnd
        }

        public SitlState(SitlStateName name, SITLInfo targetSitlInfo, SITLInfo stepSitlInfo) =>
            (Name, TargetInfo, StepInfo) = (name, targetSitlInfo, stepSitlInfo);

        public void SetState(SITLInfo targetSitlInfo, SITLInfo stepSitlInfo)
        {
            TargetInfo = targetSitlInfo;
            TargetInfo = stepSitlInfo;
        }

        public double CalculateParamValue(double aircraftValue, SitlParam.ParameterName name, int timeSpanInMs)
        {
            double secondsPassed = timeSpanInMs / 1000D;
            var targetValue = TargetInfo.ParamList.GetParamValue(name);
            var stepValue = StepInfo.ParamList.GetParamValue(name) * secondsPassed;
            if (Math.Abs(targetValue - aircraftValue) < stepValue || TargetInfo.ParamList.GetParamIsRealUpdated(name))
            {
                return targetValue;
            }
            else
            {
                return aircraftValue + Math.Sign(targetValue - aircraftValue) * stepValue;
            }
        }
    }
}