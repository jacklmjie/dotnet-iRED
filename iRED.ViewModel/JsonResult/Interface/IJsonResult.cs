namespace iRED.ViewModel.JsonResult.Interface
{
    public interface IJsonResult
    {
        /// <summary>
        /// 返回错误码
        /// </summary>
        int errcode { get; set; }

        /// <summary>
        /// 返回结果信息
        /// </summary>
        string errmsg { get; set; }
    }
}
