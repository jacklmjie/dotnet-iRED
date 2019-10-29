using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxProductVMs
{
    public partial class WxProductBatchVM : BaseBatchVM<WxProduct, WxProduct_BatchEdit>
    {
        public WxProductBatchVM()
        {
            ListVM = new WxProductListVM();
            LinkedVM = new WxProduct_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class WxProduct_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
