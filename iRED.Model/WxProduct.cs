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

        [Display(Name = "图片")]
        public int PictureId { get; set; }

        [Display(Name = "图片")]
        public FileAttachment Picture { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}是必填项")]
        public decimal Price { get; set; }

        [Display(Name = "描述")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Description { get; set; }

        [Display(Name = "库存")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int Stock { get; set; }

        [Display(Name = "可用库存")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int AvailableStock { get; set; }

        [Display(Name = "所属场馆")]
        [Required()]
        public int? WxVenueId { get; set; }

        [Display(Name = "所属场馆")]
        public WxVenue WxVenue { get; set; }

        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="quantity"></param>
        public void AddStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception($"不能小于0");
            }
            this.Stock += quantity;
            this.AvailableStock += quantity;
        }

        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="quantity"></param>
        public void RemoveStock(int quantity)
        {
            if (AvailableStock == 0)
            {
                throw new Exception($"可用库存为0");
            }

            if (quantity <= 0)
            {
                throw new Exception($"不能小于0");
            }

            int removed = Math.Min(quantity, this.AvailableStock);

            this.Stock -= removed;
            this.AvailableStock -= removed;
        }
    }
}
