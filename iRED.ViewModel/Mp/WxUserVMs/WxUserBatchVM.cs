using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxUserVMs
{
    public partial class WxUserBatchVM : BaseBatchVM<WxUser, WxUser_BatchEdit>
    {
        public WxUserBatchVM()
        {
            ListVM = new WxUserListVM();
            LinkedVM = new WxUser_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class WxUser_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
