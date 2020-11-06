using System.Collections.Generic;

namespace MissionPlanner
{
    public static class SitlStateGenerator
    {
        private static List<SitlParam.ParameterName> _updatedParametersUntilLandStart =
            new List<SitlParam.ParameterName>()
            {
                SitlParam.ParameterName.VerticalSpeed,
                SitlParam.ParameterName.AirSpeed,
                SitlParam.ParameterName.GroundSpeed,
                SitlParam.ParameterName.Alt,
                SitlParam.ParameterName.TargetAlt
            };

        private static List<SitlParam.ParameterName> updatedParametersUntilLandEnd = new List<SitlParam.ParameterName>()
        {
            SitlParam.ParameterName.Temperature
        };

        public static void Generate(List<SitlState> sitlStates)
        {
            sitlStates.Add(GenerateInitialState());
            sitlStates.Add(GenerateEngineStartState());
            sitlStates.Add(GenerateEngineWarmUpState());
            sitlStates.Add(GenerateTakeoffState());
            sitlStates.Add(GenerateFlightState());
            sitlStates.Add(GenerateLandStartState());
            sitlStates.Add(GenerateLandCompleteState());
        }

        private static SitlState GenerateLandCompleteState()
        {
            return new SitlState(SitlState.SitlStateName.LandingEnd,
                new SITLInfo(new SitlParamList(updatedParametersUntilLandEnd, 0, 0, 0, 0, 0)),
                new SITLInfo(new SitlParamList(rpm: 400, temperature: 2, verticalSpeed: 1.5, groundSpeed: 30,
                    airspeed: 5, alt: 5, targetAlt: 10)));
        }

        private static SitlState GenerateLandStartState()
        {
            return new SitlState(SitlState.SitlStateName.LandingStart,
                new SITLInfo(new SitlParamList(null, 0, 0, -5, 0, 0.5)),
                new SITLInfo(new SitlParamList(rpm: 1000, temperature: 2, verticalSpeed: 1.5, groundSpeed: 30,
                    airspeed: 5, alt: 5, targetAlt: 10)));
        }

        private static SitlState GenerateFlightState()
        {
            return new SitlState(SitlState.SitlStateName.Flight,
                new SITLInfo(new SitlParamList(_updatedParametersUntilLandStart, 6200, 120)),
                new SITLInfo(new SitlParamList(rpm: 400, temperature: 1)));
        }

        private static SitlState GenerateTakeoffState()
        {
            return new SitlState(SitlState.SitlStateName.Takeoff,
                new SITLInfo(new SitlParamList(_updatedParametersUntilLandStart, 8000, 80)),
                new SITLInfo(new SitlParamList(rpm: 800, temperature: 2)));
        }


        private static SitlState GenerateEngineWarmUpState()
        {
            return new SitlState(SitlState.SitlStateName.EngineWarmUp,
                new SITLInfo(new SitlParamList(_updatedParametersUntilLandStart, 4200, 60)),
                new SITLInfo(new SitlParamList(rpm: 200, temperature: 1)));
        }

        private static SitlState GenerateEngineStartState()
        {
            return new SitlState(SitlState.SitlStateName.EngineStart,
                new SITLInfo(new SitlParamList(_updatedParametersUntilLandStart, 3500, 40)),
                new SITLInfo(new SitlParamList(rpm: 400, temperature: 2)));
        }

        private static SitlState GenerateInitialState()
        {
            List<SitlParam.ParameterName> updatedParametersUntilEngineStart =
                new List<SitlParam.ParameterName>(_updatedParametersUntilLandStart);
            updatedParametersUntilEngineStart.Add(SitlParam.ParameterName.Temperature);
            return new SitlState(SitlState.SitlStateName.PrepareFlight,
                new SITLInfo(new SitlParamList(updatedParametersUntilEngineStart)),
                new SITLInfo(new SitlParamList(rpm: 700, temperature: 1000)));
        }
    }
}