namespace iRED.ViewModel.JsonResult.Request
{
    /// <summary>
    /// 小程序登录
    /// </summary>
    public class WxLoginRequest
    {
        public string code { get; set; }
        public string rawData { get; set; }
        public string signature { get; set; }
        public string encryptedData { get; set; }
        public string iv { get; set; }
    }
}
