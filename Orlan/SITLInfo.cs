using System.Collections.Generic;

namespace MissionPlanner
{
    public class SITLInfo
    {
        public SitlParamList ParamList;

        public SITLInfo() => ParamList = new SitlParamList();

        public SITLInfo(SitlParamList paramList) => ParamList = paramList;

        // public void SetParameters(SitlParamList paramList)
        // {
        //     foreach (var param in paramList.Params)
        //     {
        //         ParamList.SetParam(param);
        //     }
        // }
    }
}