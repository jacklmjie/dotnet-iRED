using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    /// <summary>
    /// 产品
    /// </summary>
    [Table("WxProducts")]
    public class WxProduct : PersistPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "所属场馆")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int? VenueId { get; set; }

        [Display(Name = "所属场馆")]
        public WxVenue Venue { get; set; }

        [Display(Name = "图片")]
        public Guid? PictureId { get; set; }

        [Display(Name = "图片")]
        public FileAttachment Picture { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}是必填项")]
        public decimal? Price { get; set; } 

        [Display(Name = "可用库存")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int? AvailableStock { get; set; }

        [Display(Name = "描述")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Description { get; set; }
    }
}
