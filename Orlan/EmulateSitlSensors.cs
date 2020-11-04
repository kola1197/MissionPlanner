using System;
using MissionPlanner.Controls;

namespace MissionPlanner
{
    public class EmulateSitlSensors
    {
        private SITLInfo TargetSitlState = new SITLInfo();

        private SITLInfo SitlSensorsStep = new SITLInfo();

        public bool EngineRunning = false;

        private readonly double _fuelConsumptionInSecond = 0.0001;

        public void SetTargetSitlParams(SITLInfo sitlInfo)
        {
            TargetSitlState.SetParameters(
                sitlInfo.VerticalSpeed,
                sitlInfo.GroundSpeed,
                sitlInfo.AirSpeed
            );
        }

        public void SetCurrentSitlToPrepareLandState()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                AircraftConnectionInfo currentAircraft = MainV2.Aircrafts[MainV2.CurrentAircraftNum];
                currentAircraft.SitlInfo.VerticalSpeed = MainV2.comPort.MAV.cs.verticalspeed;
                currentAircraft.SitlInfo.GroundSpeed = MainV2.comPort.MAV.cs.groundspeed;
                currentAircraft.SitlInfo.AirSpeed = MainV2.comPort.MAV.cs.airspeed;
            }

            SitlSensorsStep.SetParameters(
                0.5,
                10,
                7
                // 300,
                // 1000
                );
        }

        public void DoSitlRpmStep()
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            AircraftConnectionInfo currentAircraft = MainV2.Aircrafts[MainV2.CurrentAircraftNum];
            SITLInfo currentSitlState = currentAircraft.SitlInfo;
            if (currentSitlState.GroundSpeed < 1 && EngineRunning)
            {
                // DoCalculationStep(ref currentSitlState.Rpm, currentSitlState.RpmLaunch, SitlSensorsStep.Rpm);
            }
            else
            {
                // DoCalculationStep(ref currentSitlState.Rpm, currentSitlState.RpmInAir, SitlSensorsStep.Rpm);
            }
        }

        public void DoSitlLandStep()
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            AircraftConnectionInfo currentAircraft = MainV2.Aircrafts[MainV2.CurrentAircraftNum];
            SITLInfo currentSitlState = currentAircraft.SitlInfo;
            // DoCalculationStep(ref currentSitlState.Rpm,);
        }

        private void DoCalculationStep(ref double currentValue, double targetValue, double stepValue)
        {
            if (Math.Abs(targetValue - currentValue) < stepValue)
            {
                currentValue = targetValue;
            }
            else
            {
                currentValue += Math.Sign(targetValue - currentValue) * stepValue;
            }
        }

        public void DoSitlFuelStep()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                MainV2.Aircrafts[MainV2.CurrentAircraftNum].Fuel -= _fuelConsumptionInSecond;
            }
        }
    }
}