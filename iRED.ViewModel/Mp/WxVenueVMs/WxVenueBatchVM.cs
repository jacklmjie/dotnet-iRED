using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxVenueVMs
{
    public partial class WxVenueBatchVM : BaseBatchVM<WxVenue, WxVenue_BatchEdit>
    {
        public WxVenueBatchVM()
        {
            ListVM = new WxVenueListVM();
            LinkedVM = new WxVenue_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class WxVenue_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
