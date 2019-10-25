using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    /// <summary>
    /// 订单项
    /// </summary>
    [Table("WxOrderItems")]
    public class WxOrderItem : BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "产品Id")]
        public int ProductId { get; set; }

        [Display(Name = "产品名称")]
        public string ProductName { get; set; }

        [Display(Name = "产品单价")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "产品数量")]
        public int Units { get; set; }

        [Display(Name = "产品图片")]
        public string PictureUrl { get; set; }

        [Display(Name = "订单Id")]
        public int OrderId { get; set; }
    }
}
