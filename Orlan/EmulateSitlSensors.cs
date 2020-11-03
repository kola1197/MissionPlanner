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
        
        public void SetCurrentSitlParams(double fuel, double vertSpeed, double groundSpeed, double airSpeed, double rpmLaunch,
            double rpmInAir)
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                AircraftConnectionInfo currentAircraft = MainV2.Aircrafts[MainV2.CurrentAircraftNum];
                currentAircraft.SitlInfo.Fuel = fuel;
                currentAircraft.SitlInfo.RpmLaunch = rpmLaunch;
                currentAircraft.SitlInfo.RpmInAir = rpmInAir;
            }
        }

        public void SetTargetSitlParams(double fuel, double vertSpeed, double groundSpeed, double airSpeed, double rpmLaunch,
            double rpmInAir)
        {
            TargetSitlState.SetParameters(
                fuel,
                vertSpeed,
                groundSpeed,
                airSpeed,
                rpmLaunch,
                rpmInAir);
        }
        
        public void SetSitlToPrepareLand()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                AircraftConnectionInfo currentAircraft = MainV2.Aircrafts[MainV2.CurrentAircraftNum];
                currentAircraft.SitlInfo.VerticalSpeed = MainV2.comPort.MAV.cs.verticalspeed;
                currentAircraft.SitlInfo.GroundSpeed = MainV2.comPort.MAV.cs.groundspeed;
                currentAircraft.SitlInfo.AirSpeed = MainV2.comPort.MAV.cs.airspeed;
            }

            SitlSensorsStep.SetParameters(
                TargetSitlState.Fuel,
                0.5,
                10,
                7,
                300,
                1000);
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
                DoCalculationStep(ref currentSitlState.Rpm, currentSitlState.RpmLaunch, SitlSensorsStep.Rpm);
            }
            else
            {
                DoCalculationStep(ref currentSitlState.Rpm, currentSitlState.RpmInAir, SitlSensorsStep.Rpm);
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
                MainV2.Aircrafts[MainV2.CurrentAircraftNum].SitlInfo.Fuel -= _fuelConsumptionInSecond;
            }
        }

    }
}