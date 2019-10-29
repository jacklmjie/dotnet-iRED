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
    public partial class WxOrderBatchVM : BaseBatchVM<WxOrder, WxOrder_BatchEdit>
    {
        public WxOrderBatchVM()
        {
            ListVM = new WxOrderListVM();
            LinkedVM = new WxOrder_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class WxOrder_BatchEdit : BaseVM
    {
        [Display(Name = "发货状态")]
        public GoodsStatusEnum? GoodsStatus { get; set; }

        protected override void InitVM()
        {
        }

    }

}
