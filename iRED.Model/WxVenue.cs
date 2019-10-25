using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    /// <summary>
    /// 场馆
    /// </summary>
    [Table("WxVenues")]
    public class WxVenue : PersistPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "图片")]
        public int PictureId { get; set; }

        [Display(Name = "图片")]
        public FileAttachment Picture { get; set; }

        [Display(Name = "描述")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Description { get; set; }

        [Display(Name = "所属类别")]
        [Required()]
        public int CategoryId { get; set; }

        [Display(Name = "所属类别")]
        public WxCategory Category { get; set; }
    }
}
