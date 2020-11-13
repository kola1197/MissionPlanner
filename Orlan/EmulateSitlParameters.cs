using System;
using System.Collections.Generic;
using System.Threading;
using Flurl.Util;
using MissionPlanner.Controls;

namespace MissionPlanner
{
    public class EmulateSitlParameters
    {
        private static List<SitlState> SitlStates = new List<SitlState>();

        private bool _engineRunning = false;

        public bool EngineRunning
        {
            get => _engineRunning;
            set
            {
                _engineRunning = value;
                if (value)
                {
                    SetTargetState(SitlState.SitlStateName.EngineStart);
                }
                else
                {
                    SetTargetState(SitlState.SitlStateName.PrepareFlight);
                }
            }
        }

        private readonly double _fuelConsumptionInSecond = 0.0001;
        // private readonly double _fuelConsumptionInSecond = 0.1;

        private static SitlState _currentTarget;

        // Step to update to real values immediately
        private Double _defaultStep = 100;


        public EmulateSitlParameters()
        {
            SitlStateGenerator.Generate(SitlStates);
            _currentTarget = SitlStates[(int) SitlState.SitlStateName.PrepareFlight];
        }

        public void AddState(SitlState sitlState)
        {
            SitlStates.Add(sitlState);
        }

        public SitlState.SitlStateName GetCurrentStateName()
        {
            return _currentTarget.Name;
        }

        public void SetTargetState(SitlState.SitlStateName name)
        {
            if (name.Equals(_currentTarget.Name))
            {
                return;
            }
            foreach (var state in SitlStates)
            {
                if (state.Name.Equals(name))
                {
                    TransferRealParams(_currentTarget, state);
                    _currentTarget = state;
                    if (name == SitlState.SitlStateName.Takeoff)
                    {
                        _engineRunning = true;
                    }
                    return;
                }
            }
        }

        private void TransferRealParams(SitlState oldState, SitlState newState)
        {
            foreach (var param in oldState.TargetInfo.ParamList.Params)
            {
                if (param.NeedUpdateFromRealSitl)
                {
                    newState.TargetInfo.ParamList.SetParamValue(param);
                }
            }
        }

        public void UpdateParametersWithRealValues()
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            foreach (var param in _currentTarget.TargetInfo.ParamList.Params)
            {
                if (param.NeedUpdateFromRealSitl)
                {
                    switch (param.Name)
                    {
                        case SitlParam.ParameterName.VerticalSpeed:
                            param.Value = MainV2.comPort.MAV.cs.verticalspeed;
                            break;
                        case SitlParam.ParameterName.GroundSpeed:
                            param.Value = MainV2.comPort.MAV.cs.groundspeed;
                            break;
                        case SitlParam.ParameterName.AirSpeed:
                            param.Value = MainV2.comPort.MAV.cs.airspeed;
                            break;
                        case SitlParam.ParameterName.Temperature:
                            param.Value = MainV2.comPort.MAV.cs.press_temp / 100;
                            break;
                        case SitlParam.ParameterName.Alt:
                            param.Value = MainV2.comPort.MAV.cs.alt;
                            break;
                        case SitlParam.ParameterName.TargetAlt:
                            param.Value = MainV2.comPort.MAV.cs.targetalt;
                            break;
                    }
                }
            }
        }

        public void DoEmulationStep(int timeSpanInMs)
        {
            if (MainV2.CurrentAircraftNum == null)
            {
                return;
            }

            AircraftConnectionInfo currentAircraft = MainV2.CurrentAircraft;
            SITLInfo currentSitlState = currentAircraft.SitlInfo;

            foreach (var param in currentSitlState.ParamList.Params)
            {
                if (!param.NeedUpdateFromRealSitl)
                {
                    param.Value = _currentTarget.CalculateParamValue(param.Value, param.Name, timeSpanInMs);
                }
            }

            UpdateParametersWithRealValues();
        }

        public void DoFuelStep()
        {
            if (MainV2.CurrentAircraftNum != null)
            {
                MainV2.CurrentAircraft.Fuel -= _fuelConsumptionInSecond;
            }
        }
    }
}