using System;
using System.Collections.Generic;
using System.Text;

namespace iRED.ViewModel.JsonResult
{
    /// <summary>
    /// 用户信息中的性别（sex）
    /// </summary>
    public enum WeixinSex
    {
        未知 = 0,
        男 = 1,
        女 = 2
    }

    /// <summary>
    /// 小程序(miniprogram)返回码
    /// </summary>
    public enum ReturnCode_MP
    {
        系统繁忙此时请开发者稍候再试 = -1,
        请求成功 = 0,
        code无效 = 40029,
        频率限制每个用户每分钟100次 = 45011
    }
}
