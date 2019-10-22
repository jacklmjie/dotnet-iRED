using iRED.Model.Enums;
using System;

namespace iRED.ViewModel.JsonResult.Interface
{
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
