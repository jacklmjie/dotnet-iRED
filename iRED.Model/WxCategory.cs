using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    public enum ParentEnum
    {
        场馆 = 10
    }

    /// <summary>
    /// 类别
    /// </summary>
    [Table("WxCategorys")]
    public class WxCategory : BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "类别")]
        [Required(ErrorMessage = "{0}是必填项")]
        public ParentEnum ParentId { get; set; }

        [Display(Name = "名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
    }
}
