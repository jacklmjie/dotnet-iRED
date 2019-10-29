using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    /// <summary>
    /// 活动
    /// </summary>
    [Table("WxActivitys")]
    public class WxActivity : PersistPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "描述")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Description { get; set; }

        [Display(Name = "图片")]
        public Guid? PictureId { get; set; }

        [Display(Name = "图片")]
        public FileAttachment Picture { get; set; }

        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime? BeginTime { get; set; }

        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime? EndTime { get; set; }
    }
}
