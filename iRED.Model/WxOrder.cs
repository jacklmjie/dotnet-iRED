using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    public enum OrderStatusEnum
    {
        已生成 = 1,
        已确认 = 2,
        已完成 = 3,
        已取消 = 4,
        已作废 = 5
    }
    public enum PayStatusEnum
    {
        待支付 = 0,
        已支付 = 1
    }
    public enum GoodsStatusEnum
    {
        待发货 = 0,
        已发货 = 1
    }
    /// <summary>
    /// 订单
    /// </summary>
    [Table("WxOrders")]
    public class WxOrder : TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "订单号")]
        public string OrderNumber { get; set; }

        [Display(Name = "总金额")]
        public decimal OrderTotal { get; set; }

        [Display(Name = "用户Id")]
        public int UserId { get; set; }

        [Display(Name = "用户信息")]
        public WxUser User { get; set; }

        [Display(Name = "收获地址")]
        public string UserAddress { get; set; }

        [Display(Name = "联系方式")]
        public string UserPhone { get; set; }

        [Display(Name = "下单时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "订单状态")]
        public OrderStatusEnum OrderStatus { get; set; }

        [Display(Name = "支付状态")]
        public PayStatusEnum PayStatus { get; set; }

        [Display(Name = "发货状态")]
        public GoodsStatusEnum GoodsStatus { get; set; }

        [Display(Name = "订单项")]
        public List<WxOrderItem> OrderItems { get; set; }
    }
}
