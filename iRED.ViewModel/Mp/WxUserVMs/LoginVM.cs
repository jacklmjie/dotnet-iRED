using iRED.Model;
using iRED.ViewModel.JsonResult.Entities;
using System;
using System.Linq;
using WalkingTec.Mvvm.Core;

namespace iRED.ViewModel.Mp.WxUserVMs
{
    public class LoginVM : BaseVM
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public WxUser DoLogin(string openId)
        {
            //根据OpenId查询用户
            var user = DC.Set<WxUser>()
                .Where(x => x.OpenId == openId)
                .SingleOrDefault();

            return user;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="decodedUser"></param>
        /// <returns></returns>
        public WxUser DoAdd(DecodedUserInfo decodedUser)
        {
            var user = new WxUser()
            {
                OpenId = decodedUser.openId,
                NickName = decodedUser.nickName,
                AvatarUrl = decodedUser.avatarUrl,
                Gender = (WxSexEnum)decodedUser.gender,
                Country = decodedUser.country,
                Province = decodedUser.province,
                City = decodedUser.city,
                Language = decodedUser.language,
                CreateTime = DateTime.Now
            };

            DC.Set<WxUser>().Add(user);
            DC.SaveChanges();
            return user;
        }
    }
}
