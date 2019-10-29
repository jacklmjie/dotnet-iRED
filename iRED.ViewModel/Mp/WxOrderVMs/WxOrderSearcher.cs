using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxOrderVMs
{
    public partial class WxOrderSearcher : BaseSearcher
    {
        [Display(Name = "订单号")]
        public String OrderNumber { get; set; }
        [Display(Name = "订单状态")]
        public OrderStatusEnum? OrderStatus { get; set; }
        [Display(Name = "支付状态")]
        public PayStatusEnum? PayStatus { get; set; }
        [Display(Name = "发货状态")]
        public GoodsStatusEnum? GoodsStatus { get; set; }

        protected override void InitVM()
        {
        }

    }
}
