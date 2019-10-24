using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    public enum WxSexEnum
    {
        未知 = 0,
        男 = 1,
        女 = 2
    }

    /// <summary>
    /// 微信用户
    /// </summary>
    [Table("WxUsers")]
    public class WxUser : TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "OpenId")]
        public string OpenId { get; set; }

        [Display(Name = "昵称")]
        public string NickName { get; set; }

        [Display(Name = "头像")]
        public string AvatarUrl { get; set; }

        [Display(Name = "性别")]
        public WxSexEnum Gender { get; set; }

        [Display(Name = "所在国家")]
        public string Country { get; set; }

        [Display(Name = "所在省份")]
        public string Province { get; set; }

        [Display(Name = "所在城市")]
        public string City { get; set; }

        [Display(Name = "所用语言")]
        public string Language { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
