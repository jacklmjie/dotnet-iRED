using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxActivityVMs
{
    public partial class WxActivityBatchVM : BaseBatchVM<WxActivity, WxActivity_BatchEdit>
    {
        public WxActivityBatchVM()
        {
            ListVM = new WxActivityListVM();
            LinkedVM = new WxActivity_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class WxActivity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
