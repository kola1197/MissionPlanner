using System;
using System.Collections.Generic;

namespace MissionPlanner
{
    public class SitlParamList
    {
        private const double InitValue = 0;
        public List<SitlParam> Params = new List<SitlParam>();

        public SitlParamList(List<SitlParam.ParameterName> realUpdatableParams = null,
            double rpm = InitValue,
            double temperature = InitValue,
            double verticalSpeed = InitValue,
            double groundSpeed = InitValue,
            double airspeed = InitValue,
            double alt = InitValue,
            double targetAlt = InitValue)
        {
            Params.Add(new SitlParam(SitlParam.ParameterName.VerticalSpeed, verticalSpeed));
            Params.Add(new SitlParam(SitlParam.ParameterName.GroundSpeed, groundSpeed));
            Params.Add(new SitlParam(SitlParam.ParameterName.AirSpeed, airspeed));
            Params.Add(new SitlParam(SitlParam.ParameterName.Rpm, rpm));
            Params.Add(new SitlParam(SitlParam.ParameterName.Temperature, temperature));
            Params.Add(new SitlParam(SitlParam.ParameterName.Alt, alt));
            Params.Add(new SitlParam(SitlParam.ParameterName.TargetAlt, targetAlt));
            if (realUpdatableParams != null)
            {
                foreach (var param in Params)
                {
                    if (realUpdatableParams.Contains(param.Name))
                    {
                        param.NeedUpdateFromRealSitl = true;
                    }
                }
            }
        }

        public void SetParamValue(SitlParam param)
        {
            foreach (var sitlParam in Params)
            {
                if (sitlParam.Name.Equals(param))
                {
                    sitlParam.Value = param.Value;
                }
            }
        }

        public double GetParamValue(SitlParam.ParameterName paramName)
        {
            foreach (var sitlParam in Params)
            {
                if (sitlParam.Name.Equals(paramName))
                {
                    return sitlParam.Value;
                }
            }

            return -1;
        }

        public string GetParamToString(SitlParam.ParameterName paramName)
        {
            foreach (var sitlParam in Params)
            {
                if (sitlParam.Name.Equals(paramName))
                {
                    return sitlParam.ToString();
                }
            }

            return "";
        }

        public bool GetParamIsRealUpdated(SitlParam.ParameterName paramName)
        {
            foreach (var sitlParam in Params)
            {
                if (sitlParam.Name.Equals(paramName))
                {
                    return sitlParam.NeedUpdateFromRealSitl;
                }
            }

            return false;
        }
    }
}