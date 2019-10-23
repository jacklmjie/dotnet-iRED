using System;

namespace iRED.ViewModel.JsonResult.Interface
{
    /// <summary>
    /// 小程序返回码
    /// </summary>
    public enum ReturnCode_MP
    {
        系统繁忙此时请开发者稍候再试 = -1,
        请求成功 = 0,
        code无效 = 40029,
        频率限制每个用户每分钟100次 = 45011
    }

    [Serializable]
    public class WxJsonResult : IJsonResult
    {
        public int errcode { get; set; }

        public string errmsg { get; set; }

        public string errcodeName { get { return ((ReturnCode_MP)errcode).ToString(); } }

        public override string ToString()
        {
            return string.Format("WxJsonResult：{{errcode:'{0}',errcode_name:'{1}',errmsg:'{2}'}}",
                errcode, errcodeName, errmsg);
        }
    }
}
