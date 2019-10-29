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
    public partial class WxOrderTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class WxOrderImportVM : BaseImportVM<WxOrderTemplateVM, WxOrder>
    {

    }

}
