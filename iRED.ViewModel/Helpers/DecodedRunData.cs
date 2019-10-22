using System;
using System.Collections.Generic;

namespace iRED.ViewModel.Helpers
{
    /// <summary>
    /// 用户运动步数解密类
    /// </summary>
    [Serializable]
    public class DecodedRunData : DecodeEntityBase
    {
        public List<DecodedRunData_StepModel> stepInfoList { get; set; }
    }

    [Serializable]
    public class DecodedRunData_StepModel
    {
        public long timestamp { get; set; }
        public long step { get; set; }
    }
}
