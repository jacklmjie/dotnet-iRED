using System;

namespace iRED.ViewModel.JsonResult.Entities
{
    /// <summary>
    /// 解码后的用户信息
    /// </summary>
    [Serializable]
    public class DecodedUserInfo : DecodeEntityBase
    {
        public string openId { get; set; }
        public string nickName { get; set; }
        public string avatarUrl { get; set; }
        public int gender { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string language { get; set; }
        public string unionId { get; set; }
    }
}
