using iRED.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    [Table("WxUsers")]
    public class WxUser : TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "OpenId")]
        public string OpenId { get; set; }

        [Display(Name = "用户昵称")]
        public string NickName { get; set; }

        [Display(Name = "用户头像")]
        public string AvatarUrl { get; set; }

        [Display(Name = "用户性别")]
        public WeixinSex Gender { get; set; }

        [Display(Name = "用户所在国家")]
        public string Country { get; set; }

        [Display(Name = "用户所在省份")]
        public string Province { get; set; }

        [Display(Name = "用户所在城市")]
        public string City { get; set; }

        [Display(Name = "用户所用语言")]
        public Language Language { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
